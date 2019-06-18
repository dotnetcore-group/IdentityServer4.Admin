import React from 'react';
import { connect } from 'dva';
import { Redirect } from 'react-router';

class Authoirze extends React.Component {
    render() {
        const { oidc = {}, children } = this.props;
        const { profile } = oidc;
        if (!profile) {
            return <Redirect to="/login" />
        }
        return (
            <React.Fragment>
                {children}
            </React.Fragment>
        )
    }
}

export default connect(({ oidc }) => ({ oidc }))(Authoirze);