import React, {
    Component, Fragment} from 'react';
import { Modal ,Button,Form } from 'react-bootstrap';




export default class EditarEvento extends Component {
    static displayName = EditarEvento.name;

    constructor(props) {
        super(props);
        this.state = {
            descricao: '',
            hora: '',
            data: '',
            id: '',
            descricaoOriginal: '',
            horaOriginal: '',
            dataOriginal: '',
        }

        this.handleChange = this.handleChange.bind(this);
       
        this.onSubmit = this.onSubmit.bind(this);
    }


    


    handleChange = event => {
        this.setState({ [event.target.name]: event.target.value });
    };

   

     onSubmit = e => {
            e.preventDefault();

         const { descricao, hora, data,  } = this.state
         //this props do insert na Agenda
         const id = this.props.idEvento
         const { atualizaEventoAgenda } = this.props
            let continuar = true;
            let mensagem = "";
         
         if (descricao === "" || hora === "" || data === "") {

             

             this.setState({
                 descricao: this.state.descricaoOriginal,
                 hora: this.state.horaOriginal,
                 data: this.state.dataOriginal
                 
             });
             


         } 

            if (continuar) {
                const dados = {
                    Descricao: descricao,
                    Periodo: hora,
                    Data: data,
                    
                }

                console.log("atualiza registros")
                console.log(dados)
                atualizaEventoAgenda(id,dados);
                
            } else {
                alert(mensagem);
            }
        };




   

    render() {

        return (
            

            <Fragment>
               
                
                <Modal.Dialog size={'xl'}>
                    <Modal.Header>
                        <Modal.Title>Edição de Evento da Agenda</Modal.Title>
                    </Modal.Header>

                    <Modal.Body>
                        <Form>
                            <Form.Group className="mb-3" controlId="formDescricao">
                                <Form.Label>Id</Form.Label>
                                <Form.Control type="text"
                                    readOnly 
                                    disabled 
                                    name={"id"}
                                    value={this.props.idEvento}
                                    placeholder=""
                                     />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="formDescricao">
                                <Form.Label>Descrição</Form.Label>
                                <Form.Control type="text" 
                                    name={"descricao"}
                                    value={this.props.descricaoEvento}
                                    placeholder=""
                                    onChange={(event) => this.handleChange(event)} />
                            </Form.Group>

                            <Form.Group className="mb-3" controlId="formPeriodo">
                                <Form.Label>Horário</Form.Label>
                                <Form.Control type="text"
                                    name={"hora"}
                                    value={this.props.periodoEvento}
                                    placeholder="HH:MM"
                                    onChange={(event) => this.handleChange(event)} />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="formData">
                                <Form.Label>Data</Form.Label>
                                <Form.Control type="date" name={"data"}
                                    
                                    defaultValue={this.props.dataEvento}
                                    placeholder=""
                                    onChange={(event) => this.handleChange(event)} />
                            </Form.Group>

                            <Button variant="primary" type="submit" onClick={(event) => this.onSubmit(event)}  >
                                Salvar
                             </Button>
                        </Form>

                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant="secondary" onClick={() => this.props.closeModalEdicaoEvento() }>Close</Button>
                    </Modal.Footer>
                    </Modal.Dialog>



            </Fragment>

        )


    }
}

