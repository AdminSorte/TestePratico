import React, { Component } from 'react';
import Agenda from './Agenda';

export class Home extends Component {
  static displayName = Home.name;

    constructor(props) {
        super(props);

    }




    render() {
        return (
            <div>
                <h1>Minha Agenda Minha Vida</h1>
                <Agenda/>
            </div>
        );
    }
} 