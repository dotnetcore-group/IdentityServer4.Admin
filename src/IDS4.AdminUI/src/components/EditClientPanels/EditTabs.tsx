import React from "react";
import Form, { FormComponentProps } from "antd/lib/form";
import { Divider, Tabs } from "antd";
import Button from 'antd/es/button/button';
import { formatMessage } from "umi-plugin-locale";
import BasicPanel from "./BasicPanel";
import AuthenticationPanel from "./AuthenticationPanel";
import AdvancedPanel from './AdvancedPanel';
import TokenPanel from "./TokenPanel";
import DeviceFlowPanel from "./DeviceFlowPanel";
import { router } from "umi";

const { TabPane } = Tabs;

export interface IEditTabsProps extends FormComponentProps {
    detail?: any;
    updating?: boolean;
    onUpdate?: (values: any) => void;
}

class EditTabs extends React.Component<IEditTabsProps> {
    render() {
        const { form, detail, onUpdate, updating } = this.props;

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
                        onUpdate && onUpdate({
                            ...detail,
                            ...fieldsValue
                        });
                    }
                })
            }}>
                {
                    form.getFieldDecorator('originalClinetId', {
                        initialValue: detail.clientId
                    })(
                        <input type="hidden" />
                    )
                }
                <Tabs defaultActiveKey={tabList[0].key}
                    animated={false}>
                    {
                        tabList.map(item => (
                            <TabPane tab={item.tab} key={item.key}>
                                {item.content}
                            </TabPane>
                        ))
                    }
                </Tabs>
                <Button loading={updating} htmlType="submit" type="primary">{formatMessage({ id: 'app.shared.update' })}</Button>
                <Divider type="vertical" />
                <Button loading={updating} htmlType="button" type="default" onClick={() => router.goBack()}>{formatMessage({ id: 'app.shared.cancel' })}</Button>
            </Form>
        )
    }
}

export default Form.create<IEditTabsProps>()(EditTabs);