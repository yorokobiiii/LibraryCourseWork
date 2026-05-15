# Этап 1: Сборка
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Копируем проект и восстанавливаем зависимости
COPY LibraryOnline.csproj .
RUN dotnet restore

# Копируем код и публикуем
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Этап 2: Запуск
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Копируем результат сборки
COPY --from=build /app/publish .

# Открываем порт
EXPOSE 8080

# Запускаем приложение
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "LibraryOnline.dll"]