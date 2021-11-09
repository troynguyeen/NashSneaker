import React, { useEffect, useState } from 'react'
import { Backdrop, Button, TextField, ButtonGroup, Fade, Grid, Modal, Paper, Table, 
    TableBody, TableCell, TableHead, TablePagination, TableRow, TableSortLabel } from '@material-ui/core';
import DeleteIcon from '@material-ui/icons/Delete';
import PropTypes from 'prop-types';
import useApi from '../../hooks/useApi';
import { makeStyles } from '@material-ui/core/styles';
import { Carousel } from 'react-responsive-carousel';
import 'react-responsive-carousel/lib/styles/carousel.min.css';
import axios from 'axios';
import { toast } from 'react-toastify';

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
    { id: 'size', align: 'center', disablePadding: false, label: 'Size', width: '50px' },
    { id: 'price', align: 'left', disablePadding: false, label: 'Unit Price', width: '100px' },
    { id: 'quantity', align: 'center', disablePadding: false, label: 'Quantity', width: '50px' },
    { id: 'action', align: 'center', disablePadding: false, label: 'Action', width: '50px' }
];

const OrderDetailTable = (props) => {

    const classes = useStyles();

    const {list, setList} = useApi();

    const serverUrl = 'https://localhost:44357/images/products/';

    const [quantityAtOrderDetail, setQuantityAtOrderDetail] = useState({orderDetailId: '', quantity: ''});
    const [images, setImages] = useState([]);
    const [isOpen, setIsOpen] = useState(false);
    const [order, setOrder] = useState('asc');
    const [orderBy, setOrderBy] = useState('id');
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(5);

    const emptyRows = rowsPerPage - Math.min(rowsPerPage, list.length - page * rowsPerPage);

    useEffect(() => {
        if(props.orderDetails != null) {
            setList(props.orderDetails);
        }

    }, [props.orderDetails])

    useEffect(async () => {
       if(quantityAtOrderDetail.orderDetailId != '' && quantityAtOrderDetail.quantity != '') {
        props.setMessage('');
        const response = await axios.put('https://localhost:44348/api/Admin/EditProductFromOrderDetail', quantityAtOrderDetail,
            {
                headers: {
                  'Authorization': `Bearer ${localStorage.getItem("jwt")}`
                }
            })

            props.setMessage(response.data.message);
       }

    }, [quantityAtOrderDetail])

    const handleQuantityChange = (obj) => {
        if(obj.quantity > 0 && obj.quantity <= 10){
            setQuantityAtOrderDetail(obj);
        }
    }

    const deleteSelectedId = async (id) => {
        if(window.confirm("Are you sure to remove Product from Order Detail #" + id +" ?")) {
            if(list.length == 1) {
                toast.warn("The last item cannot be deleted!", {
                    theme: "colored"
                });
            }
            else {
                props.setMessage('');
                const response = await axios.delete(`https://localhost:44348/api/Admin/DeleteProductFromOrderDetail/${id}`,
                {
                    headers: {
                      'Authorization': `Bearer ${localStorage.getItem("jwt")}`
                    }
                })
    
                props.setMessage(response.data.message);
                setPage(rowsPerPage - emptyRows == 1 ? 0 : page)
            }
        }
    }

    const handleOpenModal = (id) => {
        const imgs = list.filter(x => x.product.id == id);

        console.log('imgs', imgs)
        setIsOpen(true)
        setImages(imgs[0].product.images)
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

    return (
        <React.Fragment>
            <h2 style={{ marginTop: '50px' }}>Edit Product of Order Details</h2>
            <Paper style={{ marginBottom: '50px', marginTop: '20px' }} elevation={3}>
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
                                                    onClickItem={() => handleOpenModal(record.product.id)}
                                                >
                                                    {record.product.images.map(img => <img src={serverUrl + img.path} />)}
                                                </Carousel>
                                            </TableCell>
                                            <TableCell align="left">{record.product.name}</TableCell>
                                            <TableCell align="left">{record.product.category.name}</TableCell>
                                            <TableCell align="center" style={{ paddingRight: '40px' }}>{record.size}</TableCell>
                                            <TableCell align="left">{record.product.price}</TableCell>
                                            <TableCell align="center" style={{ paddingRight: '40px' }}>
                                                <TextField
                                                    name="quantity"
                                                    variant="outlined"
                                                    label="Quantity"
                                                    value={quantityAtOrderDetail.orderDetailId == record.id ? quantityAtOrderDetail.quantity : record.quantity}
                                                    type="number"
                                                    onChange={(e) => handleQuantityChange({orderDetailId: record.id, quantity: e.target.value})}
                                                    style={{ minWidth: '50px'}}
                                                />
                                            </TableCell>
                                            <TableCell align="center" style={{ paddingRight: '40px' }}>
                                                <ButtonGroup variant="text">
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
                                                    {images.map(img => <img src={serverUrl + img.path} />)}
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

export default OrderDetailTable