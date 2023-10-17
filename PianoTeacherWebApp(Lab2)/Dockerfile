#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PianoTeacherWebApp(Lab2)/PianoTeacherWebApp(Lab2).csproj", "PianoTeacherWebApp(Lab2)/"]
RUN dotnet restore "PianoTeacherWebApp(Lab2)/PianoTeacherWebApp(Lab2).csproj"
COPY . .
WORKDIR "/src/PianoTeacherWebApp(Lab2)"
RUN dotnet build "PianoTeacherWebApp(Lab2).csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PianoTeacherWebApp(Lab2).csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PianoTeacherWebApp(Lab2).dll"]