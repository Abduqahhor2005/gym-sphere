- Создайте базу данных и примените миграции:
   ```bash
   dotnet ef migrations add InitialCreate --output-dir DataContext/Migrations
   dotnet ef database update