# Instruções de utilização

Base para configuração do entity
https://www.youtube.com/watch?v=SryQxUeChMc&list=PLdo4fOcmZ0oX7uTkjYwvCJDG2qhcSzwZ6

## Instalação do Site

Inicio:
1. Alterar o arquivo 'Data/GestLabContext.cs' e configurar a connection string caso necessario
2. Acessar Tools -> NuGet Package Manager - Package Manager Console
3. Update-Database

Criar nova tela:
Criar Pasta com o nome da entidade trabalhada dentro de View, e um novo Index.cshtml
Criar Classe dentro da pasta Model, com o nome da nova entidade
Alterar o arquivo 'Data/GestLabContext.cs' e adicionar a ele 'public DbSet<NomeModel> Nome { get; set; }'
Criar nova controller da pasta Controller com o nome da nova entidade
Executar procedimento para alteração de banco

Alterações de banco:
1. Realizar as alterações necessarias no model do projeto
2. Acessar Tools -> NuGet Package Manager - Package Manager Console
3. Add-Migration NomeMigration
4. Update-Database


## Histórico de versões

### [0.1.0] - DD/MM/AAAA
#### Adicionado
- Adicionado ...