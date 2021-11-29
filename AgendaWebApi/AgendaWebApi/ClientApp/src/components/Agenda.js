import React,{ Component } from 'react';
import TabelaEventos from './TabelaEventos';
import NovoEvento from './NovoEvento';
import EditarEvento from './EditarEvento';
import { Button,Container , Row, Col} from 'react-bootstrap';
import { Fragment } from 'react';
import { data } from 'jquery';


export default class Agenda extends Component {
    static displayName = Agenda.name;

  constructor(props) {
      super(props);


      this.state = {
          abreTabelaEventos: false,
          ltsEventos: [],
          ltsEventoEdicao: [],
          abreModalCadastroEventos: false,
          modalCriarEvento: false,
          abreModalEditarEvento: false,
          idEvento: "",
          dataEvento: "",
          periodoEvento: "",
          descricaoEvento: "",
         
      }
    
      this.getEventosCadastrados = this.getEventosCadastrados.bind(this);
      this.atualizaTabelaEventos = this.atualizaTabelaEventos.bind(this);
      this.openModalCadastroEventos = this.openModalCadastroEventos.bind(this);
      this.closeModalCadastroEventos = this.closeModalCadastroEventos.bind(this);
      this.insertEventoAgenda = this.insertEventoAgenda.bind(this);
      this.closeModalEdicaoEvento = this.closeModalEdicaoEvento.bind(this);
      this.openModalEditarCadastroEventos = this.openModalEditarCadastroEventos.bind(this);
      this.atualizaEventoAgenda = this.atualizaEventoAgenda.bind(this);


  }
    
    componentDidMount() {
       
        this.getEventosCadastrados()
    }


    

    atualizaTabelaEventos() {
        console.log("atualiza tabela")
        this.getEventosCadastrados()

    }


    openModalCadastroEventos() {
        this.setState({ abreModalCadastroEventos: true})

    }

    closeModalCadastroEventos() {
        this.setState({
            abreModalCadastroEventos: false,
            abreTabelaEventos: true
        })

    }

    openModalEditarCadastroEventos(evento) {

        
        const DataEditada = evento.data
        const recortaHora = DataEditada.substring(0, 10)
        const FormataParaBR = recortaHora.split('-').reverse().join('/');


        console.log(DataEditada)
        console.log(evento.descricao)
        this.setState({
            abreModalEditarEvento: true,
            idEvento: evento.id,
            dataEvento: FormataParaBR,
            periodoEvento: evento.periodo,
            descricaoEvento: evento.descricao,


        });
        

    }

    closeModalEdicaoEvento() {
        this.setState({
            abreModalEditarEvento: false,


        });

    }

   

    //Consulta Eventos cadastrados
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

  
    //Insere novo evento
    insertEventoAgenda(evento) {

        const eventos = JSON.stringify(evento)
        JSON.parse(eventos)

        fetch('Agenda',{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: eventos
        })
           .then(resp => {
                if (resp.status === 200) {
                    this.closeModalCadastroEventos()
                } else {
                    console.log("Status: " + resp.status)
                    
                }
            })
            .catch(err => {
                if (err === "server") {
                    console.log(err)
                }
                    
                
            })

    }

    //atualiza evento por id 
    atualizaEventoAgenda(id, evento) {

        const eventos = JSON.stringify(evento)
        JSON.parse(eventos)

        fetch('Agenda/'+ id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: eventos
        })
            .then(resp => {
                if (resp.status === 200) {
                    this.closeModalCadastroEventos()
                } else {
                    console.log("Status: " + resp.status)

                }
            })
            .catch(err => {
                if (err === "server") {
                    console.log(err)
                }


            })

    }


  render() {
      return (

          <Container fluid="xl" className="containerTelaAgenda">

              {this.state.abreModalCadastroEventos && this.state.abreModalEditarEvento == false &&

                  <NovoEvento
                  closeModalCadastroEventos={this.closeModalCadastroEventos}
                  insertEventoAgenda={this.insertEventoAgenda}

                  />

              }

              {this.state.abreModalEditarEvento && this.state.abreModalCadastroEventos == false &&

                  <EditarEvento

                  closeModalCadastroEventos={this.closeModalCadastroEventos}
                  idEvento={this.state.idEvento}
                  dataEvento={this.state.dataEvento}
                  periodoEvento={this.state.periodoEvento}
                  descricaoEvento={this.state.descricaoEvento}
                  atualizaEventoAgenda={this.atualizaEventoAgenda}
                      

                  />

              }

              <Row>
              {
                      this.state.abreTabelaEventos && this.state.abreModalCadastroEventos == false && this.state.abreModalEditarEvento == false &&

                  <TabelaEventos
                          lstEventosCadastrados={this.state.ltsEventos}
                          atualizaTabelaEventos={this.atualizaTabelaEventos}
   
                          openModalEditarCadastroEventos={this.openModalEditarCadastroEventos}
                  />
              }

              </Row>
              <Col>

              {this.state.abreModalCadastroEventos == false && this.state.abreModalEditarEvento == false &&
                      <Row>
                          <Button variant="outline-success" className="btnCriaEventos" style={{ marginLeft: '3%', marginTop: '1%' }} onClick={this.openModalCadastroEventos} >Criar Evento</Button>
                      </Row>

              }
             
              </Col>
               
             
              
           </Container>
    );
  }
}

