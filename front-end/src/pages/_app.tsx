import type { AppProps } from 'next/app';
import { ChakraProvider } from '@chakra-ui/react';

import { CalendarProvider } from "./../context/Calendar";
import { theme } from "./../styles/theme";

function MyApp({ Component, pageProps }: AppProps) {

    return (

        <ChakraProvider theme={theme}>

            <CalendarProvider>

                <Component {...pageProps} />

            </CalendarProvider>


        </ChakraProvider>

    )

}

export default MyApp
