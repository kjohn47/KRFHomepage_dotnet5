KRFHomepage

Important during service dev: (on KRFCommon nuget)
install swagger
Install-Package Swashbuckle.AspNetCore -Version 5.0.0-rc4


install jwtBearer
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 3.1.0

Config DB
add localDB database
create database HomeDB on (name='HomeDB', filename='[DIR TO PROJECT]\KRFHomepage\KRFHomepage.Infrastructure\Database\DBFiles\homeDB.mdf');  ??

Migrations
		dotnet tool install --global dotnet-ef
		go to infrastructure project [KRFHomepage.Infrastructure]
		run:
		dotnet ef  migrations add [migration_name] --context Database.DBContext.[ContextMain] -o KRFHomepage.Infrastructure/Database/Migrations
		.
OR RUN this:
--> Add-Migration [migration_name] -OutputDir "Database/Migrations" -Project KRFHomepage.Infrastructure