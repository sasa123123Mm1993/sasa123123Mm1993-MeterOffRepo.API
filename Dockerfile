# Use the official .NET 7 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the solution file and restore dependencies
COPY SolutionBasic.sln ./
COPY MeterOff.API/MeterOff.API.csproj MeterOff.API/
COPY MeterOff.Core/MeterOff.Core.csproj MeterOff.Core/
COPY MeterOff.EF/MeterOff.EF.csproj MeterOff.EF/

# Restore the dependencies
RUN dotnet restore MeterOff.API/MeterOff.API.csproj

# Copy the rest of the project files
COPY . .

# Build the project and publish the output to a folder
RUN dotnet publish MeterOff.API/MeterOff.API.csproj -c Release -o /app/publish

# Use a runtime image to keep the container lightweight
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy the build artifacts from the SDK image to the runtime image
COPY --from=build /app/publish .

# Expose the port on which your API will run
EXPOSE 80

# Start the API
ENTRYPOINT ["dotnet", "MeterOff.API.dll"]
