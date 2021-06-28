## API

Para executar a api faça:
  - Execute no SQL Server os scripts que estão na pasta `SqlScripts`
  - Ajuste a connection string no arquivo `Todo.Api/appsettings.json`
    - Exemplo: `Data Source=.;Initial Catalog=DATABASE_NAME;User Id=USER;Password=PASSWORD`

Para acessar a documentação da api acesse o endereço (verifique a porta):
  - `http://localhost:5000/swagger/index.html`
    
Recursos utilizados:
  -.Net Core 5
  - Autenticação JWT
  - Dependency Injection
  - ORM Dapper
  - Procedures
  - SQL Server
  - Swagger
    

## WEB

Antes de executar o projeto web, verifique se no arquivo 'todo_web/src/services/api.ts' na linha '5', se a url da api está correta.

Execute o comando `npm i` para instalar os pacotes.

Recursos utilizados:
  - ReactJS
  - Typescript
  - Redux
  - Redux Saga
  - React Hooks
  - Axios
  - Material-UI
