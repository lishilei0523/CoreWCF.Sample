FROM mcr.microsoft.com/dotnet/aspnet:3.1
MAINTAINER Lee <lishilei0523@163.com>
WORKDIR /app
EXPOSE 4071
EXPOSE 40710
COPY ./publish .
ENTRYPOINT ["dotnet", "Sample.AppService.Host.dll"]