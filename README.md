# EasyShop – Mini E-commerce com Persistência Poliglota

**Integrantes:**
- Gabriel Braga
- Gustavo Ayres

## 1. Sobre o projeto

O EasyShop é um protótipo de aplicativo Android desenvolvido em C# com .NET MAUI. Ele demonstra o uso simultâneo de dois paradigmas de persistência local no mesmo aplicativo:

- **LiteDB (NoSQL orientado a documentos):** armazena o catálogo de produtos. Cada produto possui nome, preço, categoria opcional e um dicionário de atributos dinâmicos. Assim, um notebook pode ter `Processador` e `Memória RAM`, enquanto uma camisa pode ter `Tamanho` e `Cor`, sem alterar a estrutura do banco.
- **SQLite (SQL relacional):** armazena clientes em uma tabela estruturada com identificador, nome completo e e-mail. O identificador é chave primária autoincremental e o e-mail possui restrição de unicidade.

Os dois bancos são arquivos locais independentes, salvos no diretório privado do aplicativo Android.

## 2. Arquitetura em camadas

```text
EasyShop/
├── Models/                 # Entidades Product e Customer
├── Data/Repositories/      # Contratos e implementação dos bancos
├── Services/               # Validações e regras de negócio
├── ViewModels/             # Estado da tela e comandos
├── Views/                  # Telas XAML e code-behind
├── App.xaml                 # Estilos globais
├── AppShell.xaml            # Navegação por abas
├── MauiProgram.cs           # Injeção de dependência
└── README.md
```

Fluxo das operações:

```text
Apresentação (Views + ViewModels)
              ↓
       Negócio (Services)
              ↓
    Acesso a dados (Repositories)
          ↙         ↘
       LiteDB       SQLite
       Produtos     Clientes
```

A interface não acessa os bancos diretamente. Os ViewModels chamam os serviços; os serviços validam os dados e usam as interfaces dos repositórios; os repositórios realizam o CRUD/persistência.

## 3. Tecnologias e pacotes

- .NET MAUI / C# / XAML
- LiteDB 5.0.21
- sqlite-net-pcl 1.9.172
- Injeção de dependência nativa do .NET MAUI

## 4. Requisitos para executar

- Windows 10/11 64 bits.
- Visual Studio 2026 com a carga de trabalho **Desenvolvimento de interface do usuário de aplicativo multiplataforma do .NET** instalada.
- .NET SDK compatível com `net10.0-android`.
- Componentes Android SDK e OpenJDK instalados pelo Visual Studio Installer.
- Emulador Android criado no Android Device Manager ou dispositivo Android com depuração USB habilitada.

## 5. Como abrir e executar

1. Baixe ou clone este repositório.
2. Abra `EasyShop.csproj` no Visual Studio 2026.
3. Aguarde a restauração dos pacotes NuGet.
4. Abra o Android Device Manager e inicie um emulador, ou conecte um aparelho Android.
5. Na lista de destinos de execução, selecione o emulador/dispositivo Android.
6. Pressione **F5** (ou clique em Iniciar Depuração).

Pela linha de comando, com o ambiente MAUI Android instalado:

```bash
dotnet workload restore
dotnet restore EasyShop.csproj
dotnet build EasyShop.csproj -f net10.0-android
dotnet build EasyShop.csproj -t:Run -f net10.0-android
```

Se o Visual Studio oferecer outro Target Framework MAUI compatível com o SDK instalado, ajuste `TargetFrameworks` no `.csproj` para o TFM Android correspondente disponível no seu ambiente.

## 6. Como testar a demonstração

### Aba Produtos – LiteDB (NoSQL)

1. Abra a aba **Produtos**.
2. Cadastre, por exemplo:
   - Nome: Notebook Pro
   - Preço: 4599,90
   - Categoria: Informática
   - Atributos: `Processador: Intel Core i7; Memória RAM: 16 GB; Armazenamento: 512 GB SSD`
3. Cadastre outro tipo de produto com atributos diferentes, por exemplo:
   - Nome: Camiseta básica
   - Preço: 59,90
   - Categoria: Vestuário
   - Atributos: `Tamanho: M; Cor: Azul`
4. Confira que os produtos aparecem na listagem com suas características próprias.
5. Feche e abra o aplicativo novamente para demonstrar que os registros permanecem salvos localmente.

### Aba Clientes – SQLite (SQL)

1. Abra a aba **Clientes**.
2. Cadastre um nome completo e um e-mail válido, por exemplo `Ana Souza` e `ana@exemplo.com`.
3. Confira o cliente na listagem e seu identificador.
4. Tente cadastrar novamente o mesmo e-mail para demonstrar a restrição de unicidade do banco.
5. Feche e abra o aplicativo novamente para verificar a persistência.

> Os exemplos acima são dados fictícios para demonstração.

## 7. Arquivos de banco

Os bancos são criados automaticamente na primeira utilização:

- `products.db` – arquivo do LiteDB, coleção `products`.
- `customers.db3` – arquivo SQLite, tabela `Customers`.

No Android, os arquivos ficam em `FileSystem.AppDataDirectory`, dentro do armazenamento privado do aplicativo. Não é necessário configurar servidor ou conexão com a internet.

## 8. Observações e escopo

O protótipo implementa cadastro e listagem (Create e Read) para os dois tipos de registro, além de validações de entrada. Atualização e exclusão não fazem parte dos requisitos mínimos descritos na atividade. O banco NoSQL é utilizado somente para produtos e o banco relacional somente para clientes, deixando explícita a separação das responsabilidades.

## 9. Roteiro sugerido para o vídeo

1. Apresentar o nome do projeto e os integrantes.
2. Mostrar a aba Produtos e cadastrar produtos com atributos diferentes.
3. Explicar que os produtos são documentos flexíveis no LiteDB.
4. Mostrar a aba Clientes e cadastrar um cliente.
5. Explicar que clientes são registros relacionais no SQLite, com chave primária e e-mail único.
6. Fechar e reabrir o aplicativo para comprovar a persistência local.
7. Mostrar rapidamente a estrutura em camadas do código.

**Importante:** o vídeo deve ser gravado no emulador Android ou dispositivo Android, com áudio explicativo ou legendas claras, conforme a atividade.
