import { Button, Box, FormControl, FormLabel, Input, Textarea, VStack, useToast } from "@chakra-ui/react";
import { useForm } from "react-hook-form";

import { useCalendar } from "../../context/Calendar";
import { api } from "../../services/api";
interface IOnSubmitData {
    date: string;
    description: string;
    description_short: string;
}
interface IFormProps {
    isEditable: boolean;
    changeId?: string | null;
    onClose: () => void;
};

export function Form({ isEditable, changeId, onClose }: IFormProps): JSX.Element {

    const { calendar, saveCalendar } = useCalendar();

    const { register, handleSubmit, reset } = useForm();

    const toast = useToast();

    console.log({
        isEditable, changeId
    })

    if (isEditable && changeId) {

        const newCalendar = [...calendar];

        const editable = newCalendar.find(element => element.id === changeId);

        console.log('editable', editable);

        if(editable) {
            reset({
                date: editable?.date,
                description: editable?.description,
                description_short: editable?.description_short
            })
        }

    }

    const onSubmit = (data: IOnSubmitData) => {

        onClose();

        if(!isEditable) {

            api.post('/calendar', data)
                .then(response => {

                    saveCalendar([
                        ...calendar,
                        response.data
                    ])

                    toast({
                        status: 'success',
                        title: 'Item cadastrado com sucesso!',
                        position: 'top-right'
                    })

                }).catch(error => {

                    toast({
                        status: 'error',
                        title: 'Aconteceu um erro no cadastro!',
                        description: error.message,
                        position: 'top-right'
                    });

                });

        } else {

            api.put(`calendar/${changeId}`, data)
                .then(response => {

                    const newList = [...calendar].map(element => {

                        if(element.id === changeId) {
                            const updateItem = {
                                ...element,
                                date: response.data.date,
                                description: response.data.description,
                                description_short: response.data.description_short
                            }

                            return updateItem;
                        }

                        return element;

                    });

                    console.log([...newList]);

                    saveCalendar(newList);

                    toast({
                        status: 'success',
                        title: 'Item atualizado com sucesso!',
                        position: 'top-right'
                    });

                }).catch(error => {

                    toast({
                        status: 'error',
                        title: 'Aconteceu um erro na alteração!',
                        description: error.message,
                        position: 'top-right'
                    });

                });

        }
        
    }

    return (

        <Box
            as="form"
            onSubmit={handleSubmit(onSubmit)}
        >

            <VStack>

                <FormControl id="date">
                    <FormLabel>Data:</FormLabel>
                    <Input
                        placeholder="Escolha uma data"
                        type="date"
                        {...register('date', { required: true })}
                    />
                </FormControl>

                <FormControl id="description_short">
                    <FormLabel>Descrição Curta (resumo):</FormLabel>
                    <Input
                        placeholder="Digite uma descrição curta"
                        type="text"
                        {...register('description_short', { required: true })} />
                </FormControl>

                <FormControl id="description">
                    <FormLabel>Descrição:</FormLabel>
                    <Textarea
                        placeholder="Digite uma descrição"
                        {...register('description', { required: true })}
                    />
                </FormControl>

                <Button
                    type="submit"
                    backgroundColor="primary"
                    _hover={{
                        backgroundColor: "primary"
                    }}
                    color="white"
                >
                    Salvar
                </Button>

            </VStack>

        </Box>


    )

}