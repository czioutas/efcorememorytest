dotnet ef migrations add "init"  --project .\src\efcorememorytest.csproj
dotnet ef database update --project .\src\efcorememorytest.csproj
dotnet ef database drop --project .\src\efcorememorytest.csproj