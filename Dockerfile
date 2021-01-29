FROM mcr.microsoft.com/dotnet/sdk:5.0 as base

WORKDIR /workspace
<<<<<<< HEAD
COPY FlutterDotNET .
=======
COPY FlutterDotNETWithAPI .
>>>>>>> 41f2fbb8d5494f37af901d8d9b8e7901e26dbaf7
RUN dotnet build
RUN dotnet publish -c Release -o out FlutterWeb.Client/FlutterWeb.Client.csproj

FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /publish
COPY --from=base workspace/out .
CMD ["dotnet", "Flutter.Client.dll"]
