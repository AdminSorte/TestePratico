import React from 'react'
import ReactDOM from 'react-dom'
import App from './Pages/Home/App'

// providers
import { ThemeProvider } from 'styled-components'
import { CommitmentProvider } from './context/Commitments'

// styles
import GlobalStyle from './styles/global'
import { theme } from './styles/themes'

ReactDOM.render(
  <React.StrictMode>
    <CommitmentProvider>
      <ThemeProvider theme={theme}>
        <App />
      </ThemeProvider>
    </CommitmentProvider>
    <GlobalStyle />
  </React.StrictMode>,
  document.getElementById('root')
)
