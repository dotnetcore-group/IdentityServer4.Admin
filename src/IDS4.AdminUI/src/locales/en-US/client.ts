export default {
    'pages.clients.list.table.client.add': 'Add Client',
    'pages.clients.list.table.client.id': 'Client ID',
    'pages.clients.list.table.client.name': 'Display Name',
    'pages.clients.list.table.client.logo': 'LOGO',
    'pages.clients.list.table.client.enabled': 'Enabled',
    'pages.clients.list.table.remove.confirm': 'Are you sure you want to delete it?',

    /**Edit Client Page */
    'pages.clients.edit.update.successful': 'Update Successful!',

    'pages.clients.edit.tabs.basic': 'Basic',
    'pages.clients.edit.tabs.settings': 'Advanced Setting',
    'pages.clients.edit.tabs.authentication': 'Authentication',
    'pages.clients.edit.tabs.token': 'Token',
    'pages.clients.edit.tabs.deviceflow': 'Device Flow',
    'pages.clients.edit.tabs.panel.clientId': 'Client Id',
    'pages.clients.edit.tabs.panel.clientName': 'Client Name',
    'pages.clients.edit.tabs.panel.clientUri': 'Client Uri',
    'pages.clients.edit.tabs.panel.logoUri': 'Logo Uri',
    'pages.clients.edit.tabs.panel.description': 'Description',
    'pages.clients.edit.tabs.panel.enabled': 'Enabled',
    'pages.clients.edit.tabs.panel.protocolType': 'Protocol Type',
    'pages.clients.edit.tabs.panel.requireClientSecret': 'Require Client Secret',
    'pages.clients.edit.tabs.panel.requirePkce': 'Require Pkce',
    'pages.clients.edit.tabs.panel.allowPlainTextPkce': 'Allow Plain Text Pkce',
    'pages.clients.edit.tabs.panel.allowOfflineAccess': 'Allow Offline Access',
    'pages.clients.edit.tabs.panel.allowAccessTokensViaBrowser': 'Allow Access Tokens Via Browser',
    'pages.clients.edit.tabs.panel.allowedScopes': 'Allowed Scopes',
    'pages.clients.edit.tabs.addscope': 'Add Scope',
    'pages.clients.edit.tabs.panel.redirectUris': 'Redirect Uris',
    'pages.clients.edit.tabs.addredirecturi': 'Add Redirect Uri',
    'pages.clients.edit.tabs.panel.allowedGrantTypes': 'Allowed Grant Types',
    'pages.clients.edit.tabs.panel.requireConsentScreen': 'Require Consent Screen',
    'pages.clients.edit.tabs.panel.clientSecrets': 'Client Secrets',
    'pages.clients.edit.tabs.panel.properties': 'Properties',
    'pages.clients.edit.tabs.panel.frontChannelLogoutUri': 'Front Channel Logout Uri',
    'pages.clients.edit.tabs.panel.frontChannelLogoutSessionRequired':
        'Front Channel Logout Session Required',
    'pages.clients.edit.tabs.panel.backChannelLogoutUri': 'Back Channel Logout Uri',
    'pages.clients.edit.tabs.panel.backChannelLogoutSessionRequired':
        'Back Channel Logout Session Required',
    'pages.clients.edit.tabs.panel.identityProviderRestrictions': 'Identity Provider Restrictions',
    'pages.clients.edit.tabs.addrestriction': 'Add Restriction',
    'pages.clients.edit.tabs.panel.allowedCorsOrigins': 'Allowed Cors Origins',
    'pages.clients.edit.tabs.addorigin': 'Add Origin',
    'pages.clients.edit.tabs.panel.identityTokenLifetime': 'Identity Token Lifetime (s)',
    'pages.clients.edit.tabs.panel.accessTokenLifetime': 'Access Token Lifetime (s)',
    'pages.clients.edit.tabs.panel.accessTokenType': 'Access Token Type',
    'pages.clients.edit.tabs.panel.authorizationCodeLifetime': 'Authorization Code Lifetime (s)',
    'pages.clients.edit.tabs.panel.absoluteRefreshTokenLifetime':
        'Absolute Refresh Token Lifetime (s)',
    'pages.clients.edit.tabs.panel.slidingRefreshTokenLifetime': 'Sliding Refresh Token Lifetime (s)',
    'pages.clients.edit.tabs.panel.refreshTokenUsage': 'Refresh Token Usage',
    'pages.clients.edit.tabs.panel.refreshTokenUsage.reuse': 'ReUse',
    'pages.clients.edit.tabs.panel.refreshTokenUsage.onetimeonly': 'One Time Only',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration': 'Refresh Token Expiration',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration.sliding': 'Sliding',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration.absolute': 'Absolute',
    'pages.clients.edit.tabs.panel.updateAccessTokenClaimsOnRefresh':
        'Update Access Token Claims On Refresh',
    'pages.clients.edit.tabs.panel.includeJwtId': 'Include Jwt Id',
    'pages.clients.edit.tabs.panel.alwaysSendClientClaims': 'Always Send Client Claims',
    'pages.clients.edit.tabs.panel.alwaysIncludeUserClaimsInIdToken':
        'Always Include User Claims In IdToken',
    'pages.clients.edit.tabs.panel.pairWiseSubjectSalt': 'Pair Wise Subject Salt',
    'pages.clients.edit.tabs.panel.clientClaimsPrefix': 'Client Claims Prefix',
    'pages.clients.edit.tabs.panel.claims': 'Claims',
    'pages.clients.edit.tabs.panel.userCodeType': 'User Code Type',
    'pages.clients.edit.tabs.panel.deviceCodeLifetime': 'Device Code Lifetime (s)',

    'pages.clients.edit.tabs.panel.clientId.tip': 'Unique ID of the client.',
    'pages.clients.edit.tabs.panel.clientName.tip':
        'Client display name (used for logging and consent screen).',
    'pages.clients.edit.tabs.panel.clientUri.tip':
        'URI to further information about client (used on consent screen).',
    'pages.clients.edit.tabs.panel.logoUri.tip': 'URI to client logo (used on consent screen).',
    'pages.clients.edit.tabs.panel.description.tip': 'Description of the client.',
    'pages.clients.edit.tabs.panel.enabled.tip': 'Specifies if client is enabled (defaults to true).',
    'pages.clients.edit.tabs.panel.requireClientSecret.tip':
        'If set to false, no client secret is needed to request tokens at the token endpoint (defaults to true).',
    'pages.clients.edit.tabs.panel.requirePkce.tip':
        'Specifies whether a proof key is required for authorization code based token requests (defaults to false).',
    'pages.clients.edit.tabs.panel.allowPlainTextPkce.tip':
        'Specifies whether a proof key can be sent using plain method (not recommended and defaults to false).',
    'pages.clients.edit.tabs.panel.allowOfflineAccess.tip':
        'Indicating whether [allow offline access]. Defaults to false.',
    'pages.clients.edit.tabs.panel.allowAccessTokensViaBrowser.tip':
        'Controls whether access tokens are transmitted via the browser for this client (defaults to false). This can prevent accidental leakage of access tokens when multiple response types are allowed.',
    'pages.clients.edit.tabs.panel.allowedScopes.tip':
        "Specifies the api scopes that the client is allowed to request. If empty, the client can't access any scope.",
    'pages.clients.edit.tabs.panel.redirectUris.tip':
        'Specifies allowed URIs to return tokens or authorization codes to.',
    'pages.clients.edit.tabs.panel.allowedGrantTypes.tip':
        'Specifies the allowed grant types (legal combinations of AuthorizationCode, Implicit, Hybrid, ResourceOwner, ClientCredentials).',
    'pages.clients.edit.tabs.panel.requireConsentScreen.tip':
        'Specifies whether a consent screen is required (defaults to true).',
    'pages.clients.edit.tabs.panel.clientSecrets.tip':
        'Client secrets - only relevant for flows that require a secret',
    'pages.clients.edit.tabs.panel.properties.tip': 'Custom properties for the client',
    'pages.clients.edit.tabs.panel.frontChannelLogoutUri.tip':
        'Specifies logout URI at client for HTTP front-channel based logout.',
    'pages.clients.edit.tabs.panel.frontChannelLogoutSessionRequired.tip':
        "Specifies is the user's session id should be sent to the FrontChannelLogoutUri (defaults to true).",
    'pages.clients.edit.tabs.panel.backChannelLogoutUri.tip':
        'Specifies logout URI at client for HTTP back-channel based logout.',
    'pages.clients.edit.tabs.panel.backChannelLogoutSessionRequired.tip':
        "Specifies is the user's session id should be sent to the BackChannelLogoutUri (defaults to true).",
    'pages.clients.edit.tabs.panel.identityProviderRestrictions.tip':
        'Specifies which external IdPs can be used with this client (if list is empty all IdPs are allowed). Defaults to empty.',
    'pages.clients.edit.tabs.panel.allowedCorsOrigins.tip':
        'Allowed CORS origins for JavaScript clients.',
    'pages.clients.edit.tabs.panel.identityTokenLifetime.tip':
        'Lifetime of identity token in seconds (defaults to 300 seconds / 5 minutes).',
    'pages.clients.edit.tabs.panel.accessTokenLifetime.tip':
        'Lifetime of access token in seconds (defaults to 3600 seconds / 1 hour).',
    'pages.clients.edit.tabs.panel.accessTokenType.tip':
        'Specifies whether the access token is a reference token or a self contained JWT token (defaults to Jwt).',
    'pages.clients.edit.tabs.panel.authorizationCodeLifetime.tip':
        'Lifetime of authorization code in seconds (defaults to 300 seconds / 5 minutes).',
    'pages.clients.edit.tabs.panel.absoluteRefreshTokenLifetime.tip':
        'Maximum lifetime of a refresh token in seconds. Defaults to 2592000 seconds / 30 days.',
    'pages.clients.edit.tabs.panel.slidingRefreshTokenLifetime.tip':
        'Sliding lifetime of a refresh token in seconds. Defaults to 1296000 seconds / 15 days.',
    'pages.clients.edit.tabs.panel.refreshTokenUsage.tip':
        'Refresh token handle when refreshing tokens.',
    'pages.clients.edit.tabs.panel.refreshTokenUsage.reuse.tip':
        'The refresh token handle will stay the same when refreshing tokens.',
    'pages.clients.edit.tabs.panel.refreshTokenUsage.onetimeonly.tip':
        'The refresh token handle will be updated when refreshing tokens.',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration.tip':
        'The lifetime will not exceed AbsoluteRefreshTokenLifetime.',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration.sliding.tip':
        'The refresh token will expire on a fixed point in time (specified by the AbsoluteRefreshTokenLifetime).',
    'pages.clients.edit.tabs.panel.refreshTokenExpiration.absolute.tip':
        'When refreshing the token, the lifetime of the refresh token will be renewed (by the amount specified in SlidingRefreshTokenLifetime).',
    'pages.clients.edit.tabs.panel.updateAccessTokenClaimsOnRefresh.tip':
        'Indicating whether the access token (and its claims) should be updated on a refresh token request (defaults to false).',
    'pages.clients.edit.tabs.panel.includeJwtId.tip':
        'Indicating whether JWT access tokens should include an identifier. Defaults to false.',
    'pages.clients.edit.tabs.panel.alwaysSendClientClaims.tip':
        'Indicating whether client claims should be always included in the access tokens - or only for client credentials flow. Defaults to false.',
    'pages.clients.edit.tabs.panel.alwaysIncludeUserClaimsInIdToken.tip':
        'When requesting both an id token and access token, should the user claims always be added to the id token instead of requring the client to use the userinfo endpoint. Defaults to false.',
    'pages.clients.edit.tabs.panel.pairWiseSubjectSalt.tip':
        'Used in pair-wise subjectId generation for users of this client.',
    'pages.clients.edit.tabs.panel.clientClaimsPrefix.tip':
        'Prefix it on client claim types. Defaults to client_.',
    'pages.clients.edit.tabs.panel.claims.tip':
        'Allows settings claims for the client (will be included in the access token).',
    'pages.clients.edit.tabs.panel.userCodeType.tip': 'The type of the device flow user code.',
    'pages.clients.edit.tabs.panel.deviceCodeLifetime.tip':
        'Lifetime of device code in seconds (defaults to 300 seconds / 5 minutes).',




    /**Client Secrets */
    'pages.clients.secrets.table.title.value': 'Secret Value',
    'pages.clients.secrets.table.title.type': 'Secret Type',
    'pages.clients.secrets.table.title.description': 'Description',
    'pages.clients.secrets.table.title.expiration': 'Expiration',
    'pages.clients.secrets.add.value': 'Secret Value',
    'pages.clients.secrets.add.submit': 'Create',
    'pages.clients.secrets.add.type': 'Secret Type',
    'pages.clients.secrets.add.hashtype': 'Hash Type',
    'pages.clients.secrets.add.expiration': 'Expiration',
    'pages.clients.secrets.add.description': 'Description',
};
