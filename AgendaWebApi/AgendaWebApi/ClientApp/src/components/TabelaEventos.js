import React, { Component } from 'react';
import { Table, Button } from 'react-bootstrap';
import RowEvento from  './RowEvento';


export default class TabelaEventos extends Component {
    static displayName = TabelaEventos.name;

  constructor(props) {
      super(props);

  }



    renderizaTabelaEventos() {

        return (


            <Table className='tabelaEventos' className='table-fixed-header' bordered striped variant="ligth" hover size="sm">
                <thead>
                    <tr>
                        
                        <th style={{ textAlign: "center" }}>Id</th>
                        <th style={{ textAlign: "center" }}>Descrição</th>
                        <th style={{ textAlign: "center" }}>Periodo</th>
                        <th style={{ textAlign: "center" }}>Data</th>
                        <th></th>
                        <th></th>
                        

                    </tr>
                </thead>
                <tbody>

                    <RowEvento
                        lstEventosCadastrados={this.props.lstEventosCadastrados}
                        atualizaTabelaEventos ={this.props.atualizaTabelaEventos}

                    />


                </tbody>
            </Table>
             

        )
    }
    render() {

        let contents = this.renderizaTabelaEventos();
        return (
            <div className={'tabelaEventos'} > {contents} </div >



        );

    }

}

