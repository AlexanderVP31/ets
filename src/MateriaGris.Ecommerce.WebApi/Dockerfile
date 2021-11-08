#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 6060
ENV ASPNETCORE_URLS=http://*:6060

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/MateriaGris.Ecommerce.WebApi/MateriaGris.Ecommerce.WebApi.csproj", "src/MateriaGris.Ecommerce.WebApi/"]
COPY ["src/MateriaGris.Ecommerce.Application/MateriaGris.Ecommerce.Application.csproj", "src/MateriaGris.Ecommerce.Application/"]
COPY ["src/MateriaGris.Ecommerce.Domain/MateriaGris.Ecommerce.Domain.csproj", "src/MateriaGris.Ecommerce.Domain/"]
COPY ["src/MateriaGris.Ecommerce.Infrastructure/MateriaGris.Ecommerce.Infrastructure.csproj", "src/MateriaGris.Ecommerce.Infrastructure/"]
RUN dotnet restore "src/MateriaGris.Ecommerce.WebApi/MateriaGris.Ecommerce.WebApi.csproj"
COPY . .
WORKDIR "/src/src/MateriaGris.Ecommerce.WebApi"
RUN dotnet build "MateriaGris.Ecommerce.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MateriaGris.Ecommerce.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MateriaGris.Ecommerce.WebApi.dll"]