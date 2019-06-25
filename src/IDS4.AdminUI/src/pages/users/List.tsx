import React from 'react';
import { Card, Table, Avatar, Button } from 'antd';
import { formatMessage } from 'umi-plugin-react/locale';
import { connect } from 'dva';
import { ConnectState } from '@/models/connect';
import { ConnectProps } from '../../models/connect';

export interface IUserListProps extends ConnectProps {
    loading?: boolean;
    list?: {
        data?: Array<any>,
        total?: number
    }
}

class UserList extends React.Component<IUserListProps> {
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
            <Card>
                <div style={{ marginBottom: '20px' }}>
                    <Button type="primary" icon="plus">添加用户</Button>
                </div>
                <Table loading={loading}
                    dataSource={data}
                    pagination={{
                        pageSize: 20,
                        total
                    }}>
                    <Table.Column title={formatMessage({ id: 'pages.users.list.table.avatar' })} dataIndex="gravatar" render={src => <Avatar src={src} />} />
                    <Table.Column title={formatMessage({ id: 'pages.users.list.table.username' })} dataIndex="userName" />
                    <Table.Column title={formatMessage({ id: 'pages.users.list.table.nickname' })} dataIndex="nickname" />
                    <Table.Column title={formatMessage({ id: 'pages.users.list.table.email' })} dataIndex="email" />
                </Table>
            </Card>
        )
    }
}

export default connect(({ loading, users }: ConnectState) => ({
    loading: loading.effects['users/fetch'],
    list: users.list
}))(UserList);