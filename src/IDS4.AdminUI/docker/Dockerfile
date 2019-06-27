FROM nginx:alpine AS base
WORKDIR /usr/share/nginx/html
EXPOSE 80

FROM centos:7 AS build 

WORKDIR /home
RUN curl --silent --location https://rpm.nodesource.com/setup_10.x | bash -
RUN yum -y install nodejs
RUN curl --silent --location https://dl.yarnpkg.com/rpm/yarn.repo | tee /etc/yum.repos.d/yarn.repo
RUN yum -y install yarn

WORKDIR /src
COPY ["src/IDS4.AdminUI","."]
RUN yarn
RUN yarn run build

FROM base AS final
COPY ["src/IDS4.AdminUI/docker/nginx.conf", "/etc/nginx/"]
WORKDIR /usr/share/nginx/html
COPY --from=build /src/dist .

# COPY ["src/IDS4.AdminUI/dist", "/usr/share/nginx/html"]