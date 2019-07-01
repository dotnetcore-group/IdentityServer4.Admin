import React from 'react';
import { Card, Table, Avatar, Button, Divider, Drawer, Form, Input, Checkbox, Popconfirm } from 'antd';
import { formatMessage } from 'umi-plugin-react/locale';
import { connect } from 'dva';
import { ConnectState } from '@/models/connect';
import { ConnectProps } from '../../models/connect';
import { router } from 'umi';
import { FormComponentProps } from 'antd/lib/form';

interface INewUserFormProps extends FormComponentProps {
    onSubmit?: (values: any) => void;
}

const NewUserForm = Form.create<INewUserFormProps>()(
    class NewUserForm extends React.Component<INewUserFormProps> {

        compareToFirstPassword(rule: any, value: any, callback: any) {
            const { form } = this.props;
            if (value && value !== form.getFieldValue('password')) {
                callback(formatMessage({ id: 'pages.users.list.create.confirmpassword.inconsistent' }));
            } else {
                callback();
            }
        }

        submitHandler(e: any) {
            e.preventDefault();
            const { form, onSubmit } = this.props;
            form.validateFields((error, values) => {
                if (!error) {
                    onSubmit && onSubmit(values);
                }
            })
        }

        render() {
            const { form: { getFieldDecorator } } = this.props;
            const formItemLayout = {
                labelCol: {
                    xs: { span: 24 },
                    sm: { span: 8 },
                },
                wrapperCol: {
                    xs: { span: 24 },
                    sm: { span: 16 },
                },
            };

            return (
                <Form {...formItemLayout} style={{ paddingTop: '20px' }} onSubmit={this.submitHandler.bind(this)}>
                    <Form.Item label="Username">
                        {getFieldDecorator('userName', {
                            rules: [{ required: true, message: formatMessage({ id: 'pages.users.list.create.username.required' }) }]
                        })(
                            <Input />
                        )}
                    </Form.Item>
                    <Form.Item label="Email">
                        {getFieldDecorator('email', {
                            rules: [{
                                type: 'email',
                                message: formatMessage({ id: 'pages.users.list.create.email.invalid' })
                            }, {
                                required: true,
                                message: formatMessage({ id: 'pages.users.list.create.email.required' })
                            }]
                        })(
                            <Input />
                        )}
                    </Form.Item>
                    <Form.Item label="Nickname">
                        {getFieldDecorator('nickname', {
                        })(
                            <Input />
                        )}
                    </Form.Item>
                    <Form.Item label="Password">
                        {getFieldDecorator('password', {
                            rules: [{ required: true, message: formatMessage({ id: 'pages.users.list.create.password.required' }) }]
                        })(
                            <Input.Password />
                        )}
                    </Form.Item>
                    <Form.Item label="Confirm Password">
                        {getFieldDecorator('confirmPassword', {
                            rules: [{
                                required: true,
                                message: formatMessage({ id: 'pages.users.list.create.confirmpassword.required' }),
                            },
                            {
                                validator: this.compareToFirstPassword.bind(this),
                            }]
                        })(
                            <Input.Password />
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
        this.fetchData(1, 10);
    }

    fetchData(pageIndex: number, pageSize: number, search = '') {
        const { dispatch } = this.props;
        dispatch && dispatch({
            type: 'users/fetch',
            payload: {
                pageIndex,
                pageSize,
                search
            }
        })
    }

    tablePageChangeHanlder(page: number, pageSize?: number) {
        this.fetchData(page, pageSize || 10)
    }

    createHandler(values: any) {
        const { dispatch } = this.props;
        dispatch && dispatch({
            type: 'users/create',
            payload: {
                ...values
            }
        });
        this.setState({ drawerVisable: false })
    }

    removeHandler(id: string) {
        const { dispatch } = this.props;
        dispatch && dispatch({
            type: 'users/remove',
            payload: id
        })
    }

    render() {
        const { loading, list = {} } = this.props;
        const { total, data } = list;

        return (
            <>
                <Card>
                    <div style={{ marginBottom: '20px' }}>
                        <Button type="primary" icon="plus" onClick={() => this.setState({ drawerVisable: true })}>{formatMessage({ id: 'pages.users.list.createuser' })}</Button>
                    </div>
                    <Table loading={loading}
                        dataSource={data}
                        rowKey="id"
                        pagination={{
                            pageSize: 20,
                            total,
                            onChange: this.tablePageChangeHanlder.bind(this)
                        }}>
                        <Table.Column title={formatMessage({ id: 'pages.users.list.table.avatar' })} dataIndex="gravatar" render={src => <Avatar src={src} />} />
                        <Table.Column title={formatMessage({ id: 'pages.users.list.table.username' })} dataIndex="userName" />
                        <Table.Column title={formatMessage({ id: 'pages.users.list.table.nickname' })} dataIndex="nickname" />
                        <Table.Column title={formatMessage({ id: 'pages.users.list.table.email' })} dataIndex="email" />
                        <Table.Column dataIndex="id" render={id => (
                            <>
                                <Button type="primary" onClick={() => router.push(`/users/${id}`)}>{formatMessage({ id: 'app.shared.edit' })}</Button>
                                <Divider type="vertical" />
                                <Popconfirm
                                    placement="topLeft"
                                    title={formatMessage({
                                        id: 'pages.users.list.table.remove.confirm',
                                        defaultMessage: 'Remove',
                                    })}
                                    onConfirm={this.removeHandler.bind(this, id || '')}
                                    okText={formatMessage({ id: 'app.shared.yes' })}
                                    cancelText={formatMessage({ id: 'app.shared.no' })}
                                >
                                    <Button type="danger">
                                        {formatMessage({ id: 'app.shared.remove', defaultMessage: 'Remove' })}
                                    </Button>
                                </Popconfirm>
                            </>
                        )} />
                    </Table>
                </Card>
                <Drawer width={450}
                    onClose={() => this.setState({ drawerVisable: false })}
                    destroyOnClose={true}
                    visible={this.state.drawerVisable}>
                    <NewUserForm onSubmit={this.createHandler.bind(this)} />
                </Drawer>
            </>
        )
    }
}

export default connect(({ loading, users }: ConnectState) => ({
    loading: loading.effects['users/fetch'] || loading.effects['users/remove'],
    list: users.list
}))(UserList);