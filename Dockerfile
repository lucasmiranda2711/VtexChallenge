FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update
RUN apt-get install tzdata
RUN ln -sf /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime
RUN rm -rf /var/cache/apk/*

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY ["Web/Vtex.Challenge.Web.csproj", "Web/"]
COPY ["Vtex.Challenge.Application/Vtex.Challenge.Application.csproj", "Vtex.Challenge.Application/"]
COPY ["Vtex.Challenge.Domain/Vtex.Challenge.Domain.csproj", "Vtex.Challenge.Domain/"]
COPY ["Vtex.Challenge.Database/Vtex.Challenge.Database.csproj", "Vtex.Challenge.Database/"]
COPY ["Vtex.Challenge.Tests/Vtex.Challenge.Tests.csproj", "Vtex.Challenge.Tests/"]

RUN dotnet restore 

COPY ["Web/.", "Web/"]
COPY ["Vtex.Challenge.Application/.", "Vtex.Challenge.Application/"]
COPY ["Vtex.Challenge.Domain/.", "Vtex.Challenge.Domain/"]
COPY ["Vtex.Challenge.Database/.", "Vtex.Challenge.Database/"]

FROM build AS publish
WORKDIR "/src/Web"

RUN dotnet publish "Vtex.Challenge.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vtex.Challenge.Web.dll"]