import React from 'react';
import IPanelPropsBase from './IPanelPropsBase';
import FormItem from './FormItem';
import { Switch, Input } from 'antd';
import { formatMessage } from 'umi-plugin-locale';
import TagsInput from '@/components/TagsInput/TagsInput';

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
        const {
            form: { getFieldDecorator },
            frontChannelLogoutUri,
            frontChannelLogoutSessionRequired,
            backChannelLogoutUri,
            backChannelLogoutSessionRequired,
            identityProviderRestrictions,
            allowedCorsOrigins,
        } = this.props;

        return (
            <>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.frontChannelLogoutUri',
                        defaultMessage: 'Front Channel Logout Uri',
                    })}
                    tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.frontChannelLogoutUri.tip' })}
                >
                    {getFieldDecorator('frontChannelLogoutUri', {
                        initialValue: frontChannelLogoutUri,
                    })(<Input />)}
                </FormItem>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.frontChannelLogoutSessionRequired',
                        defaultMessage: 'Front Channel Logout Session Required',
                    })}
                    tip={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.frontChannelLogoutSessionRequired.tip',
                    })}
                >
                    {getFieldDecorator('frontChannelLogoutSessionRequired', {
                        initialValue: frontChannelLogoutSessionRequired,
                        valuePropName: 'checked',
                    })(<Switch />)}
                </FormItem>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.backChannelLogoutUri',
                        defaultMessage: 'Back Channel Logout Uri',
                    })}
                    tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.backChannelLogoutUri.tip' })}
                >
                    {getFieldDecorator('backChannelLogoutUri', {
                        initialValue: backChannelLogoutUri,
                    })(<Input />)}
                </FormItem>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.backChannelLogoutSessionRequired',
                        defaultMessage: 'Back Channel Logout Session Required',
                    })}
                    tip={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.backChannelLogoutSessionRequired.tip',
                    })}
                >
                    {getFieldDecorator('backChannelLogoutSessionRequired', {
                        initialValue: backChannelLogoutSessionRequired,
                        valuePropName: 'checked',
                    })(<Switch />)}
                </FormItem>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.identityProviderRestrictions',
                        defaultMessage: 'Identity Provider Restrictions',
                    })}
                    tip={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.identityProviderRestrictions.tip',
                    })}
                >
                    {getFieldDecorator('identityProviderRestrictions', {
                        initialValue: identityProviderRestrictions,
                    })(
                        <TagsInput
                            newText={formatMessage({
                                id: 'pages.clients.edit.tabs.addrestriction',
                                defaultMessage: 'Add Restriction',
                            })}
                        />,
                    )}
                </FormItem>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.allowedCorsOrigins',
                        defaultMessage: 'Allowed Cors Origins',
                    })}
                    tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowedCorsOrigins.tip' })}
                >
                    {getFieldDecorator('allowedCorsOrigins', {
                        initialValue: allowedCorsOrigins,
                    })(
                        <TagsInput
                            longTagLength={-1}
                            newText={formatMessage({
                                id: 'pages.clients.edit.tabs.addorigin',
                                defaultMessage: 'Add Origin',
                            })}
                        />,
                    )}
                </FormItem>
            </>
        );
    }
}
