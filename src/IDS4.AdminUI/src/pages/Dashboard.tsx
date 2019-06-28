import React from 'react';
import { connect } from 'dva';
import { Typography, PageHeader, Avatar, Row, Col, Card } from 'antd';
import { formatMessage } from 'umi-plugin-locale';
import styles from './Dashboard.less'
import { ConnectState, ConnectProps } from '../models/connect';
import UserProfile from '@/@types/userProfile';
const { Title, Text } = Typography;

export interface IDashboardProps extends ConnectProps {
    userinfo?: UserProfile
}

class Dashboard extends React.Component<IDashboardProps> {
    render() {
        const { userinfo = {} } = this.props;
        const { nickname, avatar } = userinfo;

        return (
            <>
                <Card style={{ marginBottom: '24px' }}>
                    <div className={styles.header}>
                        <Avatar size={72} src={avatar} />
                        <div className={styles.content}>
                            <Title level={3}>{formatMessage({ id: 'shared.welcome' })}，{nickname}！</Title>
                            <Text>中午好！</Text>
                        </div>
                    </div>
                </Card>
                <Card>

                </Card>
            </>
        )
    }
}

export default connect(({ user }: ConnectState) => ({
    userinfo: user.currentUser
}))(Dashboard)