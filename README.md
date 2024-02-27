`docker run -e "ACCEPT_EULA=1" -e "MSSQL_USER=SA" -e "MSSQL_SA_PASSWORD=SQLConnect1" -e "MSSQL_PID=Developer" -p 1433:1433 -d --name=sql_connect mcr.microsoft.com/azure-sql-edge`

`dotnet ef migrations add init`

`dotnet ef database update`

This is one backend web api application based on .net, which is used to connect to the database and provide the data to the frontend.
