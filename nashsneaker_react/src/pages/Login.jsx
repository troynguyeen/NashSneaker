import React from 'react'
import { Paper } from '@material-ui/core'
import { Button, CircularProgress, Grid, Modal, TextField, Tooltip } from '@mui/material'
import { Box } from '@mui/system'
import { makeStyles } from '@material-ui/core/styles';
import InfoIcon from '@material-ui/icons/Info';
import useLogin from '../components/useLogin';

const useStyles = makeStyles(() => ({
    root: {
        flexDirection: 'column',
        alignItems: 'center'
    },
    paper: {
        margin: '50px 300px',
        padding: '20px 70px'
    },
    header: {
        textAlign: 'center',
        paddingBottom: '20px',
        paddingTop: '40px',
        fontSize: '25px',
        fontWeight: 'bold'
    },
    textField: {
        padding: '15px',
        width: '500px'
    },
    button: {
        padding: '10px 15px !important',
        margin: '20px 0 !important',
        background: '-webkit-linear-gradient(-65deg, #FC466B 0, #3F5EFB 100%)',
        width: '100px'
    },
    boxLoading: {
        position: 'absolute',
        top: '35%',
        left: '49%',
        outline: 'none'
    }

}));

const initialFieldValues = {
    email: '',
    password: ''
}

const Login = (props) => {

    const classes = useStyles();

    const {values, errors, isLoading, handleInputChange, handleSubmit} = useLogin(initialFieldValues, props)

    return (
        <Paper className={classes.paper} elevation={5}>
            <form onSubmit={handleSubmit}>
                <Modal
                    open={isLoading}
                    onClose={!isLoading}
                >
                    <Box className={classes.boxLoading}>
                        <CircularProgress style={{ color: '#3F5EFB' }}/>
                    </Box>
                </Modal>
                <div className={classes.header}>Login as Admin</div>
                {errors ? <div style={{ color: 'red', textAlign: 'center' }}>{errors}</div> : ''}
                <Grid className={classes.root} container>
                    <Grid className={classes.textField} item xs={12}>
                        <TextField
                            style={{ width: '100%' }}
                            name="email"
                            variant="outlined"
                            type="text"
                            label="Email"
                            value={values.email}
                            onChange={handleInputChange}
                        />
                    </Grid>
                    <Grid className={classes.textField} item xs={12}>
                        <TextField
                            style={{ width: '100%' }}
                            name="password"
                            variant="outlined"
                            type="password"
                            label="Password"
                            value={values.password}
                            onChange={handleInputChange}
                        />
                    </Grid>
                    <Grid item xs={12} style={{ textAlign: 'center' }}>
                        <Button className={classes.button} variant="contained" color="primary" type="submit">Login</Button>
                    </Grid>
                </Grid>
                <div style={{ textAlign: 'end' }}>
                    <Tooltip title="(username: admin, password: 123456)" placement="top-end">
                        <InfoIcon />
                    </Tooltip>
                </div>
            </form>
        </Paper>
    )
}

export default Login
