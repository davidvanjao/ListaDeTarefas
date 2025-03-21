# Lista De Tarefas

### Este é um projeto de Lista de Tarefas (To-Do List) desenvolvido em C# com SQL Server, implementando operações CRUD (Create, Read, Update, Delete) para gerenciamento de tarefas de forma simples e eficiente.

## Instruções de instalação

### Pré requisitos

- Visual Studio Code
- .NET 8.0 SDK
- SQL Server (ou um banco compatível com SQL Server)
- Ferramenta `dotnet-ef` instalada

Caso não tenha instalado a ferramenta dotnet-ef, que é usada para gerenciar migrações do Entity Framework. Para instalá-la, execute o seguinte comando no terminal:

1. No prompt, realize a instalação do dotnet-ef
```bash
 dotnet tool install --global dotnet-ef
```
2. Verifique se a intalação foi bem sucessida: 
```bash
  dotnet ef --version
```
Se a versão for exibida corretamente, a ferramenta está pronta para uso.

### Etapas

1️⃣ Clonar o Repositório e acessar a pasta principal do projeto:

```bash
    git clone https://github.com/davidvanjao/ListaDeTarefas.git
    cd ListaDeTarefas/ListaDeTarefas
```

2️⃣ Configurar o Banco de Dados
1. Certifique-se de ter o SQL Server instalado e em execução.
2. Configure a string de conexão no arquivo appsettings.json:

```json
    "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ListaDeTarefasProjetoVideo;User Id=USUARIO;Password=SENHA;trustservercertificate=true"
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

## Instruções de uso

1. Abra o navegador e acesse http://localhost:PORTA (O numero da porta estara disponivel no prompt.)

2. Cadastrar:
    É possivel cadastrar uma nova tarefa inserindo os seguintes campos: Descrição, categoria(Academia, casa, compras, faculdade e trabalho), data de vencimento e situação(Aberto e coompleto). 

3. Atualizar:
    Quando uma tarefa é realizada, o usuário deve clicar no botão completar para mudar o status da tarefa como completo. Tarefas vencidas, tem a linha destacada na cor laranja.

4. Deletar: 
    É possivel deletar as tarefas que estão com o status completo.

5. Filtrar:
    É possivel filtrar as tarefas cadastradas utilizando os campos como filtro: Categoria, data de vencimento e situação. 

## Licença

Este projeto está licenciado sob a Licença MIT.

### Resumo da Licença MIT:

A Licença MIT permite que você faça quase qualquer coisa com o código, incluindo usá-lo, copiá-lo, modificá-lo, mesclá-lo, publicá-lo, distribuí-lo, sublicenciá-lo e/ou vendê-lo, desde que a seguinte declaração de copyright e a isenção de responsabilidade sejam incluídas em todas as cópias ou partes substanciais do software.

O software é fornecido "no estado em que se encontra", sem qualquer tipo de garantia expressa ou implícita, incluindo, mas não se limitando a, garantias de comercialização ou adequação a um propósito específico. Em nenhum caso os autores ou detentores de direitos autorais serão responsáveis por qualquer reclamação, dano ou outra responsabilidade, seja em uma ação contratual, delito ou de outro tipo, decorrente de, ou em conexão com, o software ou o uso ou outros negócios no software.
