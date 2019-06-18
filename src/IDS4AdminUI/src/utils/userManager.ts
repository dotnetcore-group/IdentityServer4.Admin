import * as oidc from 'oidc-client';

const settings = {
    authority: "https://localhost:5005",
    client_id: 'ids4-admin-ui',
    client_secret: '266D5022-5BCA-45FF-BC77-EE013CA2A129',
    redirect_uri: 'http://localhost:8000/signin-callback-oidc',
    response_type: 'token id_token',
    scope: 'openid profile',
    automaticSilentRenew: true,
    filterProtocolClaims: true,
    loadUserInfo: true,
};

const userManager = new oidc.UserManager(settings);


export default userManager;
