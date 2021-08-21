import { Box, FormControl, FormLabel, Input, Textarea, VStack } from "@chakra-ui/react";

export function Form() : JSX.Element {

    return (

        <Box 
            as="form"
        >

            <VStack>

                <FormControl id="date">
                    <FormLabel>Data:</FormLabel>
                    <Input
                        placeholder="Escolha uma data"
                        type="date" />
                </FormControl>  

                <FormControl id="description_short">
                    <FormLabel>Descrição Curta (resumo):</FormLabel>
                    <Input
                        placeholder="Digite uma descrição curta"
                        type="text" />
                </FormControl>

                <FormControl id="description">
                    <FormLabel>Descrição:</FormLabel>
                    <Textarea 
                        placeholder="Digite uma descrição"
                    />
                </FormControl>

            </VStack>

        </Box>


    )

}