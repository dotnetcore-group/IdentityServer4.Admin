FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/IdentityServer4.SSO/IdentityServer4.SSO.csproj", "src/IdentityServer4.SSO/"]
COPY ["src/IdentityServer4.Admin.Data.Mysql/IdentityServer4.Admin.Data.Mysql.csproj", "src/IdentityServer4.Admin.Data.Mysql/"]
COPY ["src/IdentityServer4.Admin.Infrastructures.Data/IdentityServer4.Admin.Data.csproj", "src/IdentityServer4.Admin.Infrastructures.Data/"]
COPY ["src/IdentityServer4.Admin.Domain.Core/IdentityServer4.Admin.Domain.Core.csproj", "src/IdentityServer4.Admin.Domain.Core/"]
COPY ["src/IdentityServer4.Admin.Domain/IdentityServer4.Admin.Domain.csproj", "src/IdentityServer4.Admin.Domain/"]
COPY ["src/IdentityServer4.Admin.BuildingBlock/IdentityServer4.Admin.BuildingBlock.csproj", "src/IdentityServer4.Admin.BuildingBlock/"]
COPY ["src/IdentityServer4.Admin.Identity/IdentityServer4.Admin.Identity.csproj", "src/IdentityServer4.Admin.Identity/"]
COPY ["src/IdentityServer4.Admin.Application/IdentityServer4.Admin.Application.csproj", "src/IdentityServer4.Admin.Application/"]
COPY ["src/IdentityServer4.Admin.Extensions/IdentityServer4.Admin.Extensions.csproj", "src/IdentityServer4.Admin.Extensions/"]
COPY ["src/IdentityServer4.Admin.IoC/IdentityServer4.Admin.IoC.csproj", "src/IdentityServer4.Admin.IoC/"]

RUN dotnet restore "src/IdentityServer4.SSO/IdentityServer4.SSO.csproj"
COPY . .
WORKDIR "/src/src/IdentityServer4.SSO"
RUN dotnet build "IdentityServer4.SSO.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IdentityServer4.SSO.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN mkdir files
ENTRYPOINT ["dotnet", "IdentityServer4.SSO.dll"]