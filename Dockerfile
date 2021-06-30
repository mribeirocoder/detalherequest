ARG REPO=mcr.microsoft.com/dotnet/aspnet
FROM $REPO:5.0-alpine

EXPOSE 80

COPY output/app/ app/

RUN apk add --no-cache tzdata

ENV LOCALE "pt_BR.UTF-8"
ENV LOCALTIME "America/Sao_Paulo"
ENV TZ="America/Sao_Paulo"

WORKDIR app

RUN apk update
RUN apk upgrade

ENTRYPOINT ["dotnet", "detalherequest.dll"]