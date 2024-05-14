FROM httpd:alpine AS base

ARG VERSION=undefined

LABEL APP="OnlySpans.PolyLeads.Api"
LABEL REPO="https://github.com/OnlySpans/PolyLeads"
LABEL VERSION="$VERSION"

RUN echo "ErrorDocument 404 /index.html" >> /usr/local/apache2/conf/httpd.conf
EXPOSE 80

FROM oven/bun:latest as deps
WORKDIR /app
COPY ./src/onlyspans.polyleads.ui/package.json .
COPY ./src/onlyspans.polyleads.ui/bunfig.toml .
RUN ["bun", "i", "--verbose"]

FROM node:current-alpine3.19 AS build
WORKDIR /app
COPY --from=deps /app .
COPY ./src/onlyspans.polyleads.ui/ .
RUN npm run build

FROM base AS final
WORKDIR /app
COPY --from=build /app/out /usr/local/apache2/htdocs/
