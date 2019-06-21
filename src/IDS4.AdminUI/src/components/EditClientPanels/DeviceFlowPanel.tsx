import React from 'react';
import IPanelPropsBase from './IPanelPropsBase';
import FormItem from './FormItem';
import { Input } from 'antd';

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
                <FormItem label="User Code Type">
                    {
                        getFieldDecorator('userCodeType', {
                            initialValue: userCodeType
                        })(
                            <Input />
                        )
                    }
                </FormItem>
                <FormItem label="Device Code Lifetime">
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