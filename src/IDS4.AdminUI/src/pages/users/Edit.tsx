import React from 'react';
import { ConnectProps } from '@/models/connect';
import { connect } from 'dva';

export interface IUserEditPageProps extends ConnectProps {

}

class UserEditPage extends React.Component<IUserEditPageProps>{
    componentDidMount() {
        const { match } = this.props;
        if(match){
            const { id } =match.params;
        }
    }

    render() {
        return (
            <div></div>
        )
    }
}

export default connect(({ }) => ({}))(UserEditPage)