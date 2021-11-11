import React, { useEffect, useState } from 'react'
import { Backdrop, Button, ButtonGroup, Fade, Grid, Modal, Paper, Table, TableBody, TableCell, TableHead, TablePagination, TableRow, TableSortLabel } from '@material-ui/core';
import EditIcon from '@material-ui/icons/Edit';
import DeleteIcon from '@material-ui/icons/Delete';
import PropTypes from 'prop-types';
import useApi from '../../hooks/useApi';
import { toast } from 'react-toastify';
import { makeStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import { Carousel } from 'react-responsive-carousel';
import 'react-responsive-carousel/lib/styles/carousel.min.css';

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
    modal: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor: 'rgba(0, 0, 0, 0.5)'
    },
    modalForm: {
        position: 'absolute',
        backgroundColor: theme.palette.background.paper,
        boxShadow: theme.shadows[5],
        outline: 'none',
        width: '600px'
    },
}))

const headCells = [
    { id: 'id', align: 'center', disablePadding: false, label: 'Id', width: '50px' },
    { id: 'images', align: 'left', disablePadding: false, label: 'Images', width: '100px' },
    { id: 'name', align: 'left', disablePadding: false, label: 'Name', width: '150px' },
    { id: 'category', align: 'left', disablePadding: false, label: 'Category', width: '50px' },
    { id: 'price', align: 'left', disablePadding: false, label: 'Price', width: '100px' },
    { id: 'description', align: 'left', disablePadding: false, label: 'Description', width: '200px' },
    { id: 'action', align: 'center', disablePadding: false, label: 'Action', width: '50px' }
];

const Products = () => {

    const classes = useStyles();

    const {list, message, setMessage, FetchAPI, DeleteAPI} = useApi();

    const serverUrl = 'https://localhost:44357/images/products/';

    const [images, setImages] = useState([]);
    const [isOpen, setIsOpen] = useState(false);
    const [order, setOrder] = useState('asc');
    const [orderBy, setOrderBy] = useState('id');
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(5);

    const emptyRows = rowsPerPage - Math.min(rowsPerPage, list.length - page * rowsPerPage);

    useEffect(() => {
        if(message !== '') {
            if(message === 'error') {
                toast.error("Delete product failed", {
                    theme: "colored"
                });
            }
            else {
                FetchAPI("Products")
                toast.success(message, {
                    theme: "colored"
                });
            }
        }

    }, [message])

    const deleteSelectedId = (id) => {
        if(window.confirm("Are you sure to remove product #" + id +" ?")) {
            DeleteAPI('DeleteProduct', id)
            setMessage('')
            setPage(rowsPerPage - emptyRows == 1 ? 0 : page)
        }
    }

    const handleOpenModal = (id) => {
        const imgs = list.filter(x => x.id == id);
        setIsOpen(true)
        setImages(imgs[0].images)
    }

    const handleCloseModal = () => {
        setIsOpen(false)
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
        FetchAPI("Products")

    }, [])

    return (
        <React.Fragment>
            <h1 style={{ textAlign: 'center', padding: '30px' }}>Products Management</h1>
            <Link to='/products/add-new'>
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
                                            <TableCell align="center">
                                                <Carousel
                                                    infiniteLoop 
                                                    emulateTouch 
                                                    autoPlay
                                                    interval={5000}
                                                    transitionTime={1000}
                                                    showThumbs={false}
                                                    onClickItem={() => handleOpenModal(record.id)}
                                                >
                                                    {record.images.map(img => <img src={img.path} />)}
                                                </Carousel>
                                            </TableCell>
                                            <TableCell align="left">{record.name}</TableCell>
                                            <TableCell align="left">{record.category.name}</TableCell>
                                            <TableCell align="left">{record.price}</TableCell>
                                            <TableCell align="left">{record.description}</TableCell>
                                            <TableCell align="center">
                                                <ButtonGroup variant="text">
                                                    <Link to={`/products/edit/${record.id}`}>
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
                                <Modal
                                    aria-labelledby="transition-modal-title"
                                    aria-describedby="transition-modal-description"
                                    className={classes.modal}
                                    open={isOpen}
                                    onClose={() => handleCloseModal()}
                                    closeAfterTransition
                                    BackdropComponent={Backdrop}
                                    BackdropProps={{
                                    timeout: 500,
                                    }}
                                >
                                    <Fade in={isOpen}>
                                        <Paper className={classes.modalForm} elevation={20}>
                                            <Grid className={classes.grid} container>
                                                <Carousel 
                                                    infiniteLoop 
                                                    emulateTouch 
                                                    autoPlay
                                                    interval={5000}
                                                    transitionTime={1000}
                                                    showThumbs={false}
                                                >
                                                    {images.map(img => <img src={img.path} />)}
                                                </Carousel>
                                            </Grid>
                                        </Paper>
                                    </Fade>
                                </Modal>
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

export default Products
