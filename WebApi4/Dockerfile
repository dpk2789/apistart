#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApi4/WebApi4.csproj", "WebApi4/"]
RUN dotnet restore "WebApi4/WebApi4.csproj"
COPY . .
WORKDIR "/src/WebApi4"
RUN dotnet build "WebApi4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi4.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi4.dll"]