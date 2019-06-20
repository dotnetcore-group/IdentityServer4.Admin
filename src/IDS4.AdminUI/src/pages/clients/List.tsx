import React from 'react';
import { connect } from 'dva';
import { ConnectState, ConnectProps } from '@/models/connect';
import IClientViewModel from '../../@types/IClientViewModel';
import { Table, Avatar, Icon, Card, Button, Badge, Popconfirm, Divider } from 'antd';
import { formatMessage } from 'umi-plugin-react/locale';
import { router } from 'umi';

export interface IClientListProps extends ConnectProps {
    list?: Array<IClientViewModel>;
    loading?: boolean
}

class ClientList extends React.Component<IClientListProps> {

    componentDidMount() {
        const { dispatch } = this.props;
        dispatch && dispatch({ type: 'client/fetchList' });
    }

    handleRemove(clientId: string) {
        const { dispatch } = this.props;

        dispatch && dispatch({ type: 'client/remove', payload: clientId });
    }

    render() {
        const { list, loading } = this.props;
        return (
            <Card>
                <div>
                    <Button type="primary" icon="plus" onClick={() => { router.push("/clients/add") }}>
                        {formatMessage({ id: 'pages.clients.list.table.client.add', defaultMessage: 'Add Client' })}
                    </Button>
                </div>
                <Table dataSource={list}
                    loading={loading}
                    rowKey="clientId"
                    pagination={false}>
                    <Table.Column width={100} dataIndex="logoUri" title={formatMessage({ id: 'pages.clients.list.table.client.logo' })}
                        render={record => (<Avatar src={record} />)} />
                    <Table.Column dataIndex="clientId" title={formatMessage({ id: 'pages.clients.list.table.client.id' })} />
                    <Table.Column dataIndex="clientName" title={formatMessage({ id: 'pages.clients.list.table.client.name' })} />
                    <Table.Column dataIndex="enabled" title={formatMessage({ id: 'pages.clients.list.table.client.enabled' })}
                        render={record =>
                            record ? (<Badge status="success" text={formatMessage({ id: 'app.shared.enabled' })} />) : (<Badge status="error" text={formatMessage({ id: 'app.shared.disabled' })} />)} />
                    <Table.Column dataIndex="clientId" render={(record) => (
                        <>
                            <Button type="ghost" onClick={() => { router.push(`/clients/edit?id=${record}`) }}>{formatMessage({ id: 'app.shared.edit', defaultMessage: 'Edit' })}</Button>
                            <Divider type="vertical" />
                            <Popconfirm placement="topLeft" title={formatMessage({ id: 'pages.clients.list.table.remove.confirm', defaultMessage: 'Remove' })}
                                onConfirm={this.handleRemove.bind(this, record)}
                                okText="Yes"
                                cancelText="No">
                                <Button type="danger">{formatMessage({ id: 'app.shared.remove', defaultMessage: 'Remove' })}</Button>
                            </Popconfirm>
                        </>
                    )} />
                </Table>
            </Card>
        )
    }
}

export default connect(({ client, loading }: ConnectState) => ({
    list: client.list,
    loading: loading.effects['client/fetchList'] || loading.effects['client/remove']
}))(ClientList)