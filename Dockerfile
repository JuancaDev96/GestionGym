# Usamos la imagen oficial de .NET 8 para la compilación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 4001

# Usamos la imagen SDK de .NET 8 para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar los archivos .csproj y restaurar las dependencias
COPY ["GestionGym.Api/GestionGym.Api.csproj", "GestionGym.Api/"]
COPY ["GestionGym.AccesoDatos/GestionGym.AccesoDatos.csproj", "GestionGym.AccesoDatos/"]
COPY ["GestionGym.Entidades/GestionGym.Entidades.csproj", "GestionGym.Entidades/"]
COPY ["GestionGym.Repositorios/GestionGym.Repositorios.csproj", "GestionGym.Repositorios/"]
COPY ["GestionGym.Servicios/GestionGym.Servicios.csproj", "GestionGym.Servicios/"]
COPY ["GestionGym.Comun/GestionGym.Comun.csproj", "GestionGym.Comun/"]
COPY ["GestionGym.Dto/GestionGym.Dto.csproj", "GestionGym.Dto/"]

# Restauramos las dependencias del proyecto
RUN dotnet restore "GestionGym.Api/GestionGym.Api.csproj"

# Copiamos todos los archivos y construimos la aplicación
COPY . .
WORKDIR "/src/GestionGym.Api"
RUN dotnet build "GestionGym.Api.csproj" -c Release -o /app/build

# Publicamos la aplicación
FROM build AS publish
RUN dotnet publish "GestionGym.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Generamos la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestionGym.Api.dll"]
