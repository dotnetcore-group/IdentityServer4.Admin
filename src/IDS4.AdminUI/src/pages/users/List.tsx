import React from 'react';
import { Card, Table, Avatar, Button, Divider, Drawer, Form, Input, Checkbox } from 'antd';
import { formatMessage } from 'umi-plugin-react/locale';
import { connect } from 'dva';
import { ConnectState } from '@/models/connect';
import { ConnectProps } from '../../models/connect';
import { router } from 'umi';
import { FormComponentProps } from 'antd/lib/form';

interface INewUserFormProps extends FormComponentProps { }

const NewUserForm = Form.create<INewUserFormProps>()(
    class NewUserForm extends React.Component<INewUserFormProps> {
        render() {
            const { form: { getFieldDecorator } } = this.props;

            return (
                <Form>
                    <Form.Item label="Username">
                        {getFieldDecorator('userName', {})(
                            <Input />
                        )}
                    </Form.Item>
                    <Form.Item label="Nickname">
                        {getFieldDecorator('nickname', {})(
                            <Input />
                        )}
                    </Form.Item>
                    <Form.Item label="Email">
                        {getFieldDecorator('email', {})(
                            <Input />
                        )}
                    </Form.Item>
                    <Form.Item label="Password">
                        {getFieldDecorator('password', {})(
                            <Input />
                        )}
                    </Form.Item>
                    <Form.Item label="Confirm Password">
                        {getFieldDecorator('confirmPassword', {})(
                            <Input />
                        )}
                    </Form.Item>
                    <Form.Item label="Email Confirmed">
                        {getFieldDecorator('emailConfirmed', {
                            initialValue: true,
                            valuePropName: 'checked'
                        })(
                            <Checkbox />
                        )}
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
                            {formatMessage({ id: 'app.shared.create' })}
                        </Button>
                    </div>
                </Form>
            )
        }
    }
)

export interface IUserListProps extends ConnectProps {
    loading?: boolean;
    list?: {
        data?: Array<any>,
        total?: number
    }
}

class UserList extends React.Component<IUserListProps> {
    state = {
        drawerVisable: false
    }

    componentDidMount() {
        const { dispatch } = this.props;
        dispatch && dispatch({
            type: 'users/fetch',
            payload: {
                pageIndex: 1,
                pageSize: 20,
                search: ''
            }
        })
    }

    render() {
        const { loading, list = {} } = this.props;
        const { total, data } = list;

        return (
            <>
                <Card>
                    <div style={{ marginBottom: '20px' }}>
                        <Button type="primary" icon="plus" onClick={() => this.setState({ drawerVisable: true })}>添加用户</Button>
                    </div>
                    <Table loading={loading}
                        dataSource={data}
                        rowKey="id"
                        pagination={{
                            pageSize: 20,
                            total
                        }}>
                        <Table.Column title={formatMessage({ id: 'pages.users.list.table.avatar' })} dataIndex="gravatar" render={src => <Avatar src={src} />} />
                        <Table.Column title={formatMessage({ id: 'pages.users.list.table.username' })} dataIndex="userName" />
                        <Table.Column title={formatMessage({ id: 'pages.users.list.table.nickname' })} dataIndex="nickname" />
                        <Table.Column title={formatMessage({ id: 'pages.users.list.table.email' })} dataIndex="email" />
                        <Table.Column dataIndex="id" render={id => (
                            <>
                                <Button type="primary" onClick={() => router.push(`/users/${id}`)}>{formatMessage({ id: 'app.shared.edit' })}</Button>
                                <Divider type="vertical" />
                                <Button type="danger">{formatMessage({ id: 'app.shared.remove' })}</Button>
                            </>
                        )} />
                    </Table>
                </Card>
                <Drawer width={450}
                    onClose={() => this.setState({ drawerVisable: false })}
                    destroyOnClose={true}
                    visible={this.state.drawerVisable}>
                    <NewUserForm />
                </Drawer>
            </>
        )
    }
}

export default connect(({ loading, users }: ConnectState) => ({
    loading: loading.effects['users/fetch'],
    list: users.list
}))(UserList);