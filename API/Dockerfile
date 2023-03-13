# Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

WORKDIR /source

COPY . .

RUN dotnet restore "./API.csproj" 
RUN dotnet publish "./API.csproj" -c release -o /app --no-restore


# Server image
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal

WORKDIR /app

COPY --from=build /app ./


EXPOSE 5000

ENTRYPOINT [ "dotnet","API.dll" ]