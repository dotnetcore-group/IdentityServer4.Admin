import React from 'react';
import { Card } from 'antd';
import { formatMessage } from 'umi-plugin-locale';
import { RouteProps } from 'dva/router';
import { ConnectProps, ConnectState } from '../../models/connect';
import { router } from 'umi';
import { connect } from 'dva';
import EditClient from './EditClient';
import EditPanel from '@/components/EditClientPanels/EditPanel';


const tabList = [
    {
        key: 'basic',
        tab: formatMessage({ id: 'pages.clients.edit.tabs.basic', defaultMessage: 'Basic' }),
    },
    {
        key: 'AS',
        tab: formatMessage({ id: 'pages.clients.edit.tabs.settings', defaultMessage: 'Advanced Setting' }),
    }, {
        key: 'authentication',
        tab: formatMessage({ id: 'pages.clients.edit.tabs.authentication', defaultMessage: 'Authentication' }),
    }, {
        key: 'token',
        tab: formatMessage({ id: 'pages.clients.edit.tabs.token', defaultMessage: 'Token' }),
    }, {
        key: 'DF',
        tab: formatMessage({ id: 'pages.clients.edit.tabs.deviceflow', defaultMessage: 'Device Flow' }),
    }
]

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
                style={{ width: '100%' }}
                title={clientName}
                tabList={tabList}
                activeTabKey={this.state.key}
                onTabChange={key => {
                    this.onTabChange(key, 'key');
                }}
            >
                <EditPanel activeKey={this.state.key}
                    detail={detail} />
            </Card >
        )
    }
}

export default connect(({ client, loading }: ConnectState) => ({
    detail: client.detail,
    loading: loading.effects['client/fetchDetail']
}))(EditClient)