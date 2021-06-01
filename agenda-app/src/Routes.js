import React from 'react'
import { Switch, Route, Redirect } from 'react-router'


import TelaInicial from './TelaInicial'
import AdicionarEditar from './AdicionarEditar'
import Edit from './Edit'

export default props => 
    <Switch>
        <Route exact path='/' component={TelaInicial} />
        <Route  path='/AddorEdit' component={AdicionarEditar} />
        <Route  path='/Edit' component={Edit} />
        <Redirect from='*' to='/' /> 
    </Switch>