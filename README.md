
# MyLoveFilmes API

A API **MyLoveFilmes** é uma plataforma para gerenciamento de filmes, onde os usuários podem cadastrar filmes, avaliar e comentar sobre eles, além de criar listas de filmes favoritos e filmes que desejam assistir. A API oferece autenticação por usuário e funcionalidades completas para interação com os filmes.

---

## Funcionalidades

- **Cadastro de filmes**: Permite cadastrar filmes com informações como nome, gênero, diretor e ano de lançamento.
- **Avaliações e comentários**: Cada usuário pode avaliar e comentar sobre os filmes cadastrados.
- **Listas de filmes**: Os usuários podem criar listas com filmes favoritos e filmes que desejam assistir.
- **Autenticação de usuários**: A API possui um sistema de autenticação baseado em usuário, permitindo ações personalizadas para cada um.

---

## Tecnologias Utilizadas

- **.NET 8**
- **Entity Framework Core**
- **JWT (JSON Web Token)**
- **PostgreSQL**

---

## Pré-requisitos

Antes de iniciar, certifique-se de ter instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/)
- [PostgreSQL](https://www.postgresql.org/)

---

## Como Executar

Siga estas etapas para configurar e executar o projeto:

1. Clone o repositório:
   ```bash
   git clone https://github.com/JoaoVic7or/MyLoveFilmesAPI.git
   ```
2. Navegue até o diretório do projeto:
   ```bash
   cd mylovefilmes
   ```
3. Configure o banco de dados:
   - Crie uma base no PostgreSQL.
   - Atualize a string de conexão no arquivo `appsettings.json`.

4. Execute as migrações:
   ```bash
   dotnet ef database update
   ```
5. Inicie o servidor:
   ```bash
   dotnet run
   ```

A API estará disponível em `http://localhost:5167`.

---

## Estrutura do Projeto

A organização do projeto segue a estrutura abaixo:

- **`Core/`**
- **`Infrastructure/`**
- **`API/`**
- **`Domain/`**
- **`Shared/`**

---

## Autenticação e Segurança

A API utiliza **JWT (JSON Web Token)** para autenticação e autorização.  
- Após o login, um token é gerado e deve ser enviado no header de cada requisição autenticada:
  ```http
  Authorization: Bearer <seu_token>
  ```

---

### **Usuários**

- `POST /api/auth/login`: Realiza login e retorna um token JWT.
  - Exemplo de payload:
    ```json
    {
      "email": "user@example.com",
      "password": "password123"
    }
    ```

---

## Contribuição

1. Faça um fork do repositório.
2. Crie uma branch para suas alterações:
   ```bash
   git checkout -b feature/nome-da-feature
   ```
3. Faça suas alterações e commit:
   ```bash
   git commit -m "Descrição das alterações"
   ```
4. Envie suas alterações para o repositório remoto:
   ```bash
   git push origin feature/nome-da-feature
   ```
5. Abra um Pull Request no repositório original.

---

## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
