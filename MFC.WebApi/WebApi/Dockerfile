﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

#WORKDIR /app
#RUN dotnet dev-certs https -ep https/aspnetapp.pfx -p 1234
#RUN dotnet dev-certs https --trust

WORKDIR /src

COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["../.office/OFFICE.DLL", ".office/OFFICE.DLL"]

RUN dotnet restore "WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#COPY ["WebApi/statements/test.docx", "statements/test.docx"]

ENTRYPOINT ["dotnet", "WebApi.dll"]