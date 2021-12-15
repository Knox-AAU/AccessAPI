FROM mcr.microsoft.com/dotnet/sdk:5.0  AS build-env
WORKDIR /app
# Copy csproj and restore as distinct layers
# the csproj references requires this structure
COPY Access API/Access API/Access API.csproj ./Access API/Access API/
# Restore metadata and dependencies
RUN dotnet restore ./Access API/Access API/Access API.csproj
# Copy everything else and build
COPY . ./
RUN dotnet publish ./Access API/Access API/Access API.csproj -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 8081
ENTRYPOINT ["dotnet", "AccessAPI.dll"]