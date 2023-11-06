# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set the working directory
WORKDIR /app

FROM node:20 AS node
WORKDIR /src

# Install NPM
RUN apt-get update \
    && apt-get install -y npm \
    && rm -rf /var/lib/apt/lists/* /var/cache/apt/archives/*

# Copy your package.json and package-lock.json to install NPM packages
COPY Organizarty.UI/package*.json ./
COPY Organizarty.UI/tailwind.config.js ./
RUN npm install

COPY . .
RUN npx tailwindcss -i ./Organizarty.UI/Styles/app.css -o /tailwind/app.css

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

COPY . ./
COPY --from=node /tailwind/ ./Organizarty.UI/wwwroot/tailwind/

RUN dotnet publish -c Release -o out ./Organizarty.UI/Organizarty.UI.csproj

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=build /out ./

ENTRYPOINT ["dotnet", "Organizarty.UI.dll"]
