#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservice/Login/LoginAPI/Login.API.csproj", "Microservice/Login/LoginAPI/"]
COPY ["Microservice/Login/Login.Application/Login.Application.csproj", "Microservice/Login/Login.Application/"]
COPY ["Microservice/Login/Login.Domain/Login.Domain.csproj", "Microservice/Login/Login.Domain/"]
COPY ["Microservice/Login/Login.Infrastructure/Login.Infrastructure.csproj", "Microservice/Login/Login.Infrastructure/"]
RUN dotnet restore "Microservice/Login/LoginAPI/Login.API.csproj"
COPY . .
WORKDIR "/src/Microservice/Login/LoginAPI"
RUN dotnet build "Login.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Login.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Login.API.dll"]