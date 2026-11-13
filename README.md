# EasyShop
**Integrantes:** - Gabriel Braga - Gustavo Ayres


**EasyShop** é um aplicativo de comércio eletrônico desenvolvido com C# e .NET MAUI, projetado para demonstrar uma abordagem flexível e eficiente de armazenamento de dados por meio de uma arquitetura de persistência poliglota.

O projeto utiliza dois bancos de dados locais, cada um responsável por armazenar o tipo de informação para o qual é mais adequado.

## Tecnologias utilizadas

- **C#** – Linguagem principal de desenvolvimento.
- **.NET MAUI** – Framework utilizado para construção da interface multiplataforma.
- **SQLite** – Banco de dados relacional utilizado para armazenar informações dos clientes.
- **LiteDB** – Banco de dados NoSQL orientado a documentos, utilizado para armazenar o catálogo de produtos.

## Funcionalidades

### Catálogo de produtos

O gerenciamento de produtos utiliza o LiteDB, permitindo armazenar informações com estruturas flexíveis e atributos personalizados.

Principais funcionalidades:
- Cadastro de produtos com nome e preço.
- Definição de categorias.
- Inclusão de atributos dinâmicos, como cor, tamanho, voltagem e especificações.
- Listagem dos produtos cadastrados.

### Cadastro de clientes

O gerenciamento de clientes utiliza o SQLite, garantindo uma estrutura organizada e consistente para os dados cadastrais.

Principais funcionalidades:
- Cadastro de clientes.
- Armazenamento de nome completo e e-mail.
- Validação dos dados informados.
- Listagem dos clientes cadastrados.

## Arquitetura do projeto

O EasyShop utiliza uma arquitetura em camadas para manter o código organizado, facilitar a manutenção e separar as responsabilidades da aplicação.

- **Presentation:** responsável pela interface, telas e interação com o usuário.
- **Services:** concentra a lógica de negócio e coordena as operações da aplicação.
- **Data:** responsável pelo acesso aos bancos de dados e pelas operações de persistência.
- **Models:** define as estruturas de dados utilizadas pelo sistema.

Essa organização reduz o acoplamento entre os componentes e facilita futuras evoluções do projeto.

## Persistência poliglota

Um dos principais conceitos aplicados no EasyShop é a utilização simultânea de diferentes paradigmas de armazenamento.

Cada banco possui uma responsabilidade específica:

| Banco de dados | Responsabilidade |
|---|---|
| LiteDB | Armazenamento do catálogo de produtos |
| SQLite | Armazenamento dos clientes |

Essa divisão permite aproveitar a flexibilidade do NoSQL para informações dinâmicas e a consistência do modelo relacional para dados estruturados.

## Execução do projeto

Para executar o EasyShop, é necessário ter instalado:

- Visual Studio com suporte ao desenvolvimento .NET MAUI.
- SDK do .NET compatível com o projeto.
- Android SDK e ferramentas de desenvolvimento Android.
- Emulador Android ou dispositivo físico compatível.

**Passos para execução:**

1. Clone este repositório.
2. Abra o arquivo `EasyShop.csproj` no Visual Studio.
3. Aguarde a restauração das dependências NuGet.
4. Configure ou inicie um emulador Android.
5. Selecione o dispositivo como destino de execução.
6. Execute o projeto utilizando o Visual Studio.

Os bancos de dados são armazenados localmente no dispositivo, dentro do diretório de dados da aplicação.

---

**EasyShop** — Uma aplicação que combina flexibilidade, organização e diferentes tecnologias de persistência em uma única solução.
