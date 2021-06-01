import React, { Component } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Button from '@material-ui/core/Button';
import ButtonGroup from '@material-ui/core/ButtonGroup';
import DeleteIcon from '@material-ui/icons/Delete';
import BuildIcon from '@material-ui/icons/Build';
import MoodIcon from '@material-ui/icons/Mood';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';

import useStyles from '../../repositories/UseStyles'

import axios from 'axios'
import AdicionarAtualizar from '../../AdicionarEditar'


export default class tabela extends Component {
 
    state = {
        agend: []
      }
   
       componentWillMount() {
           axios.get('https://localhost:44387/api/v1/agenda/get-all')
           .then(response => {
   
              this.setState({agend: response.data.data})
              console.log(this.state)
           })
       }

       remove(agenda) {
        axios.delete(`https://localhost:44387/api/v1/agenda/remove/${agenda.id}`)
        .then(response => {
          console.log(response)
        })
     }

     
   renderCard(agenda) {
      axios.get(`https://localhost:44387/api/v1/agenda/get-agenda/${agenda.id}`)
      .then(response => {
        console.log(response.data)
        return (
          <Card variant="outlined">
            <CardContent>
            {this.state.agend.map((agenda) => (
                 <CardContent>
                 <Typography  color="textSecondary" gutterBottom>
                  {agenda.id}
                 </Typography>
                 <Typography variant="h5" component="h2">
                   {agenda.titulo}
                 </Typography>
                 <Typography  color="textSecondary">
                 {agenda.descricao}
                 </Typography>
                 <Typography variant="body2" component="p">
                   <br />
                   {agenda.data}
                 </Typography>
               </CardContent> 
             ))}
            </CardContent>
              
             
          </Card>
        )
      })
   }

    render() {
        return (
            <TableContainer component={Paper}>
              <Table className={useStyles.table} aria-label="caption table">
                <TableHead>
                  <TableRow>
                    <TableCell>ID Agenda</TableCell>
                    <TableCell align="inherit">Descrição curta</TableCell>
                    <TableCell align="inherit">Actions</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {this.state.agend.map((agenda) => (
                    <TableRow key={agenda.id}>
                      <TableCell component="th" scope="row">{agenda.id}</TableCell>
                      <TableCell align="inherit">{agenda.titulo}</TableCell>
                      <TableCell align="inherit">
                      <ButtonGroup color="primary" aria-label="outlined primary button group" key={agenda}>
                            <Button startIcon={<DeleteIcon />} onClick={ () => this.remove(agenda) } color="secondary">Deletar</Button>
                            <Button startIcon={<MoodIcon />} color="inherit" onClick={() => this.renderCard(agenda)}>Vizualizar</Button>
                            <Button startIcon={<BuildIcon />} color="primary"  href="/Edit">Editar</Button>
                            
                      </ButtonGroup>
                           
                    </TableCell>   
                    </TableRow>
                    
                  ))}
                </TableBody>
              </Table>
              
            </TableContainer>
            

          );
    }

 
}