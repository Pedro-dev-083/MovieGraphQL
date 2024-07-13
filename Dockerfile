FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 6000
EXPOSE 6001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["MovieGraphQL/MovieGraphQL.csproj", "MovieGraphQL/"]
RUN dotnet restore "./MovieGraphQL/MovieGraphQL.csproj"
COPY . .
WORKDIR "/src/MovieGraphQL"
RUN dotnet build "./MovieGraphQL.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "./MovieGraphQL.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV GRAPHQL_PLAYGROUND_ENABLED=true

ENTRYPOINT ["dotnet", "MovieGraphQL.dll"]