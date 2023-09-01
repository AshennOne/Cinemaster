# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy the .csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore
# Copy the rest of the application source code
COPY . ./

# Publish the application
RUN dotnet publish -c Release -o out

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
# Copy the published application from the build image
COPY --from=build-env /app/out .
# Set environment variables for the PostgreSQL connection
#ENV ConnectionStrings__DefaultConnection "Server=localhost; Port=5432; User Id=postgres;Password=postgrespw; Database=cinemaster"

# Start the application
ENTRYPOINT ["dotnet", "API.dll"]
