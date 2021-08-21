import { Box, Button, Heading, IconButton, Table, TableCaption, Tbody, Td, Tfoot, Th, Thead, Tr, useDisclosure } from "@chakra-ui/react";
import { FaRegTrashAlt, FaEdit, FaAngleRight, FaAngleLeft } from 'react-icons/fa';

import { ModalItem } from "../ModalItem";

export function CalendarList(): JSX.Element {

    const { isOpen, onOpen, onClose } = useDisclosure();

    return (

        <Box
            marginTop={["4", "4", "4", "8"]}
        >

            <Box
                overflowX="auto"
            >

                <Heading
                    as="h4"
                    fontSize="md"
                    marginBottom={["4", "4", "4", "8"]}
                    color="text"
                >
                    Veja seus agendamentos
                </Heading>

                <Table 
                    variant="simple" 
                    size="sm"
                    colorScheme="blackAlpha"
                >
                    <TableCaption>Os seus compromissos estão listados acima</TableCaption>
                    <Thead>
                        <Tr>
                            <Th>Data</Th>
                            <Th>Descrição</Th>
                            <Th>Açoões</Th>
                        </Tr>
                    </Thead>
                    <Tbody>
                        <Tr>
                            <Td>25/02/1996</Td>
                            <Td>Pequena descrição</Td>
                            <Td
                                display="flex"
                            >
                                <IconButton
                                    aria-label="Editar"
                                    icon={<FaEdit />}
                                    onClick={onOpen}
                                    backgroundColor="transparent"
                                />
                                <IconButton
                                    aria-label="Excluir"
                                    icon={<FaRegTrashAlt />}
                                    backgroundColor="transparent"
                                />
                            </Td>
                        </Tr>
                    </Tbody>
                    <Tfoot>
                        <Tr>
                            <Td 
                                colSpan="3"
                                textAlign="right"
                            >
                                <IconButton
                                    color="white"
                                    backgroundColor="primary"
                                    _hover={{
                                        backgroundColor: "primary"
                                    }}
                                    aria-label="Voltar"
                                    icon={<FaAngleLeft />}
                                    marginRight="4"
                                />
                                <IconButton
                                    color="white"
                                    backgroundColor="primary"
                                    _hover={{
                                        backgroundColor: "primary"
                                    }}
                                    aria-label="Avançar"
                                    icon={<FaAngleRight />}
                                />
                            </Td>
                        </Tr>
                    </Tfoot>
                </Table>

            </Box>

            <ModalItem
                isOpen={isOpen}
                onClose={onClose}
                isEditable={true}
            />

        </Box>

    )

}