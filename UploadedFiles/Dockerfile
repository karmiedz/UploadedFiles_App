FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /uploaded-files

# kopiujemy plik .csproj oraz używamy polecenia dotnet restore
COPY *.csproj ./
RUN dotnet restore


# kopiujemy i dokonujemy build'a całej reszty
COPY . ./uploaded-files
RUN dotnet build -c Release
ENTRYPOINT ["dotnet", "run", "-c", "Release", "--no-build"]