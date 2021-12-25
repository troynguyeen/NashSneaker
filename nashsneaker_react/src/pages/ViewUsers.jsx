import React, { useEffect, useState } from 'react'
import { Button, ButtonGroup, Grid, Paper, Table, TableBody, TableCell, TableHead, TablePagination, TableRow, TableSortLabel } from '@material-ui/core';
import EditIcon from '@material-ui/icons/Edit';
import DeleteIcon from '@material-ui/icons/Delete';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import PropTypes from 'prop-types';
import useApi from '../hooks/useApi';
import { toast } from 'react-toastify';
import { makeStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import axios from 'axios';

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
    { id: 'id', align: 'center', disablePadding: false, label: 'Id', width: '20px' },
    { id: 'firstName', align: 'left', disablePadding: false, label: 'First Name', width: '80px' },
    { id: 'lastName', align: 'left', disablePadding: false, label: 'Last Name', width: '80px' },
    { id: 'email', align: 'left', disablePadding: false, label: 'Email', width: '150px' },
    { id: 'phoneNumber', align: 'left', disablePadding: false, label: 'Phone Number', width: '100px' },
    { id: 'role', align: 'left', disablePadding: false, label: 'Role', width: '50px' },
    { id: 'action', align: 'center', disablePadding: false, label: 'Action', width: '50px' }
];

const ViewUsers = () => {

    const classes = useStyles();

    const {list, FetchAPI} = useApi();

    const [message, setMessage] = useState('');
    const [isShowRoles, setIsShowRoles] = useState(false);
    const [roles, setRoles] = useState([]);
    const [showAtUser, setShowAtUser] = useState({userId: '', roleName: ''});
    const [order, setOrder] = useState('asc');
    const [orderBy, setOrderBy] = useState('id');
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(5);

    const emptyRows = rowsPerPage - Math.min(rowsPerPage, list.length - page * rowsPerPage);

    useEffect(() => {
        if(message !== '') {
            if(message === 'error') {
                toast.error("Something went wrong!", {
                    theme: "colored"
                });
                setMessage('');
            }
            else {
                FetchAPI("ViewUsers")
                toast.success(message, {
                    theme: "colored"
                });
                setMessage('');
            }
        }

    }, [message])

    const handleUpdateRole = (e, userEmail) => {
        const roleName = e.target.value;
        const data = {
            'UserEmail': userEmail,
            'RoleName': roleName
        }

        axios.put('https://localhost:44348/api/Admin/UpdateUserRole', data,
        {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem("jwt")}`
            }
        })
            .then((res) => {
                setShowAtUser({userId: '', roleName: ''});
                setMessage(res.data.message);
            })
            .catch(e => console.log(e))
    }

    const handleShowRoles = (obj) => {
        axios.get('https://localhost:44348/api/Admin/GetRoles', 
        {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem("jwt")}`
            }
        })
            .then((res) => {
                setRoles(res.data);
                setShowAtUser(obj);
                setIsShowRoles(!isShowRoles);
            })
            .catch(e => console.log(e));
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
        FetchAPI("ViewUsers")

    }, [])

    return (
        <React.Fragment>
            <h1 style={{ textAlign: 'center', padding: '30px' }}>View Users Management</h1>
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
                                            <TableCell align="center" style={{ paddingRight: '40px' }}>{index + 1}</TableCell>
                                            <TableCell align="left">{record.firstName}</TableCell>
                                            <TableCell align="left">{record.lastName}</TableCell>
                                            <TableCell align="left">{record.email}</TableCell>
                                            <TableCell align="left">{record.phoneNumber}</TableCell>
                                            <TableCell align="left">
                                                {
                                                    record.id == showAtUser.userId && isShowRoles ? 
                                                    <FormControl style={{ width: 'auto', margin: '10px 0' }}>
                                                        <InputLabel id="label">Role</InputLabel>
                                                        <Select
                                                            name="roleName"
                                                            labelId="label"
                                                            variant="outlined"
                                                            value={showAtUser.roleName}
                                                            label="Role"
                                                            onChange={(e) => handleUpdateRole(e, record.email)}
                                                            style={{ textAlign: 'start', height: '45px' }}
                                                        >
                                                            {roles.map(role => <MenuItem value={role.name}>{role.name}</MenuItem>)}
                                                        </Select>
                                                    </FormControl>
                                                    :
                                                    record.role
                                                }
                                            </TableCell>
                                            <TableCell align="center">
                                                {
                                                    record.role !== 'Admin' ?
                                                    <Button onClick={() => handleShowRoles({userId: record.id, roleName: record.role})}>
                                                        <EditIcon color="primary"/>
                                                    </Button>
                                                    : ''
                                                }
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

export default ViewUsers
