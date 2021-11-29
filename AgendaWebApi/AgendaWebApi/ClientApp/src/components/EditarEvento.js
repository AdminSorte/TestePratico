import React, {
    Component, Fragment} from 'react';
import { Modal ,Button,Form } from 'react-bootstrap';




export default class EditarEvento extends Component {
    static displayName = EditarEvento.name;

    constructor(props) {
        super(props);
        this.state = {
            descricaoEvento:"",
            periodoEvento: "",
            dataEvento: "",
            
            
        }

        this.handleChange = this.handleChange.bind(this);
       
        this.onSubmit = this.onSubmit.bind(this);
    }

    componentDidMount() {

        this.setState({
            descricaoEvento: this.props.descricaoEvento,
            periodoEvento: this.props.periodoEvento,
            dataEvento: this.props.dataEvento
        });

    }
    


    handleChange = event => {
        this.setState({ [event.target.name]: event.target.value });
    };

   

    onSubmit = e => {
        e.preventDefault();

        const { descricaoEvento, periodoEvento, dataEvento } = this.state
        //this props do insert na Agenda
        const id = this.props.idEvento
        const { atualizaEventoAgenda } = this.props

        let continuar = true;
        let mensagem = "";

        if (descricaoEvento === "" || periodoEvento === "" || dataEvento === "") {
            alert("Por favor preencha todos os campos para cadastro do evento na agenda");
            continuar = false;
        }

            if (continuar) {
                const dados = {
                    Descricao: descricaoEvento,
                    Periodo: periodoEvento,
                    Data: dataEvento,
                    
                }

                console.log("atualiza registros")
                console.log(dados)
                console.log(id)
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
                        <Modal.Title>Edi��o de Evento da Agenda</Modal.Title>
                    </Modal.Header>

                    <Modal.Body>
                        <Form>
                            <Form.Group className="mb-3" controlId="formDescricao">
                                <Form.Label>Id</Form.Label>
                                <Form.Control type="text"
                                    readOnly 
                                    disabled 
                                    name={"idEvento"}
                                    value={this.props.idEvento}
                                    placeholder=""
                                     />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="formDescricao">
                                <Form.Label>Descri��o</Form.Label>
                                <Form.Control type="text" 
                                    name={"descricaoEvento"}
                                    value={this.state.descricaoEvento}
                                    placeholder=""
                                    onChange={(event) => this.handleChange(event)} />
                            </Form.Group>

                            <Form.Group className="mb-3" controlId="formPeriodo">
                                <Form.Label>Hor�rio</Form.Label>
                                <Form.Control type="text"
                                    name={"periodoEvento"}
                                    value={this.state.periodoEvento}
                                    placeholder="HH:MM"
                                    onChange={(event) => this.handleChange(event)} />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="formData">
                                <Form.Label>Data</Form.Label>
                                <Form.Control type="text" name={"dataEvento"}
                                    readOnly
                                    disabled 
                                    value={this.state.dataEvento}
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

