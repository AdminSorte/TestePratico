import React, { Component } from 'react';
import TabelaEventos from './TabelaEventos';
import { Button,Container , Row, Col} from 'react-bootstrap';


export default class Agenda extends Component {
    static displayName = Agenda.name;

  constructor(props) {
      super(props);


      this.state = {
          abreTabelaEventos: false,
          //ltsEventoSelecionado: [],
          ltsEventos:[],
      }
    
      this.getEventosCadastrados = this.getEventosCadastrados.bind(this);
      this.atualizaTabelaEventos = this.atualizaTabelaEventos.bind(this);

  }
    
    componentDidMount() {

       
        this.getEventosCadastrados()



    }


    componentDidUpdate() {

        this.getEventosCadastrados()
    }


    

    atualizaTabelaEventos() {
        console.log("atualiza tabela")
        this.getEventosCadastrados()

    }

    




    getEventosCadastrados() {
        let eventosAgenda = []

        var url = "Agenda"
        fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'text/html',
            }
        }).then(response => response.json())
            .then(data => {
                if (data.length > 0) {

                    data.map(item => {

                        let idEvento, dsEvento, periodoEvento, dataEvento
                        idEvento = item.id
                        dsEvento = item.descricao
                        periodoEvento = item.periodo
                        dataEvento = item.data
                        eventosAgenda.push({ id: idEvento, descricao: dsEvento, periodo: periodoEvento, data: dataEvento })


                    })

                }

                if (eventosAgenda.length > 0) {
                   
                    this.setState({
                        abreTabelaEventos: true,
                        ltsEventos: eventosAgenda

                    });
                }

              

            });

       
    }

  render() {
      return (
          <Container fluid="ml" className="containerTelaAgenda">

              <Row>
              {this.state.abreTabelaEventos &&
                  <TabelaEventos
                  lstEventosCadastrados={this.state.ltsEventos}
                  atualizaTabelaEventos={this.atualizaTabelaEventos}
                  />
              }

              </Row>
              <Col>
              <Row>
                  <Button variant="outline-success" className="btnCriaEventos" style={{ marginLeft: '3%', marginTop: '1%' }} onClick={this.handleOpenModal}>Criar Evento</Button>
              </Row>
              </Col>
            
            
           </Container>
    );
  }
}

