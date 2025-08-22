# 👤 Controlador de Usuários – ASP.NET Core MVC

## 📌 Visão Geral
O **Controlador de Usuários** é responsável por gerenciar todas as operações relacionadas ao **cadastro, edição, listagem e exclusão de usuários** dentro do sistema.  
Ele segue o padrão **MVC (Model-View-Controller)**, recebendo as requisições do usuário, manipulando os dados por meio do repositório e retornando a resposta adequada para a *View*.

---

## ⚙️ Funcionalidades

O controlador implementa os seguintes métodos:

- **Index()** → Lista todos os usuários cadastrados.  
- **Criar()** → Retorna a *view* para criação de um novo usuário.  
- **Criar() [POST]** → Recebe os dados do formulário e salva o novo usuário no banco de dados.  
- **Editar(int id)** → Retorna a *view* de edição de um usuário específico.  
- **Editar() [POST]** → Recebe os dados atualizados e os salva no banco de dados.  
- **ApagarConfirmacao(int id)** → Retorna uma *view* de confirmação antes da exclusão.  
- **Apagar(int id)** → Remove o usuário do banco de dados.  
---
