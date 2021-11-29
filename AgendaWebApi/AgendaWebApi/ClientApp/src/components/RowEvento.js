import React, { Component, Fragment } from 'react';
import { Button } from 'react-bootstrap';


export default class RowEvento extends Component {
    static displayName = RowEvento.name;

    constructor(props) {
        super(props);
        this.state = {

            modalExcluirEvento: false,
            ltsEventoEdicao:[]
        }
             
        this.excluirEvento = this.excluirEvento.bind(this);
        this.getEventoPorId = this.getEventoPorId.bind(this);
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
        var url = "Agenda/"+id
        fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'text/html',
            }
        }).then(response => response.json())
            .then(data => {

                this.setState({

                    ltsEventoEdicao: data

                });
                //if (data.length > 0) {
                //    console.log(data)
                   

                //}
               // console.log(this.state.ltsEventoEdicao)
               
                openModalEditarCadastroEventos(this.state.ltsEventoEdicao)


            });


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
                            <td> <Button variant="warning" className="btnAlterarEventos" style={{ marginLeft: '3%', marginTop: '1%' }} onClick={() => this.getEventoPorId(eventos.id)}>Alterar</Button>
                            </td>
                            

                        </tr>


                    )}

            </Fragment>

        )


    }
}

