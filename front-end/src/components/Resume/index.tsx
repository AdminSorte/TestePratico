import Link from 'next/link';
import { Box, Heading, Table, Tbody, Td, Tr, Th, Flex, IconButton } from "@chakra-ui/react";

import { FaAngleDoubleLeft } from 'react-icons/fa';

interface IInfoProps {
    info: {
        id: string;
        date: string;
        description: string;
        description_short: string;
    }
}

export function Resume({ info }: IInfoProps): JSX.Element {

    return (


        <Box
            paddingTop="4"
            paddingBottom="32"
        >
            <Flex
                alignItems="center"
                marginBottom="8"
            >
                
                <Link
                    href="/"
                    passHref
                >

                    <IconButton
                        marginRight="8"
                        aria-label="Visualizar"
                        as="a"
                        href="/"
                        icon={<FaAngleDoubleLeft />}
                        backgroundColor="primary"
                        color="white"
                    />

                </Link>

                <Heading
                    color="primary"
                    fontWeight="600"
                    fontSize="lg"
                >
                    Informações completas de:
                </Heading>

            </Flex>

            <Table
                variant="simple"
                size="sm"
                colorScheme="blackAlpha"
            >
                <Tbody>
                    <Tr>

                        <Th>Id:</Th>
                        <Td>{info.id}</Td>
                    </Tr>
                    <Tr>

                        <Th>Data:</Th>
                        <Td>{info.date}</Td>
                    </Tr>
                    <Tr>

                        <Th>Descrição curta:</Th>
                        <Td>{info.description_short}</Td>
                    </Tr>
                    <Tr>

                        <Th>Descrição:</Th>
                        <Td>{info.description}</Td>
                    </Tr>
                </Tbody>
            </Table>

        </Box>


    )

}