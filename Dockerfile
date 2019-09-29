FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /build

# Copy csproj and restore as distinct layers
COPY *.sln .

COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

# Copy everything else and build
COPY ./src ./src 

RUN dotnet publish UserService.sln -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Service.dll"]