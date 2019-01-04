FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 63837

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ToDoWebApp/ToDoWebApp.csproj ToDoWebApp/
RUN dotnet restore ToDoWebApp/ToDoWebApp.csproj
COPY . .
WORKDIR /src/ToDoWebApp
RUN dotnet build ToDoWebApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ToDoWebApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ToDoWebApp.dll"]
