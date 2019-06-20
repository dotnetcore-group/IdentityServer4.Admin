import React from "react";
import Form, { FormComponentProps } from "antd/lib/form";
import styles from './index.less';
import { Col, Row, Divider } from "antd";
import Button from 'antd/es/button/button';
import { formatMessage } from "umi-plugin-locale";
import { router } from "umi";

const BasicPanel = React.lazy(() => import('@/components/EditClientPanels/BasicPanel'));
const AdvancedPanel = React.lazy(() => import('@/components/EditClientPanels/AdvancedPanel'));
const AuthenticationPanel = React.lazy(() => import('@/components/EditClientPanels/AuthenticationPanel'));
const TokenPanel = React.lazy(() => import('@/components/EditClientPanels/TokenPanel'));
const DeviceFlowPanel = React.lazy(() => import('@/components/EditClientPanels/DeviceFlowPanel'));

export interface IEditPanelProps extends FormComponentProps {
    activeKey?: string;
    detail?: any
}

class EditPanel extends React.Component<IEditPanelProps> {
    render() {
        const { activeKey, form, detail } = this.props;

        return (
            <Form>
                <Row>
                    <React.Suspense fallback={null}>
                        <Col lg={12} xs={24}>
                            <div className={activeKey !== 'basic' ? styles.none : ''}> <BasicPanel form={form} detail={detail} /> </div>
                            <div className={activeKey !== 'AS' ? styles.none : ''}> <AdvancedPanel form={form} /> </div>
                            <div className={activeKey !== 'authentication' ? styles.none : ''}> <AuthenticationPanel form={form} /> </div>
                            <div className={activeKey !== 'token' ? styles.none : ''}> <TokenPanel form={form} /> </div>
                            <div className={activeKey !== 'DF' ? styles.none : ''}> <DeviceFlowPanel form={form} /> </div>
                        </Col>
                    </React.Suspense>
                </Row>
                <Row>
                    <Divider />
                    <Col lg={12} xs={24}>
                        <Button htmlType="submit" type="primary">{formatMessage({ id: 'app.shared.update' })}</Button>
                        <Divider type="vertical" />
                        <Button onClick={() => { router.goBack() }} type="ghost">{formatMessage({ id: 'app.shared.cancel' })}</Button>
                    </Col>
                </Row>
            </Form >
        )
    }
}

export default Form.create<IEditPanelProps>()(EditPanel);