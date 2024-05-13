cd MFC.WebApi/WebApi


$restoreJob = Start-Job -ScriptBlock{
    dotnet restore "WebApi.csproj"
}
Wait-Job $restoreJob.Name

$buildJob = Start-Job -ScriptBlock{
    dotnet build "WebApi.csproj" -c Release
}
Wait-Job $buildJob.Name

$publishJob = Start-Job -ScriptBlock{
    dotnet publish "WebApi.csproj" -c Release
}
Wait-Job $publishJob.Name

cd bin/Release/net8.0

dotnet WebApi.dll --urls "http://localhost:8080"