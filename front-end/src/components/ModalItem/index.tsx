import { Modal, ModalBody, ModalCloseButton, ModalContent, ModalHeader, ModalOverlay } from "@chakra-ui/react";

import { Form } from "../Form";
interface IModalItemProps {
    isOpen: boolean;
    onClose: () => void;
    isEditable?: boolean;
    changeId?: string | null;
}

export function ModalItem({ isOpen, onClose, isEditable = false, changeId = null }: IModalItemProps) {    

    if(!isOpen) {

        return (null);

    }

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

                    <Form 
                        isEditable={isEditable}
                        changeId={changeId}
                        onClose={onClose}
                    />

                </ModalBody>

            </ModalContent>
        </Modal>

    )

}