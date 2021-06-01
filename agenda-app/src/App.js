import React from 'react';
import {  BrowserRouter } from 'react-router-dom'
import Routes from './Routes'

import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';


function App() {
  return (
    <BrowserRouter>
         <div className="App">
           <Routes />
        </div>
    </BrowserRouter>
       

  );
}

export default App;
