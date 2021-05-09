import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <div>
            <div id="addForm">
                <h3>Adicionar</h3>
                <form>
                    <input type="text" id="add-name" placeholder="Nome"></input>
                    <input type="text" id="add-description" placeholder="Descrição"></input>
                    <input type="submit" value="Adicionar"></input>
                </form>
            </div>
            <div id="searchForm">
                <h3>Pesquisar</h3>
                <form action="javascript:void(0);" method="GET" onsubmit="searchItems()">
                    <input type="text" id="search-Item" placeholder="Insira o nome da agenda"></input>
                    <input type="submit" value="Pesquisar"></input>
                    <button onclick="getItems()">Limpar</button>
                </form>
            </div>
            <div id="editForm">
                <h3>Editar agenda</h3>
                <form action="javascript:void(0);" onsubmit="updateItem()">
                    <input type="hidden" id="edit-id"></input>
                    <input type="checkbox" id="edit-isComplete"></input>
                    <input type="text" id="edit-name"></input>
                    <input type="text" id="edit-description"></input>
                    <input type="submit" value="Save"></input>
                    <a onclick="displayDivForm('editForm')" aria-label="Close">&#10006;</a>
                </form>
            </div>
            <div>
                <h3>Agendas</h3>
                <p id="counter"></p>
                <table>
                    <tbody id="agendas"></tbody>
                </table>
            </div>
            <button onclick="displayDivForm('addForm')">Adicionar</button>
            <button onclick="displayDivForm('searchForm')">Pesquisar</button>
            <script src="js/agenda.js" asp-append-version="true"></script>
            <script type="text/javascript">
                getItems();
                displayDivForm('searchForm');
                displayDivForm('addForm');
              </script>
        </div>
    );
  }
}
