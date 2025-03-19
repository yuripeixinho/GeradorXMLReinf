# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copiar arquivos de projeto
COPY *.sln .

COPY 01.EFD.WebApi/. ./01.EFD.WebApi/
COPY 02.EFD.Manager/. ./02.EFD.Manager/
COPY 03.EFD.Data/. ./03.EFD.Data/
COPY 04.EFD.Core/. ./04.EFD.Core/  
COPY EFD.Core.Shared/. ./EFD.Core.Shared/

# Restaurar as dependências da solução completa
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build app/out .

# Configurar a execu��o da API
ENTRYPOINT ["sh", "-c", "dotnet ef database update --no-build && dotnet EFD.WebApi.dll"]
