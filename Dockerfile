#FROM mcr.microsoft.com/dotnet/core/sdk:3.1
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY Application/bin/Release/netcoreapp3.1/publish app/

WORKDIR /app

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "Application.dll"]