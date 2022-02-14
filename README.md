# Desafio Minha Agenda Minha Vida

Projeto de gerenciamento de agenda

## Pré-requisitos 

Os seguintes programas são necessários:

1. [dotnet 3.1](https://dotnet.microsoft.com/en-us/download) 
2. [npm](https://docs.npmjs.com/cli/v7/configuring-npm/install)

## Configurações

### Backend (dotnet)

Configure o arquivo [appsettings.json](CalendarAPI\appsettings.json). 
As seguintes chaves são necessárias:

1. AuthKey: chave para construir o jwt token
2. UserDBConnectString: Connecstring do banco sqlite para salvar dados dos usuários
3. CalendarDBConnectString: Connecstring do banco sqlite para salvar dados de eventos

### Frontend (react)

Configure o arquivo [.env](CalendarAPI\ClientApp\.env). 
As seguintes chaves são necessárias:

1. REACT_APP_URL_BASE: url do backend


## Primeiros passos

Após configurar o projeto, é necessário instalar as bibliotecas do react e inicializar o banco SQL


### Inicialização do banco sql

Rode os seguintes comandos:

```
cd CalendarAPI
```

```
dotnet ef migrations add InitialCreateUser --contenxt UserDB
```

```
dotnet ef migrations add InitialCreateUser --contenxt CalendarDB
```

```
dotnet ef database update --context UserDB
```

```
dotnet ef database update --context CalendarDB
```

Os comandos acima criarão as tabelas e criarão o usuário padrão

```
{
  "email":"root",
  "password":"root",
  "senha":"root"
}
```

### Instalação das bibliotecas

Rode os seguintes comandos:

```
cd CalendarAPI
```

```
cd ClienteApp
```

```
npm install
```

## Run

Rode os seguintes comandos:


```
cd CalendarAPI
```

```
dotnet build
```

```
dotnet run
```

Em outro terminal

```
cd CalendarAPI
```

```
cd ClienteApp
```

```
npm start
```


## Acessando API

O backend possui swagger para acessar a documentação dos endpoints
Acesse /swagger/ui/index.html ou o botão 'Swagger' na tela inicial

## Rodar os testes unitários

Roda os seguintes comandos

```
cd CalendarTest
```

```
dotnet build
```

```
dotnet test
```


# TODO 

1. Melhorar a documentação
2. Mudar modal do calendário para adicionar descrição
3. Criar testes unitários para considerar o banco SQL
4. Mudar banco SQLite para MySQL
5. Tratar casos de excessões