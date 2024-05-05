param([string] $action = "remove", [string] $migrationName)

if ($action -eq "remove") {
    Write-Warning "Revert to previus migration"
    dotnet ef migrations remove --context MfcContext -p ./Infrastructure -- --provider PostgreSQL
}
elseif ($action -eq "update") {
    Write-Warning "updating..."
    dotnet ef database update --context MfcContext -p ./Infrastructure -- --provider PostgreSQL
}
elseif ($action -eq "add") {
    Write-Warning "adding..."
    dotnet ef migrations add $migrationName --context MfcContext -p ./Infrastructure -- --provider PostgreSQL
}
elseif ($action -eq "dump") {
    Set-Location "D:\RUT\DB\pgsql\bin"
    ./pg_dump.exe -d MFC_DB -U postgres -E UTF-8 -f "D:\RUT\DIPLOM\Project\MFC\MFC.WebApi\MFC.sql"
    Write-Warning "Nice Dick"
    Set-Location "D:\RUT\DIPLOM\Project\MFC\MFC.WebApi"
}

