import React from 'react';
import Link from '@material-ui/core/Link';
import Toolbar from '@material-ui/core/Toolbar';
import AppBar from '@material-ui/core/AppBar';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';

import useStyles from '../../repositories/UseStyles'

  
export default function NavBar()
{
    const classes = useStyles();

    return (
        <AppBar position="static" color="default" elevation={0} className={classes.appBar}>
        <Toolbar className={classes.toolbar}>
          <Typography variant="h6" color="inherit" noWrap className={classes.toolbarTitle}>
            Company name
          </Typography>
          <nav>
            <Link variant="button" color="textPrimary" href="#" className={classes.link}>
              Features
            </Link>
            <Link variant="button" color="textPrimary" href="#" className={classes.link}>
              Enterprise
            </Link>
            <Link variant="button" color="textPrimary" href="#" className={classes.link}>
              Support
            </Link>
          </nav>
          <Button href="#" color="primary" variant="outlined" className={classes.link}>
            Login
          </Button>
        </Toolbar>

        
            <Fab color="inherit" aria-label="add" href="/AddorEdit">
              <AddIcon />
           </Fab>
        
      </AppBar>
    )
}