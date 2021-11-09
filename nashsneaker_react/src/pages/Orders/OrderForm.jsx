import React, { useState, useEffect } from 'react'
import TextareaAutosize from '@mui/material/TextareaAutosize';
import { Button, ButtonGroup, CircularProgress, Container, Grid, Modal, Paper, TextField } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import useApi from '../../hooks/useApi';
import { toast, ToastContainer } from 'react-toastify';
import { AiOutlineArrowLeft } from "react-icons/ai";
import { useHistory, useParams, useLocation } from 'react-router-dom';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import moment from 'moment';
import OrderDetailTable from './OrderDetailTable';

const useStyles = makeStyles((theme) => ({
    root: {
        '& .MuiTextField-root': {
            margin: theme.spacing(2),
            minWidth: '600px'
        },
        '& .MuiGrid-root': {
            textAlign: 'center'
        },
        '& .MuiInput-root': {
            width: '180px'
        }
    },
    container: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center'
    },
    paper: {
        padding: '20px',
        margin: '30px',
        width: '700px'
    },
    grid: {
        flexDirection: 'row',
        alignItems: 'center'
    },
    buttonContainer: {
        display: 'flex',
        justifyContent: 'space-around',
        margin: '25px 15px'
    },
    button: {
        marginRight: '15px !important'
    },
    boxLoading: {
        position: 'absolute',
        top: '35%',
        left: '48%',
        outline: 'none'
    },
}))

const initialValue = {
    id: '',
    user: '',
    recipientName: '',
    address: '',
    phoneNumber: '',
    paymentMethod: '',
    totalAmount: '',
    status: '',
    createdDate: ''
}

const OrderForm = () => {

    const classes = useStyles();

    const history = useHistory();
    const location = useLocation();
    const param = useParams();

    const [imagesDelete, setImagesDelete] = useState([])
    const [images, setImages] = useState([])
    
    const {values, setValues, message, setMessage, FetchAPI, GetByIdAPI, PutAPI, DeleteAPI, handleInputChange} = useApi(initialValue);

    useEffect(() => {
        if(message !== '') {
            if(message === 'error') {
                toast.error("Something went wrong!", {
                    theme: "colored"
                });
            }
            else {
                GetByIdAPI('GetOrderById', param.id)
                toast.success(message, {
                    theme: "colored"
                });
            }
        }

    }, [message])

    useEffect(() => {
        //Switch route
        if(location.pathname.includes("edit")) {
            param.id > 0 ? GetByIdAPI('GetOrderById', param.id) : history.push('/orders')
        }

    }, [])

    const handleSubmit = async (e) => {
        e.preventDefault();

        if(values.id != '' && values.recipientName != '' && values.address != '' && values.phoneNumber != '' && values.status != '' && values.paymentMethod != '') {
            PutAPI('EditOrder');
            setMessage('');
        }
        else {
            toast.warning("All information can not be empty", {
                theme: "colored"
            });
        }
    }

    const handleReset = () => {
        setValues(initialValue);
    }

    return (
        <Container className={classes.container}>
            <h2>Edit Order Details</h2>
            <Paper className={classes.paper} elevation={5}>
                <AiOutlineArrowLeft onClick={() => history.push('/orders')} style={{ fontSize: '25px', cursor: 'pointer' }}/>
                <form noValidate className={classes.root} onSubmit={handleSubmit}>
                    <Grid container>
                        <Grid item xs={6}>
                            <TextField
                                name="id"
                                variant="outlined"
                                label="Order Id"
                                value={values.id}
                                style={{ minWidth: '285px', marginRight: '-20px', background: '#F5F5F5' }}
                                InputProps={{
                                    readOnly: true
                                }}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField
                                name="userCreated"
                                variant="outlined"
                                label="User Created"
                                value={values.user.firstName + " " + values.user.lastName}
                                style={{ minWidth: '285px', marginLeft: '-20px', background: '#F5F5F5' }}
                                InputProps={{
                                    readOnly: true
                                }}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField
                                name="recipientName"
                                variant="outlined"
                                label="Recipient Name"
                                value={values.recipientName}
                                onChange={handleInputChange}
                                style={{ minWidth: '285px', marginRight: '-20px' }}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField
                                name="phoneNumber"
                                variant="outlined"
                                label="Phone Number"
                                value={values.phoneNumber}
                                type="number"
                                onChange={handleInputChange}
                                style={{ minWidth: '285px', marginLeft: '-20px' }}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                name="address"
                                variant="outlined"
                                label="Address"
                                value={values.address}
                                onChange={handleInputChange}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <FormControl style={{ width: '285px', margin: '16px', marginLeft: '50px' }}>
                                <InputLabel id="label">Payment Method</InputLabel>
                                <Select
                                    name="paymentMethod"
                                    labelId="label"
                                    variant="outlined"
                                    value={values.paymentMethod}
                                    label="Payment Method"
                                    onChange={handleInputChange}
                                    style={{ textAlign: 'start' }}
                                >
                                    <MenuItem value="Cash on delivery (COD)">Cash on delivery (COD)</MenuItem>
                                    <MenuItem value="Napas ATM/Internet Banking">Napas ATM/Internet Banking</MenuItem>
                                    <MenuItem value="MoMo Wallet">MoMo Wallet</MenuItem>
                                </Select>
                            </FormControl>
                        </Grid>
                        <Grid item xs={6}>
                            <FormControl style={{ width: '285px', margin: '16px', marginRight: '50px' }}>
                                <InputLabel id="label">Status</InputLabel>
                                <Select
                                    name="status"
                                    labelId="label"
                                    variant="outlined"
                                    value={values.status}
                                    label="Status"
                                    onChange={handleInputChange}
                                    style={{ textAlign: 'start' }}
                                >
                                    <MenuItem value="Wait for confirmation">Wait for confirmation</MenuItem>
                                    <MenuItem value="Confirmed">Confirmed</MenuItem>
                                </Select>
                            </FormControl>
                        </Grid>
                        <Grid item xs={6}>
                            <TextField
                                name="createdDate"
                                variant="outlined"
                                label="Created Date"
                                value={moment(values.createdDate).format('YYYY-MM-DD HH:mm:ss')}
                                style={{ minWidth: '285px', marginRight: '-20px', background: '#F5F5F5' }}
                                InputProps={{
                                    readOnly: true
                                }}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField
                                name="totalAmount"
                                variant="outlined"
                                label="Total Amount"
                                value={values.totalAmount}
                                style={{ minWidth: '285px', marginLeft: '-20px', background: '#F5F5F5' }}
                                InputProps={{
                                    readOnly: true
                                }}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <div className={classes.buttonContainer}>
                                <Button className={classes.button} variant="contained" color="primary" type="submit">Save</Button>
                                <Button style={{ backgroundColor: '#DCDCDC', color: '#000' }} variant="contained" type="reset" onClick={handleReset}>Reset</Button>
                            </div>
                        </Grid>
                    </Grid>
                </form>
            </Paper>
            <OrderDetailTable orderDetails={values.orderDetails} setMessage={setMessage}/>
        </Container>
    )
}

export default OrderForm
