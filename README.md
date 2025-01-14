# Sistema de Controle de Estudantes IEL

Este projeto é um sistema web para gerenciamento de cadastro de estudantes na IEL. Ele permite o cadastro, edição, exclusão e visualização de informações dos estudantes, facilitando a organização e o acesso aos dados.

## Funcionalidades

*   **Cadastro de Estudantes:** Permite a inclusão de novos alunos no sistema, com informações como nome, CPF, data de conclusão, etc.
*   **Edição de Estudantes:** Possibilita a alteração de dados de alunos já cadastrados.
*   **Exclusão de Estudantes:** Permite a remoção de registros de alunos do sistema.
*   **Listagem de Estudantes:** Exibe uma lista com os alunos cadastrados, permitindo a busca e a ordenação.

## Tecnologias Utilizadas

*   **ASP.NET Core MVC:** Framework web para o desenvolvimento do backend.
*   **C#:** Linguagem de programação utilizada no backend.
*   **Entity Framework Core:** ORM (Object-Relational Mapper) para interação com o banco de dados.
*   **SQL Server (ou outro banco de dados):** Banco de dados utilizado para armazenar as informações dos estudantes.
*   **HTML, CSS e JavaScript:** Tecnologias web para o desenvolvimento do frontend.
*   **Bootstrap:** Framework CSS para estilização e responsividade da interface.
*   **jQuery:** Biblioteca JavaScript para manipulação do DOM e requisições AJAX.
*   **jQuery Validate e jQuery Unobtrusive Validation:** Bibliotecas para validação client-side.
*   **DataTables:** Plugin jQuery para tabelas com paginação, ordenação e busca.

## Pré-requisitos

*   .NET SDK: Versão  9.0.
*   **Visual Studio ou Visual Studio Code:** IDE (Integrated Development Environment) para desenvolvimento.
*   **SQL Server ou outro banco de dados:** Com as credenciais de acesso configuradas.

## Configuração

1.  **Clone o repositório:**

    ```bash
    git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/seu-usuario/seu-repositorio.git)
    ```

2.  **Abra a solução no Visual Studio ou Visual Studio Code.**

3.  **Configure a string de conexão do banco de dados:**
    *   Localize o arquivo `appsettings.json`.
    *   Modifique a string de conexão na seção "ConnectionStrings" para apontar para o seu banco de dados. Exemplo:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ControleDeEstudantesIEL;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```

4.  **Execute as migrations do Entity Framework Core:**

    Abra o console do Gerenciador de Pacotes (Package Manager Console) no Visual Studio ou o terminal na pasta do projeto e execute os seguintes comandos:

    ```bash
    dotnet ef database update
    ```

5.  **Execute o projeto.**


## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.
