import React,{ useState, useEffect } from 'react';
import axios from 'axios';
import { Button, Container, Grid, Paper, TextField } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import { AiOutlineArrowLeft } from "react-icons/ai";
import { useHistory } from 'react-router-dom';
import useApi from '../hooks/useApi';
import { toast } from 'react-toastify';

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
    }
}))

const initialProfile = {
    id: '',
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    role: ''
}

const Profile = (props) => {

    const classes = useStyles();

    const history = useHistory();

    const {values, setValues, message, setMessage, PutAPI, handleInputChange} = useApi(initialProfile);

    useEffect(() => {
        //Fetch profile admin
        fetchProfile();
        
    }, [])

    useEffect(() => {
        if(message !== '') {
            if(message === 'error') {
                toast.error("Something went wrong!", {
                    theme: "colored"
                });
            }
            else {
                toast.success(message, {
                    theme: "colored"
                });
            }
        }

    }, [message])

    const fetchProfile = async () => {
        const response = await axios.get('https://localhost:44348/api/Admin/Profile',
        {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem("jwt")}`
            }
        })

        setValues({...response.data});
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        if(values.firstName != '' && values.lastName != '' && values.phoneNumber != '') {
            await PutAPI('EditProfile');
            props.setFullName(values.firstName + " " + values.lastName)
            localStorage.setItem('fullName', values.firstName + " " + values.lastName);
            setMessage('');
        }
        else {
            toast.warning("All information can not be empty", {
                theme: "colored"
            });
        }
    }

    return (
        <Container className={classes.container}>
            <h2>Profile</h2>
            <Paper className={classes.paper} elevation={5}>
                <AiOutlineArrowLeft onClick={() => history.push('/dashboard')} style={{ fontSize: '25px', cursor: 'pointer' }}/>
                <form noValidate className={classes.root} onSubmit={handleSubmit}>
                    <Grid container>
                        <Grid item xs={6}>
                            <TextField
                                name="firstName"
                                variant="outlined"
                                label="First Name"
                                value={values.firstName}
                                onChange={handleInputChange}
                                style={{ minWidth: '285px', marginLeft: '50px' }}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField
                                name="lastName"
                                variant="outlined"
                                label="Last Name"
                                value={values.lastName}
                                onChange={handleInputChange}
                                style={{ minWidth: '285px', marginLeft: '-20px' }}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                name="email"
                                variant="outlined"
                                label="Email"
                                value={values.email}
                                onChange={handleInputChange}
                                InputProps={{
                                    readOnly: true
                                }}
                                style={{ background: '#F5F5F5' }}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField
                                name="phoneNumber"
                                variant="outlined"
                                label="Phone Number"
                                value={values.phoneNumber}
                                onChange={handleInputChange}
                                type="number"
                                style={{ minWidth: '285px', marginLeft: '50px' }}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField
                                name="role"
                                variant="outlined"
                                label="Role"
                                value={values.role}
                                onChange={handleInputChange}
                                style={{ minWidth: '285px', marginLeft: '-20px', background: '#F5F5F5' }}
                                InputProps={{
                                    readOnly: true
                                }}
                            />
                        </Grid>
                        <Grid item xs={12}>
                        <div className={classes.buttonContainer} style={{ paddingTop: '15px' }}>
                            <Button className={classes.button} variant="contained" color="primary" type="submit">Save</Button>
                        </div>
                        </Grid>
                    </Grid>
                </form>
            </Paper>
        </Container>
    )
}

export default Profile
