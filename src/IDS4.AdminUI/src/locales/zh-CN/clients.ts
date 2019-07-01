export default {
    'pages.clients.list.table.client.add': '添加客户端',
    'pages.clients.list.table.client.id': '客户端ID',
    'pages.clients.list.table.client.name': '客户端名称',
    'pages.clients.list.table.client.logo': '图标',
    'pages.clients.list.table.client.enabled': '状态',
    'pages.clients.list.table.remove.confirm': '确定要删除吗？',

    /** Add Client Page */
    'pages.clients.add.goback': '返回列表',
    'pages.clients.add.form.clientid': '客户端ID',
    'pages.clients.add.form.clientid.tip': '客户端唯一ID',
    'pages.clients.add.form.clientid.required': '请输入客户端ID',
    'pages.clients.add.form.clientname': '客户端名称',
    'pages.clients.add.form.clientname.tip': '显示名称（用于用户登录显示客户端名称）',
    'pages.clients.add.form.clientname.required': '请输入客户端名称',
    'pages.clients.add.form.clienturi': '客户端地址',
    'pages.clients.add.form.clienturi.tip': '客户端地址',
    'pages.clients.add.form.logouri': 'LOGO地址',
    'pages.clients.add.form.logouri.tip': '客户端的LOGO地址',
    'pages.clients.add.form.description': '描述',
    'pages.clients.add.form.description.tip': '客户端的详细描述',
    'pages.clients.add.from.create': '创建',

    /**Edit Client Page */
    'pages.clients.edit.update.successful': '更新成功！',

    'pages.clients.edit.tabs.basic': '基础',
    'pages.clients.edit.tabs.settings': '高级',
    'pages.clients.edit.tabs.authentication': '身份认证',
    'pages.clients.edit.tabs.token': '令牌',
    'pages.clients.edit.tabs.deviceflow': '设备流',
    'pages.clients.edit.tabs.addscope': '添加范围',
    'pages.clients.edit.tabs.addredirecturi': '添加跳转地址',
    'pages.clients.edit.tabs.addrestriction': '添加限制',
    'pages.clients.edit.tabs.addorigin': '添加源',
    'pages.clients.edit.tabs.panel.clientId': '客户端ID',
    'pages.clients.edit.tabs.panel.clientName': '客户端名称',
    'pages.clients.edit.tabs.panel.clientUri': '客户端地址',
    'pages.clients.edit.tabs.panel.logoUri': '图标地址',
    'pages.clients.edit.tabs.panel.description': '描述',
    'pages.clients.edit.tabs.panel.enabled': '启用状态',
    'pages.clients.edit.tabs.panel.protocolType': '协议类型',
    'pages.clients.edit.tabs.panel.requireClientSecret': '需要客户端 Secret',
    'pages.clients.edit.tabs.panel.requirePkce': '需要 Pkce',
    'pages.clients.edit.tabs.panel.allowPlainTextPkce': '允许纯文本 Pkce',
    'pages.clients.edit.tabs.panel.allowOfflineAccess': '允许离线访问',
    'pages.clients.edit.tabs.panel.allowAccessTokensViaBrowser': '允许通过浏览器访问令牌',
    'pages.clients.edit.tabs.panel.allowedScopes': '允许范围',
    'pages.clients.edit.tabs.panel.redirectUris': '重定向地址',
    'pages.clients.edit.tabs.panel.allowedGrantTypes': '允许授权类型',
    'pages.clients.edit.tabs.panel.requireConsentScreen': '需要用户同意',
    'pages.clients.edit.tabs.panel.clientSecrets': '机密',
    'pages.clients.edit.tabs.panel.properties': '属性',
    'pages.clients.edit.tabs.panel.frontChannelLogoutUri': '前端通道注销地址',
    'pages.clients.edit.tabs.panel.frontChannelLogoutSessionRequired': '需要前端通道注销会话',
    'pages.clients.edit.tabs.panel.backChannelLogoutUri': '反向通道注销地址',
    'pages.clients.edit.tabs.panel.backChannelLogoutSessionRequired': '需要反向通道注销会话',
    'pages.clients.edit.tabs.panel.identityProviderRestrictions': '身份提供商限制',
    'pages.clients.edit.tabs.panel.allowedCorsOrigins': '允许跨域的源地址',
    'pages.clients.edit.tabs.panel.identityTokenLifetime': '身份令牌生命周期（秒）',
    'pages.clients.edit.tabs.panel.accessTokenLifetime': '访问令牌生命周期（秒）',
    'pages.clients.edit.tabs.panel.accessTokenType': '访问令牌类型',
    'pages.clients.edit.tabs.panel.authorizationCodeLifetime': '授权码生命周期（秒）',
    'pages.clients.edit.tabs.panel.absoluteRefreshTokenLifetime': '绝对刷新令牌生命周期（秒）',
    'pages.clients.edit.tabs.panel.slidingRefreshTokenLifetime': '滑动刷新令牌生命周期（秒）',
    'pages.clients.edit.tabs.panel.refreshTokenUsage': '刷新令牌使用情况',
    'pages.clients.edit.tabs.panel.refreshTokenUsage.reuse': '重复使用',
    'pages.clients.edit.tabs.panel.refreshTokenUsage.onetimeonly': '仅一次',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration': '刷新令牌过期类型',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration.sliding': '滑动',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration.absolute': '绝对',
    'pages.clients.edit.tabs.panel.updateAccessTokenClaimsOnRefresh': '刷新时更新访问令牌声明',
    'pages.clients.edit.tabs.panel.includeJwtId': '包括Jwt Id',
    'pages.clients.edit.tabs.panel.alwaysSendClientClaims': '始终发送客户端声明',
    'pages.clients.edit.tabs.panel.alwaysIncludeUserClaimsInIdToken': '始终在 IdToken 中包含用户声明',
    'pages.clients.edit.tabs.panel.pairWiseSubjectSalt': '盐',
    'pages.clients.edit.tabs.panel.clientClaimsPrefix': '客户端声明前缀',
    'pages.clients.edit.tabs.panel.claims': '声明',
    'pages.clients.edit.tabs.panel.userCodeType': '用户代码类型',
    'pages.clients.edit.tabs.panel.deviceCodeLifetime': '设备代码生命周期（秒）',

    'pages.clients.edit.tabs.panel.clientId.tip': '客户的唯一 ID。',
    'pages.clients.edit.tabs.panel.clientName.tip': '客户端显示名称（用于记录和同意屏幕）。',
    'pages.clients.edit.tabs.panel.clientUri.tip': '有关客户端的更多信息的URI（在同意屏幕上使用）。',
    'pages.clients.edit.tabs.panel.logoUri.tip': '客户端徽标的 URI（在同意屏幕上使用）。',
    'pages.clients.edit.tabs.panel.description.tip': '客户端描述。',
    'pages.clients.edit.tabs.panel.enabled.tip': '指定是否启用客户端（默认为 true）。',
    'pages.clients.edit.tabs.panel.requireClientSecret.tip':
        '如果设置为 false，则在令牌端点请求令牌不需要客户端密码（默认为 true）。',
    'pages.clients.edit.tabs.panel.requirePkce.tip':
        '指定基于授权码的令牌请求是否需要证明密钥（默认为 false）。',
    'pages.clients.edit.tabs.panel.allowPlainTextPkce.tip':
        '指定是否可以使用普通方法发送校样密钥（不推荐使用，默认为 false）。',
    'pages.clients.edit.tabs.panel.allowOfflineAccess.tip': '表示是否 [允许离线访问]。默认为 false。',
    'pages.clients.edit.tabs.panel.allowAccessTokensViaBrowser.tip':
        '控制是否通过浏览器为此客户端传输访问令牌（默认为 false）。这可以防止在允许多种响应类型时意外泄漏访问令牌。 ',
    'pages.clients.edit.tabs.panel.allowedScopes.tip':
        '指定允许客户端请求的 api 作用域。如果为空，则客户端无法访问任何作用域。',
    'pages.clients.edit.tabs.panel.redirectUris.tip': '指定允许的 URI 返回令牌或授权码。',
    'pages.clients.edit.tabs.panel.allowedGrantTypes.tip':
        '指定允许的授权类型（AuthorizationCode, Implicit, Hybrid, ResourceOwner, ClientCredentials 的合法组合）。',
    'pages.clients.edit.tabs.panel.requireConsentScreen.tip': '指定是否需要同意屏幕（默认为true）。',
    'pages.clients.edit.tabs.panel.clientSecrets.tip': '仅与需要保密的流量相关',
    'pages.clients.edit.tabs.panel.properties.tip': '客户端的自定义属性',
    'pages.clients.edit.tabs.panel.frontChannelLogoutUri.tip':
        '指定客户端的注销URI，用于基于HTTP前端通道的注销。',
    'pages.clients.edit.tabs.panel.frontChannelLogoutSessionRequired.tip':
        '指定是否应将用户的会话ID发送到 FrontChannelLogoutUri（默认为true）。',
    'pages.clients.edit.tabs.panel.backChannelLogoutUri.tip':
        '指定客户端的注销URI，用于基于HTTP反向通道的注销。',
    'pages.clients.edit.tabs.panel.backChannelLogoutSessionRequired.tip':
        '指定是否应将用户的会话ID发送到 BackChannelLogoutUri（默认为true）。',
    'pages.clients.edit.tabs.panel.identityProviderRestrictions.tip':
        '指定哪个外部IdP可以与此客户端一起使用（如果列表为空,则允许所有IdP。）默认为空。',
    'pages.clients.edit.tabs.panel.allowedCorsOrigins.tip': '允许 JavaScript 客户端的 CORS 源。',
    'pages.clients.edit.tabs.panel.identityTokenLifetime.tip':
        '身份令牌的生命周期，以秒为单位（默认为300秒/ 5分钟）。',
    'pages.clients.edit.tabs.panel.accessTokenLifetime.tip':
        '访问令牌的生命周期，以秒为单位（默认为3600秒/ 1小时）。',
    'pages.clients.edit.tabs.panel.accessTokenType.tip':
        '指定访问令牌是引用令牌还是自包含的 JWT 令牌（默认为Jwt）。',
    'pages.clients.edit.tabs.panel.authorizationCodeLifetime.tip':
        '授权代码的生命周期，以秒为单位（默认为300秒/ 5分钟）。',
    'pages.clients.edit.tabs.panel.absoluteRefreshTokenLifetime.tip':
        '刷新令牌的最长生命周期，以秒为单位。默认为2592000秒/ 30天。',
    'pages.clients.edit.tabs.panel.slidingRefreshTokenLifetime.tip':
        '刷新令牌的滑动生命周期，以秒为单位。默认为1296000秒/ 15天。',
    'pages.clients.edit.tabs.panel.refreshTokenUsage.tip': '刷新令牌时刷新令牌句柄。',
    'pages.clients.edit.tabs.panel.refreshTokenUsage.reuse.tip':
        '在刷新令牌时，刷新令牌句柄将保持不变。',
    'pages.clients.edit.tabs.panel.refreshTokenUsage.onetimeonly.tip':
        '刷新令牌时将更新刷新令牌句柄。',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration.tip':
        '生命周期不会超过 AbsoluteRefreshTokenLifetime。',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration.sliding.tip':
        '刷新令牌将在一个固定的时间点到期（由 AbsoluteRefreshTokenLifetime 指定）。',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration.absolute.tip':
        '刷新令牌时，刷新令牌的生命周期将被更新（按 SlidingRefreshTokenLifetime 中指定的值）。',
    'pages.clients.edit.tabs.panel.updateAccessTokenClaimsOnRefresh.tip':
        '指示是否应该在刷新令牌请求上更新访问令牌（及其声明）（默认为 false）。',
    'pages.clients.edit.tabs.panel.includeJwtId.tip':
        '指示 JWT 访问令牌是否应包含标识符。默认为 false。',
    'pages.clients.edit.tabs.panel.alwaysSendClientClaims.tip':
        '指示客户端声明是否应始终包含在访问令牌中 - 或仅用于客户端凭据流。默认为 false。',
    'pages.clients.edit.tabs.panel.alwaysIncludeUserClaimsInIdToken.tip':
        '当同时请求 IdToken 和 AccessToken 时,用户是否应声明始终将其添加到 IdToken，而不是要求客户端使用 userinfo 端点。默认为 false。',
    'pages.clients.edit.tabs.panel.pairWiseSubjectSalt.tip':
        '用于此客户端用户的成对 subjectId 生成。',
    'pages.clients.edit.tabs.panel.clientClaimsPrefix.tip':
        '在客户端声明类型上加前缀。默认为 client_。',
    'pages.clients.edit.tabs.panel.claims.tip': '允许客户端的设置声明（将包含在访问令牌中）。',
    'pages.clients.edit.tabs.panel.userCodeType.tip': '设备流用户代码的类型。',
    'pages.clients.edit.tabs.panel.deviceCodeLifetime.tip':
        '设备代码的生命周期，以秒为单位（默认为300秒/ 5分钟）。',



    /**Client Secrets */
    'pages.clients.secrets.add': '添加机密',
    'pages.clients.secrets.table.remove.confirm':'你确定要删除吗？',
    'pages.clients.secrets.table.title.value': 'Secret 值',
    'pages.clients.secrets.table.title.type': 'Secret 类型',
    'pages.clients.secrets.table.title.description': '描述',
    'pages.clients.secrets.table.title.expiration': '过期时间',
    'pages.clients.secrets.add.value': '值',
    'pages.clients.secrets.add.submit': '创建',
    'pages.clients.secrets.add.type': '机密类型',
    'pages.clients.secrets.add.hashtype': '哈希方式',
    'pages.clients.secrets.add.expiration': '过期时间',
    'pages.clients.secrets.add.description': '描述',

    /**Client Properties */
    'pages.clients.properties.add':'添加属性',
    'pages.clients.properties.table.title.key':'键',
    'pages.clients.properties.table.title.value':'值',
    'pages.clients.properties.table.remove.confirm':'你确定要删除这个属性吗？'
};
