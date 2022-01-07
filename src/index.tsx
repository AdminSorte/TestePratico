import React from 'react'
import ReactDOM from 'react-dom'
import App from './Pages/Home/App'
import GlobalStyle from './styles/global'

import { CommitmentProvider } from './context/Commitments'

ReactDOM.render(
  <React.StrictMode>
    <CommitmentProvider>
      <App />
    </CommitmentProvider>
    <GlobalStyle />
  </React.StrictMode>,
  document.getElementById('root')
)
