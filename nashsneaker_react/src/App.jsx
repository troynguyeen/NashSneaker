import React, { useEffect, useState } from 'react';
import './App.css';
import Login from './pages/Login';
import { BrowserRouter, Link, Switch, Route, useHistory } from 'react-router-dom';
import { Box, CircularProgress, Container, Menu, MenuItem, Modal, AppBar, Toolbar, Typography, Button, IconButton } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import MenuIcon from '@material-ui/icons/Menu';
import { ToastContainer } from 'react-toastify';
import { ToastProvider } from 'react-toast-notifications';
import 'react-toastify/dist/ReactToastify.css';
import Sidebar from './components/Sidebar';
import MuiAppBar from '@mui/material/AppBar';
import { styled } from '@mui/material/styles';
import Dashboard from './pages/Dashboard';
import Categories from './pages/Categories';
import Products from './pages/Products';
import ViewUsers from './pages/ViewUsers';
import CategoryForm from './pages/CategoryForm';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  header: {
    background: '-webkit-linear-gradient(-65deg, #FC466B 0, #3F5EFB 100%)'
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
  boxLoading: {
    position: 'absolute',
    top: '35%',
    left: '48%',
    outline: 'none'
  },
  footer: {
    padding: '50px',
    textAlign: 'center',
    fontSize: '15px'
  }
}));

function App() {

  const classes = useStyles();

  const [open, setOpen] = useState(false);
  const [isLoading, setIsLoading] = useState(false)
  const [fullName, setFullName] = useState(sessionStorage.getItem("fullName") ? sessionStorage.getItem("fullName") : '');

  const [anchorEl, setAnchorEl] = useState(null);
  const openMenu = Boolean(anchorEl);

  const drawerWidth = 240;

  const AppBar = styled(MuiAppBar, {
    shouldForwardProp: (prop) => prop !== 'open',
  })(({ theme, open }) => ({
    transition: theme.transitions.create(['margin', 'width'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    ...(open && {
      width: `calc(100% - ${drawerWidth}px)`,
      marginLeft: `${drawerWidth}px`,
      transition: theme.transitions.create(['margin', 'width'], {
        easing: theme.transitions.easing.easeOut,
        duration: theme.transitions.duration.enteringScreen,
      }),
    }),
  }));

  const Main = styled('main', { shouldForwardProp: (prop) => prop !== 'open' })(
  ({ theme, open }) => ({
    flexGrow: 1,
    padding: theme.spacing(3),
    transition: theme.transitions.create('margin', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    marginLeft: `-${drawerWidth}px`,
    ...(open && {
      transition: theme.transitions.create('margin', {
        easing: theme.transitions.easing.easeOut,
        duration: theme.transitions.duration.enteringScreen,
      }),
      marginLeft: 0,
    }),
  }),
  );

  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };

  const handleMenu = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleLogout = () => {
    setIsLoading(true)
    setAnchorEl(null);

    setTimeout(() => {
      setIsLoading(false)
      setFullName('')
      sessionStorage.removeItem("fullName");
      sessionStorage.removeItem("jwt");
    }, 2000);
  }

  return (
    <BrowserRouter>
      <ToastProvider autoDismiss={true}>
        <Modal open={isLoading} onClose={!isLoading}>
          <Box className={classes.boxLoading}>
            <CircularProgress style={{ color: "#3F5EFB" }}/>
          </Box>
        </Modal>
        <ToastContainer
            position="top-right"
            autoClose={3000}
            hideProgressBar={false}
            newestOnTop={true}
            closeOnClick={true}
            rtl={false}
            pauseOnFocusLoss={true}
            draggable={true}
            pauseOnHover={true}
        />
        <AppBar className={classes.header} position="static" open={open}>
          <Toolbar style={{ display: 'flex', justifyContent: 'space-between'}}>
            <div style={{ display: 'flex', alignItems: 'center' }}>
              {
                open ? '' 
                :
                <IconButton 
                  className={classes.menuButton} 
                  edge="start" 
                  color="inherit" 
                  aria-label="menu"
                  onClick={handleDrawerOpen}
                >
                  <MenuIcon />
                </IconButton>
              }
              <Link to="/">
                <Typography className={classes.title} variant="h6">
                    <div style={{ display: 'flex', flexDirection: 'row', alignItems: 'center' }}>NashSneaker</div>
                </Typography>
              </Link>
            </div>
              {
                fullName == '' ?
                <Link to="/login">
                  <Button color="inherit">Login</Button>
                </Link>
                :
                <div style={{ display: 'flex', alignItems: 'center', fontSize: '20px', fontWeight: '500' }}>
                  <Button
                    onClick={handleMenu}
                    color="inherit"
                  >
                    <AccountCircleIcon style={{ fontSize: '30px', paddingRight: '10px' }}/>
                    {fullName}
                  </Button>
                  <Menu
                    style={{ top: '50px', left: '1700px' }}
                    anchorEl={anchorEl}
                    anchorOrigin={{
                      vertical: 'bottom',
                      horizontal: 'center',
                    }}
                    transformOrigin={{
                      vertical: 'top',
                      horizontal: 'center',
                    }}
                    open={openMenu}
                    onClose={handleClose}
                  >
                    <MenuItem style={{ width: '120px' }} onClick={handleClose}>Profile</MenuItem>
                    <MenuItem style={{ width: '120px' }} onClick={handleLogout}>Logout</MenuItem>
                  </Menu>
                </div>
              }
          </Toolbar>
        </AppBar>
        <Sidebar 
          open={open}
          handleDrawerClose={handleDrawerClose} 
          drawerWidth={drawerWidth}
        />
        <Container>
          <Switch>
            <Route exact path="/login" component={() => fullName !== '' ? '' : <Login fullName={fullName} setFullName={setFullName}/>} />
          </Switch>
        </Container>
        <Main open={open}>
          <Container>
            <Switch>
              <Route exact path='/dashboard' component={() => <Dashboard />} />
              <Route exact path='/categories' component={() => <Categories />} />
              <Route exact path='/categories/add-new' component={() => <CategoryForm />} />
              <Route exact path='/products' component={() => <Products />} />
              <Route exact path='/view-users' component={() => <ViewUsers />} />
            </Switch>
          </Container>
        </Main>
      </ToastProvider>
    </BrowserRouter>
  );
}

export default App;
