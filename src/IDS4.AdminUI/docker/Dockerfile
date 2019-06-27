FROM nginx:alpine AS base
WORKDIR /usr/share/nginx/html
EXPOSE 80

FROM zengande/yarn:centos7-node10 AS build 

WORKDIR /src
COPY ["src/IDS4.AdminUI","."]
RUN yarn
RUN yarn run build

FROM base AS final
COPY ["src/IDS4.AdminUI/docker/nginx.conf", "/etc/nginx/"]
WORKDIR /usr/share/nginx/html
COPY --from=build /src/dist .

# COPY ["src/IDS4.AdminUI/dist", "/usr/share/nginx/html"]