import { Box, IconButton, Table, TableCaption, Tbody, Td, Thead, Tr, Th, useDisclosure, useToast, Heading } from "@chakra-ui/react";
import { useState } from "react";
import { FaRegTrashAlt, FaEdit, FaAngleRight, FaAngleLeft } from 'react-icons/fa';

import { useCalendar } from "../../context/Calendar";
import { api } from "../../services/api";

import { LoadingCalendarList } from "../LoadingCalendarList";
import { ModalItem } from "../ModalItem";

export function CalendarList(): JSX.Element {

    const [changeId, setChangeId] = useState('');

    const { isOpen, onOpen, onClose } = useDisclosure();

    const toast = useToast();

    const { isLoadingCalendar, calendar, saveCalendar } = useCalendar();

    const handleEdit = (id: string) => {
        onOpen();
        setChangeId(id);
    };

    const handleDelete = (id: string) => {

        const confirmDelete = confirm(`Você realmente deseja excluir o item: ${id}`);

        if (confirmDelete) {

            api.delete(`calendar/${id}`)
                .then(response => {

                    const newCalendar = calendar.filter(element => element.id !== id);

                    saveCalendar([...newCalendar]);

                    toast({
                        status: 'success',
                        title: 'Item deletado com sucesso!',
                        position: 'top-right'
                    });

                }).catch(error => {

                    toast({
                        status: 'error',
                        title: 'Aconteceu um erro na exclusão!',
                        description: error.message,
                        position: 'top-right'
                    });

                });

        }

    }

    if(isLoadingCalendar) {
        return (
            <LoadingCalendarList />
        )
    }

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
                    <TableCaption>

                        {
                            calendar.length > 0 ? (

                                <>Os seus compromissos estão listados acima</>

                            ) : (

                                <>Você não possui nenhum item cadastrado!</>

                            )
                        }
                        
                    </TableCaption>
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
                                            onClick={() => handleDelete(element.id)}
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