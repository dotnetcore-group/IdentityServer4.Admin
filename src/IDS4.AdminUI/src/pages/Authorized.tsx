import { ConnectProps, ConnectState, UserModelState } from '@/models/connect';
import React from 'react';
import { connect } from 'dva';
import Redirect from 'umi/redirect';

interface AuthComponentProps extends ConnectProps {
    user: UserModelState;
}

const AuthComponent: React.FC<AuthComponentProps> = ({
    children,
    user,
}) => {
    const { currentUser } = user;
    const isLogin = currentUser && currentUser.name;

    if (isLogin) {
        return <>{children}</>;
    }
    return <Redirect to="/user/login"></Redirect>
};

export default connect(({ user }: ConnectState) => ({
    user,
}))(AuthComponent);
