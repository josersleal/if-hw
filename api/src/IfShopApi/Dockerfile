FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5022

ENV ASPNETCORE_URLS=http://+:5022

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["if-hw/api/src/IfShopApi/IfShopApi.csproj", "if-hw/api/src/IfShopApi/"]
RUN dotnet restore "if-hw/api/src/IfShopApi/IfShopApi.csproj"
COPY . .
WORKDIR "/src/if-hw/api/src/IfShopApi"
RUN dotnet build "IfShopApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "IfShopApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IfShopApi.dll"]
