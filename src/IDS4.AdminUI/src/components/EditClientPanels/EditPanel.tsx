import React from "react";
import Form, { FormComponentProps } from "antd/lib/form";
import { Col, Row, Divider, Tabs, Input } from "antd";
import Button from 'antd/es/button/button';
import { formatMessage } from "umi-plugin-locale";
import BasicPanel from "./BasicPanel";
import AuthenticationPanel from "./AuthenticationPanel";
import AdvancedPanel from './AdvancedPanel';
import TokenPanel from "./TokenPanel";
import DeviceFlowPanel from "./DeviceFlowPanel";

const { TabPane } = Tabs;

export interface IEditPanelProps extends FormComponentProps {
    detail?: any
}

class EditPanel extends React.Component<IEditPanelProps> {
    render() {
        const { form, detail } = this.props;

        const tabList = [
            {
                key: 'basic',
                tab: formatMessage({ id: 'pages.clients.edit.tabs.basic', defaultMessage: 'Basic' }),
                content: <BasicPanel form={form} {...detail} />
            },
            {
                key: 'AS',
                tab: formatMessage({ id: 'pages.clients.edit.tabs.settings', defaultMessage: 'Advanced Setting' }),
                content: <AdvancedPanel form={form} {...detail} />
            }, {
                key: 'authentication',
                tab: formatMessage({ id: 'pages.clients.edit.tabs.authentication', defaultMessage: 'Authentication' }),
                content: <AuthenticationPanel form={form} {...detail} />
            }, {
                key: 'token',
                tab: formatMessage({ id: 'pages.clients.edit.tabs.token', defaultMessage: 'Token' }),
                content: <TokenPanel form={form}  {...detail} />
            }, {
                key: 'DF',
                tab: formatMessage({ id: 'pages.clients.edit.tabs.deviceflow', defaultMessage: 'Device Flow' }),
                content: <DeviceFlowPanel form={form}  {...detail} />
            }
        ]

        return (
            <Form onSubmit={(e) => {
                e.preventDefault();
                form.validateFields((err, fieldsValue) => {
                    if (!err) {
                        console.log(fieldsValue);
                    }
                })
            }}>
                <Tabs defaultActiveKey={tabList[0].key}>
                    {
                        tabList.map(item => (
                            <TabPane tab={item.tab} key={item.key}>
                                {item.content}
                            </TabPane>
                        ))
                    }
                </Tabs>
                <Button htmlType="submit" type="primary">{formatMessage({ id: 'app.shared.update' })}</Button>
                <Divider type="vertical" />
                <Button htmlType="button" type="default">{formatMessage({ id: 'app.shared.cancel' })}</Button>
            </Form >
        )
    }
}

export default Form.create<IEditPanelProps>()(EditPanel);