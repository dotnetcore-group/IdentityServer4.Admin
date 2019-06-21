import React from 'react';
import IPanelPropsBase from './IPanelPropsBase';
import FormItem from './FormItem';
import { Switch, Input } from 'antd';
import { formatMessage } from 'umi-plugin-locale';

export interface IAuthenticationPanelProps extends IPanelPropsBase {
    frontChannelLogoutUri?: string;
    frontChannelLogoutSessionRequired?: boolean;
    backChannelLogoutUri?: string;
    backChannelLogoutSessionRequired?: boolean;
    identityProviderRestrictions?: Array<string>;
    allowedCorsOrigins?: Array<string>;
}

export default class AuthenticationPanel extends React.Component<IAuthenticationPanelProps> {
    render() {
        const { form: { getFieldDecorator },
            frontChannelLogoutUri,
            frontChannelLogoutSessionRequired,
            backChannelLogoutUri,
            backChannelLogoutSessionRequired,
            identityProviderRestrictions,
            allowedCorsOrigins
        } = this.props;

        return (
            <>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.frontChannelLogoutUri', defaultMessage: "Front Channel Logout Uri" })}>
                    {
                        getFieldDecorator('frontChannelLogoutUri', {
                            initialValue: frontChannelLogoutUri,
                        })(
                            <Input />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.frontChannelLogoutSessionRequired', defaultMessage: "Front Channel Logout Session Required" })}>
                    {
                        getFieldDecorator('frontChannelLogoutSessionRequired', {
                            initialValue: frontChannelLogoutSessionRequired,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.backChannelLogoutUri', defaultMessage: "Back Channel Logout Uri" })}>
                    {
                        getFieldDecorator('backChannelLogoutUri', {
                            initialValue: backChannelLogoutUri,
                        })(
                            <Input />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.backChannelLogoutSessionRequired', defaultMessage: "Back Channel Logout Session Required" })}>
                    {
                        getFieldDecorator('backChannelLogoutSessionRequired', {
                            initialValue: backChannelLogoutSessionRequired,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.identityProviderRestrictions', defaultMessage: "Identity Provider Restrictions" })}>
                    {
                        getFieldDecorator('identityProviderRestrictions', {
                            initialValue: identityProviderRestrictions,
                        })(
                            <Input />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowedCorsOrigins', defaultMessage: "Allowed Cors Origins" })}>
                    {
                        getFieldDecorator('allowedCorsOrigins', {
                            initialValue: allowedCorsOrigins,
                        })(
                            <Input />
                        )
                    }
                </FormItem>
            </>
        )
    }
}