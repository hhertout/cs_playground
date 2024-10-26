#### Migrations:

Require EF design installed on the project

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Install dotnet-ef

```bash
dotnet tool install --global dotnet-ef
```

then run

```bash
dotnet ef migrations add <nameForYourMigration>
```

To update the DB from the migration files :

```bash
dotnet ef database update
```
