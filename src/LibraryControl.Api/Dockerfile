FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/LibraryControl.Api/LibraryControl.Api.csproj", "LibraryControl.Api/"]
RUN dotnet restore "src/LibraryControl.Api/LibraryControl.Api.csproj"
COPY . .
WORKDIR "/src/LibraryControl.Api"
RUN dotnet build "LibraryControl.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryControl.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryControl.Api.dll"]
