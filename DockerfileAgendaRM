#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["puc.poc.modulo.agenda.hostservice.readmodel/puc.poc.modulo.agenda.hostservice.readmodel.csproj", "puc.poc.modulo.agenda.hostservice.readmodel/"]
COPY ["puc.poc.modulo.agenda.messages/puc.poc.modulo.agenda.messages.csproj", "puc.poc.modulo.agenda.messages/"]
COPY ["puc.poc.modulo.cross/puc.poc.modulo.cross.csproj", "puc.poc.modulo.cross/"]
COPY ["puc.poc.modulo.agenda.repositorio.readmodel/puc.poc.modulo.agenda.repositorio.readmodel.csproj", "puc.poc.modulo.agenda.repositorio.readmodel/"]
COPY ["puc.poc.modulo.agenda.dominio/puc.poc.modulo.agenda.dominio.csproj", "puc.poc.modulo.agenda.dominio/"]
COPY ["puc.poc.modulo.associado.messages/puc.poc.modulo.associado.messages.csproj", "puc.poc.modulo.associado.messages/"]
RUN dotnet restore "puc.poc.modulo.agenda.hostservice.readmodel/puc.poc.modulo.agenda.hostservice.readmodel.csproj"
COPY . .
WORKDIR "/src/puc.poc.modulo.agenda.hostservice.readmodel"
RUN dotnet build "puc.poc.modulo.agenda.hostservice.readmodel.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "puc.poc.modulo.agenda.hostservice.readmodel.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "puc.poc.modulo.agenda.hostservice.readmodel.dll"]