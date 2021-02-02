FROM mcr.microsoft.com/dotnet/sdk:5.0 as base

WORKDIR /workspace
COPY FlutterWeb .
RUN dotnet build -c Release
RUN dotnet publish --no-build -c Release -o out FlutterWeb.Client/FlutterWeb.Client.csproj

FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /publish
COPY --from=base workspace/out .
CMD ["dotnet", "Flutter.Client.dll"]
