import React from 'react'
import ReactDOM from 'react-dom'
import App from './Pages/Home/App'
import GlobalStyle from './styles/global'

ReactDOM.render(
  <React.StrictMode>
    <App />
    <GlobalStyle />
  </React.StrictMode>,
  document.getElementById('root')
)
