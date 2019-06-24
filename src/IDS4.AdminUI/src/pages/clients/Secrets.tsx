import React from "react";
import { Card, Button, Table, Divider, Drawer, Form, Input, Select, DatePicker, Popconfirm } from "antd";
import { connect } from "dva";
import { ConnectProps, ConnectState } from '../../models/connect';
import { formatMessage } from "umi-plugin-locale";
import { router } from "umi";
import { FormComponentProps } from "antd/lib/form";

export interface ICreateSecretProps extends FormComponentProps {
    onSubmit?: (values: any) => void;
}

const CreateSecretForm = Form.create<ICreateSecretProps>()(
    class CreateSecret extends React.Component<ICreateSecretProps> {

        handleSubmit(e: React.FormEvent) {
            const { form, onSubmit } = this.props;
            e.preventDefault();
            form.validateFields((error, values) => {
                if (!error) {
                    onSubmit && onSubmit(values);
                }
            })
        }

        render() {
            const { form: { getFieldDecorator } } = this.props;

            return (
                <Form onSubmit={this.handleSubmit.bind(this)}>
                    <Form.Item label={formatMessage({ id: 'pages.clients.secrets.add.type' })}>
                        {getFieldDecorator('type', {
                            initialValue: 'SharedSecret',
                            rules: [{ required: true }]
                        })(
                            <Select>
                                <Select.Option value='SharedSecret'>Shared Secret</Select.Option>
                                <Select.Option value='X509Thumbprint'>X509 Thumbprint</Select.Option>
                                <Select.Option value='X509Name'>X509 Name</Select.Option>
                                <Select.Option value='X509CertificateBase64'>X509 Certificate Base64</Select.Option>
                            </Select>
                        )}
                    </Form.Item>
                    <Form.Item label={formatMessage({ id: 'pages.clients.secrets.add.value' })}>
                        {getFieldDecorator('value', {
                            rules: [{ required: true }]
                        })(<Input />)}
                    </Form.Item>
                    <Form.Item label={formatMessage({ id: 'pages.clients.secrets.add.hashtype' })}>
                        {getFieldDecorator('hashType', {
                            initialValue: 0
                        })(
                            <Select>
                                <Select.Option value={0}>Sha256</Select.Option>
                                <Select.Option value={1}>Sha512</Select.Option>
                            </Select>
                        )}
                    </Form.Item>
                    <Form.Item label={formatMessage({ id: 'pages.clients.secrets.add.expiration' })}>
                        {getFieldDecorator('expiration', {
                        })(<DatePicker showTime />)}
                    </Form.Item>
                    <Form.Item label={formatMessage({ id: 'pages.clients.secrets.add.description' })}>
                        {getFieldDecorator('description', {
                        })(<Input.TextArea />)}
                    </Form.Item>

                    <div
                        style={{
                            position: 'absolute',
                            left: 0,
                            bottom: 0,
                            width: '100%',
                            borderTop: '1px solid #e9e9e9',
                            padding: '10px 16px',
                            background: '#fff',
                            textAlign: 'right',
                        }}
                    >
                        <Button type="primary" htmlType="submit">
                            {formatMessage({ id: 'pages.clients.secrets.add.submit' })}
                        </Button>
                    </div>
                </Form>
            )
        }
    }
);

export interface IClientSecretsProps extends ConnectProps {
    secrets?: Array<any>;
    loading?: boolean
}

class ClientSecrets extends React.Component<IClientSecretsProps> {
    state = {
        drawerVisable: false,
        clientId: ''
    }
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
        this.setState({ clientId: id });
    }

    createSecret(values: any) {
        const { dispatch } = this.props;
        const { clientId } = this.state;
        dispatch && dispatch({
            type: 'client/createSecret',
            payload: {
                clientId,
                model: values
            }
        });
        this.setState({ drawerVisable: false });
    }

    onRemove(id: string) {
        const { dispatch } = this.props;
        const { clientId } = this.state;
        dispatch && dispatch({
            type: 'client/removeSecret',
            payload: {
                clientId,
                id
            }
        })
    }

    render() {
        const { loading, secrets = [] } = this.props;

        return (
            <>
                <Card title={
                    <>
                        <Button onClick={() => router.goBack()} icon="left" type="link">Go Back</Button>
                        <Divider type="vertical" />
                        <Button type="primary" onClick={() => this.setState({ drawerVisable: true })}>{formatMessage({ id: 'pages.clients.secrets.add' })}</Button>
                    </>
                }>

                    <Table dataSource={secrets}
                        title={() => <h1>Secrets: {this.state.clientId}</h1>}
                        rowKey="id"
                        pagination={false}
                        loading={loading}>
                        <Table.Column title={formatMessage({ id: 'pages.clients.secrets.table.title.value' })} dataIndex="value" />
                        <Table.Column title={formatMessage({ id: 'pages.clients.secrets.table.title.type' })} dataIndex="type" />
                        <Table.Column title={formatMessage({ id: 'pages.clients.secrets.table.title.description' })} dataIndex="description" />
                        <Table.Column title={formatMessage({ id: 'pages.clients.secrets.table.title.expiration' })} dataIndex="expiration" />
                        <Table.Column dataIndex="id" render={(id, record) => (
                            <Popconfirm
                                placement="topLeft"
                                title={formatMessage({
                                    id: 'pages.clients.secrets.table.remove.confirm'
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
                <Drawer visible={this.state.drawerVisable}
                    width={450}
                    onClose={() => this.setState({ drawerVisable: false })}
                    destroyOnClose={true}>
                    <CreateSecretForm onSubmit={this.createSecret.bind(this)} />
                </Drawer>
            </>
        )
    }
}

export default connect(({ client, loading }: ConnectState) => ({
    secrets: client.secrets,
    loading: loading.effects['client/fetchSecrets'] || loading.effects['client/removeSecret']
}))(ClientSecrets);
