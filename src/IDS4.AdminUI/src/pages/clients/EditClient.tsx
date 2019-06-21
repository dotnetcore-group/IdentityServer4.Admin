import React from 'react';
import { Card } from 'antd';
import { formatMessage } from 'umi-plugin-locale';
import { RouteProps } from 'dva/router';
import { ConnectProps, ConnectState } from '../../models/connect';
import { router } from 'umi';
import { connect } from 'dva';
import EditPanel from '@/components/EditClientPanels/EditPanel';



export interface IEditClientProps extends RouteProps, ConnectProps {
    loading?: boolean;
    detail?: any
}

class EditClient extends React.Component<IEditClientProps> {
    state = {
        key: 'basic'
    };

    componentDidMount() {
        const { dispatch, location: { query: { id } } } = this.props;
        if (!id || id === '') {
            router.push('/exception/404');
            return;
        }
        dispatch && dispatch({
            type: 'client/fetchDetail',
            payload: id
        })
    }

    onTabChange = (key: string, type: string) => {
        this.setState({ [type]: key });
    };

    render() {
        const { detail = {} } = this.props;
        const { clientName } = detail;

        console.log(detail);

        return (
            <Card
                style={{ width: '100%',padding: '0px' }}>
                <h1>{clientName}</h1>
                <EditPanel detail={detail} />
            </Card >
        )
    }
}

export default connect(({ client, loading }: ConnectState) => ({
    detail: client.detail,
    loading: loading.effects['client/fetchDetail']
}))(EditClient)