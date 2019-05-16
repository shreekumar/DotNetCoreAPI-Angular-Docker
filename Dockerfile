FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["BuySellApi/BuySellApi.csproj", "BuySellApi/"]
COPY ["BuySellApi.Core/BuySellApi.Core.csproj", "BuySellApi.Core/"]
COPY ["BuySellApi.Data/BuySellApi.Data.csproj", "BuySellApi.Data/"]
RUN dotnet restore "BuySellApi/BuySellApi.csproj"
COPY . .
WORKDIR "/src/BuySellApi"
RUN dotnet build "BuySellApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BuySellApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BuySellApi.dll", "--server.urls", "http://0.0.0.0:5000"]
