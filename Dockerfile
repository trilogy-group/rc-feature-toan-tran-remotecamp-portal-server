#####################
### common ###
#####################

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS common
# Install updates
RUN apt-get update

# Set working directory
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY src/*.sln .
COPY src/*.config .
COPY src/RemoteCamp.Portal.Core/*.csproj ./RemoteCamp.Portal.Core/
COPY src/RemoteCamp.Portal.Web/*.csproj ./RemoteCamp.Portal.Web/
COPY src/RemoteCamp.Portal.Database.MigrationTool/*.csproj ./RemoteCamp.Portal.Database.MigrationTool/
COPY src/Tests/RemoteCamp.Portal.Core.Test/*.csproj ./Tests/RemoteCamp.Portal.Core.Test/
RUN dotnet restore

# Copy everything else
COPY src/RemoteCamp.Portal.Core/. ./RemoteCamp.Portal.Core/
COPY src/RemoteCamp.Portal.Web/. ./RemoteCamp.Portal.Web/
COPY src/RemoteCamp.Portal.Database.MigrationTool/. ./RemoteCamp.Portal.Database.MigrationTool/
COPY src/Tests/. ./Tests/

############
### test ###
############
FROM common AS test
WORKDIR /src/Tests/RemoteCamp.Portal.Core.Test
RUN dotnet test --filter "FullyQualifiedName!~RemoteCamp.Portal.Core.Test.Integration" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura

####################
### DB Migration ###
####################
FROM common AS dbmigration
WORKDIR /src/RemoteCamp.Portal.Database.MigrationTool
ARG PUBLISH_MODE
RUN dotnet publish -c $PUBLISH_MODE -o migrationtool
WORKDIR /src/RemoteCamp.Portal.Database.MigrationTool/migrationtool


#############
### build ###
#############
FROM common AS build
WORKDIR /src/RemoteCamp.Portal.Web
ARG PUBLISH_MODE
RUN dotnet publish -c $PUBLISH_MODE -o out

###############
### release ###
###############
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS runtime
RUN apt-get update \
    && apt-get install -y net-tools vim
WORKDIR /app
COPY --from=build /src/RemoteCamp.Portal.Web/out ./

# Run the app
COPY entrypoint.sh .
RUN chmod +x ./entrypoint.sh
ENTRYPOINT ["./entrypoint.sh"]
