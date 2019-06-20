import React from 'react';
import { Button } from 'antd';
import userManager from '@/utils/userManager';

export default class Login extends React.Component {

    Login = () => {
        userManager.signinRedirect();
    }

    render() {
        return (
            <div style={{ textAlign: 'center' }}>
                <Button onClick={this.Login} type="primary">Redirect to login</Button>
            </div>
        )
    }
}