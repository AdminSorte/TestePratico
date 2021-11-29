import React, {
    Component, Fragment} from 'react';
import { Modal ,Button,Form } from 'react-bootstrap';




export default class NovoEvento extends Component {
    static displayName = NovoEvento.name;

    constructor(props) {
        super(props);
        this.state = {
            descricao: '',
            hora: '',
            data: '',
        }

        this.handleChange = this.handleChange.bind(this);
       
        this.onSubmit = this.onSubmit.bind(this);
    }




    handleChange = event => {
        this.setState({ [event.target.name]: event.target.value });
    };

   

     onSubmit = e => {
            e.preventDefault();

         const { descricao, hora, data } = this.state;
         //this props do insert na Agenda
         const { insertEventoAgenda } = this.props;
            let continuar = true;
            let mensagem = "";

         if (descricao === "" || hora === "" || data === "") {
                alert("Por favor preencha todos os campos para cadastro do evento na agenda");
                continuar = false;
            }
            if (continuar) {
                const dados = {
                    
                    Descricao: descricao,
                    Periodo: hora,
                    Data: data,
                    
                }

                insertEventoAgenda(dados);
                
            } else {
                alert(mensagem);
            }
        };




   

    render() {

        return (
            

            <Fragment>
               
                
                <Modal.Dialog size={'xl'}>
                    <Modal.Header>
                        <Modal.Title>Cadastro Evento da Agenda</Modal.Title>
                    </Modal.Header>

                    <Modal.Body>
                        <Form>
                            <Form.Group className="mb-3" controlId="formDescricao">
                                <Form.Label>Descrição</Form.Label>
                                <Form.Control type="text" name={"descricao"} placeholder="Descrição do Evento" onChange={(event) => this.handleChange(event)  } />
                            </Form.Group>

                            <Form.Group className="mb-3" controlId="formPeriodo">
                                <Form.Label>Horário</Form.Label>
                                <Form.Control type="text" name={"hora"} placeholder="HH:MM" onChange={(event) => this.handleChange(event) } />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="formData">
                                <Form.Label>Data</Form.Label>
                                <Form.Control type="date" name={"data"} placeholder="Data" onChange={(event) => this.handleChange(event) }/>
                            </Form.Group>

                            <Button variant="primary" type="submit" onClick={(event) => this.onSubmit(event)}  >
                                Salvar
                             </Button>
                        </Form>

                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant="secondary"  onClick={() => this.props.closeModalCadastroEventos() }>Close</Button>
                    </Modal.Footer>
                    </Modal.Dialog>



            </Fragment>

        )


    }
}

