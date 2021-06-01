import React from 'react'
import Container from '@material-ui/core/Container';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import useStyles from '../../repositories/UseStyles'

import Typography from '@material-ui/core/Typography';
import Link from '@material-ui/core/Link';
import Card from '../Template/Card'

import Tabela from  '../Template/Tabela'


const footers = [ ];

export default function Footer() {
    const classes = useStyles();
    const tab = new Tabela();

    return(
        <Container maxWidth="md" component="footer" className={classes.footer}>
        <Grid container spacing={4} justify="space-evenly">
          {footers.map((footer) => (
            <Grid item xs={6} sm={3} key={footer.title}>
              <Typography variant="h6" color="textPrimary" gutterBottom>
                {footer.title}
              </Typography>
              <ul>
                {footer.description.map((item) => (
                  <li key={item}>
                    <Link href="#" variant="subtitle1" color="textSecondary">
                      {item}
                    </Link>
                  </li>
                ))}
              </ul>
            </Grid>
          ))}
        </Grid>
        <Box mt={5}>
          {tab.renderCard(tab.state.agend.id)}
        </Box>
      </Container>
    )
}