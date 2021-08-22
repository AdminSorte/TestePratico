import { Box, Spinner, Heading } from "@chakra-ui/react";

export function LoadingCalendarList(): JSX.Element {
    return (
        <Box
            marginTop="12"
            textAlign="center"
        >
            <Spinner
                thickness="4px"
                speed="0.65s"
                emptyColor="gray.200"
                color="primary"
                size="xl"
            />

            <Heading
                fontSize="md"
                color="primary"
            >
                Carregando ...
            </Heading>

        </Box>
    )
}