import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Swagger } from './components/Swagger'
import { Agenda } from './components/Calendar'
import './custom.css'


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/swagger' component={Swagger} />
            <Route exact path='/' component={Agenda} />
      </Layout>
    );
  }
}
