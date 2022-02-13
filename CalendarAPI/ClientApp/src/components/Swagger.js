import React from 'react';

const API_URL = process.env.REACT_APP_URL_BASE

export class Swagger extends React.Component {
    componentDidMount() {
        window.location.href = API_URL + "/index.html"; }
    render() {
        return (
            <div>
                <h2>Redirect</h2>
            </div>
        )
    }
}

