# Sistema de Controle de Estudantes IEL

Este projeto é um sistema web para gerenciamento de cadastro de estudantes da IEL (Instituto Educacional Local - substitua pela sigla/nome correto). Ele permite o cadastro, edição, exclusão e visualização de informações dos alunos, facilitando a organização e o acesso aos dados.

## Funcionalidades

*   **Cadastro de Estudantes:** Permite a inclusão de novos alunos no sistema, com informações como nome, CPF, data de conclusão, etc.
*   **Edição de Estudantes:** Possibilita a alteração de dados de alunos já cadastrados.
*   **Exclusão de Estudantes:** Permite a remoção de registros de alunos do sistema.
*   **Listagem de Estudantes:** Exibe uma lista com os alunos cadastrados, permitindo a busca e a ordenação.
*   **Validação de CPF:** Implementa validação client-side e server-side do CPF, incluindo a verificação de CPF já cadastrado.

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

*   **.NET SDK:** Versão X.X (especifique a versão do .NET SDK utilizada).
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

## Validação de CPF

O sistema implementa a validação de CPF em duas etapas:

*   **Client-Side (JavaScript):** Valida o formato e o dígito verificador do CPF em tempo real, antes do envio do formulário. Também verifica se o CPF já existe no banco de dados através de uma requisição AJAX para um endpoint da API.
*   **Server-Side (C#):** Realiza a mesma validação no servidor como uma camada extra de segurança, garantindo que dados inválidos não sejam persistidos no banco de dados.

## Endpoints da API

*   `/api/cpf/existe?cpf={cpf}`: Endpoint para verificar a existência de um CPF no banco de dados. Retorna um JSON com o formato `{"existe": true/false}`.

## Estrutura do Projeto (opcional)

(Aqui você pode adicionar uma breve descrição da estrutura de pastas do seu projeto, se achar relevante)

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

(Adicione a licença do seu projeto, por exemplo, MIT License)
