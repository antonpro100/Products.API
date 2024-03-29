#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Products.API/Products.API.csproj", "Products.API/"]
COPY ["Products.Application/Products.Application.csproj", "Products.Application/"]
COPY ["Products.Core/Products.Core.csproj", "Products.Core/"]
COPY ["Products.DataAccess/Products.DataAccess.csproj", "Products.DataAccess/"]
RUN dotnet restore "Products.API/Products.API.csproj"
COPY . .
WORKDIR "/src/Products.API"
RUN dotnet build "Products.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Products.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Products.API.dll"]