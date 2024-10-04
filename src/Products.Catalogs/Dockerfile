# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo da solution e os projetos
COPY ["Products.Catalogs.sln", "./"]
COPY ["Products.Catalogs.Api/Products.Catalogs.Api.csproj", "Products.Catalogs.Api/"]
COPY ["Products.Catalogs.Domain/Products.Catalogs.Domain.csproj", "Products.Catalogs.Domain/"]
COPY ["Products.Catalogs.Infrastructure.Repository/Products.Catalogs.Infrastructure.Repository.csproj", "Products.Catalogs.Infrastructure.Repository/"]
COPY ["Products.Catalogs.Tests/Products.Catalogs.Tests.csproj", "Products.Catalogs.Tests/"]

# Restaurar dependências diretamente do feed do NuGet, ignorando qualquer pasta fallback
RUN dotnet restore --no-cache --disable-parallel "Products.Catalogs.Api/Products.Catalogs.Api.csproj"

# Copiar o restante dos arquivos
COPY . .

# Definir o diretório de trabalho para o projeto API
WORKDIR /src/Products.Catalogs.Api

# Renomear appsettings.Docker.json (se existir) para appsettings.json
RUN if [ -f appsettings.Docker.json ]; then mv appsettings.Docker.json appsettings.json; fi

# Build da aplicação
RUN dotnet build "Products.Catalogs.Api.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Products.Catalogs.Api.csproj" -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

# Expor a porta da aplicação
EXPOSE 51000

# Definir o entrypoint para iniciar a API
ENTRYPOINT ["dotnet", "Products.Catalogs.Api.dll"]