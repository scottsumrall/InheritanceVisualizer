# Game Store

## Starting SQL Server docker container

'''Powershell
$sa_password = "SA PASSWORD HERE"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -d -v sqlvolume:/var/opt/mssql --rm --name mssqlserver mcr.microsoft.com/mssql/server:2022-latest
'''

## Setting the connection string in Secret Manager
'''powershell
$sa_password = "SA PW HERE"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=AbstractionOrganizer; Trusted_Connection=True; User Id=sa; Password= $sa_password; TrustServerCertificate=True"
'''

