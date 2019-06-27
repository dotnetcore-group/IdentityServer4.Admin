import React from "react";
import { Card, Button, Divider, Table, Popconfirm } from "antd";
import { connect } from "dva";
import { ConnectProps } from "@/models/connect";
import { ConnectState } from '../../models/connect';
import { router } from "umi";
import { formatMessage } from "umi-plugin-locale";

export interface IClientPropertiesProps extends ConnectProps {
    loading?: boolean;
    properties?: Array<any>
}

class ClientProperties extends React.Component<IClientPropertiesProps> {
    state = {
        clientId: ''
    }

    componentDidMount() {
        const { match, dispatch } = this.props;
        if (match) {
            const { id } = match.params;
            dispatch && dispatch({
                type: 'client/fetchProperties',
                payload: id
            });
            this.setState({ clientId: id });
        }
    }

    onRemove() { }

    render() {
        const { properties, loading } = this.props;

        return (
            <>
                <Card title={
                    <>
                        <Button onClick={() => router.goBack()} icon="left" type="link">Go Back</Button>
                        <Divider type="vertical" />
                        <Button type="primary" onClick={() => this.setState({ drawerVisable: true })}>{formatMessage({ id: 'pages.clients.properties.add' })}</Button>
                    </>
                }>

                    <Table dataSource={properties}
                        title={() => <h1>Properties: {this.state.clientId}</h1>}
                        rowKey="key"
                        pagination={false}
                        loading={loading}>
                        <Table.Column title={formatMessage({ id: 'pages.clients.properties.table.title.key' })} dataIndex="key" />
                        <Table.Column title={formatMessage({ id: 'pages.clients.properties.table.title.value' })} dataIndex="value" />
                        <Table.Column dataIndex="id" render={(id, record) => (
                            <Popconfirm
                                placement="topLeft"
                                title={formatMessage({
                                    id: 'pages.clients.properties.table.remove.confirm'
                                })}
                                onConfirm={this.onRemove.bind(this, id)}
                                okText={formatMessage({ id: 'app.shared.yes' })}
                                cancelText={formatMessage({ id: 'app.shared.no' })}
                            >
                                <Button type="danger">
                                    {formatMessage({ id: 'app.shared.remove', defaultMessage: 'Remove' })}
                                </Button>
                            </Popconfirm>
                        )} />
                    </Table>
                </Card>
            </>
        )
    }
}

export default connect(({ loading, client }: ConnectState) => ({
    loading: loading.effects['client/fetchProperties'],
    properties: client.properties
}))(ClientProperties)