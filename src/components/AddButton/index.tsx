import { Fragment } from "react";
import { IconButton, useDisclosure } from "@chakra-ui/react";

import { RiMenuAddFill } from 'react-icons/ri';
import { ModalItem } from "../ModalItem";

export function AddButton(): JSX.Element {

    const { isOpen, onOpen, onClose } = useDisclosure();

    return(

        
        <Fragment>

            <IconButton
                width="16"
                height="16"
                aria-label="Adicionar Item"
                position="fixed"
                bottom="8"
                right="8"
                backgroundColor="primary"
                _hover={{
                    backgroundColor: "primary"
                }}
                icon={ <RiMenuAddFill /> }
                color="white"
                borderRadius="full"
                onClick={ onOpen }
            />

            <ModalItem 
                isOpen={isOpen}
                onClose={onClose}
            />

        </Fragment>


    )

}