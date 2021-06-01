import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';

import Input from '@material-ui/core/Input';
import InputLabel from '@material-ui/core/InputLabel';
import InputAdornment from '@material-ui/core/InputAdornment';
import FormControl from '@material-ui/core/FormControl';
import AccountCircle from '@material-ui/icons/AccountCircle';

import useStyles from './repositories/UseStyles'

export default function Content() {
    const classes = useStyles();

    return(
        <Container maxWidth="sm" component="main" className={classes.heroContent}>
        <Typography component="h1" variant="h2" align="center" color="textPrimary" gutterBottom>
          Minha Agenda Minha Vida 
        </Typography>
        <Typography variant="h6" align="center" color="textSecondary" component="p">
          Quickly build an effective pricing table for your potential customers with this layout.
          It&apos;s built with default Material-UI components with little customization.
        </Typography>
      <FormControl className={useStyles.table}>
                            <InputLabel htmlFor="input-with-icon-adornment">Busca Agenda </InputLabel>
                          <Input
                             id="input-with-icon-adornment"
                             startAdornment={
                            <InputAdornment position="end">
                            <AccountCircle />
                            </InputAdornment>
                                             }/>
                        </FormControl>

      
      <div>
      </div>
      </Container>

    
    )
   
}