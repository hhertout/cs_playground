FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . .

EXPOSE 4000