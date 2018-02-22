# Criar uma API Web com o ASP.NET Core e o Visual Studio para Windows

API Web simples criada a partir do tutorial disponível em: https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api

## Visão geral

| API |	Descrição | Corpo da solicitação	| Corpo da resposta
|-|-|-|-|
|`GET /api/todo` | Obter todos os itens de tarefas pendentes	|Nenhum | Matriz de itens de tarefas pendentes
|`GET /api/todo/{id}`	| Obter um item por ID |	Nenhum |	Item de tarefas pendentes
|`POST /api/todo`	| Adicionar um novo item | Item de tarefas pendentes | Item de tarefas pendentes
|`PUT /api/todo/{id}`	| Atualizar um item existente | Item de tarefas pendentes | Nenhum
|`DELETE /api/todo/{id}` | Excluir um item | Nenhum | Nenhum

* O cliente é tudo o que consome a API Web (aplicativo móvel, navegador, etc.). Este tutorial não cria um cliente. Postman ou curl são usados como clientes para testar o aplicativo.

* Um modelo é um objeto que representa os dados no aplicativo. Nesse caso, o único modelo é um item de tarefas pendentes. Modelos são representados como classes c#, também conhecidos como Plain Old C# Objeto (POCOs).

* Um controlador é um objeto que manipula solicitações HTTP e cria a resposta HTTP. Este aplicativo tem um único controlador.

* Para manter o tutorial simples, o aplicativo não usa um banco de dados persistente. O aplicativo de exemplo armazena os itens de tarefas pendentes em um banco de dados em memória.