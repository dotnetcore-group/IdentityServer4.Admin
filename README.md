
<h1 align="center">IdentityServer4 AdminUI</h1>

<p align="center"><img src="./ids4-admin.png"/>
<p align="center">IdentityServer4 AdminUI and Single Sign On</p>


[![Build Status](https://zengande.visualstudio.com/IdentityServer4%20Admin/_apis/build/status/zengande.IdentityServer4.Admin?branchName=master)](https://zengande.visualstudio.com/IdentityServer4%20Admin/_build/latest?definitionId=2&branchName=master)
[![Licensed under the MIT License](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/zengande/IdentityServer4.Admin/blob/master/LICENSE)

> This project is only a demonstration project, do not use it in production! 

## run in docker
1. replace your ip address:
- `.env` : `EXTERNAL_DNS_NAME_OR_IP=[your ip]`
- `src\IDS4.AdminUI\docker\nginx.conf` : `proxy_pass http://[your ip]:5004`
- `src\IDS4.AdminUI\config\config.ts` : `define: ...`

2. start up
run `docker-compose up --build` command in the root directory.

3. open in browser
- AdminUI: `http:[your ip]:8000`
- SSO: `http:[your ip]:5006`
- API: `http:[your ip]:5004/swagger/index.html`