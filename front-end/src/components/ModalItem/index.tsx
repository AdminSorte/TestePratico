import { Button, Modal, ModalBody, ModalCloseButton, ModalContent, ModalFooter, ModalHeader, ModalOverlay } from "@chakra-ui/react";
import { Form } from "../Form";

interface IModalItemProps {
    isOpen: boolean;
    onClose: () => void;
    isEditable?: boolean;
}

export function ModalItem({ isOpen, onClose, isEditable = false }: IModalItemProps): JSX.Element {

    return (

        <Modal isOpen={isOpen} onClose={onClose}>

            <ModalOverlay />

            <ModalContent>

                <ModalHeader>
                    {
                        isEditable ? `Alterar item:` : "Adicionar novo item"
                    }
                </ModalHeader>

                <ModalCloseButton />

                <ModalBody>

                    <Form />

                </ModalBody>

                <ModalFooter>

                    <Button
                        backgroundColor="primary"
                        _hover={{
                            backgroundColor: "primary"
                        }}
                        color="white"
                    >
                        Salvar
                    </Button>

                </ModalFooter>
            </ModalContent>
        </Modal>

    )

}