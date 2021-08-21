import { Box, Heading } from "@chakra-ui/react";

export function Header(): JSX.Element {

    return(

        
        <Box
            backgroundColor="primary"
            paddingTop="4"
            paddingBottom="32"
        >

            <Heading
                color="white"
                fontWeight="400"
                textAlign="center"
                textTransform="uppercase"
            >

                Minha Agenda

                <Box
                    fontWeight="600"
                >
                    Minha Vida
                </Box>
                
            </Heading>

        </Box>


    )

}