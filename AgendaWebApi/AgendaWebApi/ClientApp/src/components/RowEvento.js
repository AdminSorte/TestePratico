import React, { Component, Fragment } from 'react';
import { Button } from 'react-bootstrap';


export default class RowEvento extends Component {
    static displayName = RowEvento.name;

    constructor(props) {
        super(props);
        this.state = {

            modalExcluirEvento: false,
            //ltsEvento: [],
            EditaEvento: false,
            visualizaEvento: false,
            
        }
             
        this.excluirEvento = this.excluirEvento.bind(this);
        this.getEventoPorId = this.getEventoPorId.bind(this);
        this.visualizarEvento = this.visualizarEvento.bind(this);
        this.editaEvento = this.editaEvento.bind(this);
    }


    //Visualizar evento
    visualizarEvento(id) {


        this.setState({
            visualizaEvento: true,


        });

        this.getEventoPorId(id) 

    }


    //Edita Evento
    editaEvento(id) {


        this.setState({
            EditaEvento: true,
            

        });


        this.getEventoPorId(id) 


    }

    //Excluir Evento 
    excluirEvento(evento) {

        console.log(evento)
        fetch('Agenda/' + evento, { method: 'DELETE' })
            .then(() => this.setState({ modalExcluirEvento: true }));


        //reenderiza Tabela de Eventos
        this.props.atualizaTabelaEventos()


    }


    //Consulta Eventos por Id
    getEventoPorId(id) {

        let eventoAgenda = []

        const { openModalEditarCadastroEventos } = this.props;
        const { openModalVisualizaEventos  } = this.props;

        var url = "Agenda/"+id
        fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'text/html',
            }
        }).then(response => response.json())
            .then(data => {
                if (this.state.EditaEvento) {
                    openModalEditarCadastroEventos(data)

                } else {

                    openModalVisualizaEventos(data)

                }
=

         });
        console.log(this.state.ltsEvento)
       

    }
   
    render() {

        return (
            

            <Fragment>
                {
                    this.props.lstEventosCadastrados.map(eventos =>

                        <tr key={eventos.id} >
                            <td style={{ textAlign: "center" }} onClick={() => this.visualizarEvento(eventos.id)} >{eventos.id}</td>
                            <td style={{ textAlign: "center" }}>{eventos.descricao}</td>
                            <td style={{ textAlign: "center" }}>{eventos.periodo}</td>
                            <td style={{ textAlign: "center" }}>{eventos.data}</td>
                            <td> <Button variant="danger" className="btnExcluirEventos" style={{ marginLeft: '3%', marginTop: '1%' }} onClick={() => this.excluirEvento(eventos.id)}>Excluir</Button>
                            </td>
                            <td> <Button variant="warning" className="btnAlterarEventos" style={{ marginLeft: '3%', marginTop: '1%' }} onClick={() => this.editaEvento(eventos.id)}>Alterar</Button>
                            </td>
                            

                        </tr>


                    )}

            </Fragment>

        )


    }
}

