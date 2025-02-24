## <span style="color:green">TechLibrary</span>

### <span style="color:green">Descrição do Projeto</span>

O TechLibrary é um projeto desenvolvido durante o evento NLW Connect - C# da Rocketseat, com adaptações e melhorias feitas por mim. O objetivo do projeto é criar uma API para gerenciar uma biblioteca virtual, permitindo operações como cadastro de usuários, login, empréstimo de livros e consulta de livros disponíveis.

O projeto foi desenvolvido utilizando C# e .NET, com uma arquitetura em camadas e boas práticas de desenvolvimento, como Injeção de Dependência, Validações com FluentValidation, Autenticação JWT e Versionamento com Git.

### <span style="color:green">Funcionalidades</span>

#### <span style="color:green">Usuários</span>

**Cadastro de Usuários:** Permite o cadastro de novos usuários com validações robustas (nome, e-mail e senha).

**Login:** Autenticação de usuários com geração de token JWT.

#### <span style="color:green">Livros</span>

**Consulta de Livros:** Listagem de livros com paginação e filtro por título.

**Empréstimo de Livros:** Registro de empréstimos de livros, com validação de disponibilidade.

#### <span style="color:green">Autenticação e Autorização</span>

**Token JWT:** Geração e validação de tokens JWT para autenticação de usuários.

**Filtros de Exceção:** Tratamento centralizado de exceções, retornando respostas padronizadas em caso de erros.

### <span style="color:green">Tecnologias Utilizadas</span>

#### <span style="color:green">Linguagem:</span> C#

#### <span style="color:green">Framework:</span> .NET

#### <span style="color:green">Banco de Dados:</span> SQLite

### <span style="color:green">Bibliotecas:</span>

#### FluentValidation: Para validações de dados.

#### BCrypt.Net: Para criptografia de senhas.

#### JWT (JSON Web Tokens): Para autenticação de usuários.

#### Entity Framework Core: Para acesso ao banco de dados.

### <span style="color:green">Ferramentas:</span>

#### Swagger: Para documentação e teste da API.

#### Git: Para versionamento do código.

### <span style="color:green">Estrutura do Projeto</span>

O projeto está organizado em camadas, seguindo boas práticas de arquitetura:

### <span style="color:green">Camadas</span>

#### <span style="color:green">API (Camada de Apresentação):</span>

Responsável por receber as requisições HTTP e retornar as respostas.

Contém os controllers e filtros de exceção.

#### <span style="color:green">Application (Camada de Negócio):</span>

Contém as regras de negócio, casos de uso e validações.

Implementa interfaces para desacoplamento.

#### <span style="color:green">Infrastructure (Camada de Infraestrutura):</span>

Cuida do acesso ao banco de dados (Entity Framework Core).

Implementa serviços de criptografia e geração de tokens JWT.

#### <span style="color:green">Communication (Camada de Comunicação):</span>

Contém os modelos de requisição e resposta (DTOs).

#### <span style="color:green">Exception (Camada de Exceções):</span>

Centraliza o tratamento de exceções personalizadas.

## <span style="color:green">Como Executar o Projeto</span>
### <span style="color:green">Pré-requisitos</span>
.NET SDK (versão 6 ou superior). (Desenvolvido em .NET 9).

Um editor de código (recomendado: Visual Studio ou Visual Studio Code).

### <span style="color:green">Exemplos de Uso</span>

#### <span style="color:green">Cadastro de Usuário</span>

**Endpoint:** POST /users

**Request:**

```json
{
  "name": "Jonas",
  "email": "jonas@example.com",
  "password": "SenhaForte123!"
}
```
**Response:**

```json
{
  "name": "Jonas",
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

#### <span style="color:green">Login</span>

**Endpoint:** POST /login

**Request:**

```json
{
  "email": "jonas@example.com",
  "password": "SenhaForte123!"
}
```

**Response:**

```json
{
  "name": "Jonas",
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

#### <span style="color:green">Consulta de Livros</span>

**Endpoint: GET /books/filter?pageNumber=1&title=C#**

**Response:**

```json
{
  "pagination": {
    "pageNumber": 1,
    "totalCount": 10
  },
  "books": [
    {
      "id": "123e4567-e89b-12d3-a456-426614174000",
      "title": "C# Programming",
      "author": "John Doe"
    }
  ]
}
```

## <span style="color:green">Contribuição</span>

Sinta-se à vontade para contribuir com o projeto! Basta seguir os passos abaixo:

- Faça um fork do repositório.
- Crie uma branch para sua feature (git checkout -b feature/nova-feature).
- Commit suas alterações (git commit -m 'Adicionando nova feature').
- Push para a branch (git push origin feature/nova-feature).
- Abra um Pull Request.

## <span style="color:green">Autor</span>

**Nome:** Jonas

**LinkedIn:** Seu LinkedIn

**GitHub:** Seu GitHub

