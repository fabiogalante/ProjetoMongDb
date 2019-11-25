FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/ProjetoMongDb.API/ProjetoMongDb.API.csproj", "src/ProjetoMongDb.API/"]
RUN dotnet restore "src/ProjetoMongDb.API/ProjetoMongDb.API.csproj"
COPY . .
WORKDIR "/src/src/ProjetoMongDb.API"
RUN dotnet build "ProjetoMongDb.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProjetoMongDb.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProjetoMongDb.API.dll"]