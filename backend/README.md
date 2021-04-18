# Rotas da API

#### [POST] /session
Verifica a existência do usuário, cria uma sessão no servidor e retorna o token JWT <br>
##### Body:
```json
{
  "username": "usuario",
  "password": "senha"
}
```
##### Retorno:
```json
{
  "authenticated": true,
  "token": "JWT Token"
}
```
## 

#### [POST] /user
Cria um novo usuário no banco de dados e retorna o token JWT <br>
##### Body:
```json
{
  "username": "usuario",
  "password": "senha"
}
```
##### Retorno:
```json
{
  "authenticated": true,
  "token": "JWT Token"
}
```


## 

#### [GET] /agendas
Realiza a busca de agendamentos do usuário logado<br>
##### Querry Params:
```json
?initialDate=1618681471129 (Timestamp) (Opcional)
?finalDate=1618681471129 (Timestamp) (Opcional)
?description=anivesario (Text) (Opcional)
```
##### Retorno:
```
[
  {
    "id": 1,
    "title": "título",
    "date": "2021-04-18",
    "initial_hour": "08:00:00",
    "final_hour": "12:30:00",
    "description": "descrição",
    "user_id": 1,
    "created_at": "2021-04-17T17:02:12.000Z",
    "updated_at": "2021-04-17T17:02:12.000Z"
  },
  {...},
  {...}
]
```

## 

#### [POST] /agenda
Cria um novo agendamento para o usuário logado<br>
##### Body:
```json
{
  "title": "título",
  "date":"2021-04-18",
  "initial_hour": "08:00:00",
  "final_hour": "12:30:00",
  "description": "descrição"
}
```
##### Retorno:
```json
{
  "id": 1,
  "title": "título",
  "date": "2021-04-18",
  "initial_hour": "08:00:00",
  "final_hour": "12:30:00",
  "description": "descrição",
  "user_id": 1,
  "created_at": "2021-04-17T17:02:12.000Z",
  "updated_at": "2021-04-17T17:02:12.000Z"
}
```

## 

#### [PUT] /agenda
Edita um agendamento<br>
##### Body:
```json
{
  "id": 1,
  "title": "título alterado",
  "date":"2021-04-19",
  "initial_hour": "08:00:00",
  "final_hour": "12:30:00",
  "description": "descrição alterada"
}
```
##### Retorno:
```json
{
  "id": 1,
  "title": "título alterado",
  "date": "2021-04-19",
  "initial_hour": "08:00:00",
  "final_hour": "12:30:00",
  "description": "descrição alterada",
  "user_id": 1,
  "created_at": "2021-04-17T17:02:12.000Z",
  "updated_at": "2021-04-17T17:02:12.000Z"
}
```

## 

#### [DELETE] /agenda
Deleta um agendamento<br>
##### Querry Params:
```
id=1 (Obrigatório)
```
##### Retorno:
```json
{
  "deletedId": 1
}
```
