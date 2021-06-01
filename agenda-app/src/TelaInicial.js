import React from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import Footer from './components/Template/Footer'
import NavBar from './components/Template/NavBar'
import Content from './Content'

import Tabela from './components/Template/Tabela'

export default function Pricing() {

  return (
    <React.Fragment>
      <CssBaseline />
      <NavBar/>
      <Content />
      <Tabela /> 
       <Footer />
    </React.Fragment>
  );
}