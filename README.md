# Lista De Tarefas

### Este é um projeto de Lista de Tarefas (To-Do List) desenvolvido em C# com SQL Server, implementando operações CRUD (Create, Read, Update, Delete) para gerenciamento de tarefas de forma simples e eficiente.

## Instruções de instalação

### Pré requisitos

- Visual Studio Code
- .NET 8.0 SDK
- SQL Server (ou um banco compatível com SQL Server)
- Ferramenta `dotnet-ef` instalada






### Etapas

1️⃣ Clonar o Repositório

```bash
    git clone https://github.com/davidvanjao/ListaDeTarefas.git
    cd nome-do-repositorio
```

2️⃣ Configurar o Banco de Dados
1. Certifique-se de ter o SQL Server instalado e em execução.
2. Crie um banco de dados (se necessário) ou configure a string de conexão no arquivo appsettings.json:

```json
    "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=NOME_DO_BANCO;User Id=USUARIO;Password=SENHA;"
    }
```

3️⃣ Restaurar Dependências:

1. Execute o seguinte comando para instalar os pacotes necessários:

```bash
    dotnet restore
```

4️⃣ Aplicar Migrações e Criar o Banco de Dados:

1. Se o projeto usa Entity Framework Core, aplique as migrações:

```bash
   dotnet ef database update
```

5️⃣ Executar o Projeto

Agora, execute a aplicação:
```bash
    dotnet run
```