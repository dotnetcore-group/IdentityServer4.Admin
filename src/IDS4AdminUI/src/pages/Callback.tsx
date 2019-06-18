import { connect } from 'dva';
import React from 'react';
import userManager from '@/utils/userManager';
import router from 'umi/router';

class CallbackPage extends React.Component<any> {

    onRedirectSuccess = (response: any) => {
        const { dispatch } = this.props;
        dispatch({
            type: 'oidc/save',
            payload: response
        });
        router.push("/")
    }

    onRedirectError = (error: any) => {
    }

    componentDidMount() {
        userManager.signinRedirectCallback()
            .then((response) => this.onRedirectSuccess(response))
            .catch((error) => this.onRedirectError(error));
    }

    render() {
        return (

            <div>Redirecting...</div>
        );
    }
}

export default connect()(CallbackPage);
