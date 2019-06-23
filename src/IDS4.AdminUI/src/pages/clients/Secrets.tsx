import React from "react";
import { Card, Button, Row, Table, Divider } from "antd";
import { connect } from "dva";
import { ConnectProps, ConnectState } from '../../models/connect';
import { formatMessage } from "umi-plugin-locale";
import { router } from "umi";

export interface IClientSecretsProps extends ConnectProps {
    secrets?: Array<any>;
    loading?: boolean
}

class ClientSecrets extends React.Component<IClientSecretsProps> {
    componentDidMount() {
        const { dispatch, location: { query = {} } } = this.props;
        const id = query.id;
        if (!id) {
            console.error('redirect to 404');
            return;
        }
        dispatch && dispatch({
            type: 'client/fetchSecrets',
            payload: id
        });
    }

    render() {
        const { loading, secrets = [] } = this.props;
        console.log(secrets);

        return (
            <Card title={
                <>
                    <Button onClick={() => router.goBack()} icon="left" type="link">Go Back</Button>
                    <Divider type="vertical"/>
                    <Button type="primary">Add Secret</Button>
                </>
            }>


                <Table dataSource={secrets}
                    title={() => <h1>Secrets: Test-client</h1>}
                    key="id"
                    pagination={false}>
                    <Table.Column title={formatMessage({ id: 'pages.clients.secrets.table.title.value' })} dataIndex="value" />
                    <Table.Column title={formatMessage({ id: 'pages.clients.secrets.table.title.type' })} dataIndex="type" />
                    <Table.Column title={formatMessage({ id: 'pages.clients.secrets.table.title.description' })} dataIndex="description" />
                    <Table.Column title={formatMessage({ id: 'pages.clients.secrets.table.title.expiration' })} dataIndex="expiration" />
                </Table>
            </Card>
        )
    }
}

export default connect(({ client, loading }: ConnectState) => ({
    secrets: client.secrets,
    loading: loading.effects['client/fetchSecrets']
}))(ClientSecrets);
