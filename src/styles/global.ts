import { createGlobalStyle } from 'styled-components'

const GlobalStyle = createGlobalStyle`
  * {
    margin: 0;
    padding: 0;
    box-sizing: border-box;

    ::-webkit-scrollbar {
      width: 0.5rem;
      margin-left: 0.5rem;
    }

    ::-webkit-scrollbar-track {
      background: #c6c6c6;
    }

    ::-webkit-scrollbar-thumb {
      background: #999;
    }

    ::-webkit-scrollbar-thumb:hover {
      background: #555;
    }
  }

  html {
    font-size: 62.5%; /* 1rem = 10px */
  }

  body {
    font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  }

  .App {
    display: flex;
    justify-content: space-between;
    flex-direction: column;
    
    width: 100%;
    min-height: 100vh;
  }
`

export default GlobalStyle
