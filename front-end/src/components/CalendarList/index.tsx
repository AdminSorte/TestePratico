import { Box, Button, Heading, IconButton, Table, TableCaption, Tbody, Td, Tfoot, Th, Thead, Tr, useDisclosure } from "@chakra-ui/react";
import { useState } from "react";
import { FaRegTrashAlt, FaEdit, FaAngleRight, FaAngleLeft } from 'react-icons/fa';

import { useCalendar } from "../../context/Calendar";

import { ModalItem } from "../ModalItem";

export function CalendarList(): JSX.Element {

    const [changeId, setChangeId] = useState('');

    const { isOpen, onOpen, onClose } = useDisclosure();

    const { calendar } = useCalendar();

    const handleEdit = (id: string) => {
        onOpen();
        setChangeId(id);
    };

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

                        {
                            calendar &&
                            calendar.map(element => (

                                <Tr key={element.id}>

                                    <Td>{element.date}</Td>
                                    <Td>{element.description_short}</Td>
                                    <Td
                                        display="flex"
                                    >

                                        <IconButton
                                            aria-label="Editar"
                                            icon={<FaEdit />}
                                            backgroundColor="transparent"
                                            onClick={() => handleEdit(element.id)}
                                        />

                                        <IconButton
                                            aria-label="Excluir"
                                            icon={<FaRegTrashAlt />}
                                            backgroundColor="transparent"
                                        />
                                    </Td>

                                </Tr>

                            ))
                        }

                        
                    </Tbody>
                
                </Table>

            </Box>

            <ModalItem
                isOpen={isOpen}
                onClose={onClose}
                isEditable={true}
                changeId={changeId}
            />

        </Box>

    )

}