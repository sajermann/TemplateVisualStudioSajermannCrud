# Stage 1
FROM mcr.microsoft.com/dotnet/sdk:3.1-buster AS build
WORKDIR /build
COPY /src .
COPY nuget.config .
RUN dotnet restore path/file.csproj
RUN dotnet publish path/file.csproj -c Release -o /app

# Stage 2
FROM mcr.microsoft.com/dotnet/aspnet:3.1-buster-slim AS final
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "dll file"]