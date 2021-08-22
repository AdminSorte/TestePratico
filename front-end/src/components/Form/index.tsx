import { Button, Box, FormControl, FormLabel, Input, Textarea, VStack, useToast, FormErrorMessage } from "@chakra-ui/react";
import { useEffect } from "react";
import { SubmitHandler, useForm } from "react-hook-form";

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

interface IResponse extends IOnSubmitData {
    id: string;
}

interface IResponseData {
    data: IResponse;
}

export function Form({ isEditable, changeId, onClose }: IFormProps): JSX.Element {

    const { calendar, saveCalendar } = useCalendar();

    const { register, handleSubmit, reset, formState: { errors, isSubmitting } } = useForm();

    const toast = useToast();

    useEffect(() => {

        if (isEditable && changeId) {

            const newCalendar = [...calendar];

            const editable = newCalendar.find(element => element.id === changeId);

            if (editable) {
                reset({
                    date: editable.date,
                    description: editable.description,
                    description_short: editable.description_short
                })
            }

        }

    }, [reset])

    const onSubmit = async (data: IOnSubmitData) => {

        let response: IResponseData;

        try {
            
            if(!isEditable) {

                response = await api.post('/calendar', data);
            
                saveCalendar([
                    ...calendar,
                    response.data
                ]);

                toast({
                    status: 'success',
                    title: 'Item cadastrado com sucesso!',
                    position: 'top-right'
                })

    
            } else {
    
                response = await api.put(`/calendar/${changeId}`, data);

                const newList = [...calendar].map(element => {

                    if (element.id === changeId) {
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
    
                saveCalendar(newList);
    
                toast({
                    status: 'success',
                    title: 'Item atualizado com sucesso!',
                    position: 'top-right'
                });
    
            }

        } catch (error) {

            toast({
                status: 'error',
                title: 'Aconteceu um erro!',
                description: error.message,
                position: 'top-right'
            });
            
        }

        onClose();

    };

    return (

        <Box
            as="form"
            onSubmit={handleSubmit(onSubmit)}
        >

            <VStack>

                <FormControl
                    id="date"
                    isInvalid={!!errors.date}
                >
                    <FormLabel>Data:</FormLabel>
                    <Input
                        placeholder="Escolha uma data"
                        type="date"
                        {...register('date', { required: "*Campo obrigátorio" })}
                    />
                    {
                        errors.date && (
                            <FormErrorMessage>
                                {errors.date.message}
                            </FormErrorMessage>
                        )
                    }

                </FormControl>

                <FormControl
                    id="description_short"
                    isInvalid={!!errors.description_short}
                >
                    <FormLabel>Descrição Curta (resumo):</FormLabel>
                    <Input
                        placeholder="Digite uma descrição curta"
                        type="text"
                        {...register('description_short', { required: "*Campo obrigátorio" })} />
                    {
                        errors.description_short && (
                            <FormErrorMessage>
                                {errors.description_short.message}
                            </FormErrorMessage>
                        )
                    }

                </FormControl>

                <FormControl
                    id="description"
                    isInvalid={!!errors.description}
                >
                    <FormLabel>Descrição:</FormLabel>
                    <Textarea
                        placeholder="Digite uma descrição"
                        {...register('description', { required: "*Campo obrigátorio" })}
                    />

                    {
                        errors.description && (
                            <FormErrorMessage>
                                {errors.description.message}
                            </FormErrorMessage>
                        )
                    }

                </FormControl>

                <Button
                    type="submit"
                    isLoading={isSubmitting}
                    loadingText="Salvando"
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