import React, { Component, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button, TextField } from '@material-ui/core';
import axios from 'axios';
import Url from './repositories/Url'
import Tabela from './components/Template/Tabela'

const initialState = {
    agenda: { id: ''  ,titulo: '', descricao: '', data: '' },
    list: []
}

export default class Edit extends Component {

    state = {...initialState}
    put() {
        const agenda = this.state.agenda
        const url = 'https://localhost:44387/api/v1/agenda/atualizar'
        axios.put(url, agenda).then(response => {
            const list = this.getUpdatedList(response.data)
            this.setState({agenda: initialState.agenda, list})

            console.log(response.data)
        })
    }

    getUpdatedList(agenda, add=true) {
        const list = this.state.list.filter(u => u.id !== agenda.id)
        if(add) list.unshift(agenda)
        return list
    }
    updateField(event) {
        const agenda = {...this.state.agenda}
        agenda[event.target.name] = event.target.value
        this.setState({ agenda })
    }

    render() {
        return(
            <div>
            <form encType="application/json">
                <div>
                     <TextField label = "ID" value = { this.state.agenda.id} name = "id" 
                       onChange = {e => this.updateField(e)}   />
                </div>
                <div>
                     <TextField label = "Titulo" value = {this.state.agenda.titulo} name = "titulo" 
                       onChange = {e => this.updateField(e)}  required/>
                </div>
                <div>
                     <TextField label = "Descricao" value = {this.state.agenda.descricao} name = "descricao" 
                       onChange = {e => this.updateField(e)} />
                </div>
                <div>
                     <TextField label = "Data" value = {this.state.agenda.data} name = "data" 
                      type="date" defaultValue="2017-05-24" InputLabelProps={{shrink: true}}
                        onChange = { e => this.updateField(e) } />
                </div>
                <div>
                    <Button variant = "container" color = "primary" onClick={e => this.put(e)}>Submit</Button>
                </div>
               
            </form>
        </div>
        )
    }

   
}