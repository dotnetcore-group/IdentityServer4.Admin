import React from 'react';
import IPanelPropsBase from './IPanelPropsBase';
import FormItem from './FormItem';
import { Input } from 'antd';
import { formatMessage } from 'umi-plugin-locale';

export interface IDeviceFlowPanelProps extends IPanelPropsBase {
    userCodeType?: string;
    deviceCodeLifetime?: number;
}

export default class DeviceFlowPanel extends React.Component<IDeviceFlowPanelProps> {
    render() {
        const { form: { getFieldDecorator },
            userCodeType,
            deviceCodeLifetime
        } = this.props;

        return (
            <>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.userCodeType', defaultMessage: "User Code Type" })}>
                    {
                        getFieldDecorator('userCodeType', {
                            initialValue: userCodeType
                        })(
                            <Input />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.deviceCodeLifetime', defaultMessage: "Device Code Lifetime" })}>
                    {
                        getFieldDecorator('deviceCodeLifetime', {
                            initialValue: deviceCodeLifetime
                        })(
                            <Input />
                        )
                    }
                </FormItem>
            </>
        )
    }
}