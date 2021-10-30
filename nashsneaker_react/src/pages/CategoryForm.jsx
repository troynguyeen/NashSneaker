import React, { useEffect } from 'react'
import TextareaAutosize from '@mui/material/TextareaAutosize';
import { Button, Container, Grid, Paper, TextField } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import useApi from '../hooks/useApi';

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

const initialValue = {
    name: '',
    description: ''
}

const CategoryForm = () => {

    const classes = useStyles();
    
    const {values, setValues, message, setMessage, PostAPI, PutAPI, handleInputChange} = useApi(initialValue);

    useEffect(() => {
        if(message === 'error') {
            console.log('looiiiiii')
        }
        else {
            console.log('message', message)
        }

    }, [message])

    const handleSubmit = async (e) => {
        e.preventDefault();
        setMessage('')
        setValues(initialValue)
        PostAPI('AddNewCategory');
    }

    const handleReset = () => {
        setValues(initialValue);
    }

    return (
        <Container className={classes.container}>
            <h2 style={{ textAlign: 'center' }}>Add new category</h2>
            <Paper className={classes.paper} elevation={5}>
                <form noValidate className={classes.root} onSubmit={handleSubmit}>
                    <Grid container>
                        <Grid item xs={12}>
                            <TextField
                                name="name"
                                variant="outlined"
                                label="Category name"
                                value={values.name}
                                onChange={handleInputChange}
                                InputProps={{
                                    //readOnly: props.currentId != 0 ? true : false
                                }}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextareaAutosize
                                name="description"
                                value={values.description}
                                onChange={handleInputChange}
                                aria-label="textarea"
                                placeholder="Category description..."
                                style={{ width: '600px', height: '150px', margin: '20px', padding: '15px' }}
                            />
                        <div className={classes.buttonContainer}>
                            <Button className={classes.button} variant="contained" color="primary" type="submit">Submit</Button>
                            <Button style={{ backgroundColor: '#DCDCDC', color: '#000' }} variant="contained" type="reset" onClick={handleReset}>Reset</Button>
                        </div>
                        </Grid>
                    </Grid>
                </form>
            </Paper>
        </Container>
    )
}

export default CategoryForm
