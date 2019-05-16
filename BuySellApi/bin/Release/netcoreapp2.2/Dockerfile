# Build image
FROM mcr.microsoft.com/dotnet/core/runtime:2.2
COPY BuySellApi/bin/Release/netcoreapp2.2 BuySellApi/
ENTRYPOINT ["dotnet", "BuySellApi.dll"]