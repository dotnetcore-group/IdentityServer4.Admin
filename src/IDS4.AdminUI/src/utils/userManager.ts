import * as oidc from 'oidc-client';
import storageManager from './storageManager';
import UserProfile from '../@types/userProfile';
import oidcResponse from '../@types/oidcResponse';

const settings: oidc.UserManagerSettings = {
  authority: 'https://localhost:5005',
  client_id: 'ids4-admin-ui',
  client_secret: '266D5022-5BCA-45FF-BC77-EE013CA2A129',
  redirect_uri: 'http://localhost:8000/signin-callback-oidc',
  response_type: 'token id_token',
  scope: 'openid profile ids4_admin_api',
  filterProtocolClaims: true,
  loadUserInfo: false,
  automaticSilentRenew: true,
  silent_redirect_uri: 'http://localhost:8000/silent-refresh',
};

export class UserManager extends oidc.UserManager {
  public getAccessToken(): string {
    const response: oidcResponse = storageManager.retrieve('oidc.user', {});
    const { token_type, access_token } = response;

    return `${token_type} ${access_token}`;
  }

  public storeOidcUser(response: oidcResponse) {
    storageManager.store('oidc.user', response);
  }

  // signinSilent() {
  //     return super.signinSilent({
  //         scope: settings.scope,
  //         response_type: settings.response_type
  //     });
  // }

  currentUser: UserProfile = storageManager.retrieve('oidc.user', {}).profile;

  oidcUser: oidcResponse = storageManager.retrieve('oidc.user', {});
}

const userManager = new UserManager(settings);

export default userManager;
