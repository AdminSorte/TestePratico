import React, { Component, Fragment } from 'react';
import { Button } from 'react-bootstrap';


export default class RowEvento extends Component {
    static displayName = RowEvento.name;

    constructor(props) {
        super(props);
        this.state = {

            modalExcluirEvento: false

        }
             
        this.excluirEvento = this.excluirEvento.bind(this);
        this.handleOpenModal = this.handleOpenModal.bind(this);
        
    }



    //Excluir Evento 
    excluirEvento(evento) {





        console.log(evento)
        fetch('Agenda/' + evento, { method: 'DELETE' })
            .then(() => this.setState({ modalExcluirEvento: true }));


        //reenderiza Tabela de Eventos
        this.props.atualizaTabelaEventos()


    }



    handleOpenModal(evento) {

        console.log(evento)
    }

   
    render() {

        return (
            

            <Fragment>
                {
                    this.props.lstEventosCadastrados.map(eventos =>

                        <tr key={eventos.id} >
                            <td style={{ textAlign: "center" }}>{eventos.id}</td>
                            <td style={{ textAlign: "center" }}>{eventos.descricao}</td>
                            <td style={{ textAlign: "center" }}>{eventos.periodo}</td>
                            <td style={{ textAlign: "center" }}>{eventos.data}</td>
                            <td> <Button variant="danger" className="btnExcluirEventos" style={{ marginLeft: '3%', marginTop: '1%' }} onClick={() => this.excluirEvento(eventos.id)}>Excluir</Button>
                            </td>
                            <td> <Button variant="warning" className="btnAlterarEventos" style={{ marginLeft: '3%', marginTop: '1%' }} onClick={()  => this.handleOpenModal(eventos.id)}> Alterar</Button>
                            </td>
                            



                        </tr>


                    )}

            </Fragment>

        )


    }
}

