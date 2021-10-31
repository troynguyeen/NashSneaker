import React, { useEffect, useState } from 'react'
import { Button, ButtonGroup, Grid, Paper, Table, TableBody, TableCell, TableHead, TablePagination, TableRow, TableSortLabel } from '@material-ui/core';
import EditIcon from '@material-ui/icons/Edit';
import DeleteIcon from '@material-ui/icons/Delete';
import PropTypes from 'prop-types';
import useApi from '../hooks/useApi';
import { toast } from 'react-toastify';
import { makeStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';

const useStyles = makeStyles((theme) => ({
    root: {
        '& .MuiGrid-root': {
            
        },
        '& .MuiTable-root': {
            width: '100%'
        },
        '& .MuiTableCell-head': {
            fontSize: '17px'
        }
    },
    visuallyHidden: {
        border: 0,
        clip: 'rect(0 0 0 0)',
        height: 1,
        margin: -1,
        overflow: 'hidden',
        padding: 0,
        position: 'absolute',
        top: 20,
        width: 1,
    },
}))

const headCells = [
    { id: 'id', align: 'center', disablePadding: false, label: 'Id', width: '50px' },
    { id: 'name', align: 'left', disablePadding: false, label: 'Name', width: '100px' },
    { id: 'description', align: 'left', disablePadding: false, label: 'Description', width: '200px' },
    { id: 'action', align: 'center', disablePadding: false, label: 'Action', width: '50px' }
];

const Categories = () => {

    const classes = useStyles();

    const {list, message, setMessage, FetchAPI, DeleteAPI} = useApi();

    const [order, setOrder] = useState('asc');
    const [orderBy, setOrderBy] = useState('id');
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(5);

    const emptyRows = rowsPerPage - Math.min(rowsPerPage, list.length - page * rowsPerPage);

    useEffect(() => {
        if(message !== '') {
            if(message === 'error') {
                toast.error("Delete category failed", {
                    theme: "colored"
                });
            }
            else {
                FetchAPI("Categories")
                toast.success(message, {
                    theme: "colored"
                });
            }
        }

    }, [message])

    const deleteSelectedId = (id) => {
        if(window.confirm("Are you sure to remove category #" + id +" ?")) {
            DeleteAPI('DeleteCategory', id)
            setMessage('')
            setPage(rowsPerPage - emptyRows == 1 ? 0 : page)
        }
    }

    const handleRequestSort = (event, property) => {
        const isAsc = orderBy === property && order === 'asc';
        setOrder(isAsc ? 'desc' : 'asc');
        setOrderBy(property);
    };

    const handleChangeRowsPerPage = (event) => {
        setRowsPerPage(parseInt(event.target.value, 10));
        setPage(0);
    };

    const handleChangePage = (event, newPage) => {
        setPage(newPage);
    };

    function descendingComparator(a, b, orderBy) {
        if (b[orderBy] < a[orderBy]) {
          return -1;
        }
        if (b[orderBy] > a[orderBy]) {
          return 1;
        }
        return 0;
    }

    function getComparator(order, orderBy) {
        return order === 'desc'
          ? (a, b) => descendingComparator(a, b, orderBy)
          : (a, b) => -descendingComparator(a, b, orderBy);
    }

    function stableSort(array, comparator) {
        const stabilizedThis = array.map((el, index) => [el, index]);
        stabilizedThis.sort((a, b) => {
          const order = comparator(a[0], b[0]);
          if (order !== 0) return order;
          return a[1] - b[1];
        });
        return stabilizedThis.map((el) => el[0]);
    }

    function EnhancedTableHead(props) {
        const { order, orderBy, rowCount, onRequestSort } = props;
        const createSortHandler = (property) => (event) => {
          onRequestSort(event, property);
        };
      
        return (
          <TableHead>
            <TableRow>
                {headCells.map((headCell) => (
                    <TableCell
                        key={headCell.id}
                        align={headCell.align}
                        padding={headCell.disablePadding ? 'none' : 'default'}
                        sortDirection={orderBy === headCell.id ? order : false}
                        width={headCell.width}
                    >
                        <TableSortLabel
                            active={orderBy === headCell.id}
                            direction={orderBy === headCell.id ? order : 'asc'}
                            onClick={createSortHandler(headCell.id)}
                        >
                            {headCell.label}
                            {orderBy === headCell.id ? (
                            <span className={classes.visuallyHidden}>
                                {order === 'desc' ? 'sorted descending' : 'sorted ascending'}
                            </span>
                            ) : null}
                        </TableSortLabel>
                    </TableCell>
                ))}
            </TableRow>
          </TableHead>
        );
    }

    EnhancedTableHead.propTypes = {
        onRequestSort: PropTypes.func.isRequired,
        order: PropTypes.oneOf(['asc', 'desc']).isRequired,
        orderBy: PropTypes.string.isRequired,
        rowCount: PropTypes.number.isRequired,
    };

    useEffect(() => {
        //Fetch API at the first rendering 
        FetchAPI("Categories")

    }, [])

    return (
        <React.Fragment>
            <h1 style={{ textAlign: 'center', padding: '30px' }}>Categories Management</h1>
            <Link to='/categories/add-new'>
                <Button 
                    style={{ 
                        backgroundColor: '#009405', 
                        color: '#fff',
                        marginBottom: '30px'
                    }} 
                    variant="contained" 
                    onClick={() => {}}
                >
                    Add new
                </Button>
            </Link>
            <Paper style={{ marginBottom: '50px'}} elevation={3}>
                <Grid container className={classes.root}>
                    <Grid item xs={12}>
                        <Table>
                            <EnhancedTableHead
                                order={order}
                                orderBy={orderBy}
                                onRequestSort={handleRequestSort}
                                rowCount={list.length}
                            />
                            <TableBody>
                                {stableSort(list, getComparator(order, orderBy))
                                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                                .map((record, index) => {

                                    return (
                                        <TableRow key={index}>
                                            <TableCell align="center" style={{ paddingRight: '40px' }}>{record.id}</TableCell>
                                            <TableCell align="left">{record.name}</TableCell>
                                            <TableCell align="left">{record.description}</TableCell>
                                            <TableCell align="center">
                                                <ButtonGroup variant="text">
                                                    <Link to={`/categories/edit/${record.id}`}>
                                                        <Button><EditIcon color="primary"/></Button>
                                                    </Link>
                                                    <Button onClick={() => deleteSelectedId(record.id)}><DeleteIcon color="secondary" /></Button>
                                                </ButtonGroup>
                                            </TableCell>
                                        </TableRow>
                                    );
                                })}
                                {emptyRows > 0 && (
                                    <TableRow style={{ height: (69) * emptyRows }}>
                                        <TableCell colSpan={7} />
                                    </TableRow>
                                )}
                            </TableBody>
                        </Table>
                    </Grid>
                </Grid>
                <TablePagination
                    rowsPerPageOptions={[5, 10, 25]}
                    component="div"
                    count={list.length}
                    rowsPerPage={rowsPerPage}
                    page={page}
                    onPageChange={handleChangePage}
                    onRowsPerPageChange={handleChangeRowsPerPage}
                />
            </Paper>
        </React.Fragment>
    )
}

export default Categories
