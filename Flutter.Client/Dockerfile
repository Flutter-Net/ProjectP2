FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Flutter.Client/Flutter.Client.csproj", "Flutter.Client/"]
RUN dotnet restore "Flutter.Client/Flutter.Client.csproj"
COPY . .
WORKDIR "/src/Flutter.Client"
RUN dotnet build "Flutter.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Flutter.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Flutter.Client.dll"]
