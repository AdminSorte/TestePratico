
import { Flex, FormControl, FormLabel, IconButton, Input } from "@chakra-ui/react";

import { FaSearch } from 'react-icons/fa'

export function Search(): JSX.Element {

    return(

        
        <Flex
            as="form"
        >

            <FormControl id="search">
                <Input 
                    placeholder="Digite algo para buscar"
                    type="search" />
            </FormControl>

            <IconButton
                aria-label="Buscar item"
                icon={ <FaSearch /> }
                backgroundColor="primary"
                color="white"
                _hover={{
                    backgroundColor: "primary"
                }}
            />


        </Flex>


    )

}