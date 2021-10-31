import React from "react";
import { styled, useTheme } from '@mui/material/styles';
import Drawer from '@mui/material/Drawer';
import List from '@mui/material/List';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import { makeStyles } from '@material-ui/core/styles';
import { MdSpaceDashboard, MdCategory } from "react-icons/md";
import { GiConverseShoe } from "react-icons/gi";
import { Link } from 'react-router-dom';

const useStyles = makeStyles((theme) => ({
  root: {
    '& .MuiDrawer-paper': {
      background: '-webkit-linear-gradient(-90deg, #FC466B 0, #3F5EFB 100%)',
      color: '#fff'
    },
    '& .MuiSvgIcon-root': {
      color: '#fff'
    },
    '& .MuiDivider-root': {
      
    }
  }
}));

const Sidebar = (props) => {

  const classes = useStyles();
  const theme = useTheme();

  const DrawerHeader = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(0, 1),
    // necessary for content to be below app bar
    ...theme.mixins.toolbar,
    justifyContent: 'flex-end',
  }));

  return (
    <Drawer
      className={classes.root}
      sx={{
        width: props.drawerWidth,
        flexShrink: 0,
        "& .MuiDrawer-paper": {
          width: props.drawerWidth,
          boxSizing: "border-box",
        },
      }}
      variant="persistent"
      anchor="left"
      open={props.open}
    >
      <DrawerHeader>
        <IconButton onClick={() => props.handleDrawerClose()}>
          {theme.direction === "ltr" ? (
            <ChevronLeftIcon />
          ) : (
            <ChevronRightIcon />
          )}
        </IconButton>
      </DrawerHeader>
      <Divider />
      <List>
        <Link to='/dashboard'>
          <ListItem button>
            <ListItemIcon>
              <MdSpaceDashboard style={{ fontSize: '20px', color: '#fff' }} />
            </ListItemIcon>
            <ListItemText primary={"Dashboard"} />
          </ListItem>
        </Link>
        <Link to='/categories'>
          <ListItem button>
            <ListItemIcon>
              <MdCategory style={{ fontSize: '20px', color: '#fff' }} />
            </ListItemIcon>
            <ListItemText primary={"Categories"} />
          </ListItem>
        </Link>
        <Link to='/products'>
          <ListItem button>
            <ListItemIcon>
              <GiConverseShoe style={{ fontSize: '20px', color: '#fff' }} />
            </ListItemIcon>
            <ListItemText primary={"Products"} />
          </ListItem>
        </Link>
      </List>
      <Divider />
      <List>
        <Link to='/view-users'>
          <ListItem button>
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
            <ListItemText primary={"View users"} />
          </ListItem>
        </Link>
      </List>
    </Drawer>
  );
};

export default Sidebar;
