import React from 'react';
import userManager from '@/utils/userManager';
class Login extends React.Component {

    onLoginButtonClick = (event: any) => {
        event.preventDefault();
        userManager.signinRedirect();
    }

    render() {
        return (
            <div>
                <h3>Welcome to the redux-oidc sample app!</h3>
                <p>Please log in to continue</p>
                <button onClick={this.onLoginButtonClick}>Login with Google</button>
            </div>
        );
    }
}

export default Login;
