FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5180

ENV ASPNETCORE_URLS=http://+:5180

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["dotnet-mvc.csproj", "./"]
RUN dotnet restore "dotnet-mvc.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "dotnet-mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnet-mvc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnet-mvc.dll"]
