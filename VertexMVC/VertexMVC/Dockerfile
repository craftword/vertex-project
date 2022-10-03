#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["VertexMVC/VertexMVC.csproj", "VertexMVC/"]
COPY ["VertexInfrastrature/VertexInfrastrature.csproj", "VertexInfrastrature/"]
COPY ["VertexCore/VertexCore.csproj", "VertexCore/"]
RUN dotnet restore "VertexMVC/VertexMVC.csproj"
COPY . .
WORKDIR "/src/VertexMVC"
RUN dotnet build "VertexMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VertexMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VertexMVC.dll"]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet VertexMVC.dll
