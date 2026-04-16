# Biblioteca API - CP1 e CP2

### Integrantes do grupo

- Felipe Bezerra Beatrici - RM564723
- Max Hayashi Batista - RM563717
- Henrique Cunha Torres - RM565119

<hr/>

### Domínio escolhido

- Biblioteca

<hr/>

### Entidades modeladas

- User (Usuários)
- Loan (Empréstimos)
- Book (Livros)
- Author (Autores)
- Publisher (Editoras)
- Category (Categorias)

<hr/>

### Resumo dos relacionamentos

- User (1:N) Loan
  - Um usuário pode ter zero ou mais empréstimos.
  - Cada empréstimo pertence a um único usuário.
- Book (1:1) Loan
  - Um livro pode ter no máximo um empréstimo.
  - Cada empréstimo pertence a um único livro.
- Publisher (1:N) Book
  - Uma editora pode publicar vários livros.
  - Cada livro pertence a uma única editora.
- Book (N:N) Author
  - Um livro pode ter vários autores.
  - Um autor pode estar em vários livros.
- Book (N:N) Category
  - Um livro pode pertencer a várias categorias.
  - Uma categoria pode conter vários livros.

<hr/>

### SGBD utilizado

- SQLite (via `Microsoft.EntityFrameworkCore.Sqlite`)

<hr/>

### Como executar

**Pré-requisitos:** .NET 10 SDK instalado.

```bash
# Restaurar dependências
dotnet restore

# Aplicar migrations e criar o banco
dotnet ef database update --project Cp1Biblioteca.Infrastructure --startup-project Cp1Biblioteca.Api

# Rodar a aplicação
dotnet run --project Cp1Biblioteca.Api
```

O banco `biblioteca.db` será criado automaticamente na pasta do projeto Api.

<hr/>

### Evidências

- Diagrama MER: `docs/MER.png`
- Esquema físico do banco: `docs/SCHEMA.png`

<hr/>

### Imagem do MER (disponível em docs/MER.png)
<img width="1044" height="442" alt="image" src="https://github.com/user-attachments/assets/dab5f583-5920-492d-878a-47a09b7f0e5e" />