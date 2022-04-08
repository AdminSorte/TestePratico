# Desafio Minha Agenda Minha Vida

## Instruções

- Faça um fork desse repositório
- Trabalhe exclusivamente no seu fork
- Os commits de seu fork precisa ter mensagens claras e objetivas, a cada commit explique a mudança e evolução.
- Ao finalizar abra um PR(Pull Request) para esse repositório

## Requerimentos

- O Website deverá ser desenvolvido em ReactJS ou VueJS ou Razor(C#).
- Faça uso de boas práticas de desenvolvimento
- Use conceitos de componentização e reaproveitamento de código
- A Agenda deverá ter:
  - Titulo do desafio: Minha Agenda Minha Vida
  - Uma boa apresentação(Abuse das animações e efeitos)
  - Tela inicial deverá ter uma listagem com ID da agenda, Descrição curta e uma lixeirinha para deletar a agenda, além de uma caixa de filtro para pesquisar pela descrição curta, um botão flutuante com um icone + para adicionar uma nova agenda
  - Tela/Modal/Popup de nova/edição agenda deverá ter, descrição curta(titulo), descrição da agenda e data da agenda, necessário um botão para salvar. OBS essa tela deverá ser tanto edição quanto nova agenda, ao finalizar
  - Tela/Modal/Popup de detalhe para exibir o as informações da agenda para somente leitura
  - Qualquer mecanismo de login(JWT, Basic, localstorage)

## Detalhes
- Aplicação dotnet core 6 MVC utilizando razor
- Utilização do Identity para autenticação e autorização
- Ultilização do EntityFramework como ORM e SQL Server.
- Bootstrap

## Como Rodar
- Baixe o projeto e configure a connection string para o seu banco de dados.
- Utilize as migrations para gerar o banco de dados da aplicação.
- Execute "update-database User -Context ApplicationDbContext" para gerar as tabelas de autorização e autenticação
- Execute "update-database Agenda -Context AgendaDbContext" para gerar a tabela Agenda
- Com o banco de dados configurado, basta executar a aplicação.

