FROM mcr.microsoft.com/dotnet/sdk:5.0 as base

WORKDIR /workspace
COPY FlutterDotNET .
RUN dotnet build
RUN dotnet publish -c Release -o out Flutter.Client/Flutter.Client.csproj

FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /publish
COPY --from=base workspace/out .
CMD ["dotnet", "Flutter.Client.dll"]
