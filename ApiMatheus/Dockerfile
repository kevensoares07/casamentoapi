# Usando a imagem base do ASP.NET para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Usando a imagem SDK para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos do projeto e restaura as dependências
COPY ["ApiMatheus/ApiMatheus.csproj", "ApiMatheus/"]
RUN dotnet restore "ApiMatheus/ApiMatheus.csproj"

# Copia todo o código e realiza o build
COPY . .
WORKDIR "/src/ApiMatheus"
RUN dotnet build -c Release -o /app/build

# Publicação do projeto
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Criando a imagem final que será executada
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiMatheus.dll"]
