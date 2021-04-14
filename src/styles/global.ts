import { createGlobalStyle } from 'styled-components';

export const GlobalStyles = createGlobalStyle`

:root{
    --yellow: #FABB18;
    --dark: #000000;

    --red: #E52E4D;
    --green: #33CC95;

    --dark-text: #000000;
    --light-text: #969CB3;

    --background: #F0F2F5;  
    --white: #FFFFFF;
}

*{
    margin: 0px;
    padding: 0px;
    box-sizing: border-box;
}

html{ 
    @media (max-width: 1080px) {
        font-size: 93.75%; // 15px (Desktop)
    }

    @media (max-width: 720px) {
        font-size: 87.5%; // 14px
    }
}

body, button, input, textarea{
    font-family: 'Poppins', sans-serif;
    font-weight: 400;
}

h1, h2, h3, h4, h5, h6, strong {
    font-weight: 600;
}

body {
    background: var(--background)
}

button { 
    cursor: pointer;
}

[disabled] {
    opacity: 0.6;
    cursor: not-allowed;
}

`;
