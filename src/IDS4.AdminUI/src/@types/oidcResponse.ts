import userProfile from './userProfile';

export default interface oidcResponse {
    access_token: string;
    refresh_token: string;
    expires_at: number;
    id_token: string;
    scope: string;
    session_state: string;
    token_type: string;
    profile: userProfile
}