# Tecnologias Utilizadas
- Banco de Dados SQLServer
- .NET 8.0

# Banco de dados
- Tabela PostoVacina:

    - Id (GUID): Identificador único do posto de vacinação.

   - Nome (string): Nome do posto de vacinação.
  
    - Endereco (string): Endereço do posto de vacinação.

- Chave Primária:
 
   - Id

- Tabela Vacina:
 
    - Id (GUID): Identificador único da vacina.
    
    - Nome (string): Nome da vacina.
    
    - Fabricante (string): Fabricante da vacina.
    
    - DataValidade (DateTime): Data de validade da vacina.
 
- Tabela Lote:
  - Id (GUID): Identificador único do lote.
  - VacinaId (GUID): Identificador da vacina associada ao lote.
  - Quantidade (int): Quantidade de vacinas no lote.
  - PostoVacinaId (GUID): Identificador do posto de vacinação onde o lote está armazenado (pode ser nulo).
 
Sendo assim, a tabela Lote, recebe um id de vacina e associa ela a um posto, fazendo com que nenhuma vacina tenha o mesmo lote e seja 
associada ao mesmo posto. 

# Instruções de como rodar o projeto
1. Clonar Repositorio.
2. Configurar o arquivo appsettings.json:
   ```
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=CadastroPostoVacina;User Id=sa;Password=YourStrong@Passw0rd;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "AllowedHosts": "*"
    }

3. Criar o banco de Dados
`CREATE DATABASE CadastroPostoVacina;`
4. Executar as migrações
  `dotnet ef database update`
5. Abrir o Visual Studio e iniciar a aplicação. 

