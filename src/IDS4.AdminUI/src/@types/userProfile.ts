export default interface UserProfile {
    auth_time?: number;
    email?: string;
    email_verified?: boolean;
    idp?: string;
    name?: string;
    nickname?: string;
    preferred_username?: string;
    role?: string;
    sid?: string;
    sub?: string;
    avatar?: string;
}