FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/NIM.Web.Host/NIM.Web.Host.csproj", "src/NIM.Web.Host/"]
COPY ["src/NIM.Web.Core/NIM.Web.Core.csproj", "src/NIM.Web.Core/"]
COPY ["src/NIM.Application/NIM.Application.csproj", "src/NIM.Application/"]
COPY ["src/NIM.Core/NIM.Core.csproj", "src/NIM.Core/"]
COPY ["src/NIM.EntityFrameworkCore/NIM.EntityFrameworkCore.csproj", "src/NIM.EntityFrameworkCore/"]
WORKDIR "/src/src/NIM.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/NIM.Web.Host", "src/NIM.Web.Host"]
COPY ["src/NIM.Web.Core", "src/NIM.Web.Core"]
COPY ["src/NIM.Application", "src/NIM.Application"]
COPY ["src/NIM.Core", "src/NIM.Core"]
COPY ["src/NIM.EntityFrameworkCore", "src/NIM.EntityFrameworkCore"]
WORKDIR "/src/src/NIM.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "NIM.Web.Host.dll"]
