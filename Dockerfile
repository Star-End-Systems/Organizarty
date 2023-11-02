# Use a base image that includes both .NET and Node.js
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the .csproj file and restore any dependencies (assuming Organizarty.UI is your .NET project)
COPY ["Organizarty.UI/Organizarty.UI.csproj", "Organizarty.UI/"]
RUN dotnet restore "Organizarty.UI/Organizarty.UI.csproj"

# Copy the rest of the application code
COPY . .

# Build the application
RUN dotnet publish -c Release -o /app/out "Organizarty.UI/Organizarty.UI.csproj"

# Use a Node.js image to install NPM packages
FROM node:16 AS node
WORKDIR /src

# Copy your package.json and package-lock.json to install NPM packages
COPY ["Organizarty.UI/package*.json", "Organizarty.UI/"]
RUN npm install

# Runtime stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/out .

# Copy NPM packages from the node build stage to the final stage
COPY --from=node /src/node_modules ./node_modules

ENTRYPOINT ["dotnet", "Organizarty.UI.dll"]
