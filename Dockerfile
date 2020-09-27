FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./ServicioMetrobus/*.csproj ./ServicioMetrobus/
COPY ./Negocio/Negocio.csproj ./Negocio/Negocio.csproj
WORKDIR /app/ServicioMetrobus
RUN dotnet restore


# Copy everything else and build
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ServicioMetrobus.dll"]