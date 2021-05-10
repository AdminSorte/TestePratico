<!-- Sobre o Projeto -->
## Sobre o Projeto 

Sistema Web que permiter o cadastro,edição,consulta e exclusão de agendas e também conta com um mecanismo de Login e cadastro de novos usuários.

<!-- Começando -->
## Começando

### Pré-requisito

Software Que necessita ter na maquina para roda o Projeto localmente.
* Visual Studio ou Visual Code
* SQL Serve


### Configuração Do Projeto MinhaAgenda.API
1.Troque as configurações  de Conexão do banco de dados Pelo o seu em src/MinhaAgenda.API/appsettings
* Exemplo de Conexão Com autenticação do Windows
   ```sh
  "ConnectionStrings": {
    "DefaultConnection": "Server=SuaInstancia;Database=MinhaAgendaMinhaVida;
    Trusted_Connection=True;MultipleActiveResultSets=true;pooling=true"
  }
   ```
* Exemplo de Conexão Com Autenticação de usuário
 
    ```sh
  "ConnectionStrings": {
    "DefaultConnection": "Server=SuaInstancia;Database=MinhaAgendaMinhaVida;UserId=Usuario;
    Password=Senha;MultipleActiveResultSets=true;pooling=true"
  }
   ```
2.Aplicado as Migrations Do Entity Framework 

3.Instale a Ferramente dotnet tool pelo o Shell 
```sh
 install --global dotnet-ef
```
4.Executer o Seguinte comado pelo o Shell ou outra ferramete de comado,dentro da Pasta Raiz do Projeto.

* Criação do Banco de dados e das tabela.
```sh
dotnet ef Database Update -p .\src\MinhaAgenda.Data\MinhaAgenda.Data.csproj -s .\src\MinhaAgenda.API\MinhaAgenda.API.csproj -c MinhaAgendaContext
```
* Criação das Tabelas do Identity Para Autoriação e Autenticação.
 ```sh
 dotnet ef Database Update -p  .\src\MinhaAgenda.API\MinhaAgenda.API.csproj -c IdentityContext
```
5.Caso não queira aplicar as Migrations.Utilizer os Script de criação de tabelas que fica em /sql.
* Crie um Banco de dados no SQL para Roda os Scripts

<!-- Uso -->
## Uso

1.Caso não queira Cadastra um usuário.Já vem um Default.
```sh
Email:SorteOnline@gmail.com
Senha:Sorte123
```


