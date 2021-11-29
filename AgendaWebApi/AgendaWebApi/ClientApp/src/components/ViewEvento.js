import React, {Component, Fragment} from 'react';
import { Modal ,Button,Form } from 'react-bootstrap';




export default class ViewEvento extends Component {
    static displayName = ViewEvento.name;

    constructor(props) {
        super(props);

       
    }

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
                                    name={"idEvento"}
                                    value={this.props.idEvento}
                                    placeholder=""
                                     />
                            </Form.Group>

                            <Form.Group className="mb-3" controlId="formDescricao">
                                <Form.Label>Descrição</Form.Label>
                                <Form.Control type="text" 
                                    readOnly
                                    disabled
                                    name={"descricaoEvento"}
                                    value={this.props.descricaoEvento}
                                    placeholder=""
                                    />
                            </Form.Group>

                            <Form.Group className="mb-3" controlId="formPeriodo">
                                <Form.Label>Horário</Form.Label>
                                <Form.Control type="text"
                                    readOnly
                                    disabled
                                    name={"periodoEvento"}
                                    value={this.props.periodoEvento}
                                    placeholder="HH:MM"
                                     />
                            </Form.Group>

                            <Form.Group className="mb-3" controlId="formData">
                                <Form.Label>Data</Form.Label>
                                <Form.Control type="text" name={"dataEvento"}
                                    readOnly
                                    disabled 
                                    value={this.props.dataEvento}
                                    placeholder=""
                                     />
                            </Form.Group>

                    
                        </Form>

                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant="secondary" onClick={() => this.props.closeModalVizualizaEvento() }>Close</Button>
                    </Modal.Footer>
                    </Modal.Dialog>



            </Fragment>

        )


    }
}

