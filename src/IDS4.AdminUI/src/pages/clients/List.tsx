import React from 'react';
import { connect } from 'dva';
import { ConnectState, ConnectProps } from '@/models/connect';
import IClientViewModel from '../../@types/IClientViewModel';
import { Table, Avatar, Icon } from 'antd';
import { formatMessage } from 'umi-plugin-react/locale';

export interface IClientListProps extends ConnectProps {
    list?: Array<IClientViewModel>;
    loading?: boolean
}

class ClientList extends React.Component<IClientListProps> {

    componentDidMount() {
        const { dispatch } = this.props;
        dispatch && dispatch({ type: 'client/fetchList' });
    }

    render() {
        const { list, loading } = this.props;
        return (
            <Table dataSource={list}
                loading={loading}
                rowKey="clientId"
                pagination={false}>
                <Table.Column width={100} dataIndex="logoUri" title={formatMessage({ id: 'pages.clientList.table.client.logo' })}
                    render={record => (<Avatar src={record} />)} />
                <Table.Column dataIndex="clientId" title={formatMessage({ id: 'pages.clientList.table.client.id' })} />
                <Table.Column dataIndex="clientName" title={formatMessage({ id: 'pages.clientList.table.client.name' })} />
                <Table.Column dataIndex="enabled" title={formatMessage({ id: 'pages.clientList.table.client.enabled' })}
                    render={record =>
                        record ? (<Icon type="check-circle" theme="twoTone" twoToneColor="#52c41a" />) : (<Icon type="close-circle" theme="twoTone" twoToneColor="red" />)} />
            </Table>
        )
    }
}

export default connect(({ client, loading }: ConnectState) => ({
    list: client.list,
    loading: loading.effects['client/fetchList']
}))(ClientList)