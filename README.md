# Desafio Minha Agenda Minha Vida

## Techs

.NET Core 5.0
SQLite
Insomnia para as requests

## Instruções

Rodar o projeto com:
dotnet run


Em https://localhost:5001/api/agenda lista todas as Agendas criadas;

## POST
URL: https://localhost:5001/api/agenda

{
	"Titulo": "Segunda Agenda",
	"Descricao": "Descrição teste",
	"DataCriacao": "2021-11-02T10:07:33.228Z"
}

## PUT
URL: https://localhost:5001/api/agenda/1

{
	"Id": 1,
	"Titulo": "Segunda TEST",
	"Descricao": "Descrição teste",
	"DataCriacao": "2021-11-02T10:07:33.228Z"
}

## DELETE
URL: https://localhost:5001/api/agenda/1
