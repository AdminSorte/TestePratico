import { ReactNode } from "react";
import { Box } from "@chakra-ui/react";

interface IContentProps {
    children: ReactNode;
}

export function Content({ children }: IContentProps): JSX.Element {

    return(

        
        <Box
            width="100%"            
            marginTop="-24"
            marginX="auto"
            paddingX="4"
        >

            <Box
                maxWidth={["none", "none", "none", "1200px"]}
                marginX="auto"
                backgroundColor="background"
                paddingX={["4", "4", "4", "24"]}
                paddingY={["8", "8", "8", "24"]}
                boxShadow="base"
                borderRadius="base"
                minHeight="100vh"
            >

                { children }

            </Box>


        </Box>


    )

}