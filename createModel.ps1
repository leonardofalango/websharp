$strconn = "Data Source=" + $args[0] + ";Initial Catalog=" + $args[1] + ";Integrated Security=True;TrustServerCertificate=true"
# String connection

dotnet add package Microsoft.EntityFrameworkCore.Design
# Entity FrameWork

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
# Sql server

dotnet tool install --global dotnet-ef
# Entity Framework tools

dotnet ef dbcontext scaffold $strconn Microsoft.EntityFrameworkCore.SqlServer --force -o Model
# Connect and create context