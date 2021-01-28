# remoteu-backend
dotnet restore
dotnet build
dotnet ef Add-Migration NewMigration -Project RemoteCamp.Portal.Core -o Database/Migrations
dotnet ef database update
dotnet run
