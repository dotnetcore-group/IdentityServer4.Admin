import React from "react";
import { connect } from "dva";
import userManager from "@/utils/userManager";
import oidcResponse from "@/@types/oidcResponse";

class SigninCallback extends React.Component<any> {

    onRedirectSuccess = (response: oidcResponse) => {
        console.log(response);
        const { dispatch } = this.props;
        dispatch({
            type: 'user/saveOidcResponse',
            payload: response
        });
    }

    onRedirectError = (error: any) => {
        console.error(error);
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

export default connect()(SigninCallback);