import React from 'react';
import IPanelPropsBase from './IPanelPropsBase';
import FormItem from './FormItem';
import { Switch, Select, Input, Button } from 'antd';
import { Link, router } from 'umi';
import { formatMessage } from 'umi-plugin-locale';
import TagsInput from '@/components/TagsInput/TagsInput';

export interface IAdvancedPanelProps extends IPanelPropsBase {
    clientId?: string;
    enabled?: boolean;
    protocolType?: string;
    requireClientSecret?: boolean;
    requirePkce?: boolean;
    allowPlainTextPkce?: boolean;
    allowOfflineAccess?: boolean;
    allowAccessTokensViaBrowser?: boolean;
    allowedScopes?: Array<string>;
    redirectUris?: Array<string>;
    allowedGrantTypes?: Array<string>;
    requireConsent?: boolean;
}

export default class AdvancedPanel extends React.Component<IAdvancedPanelProps> {
    render() {
        const { form: { getFieldDecorator },
            clientId,
            enabled,
            protocolType,
            requireClientSecret,
            requirePkce,
            allowPlainTextPkce,
            allowOfflineAccess,
            allowAccessTokensViaBrowser,
            allowedScopes,
            redirectUris,
            allowedGrantTypes,
            requireConsent
        } = this.props;

        return (
            <>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.enabled', defaultMessage: "Enabled" })}>
                    {
                        getFieldDecorator('enabled', {
                            initialValue: enabled,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.protocolType', defaultMessage: "Protocol Type" })}>
                    {
                        getFieldDecorator('protocolType', {
                            initialValue: protocolType,
                        })(
                            <Select>
                                <Select.Option value="oidc">oidc</Select.Option>
                            </Select>
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.requireClientSecret', defaultMessage: "Require Client Secret" })}>
                    {
                        getFieldDecorator('requireClientSecret', {
                            initialValue: requireClientSecret,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.requirePkce', defaultMessage: "Require Pkce" })}>
                    {
                        getFieldDecorator('requirePkce', {
                            initialValue: requirePkce,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowPlainTextPkce', defaultMessage: "Allow Plain Text Pkce" })}>
                    {
                        getFieldDecorator('allowPlainTextPkce', {
                            initialValue: allowPlainTextPkce,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowOfflineAccess', defaultMessage: "Allow Offline Access" })}>
                    {
                        getFieldDecorator('allowOfflineAccess', {
                            initialValue: allowOfflineAccess,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowAccessTokensViaBrowser', defaultMessage: "Allow Access Tokens Via Browser" })}>
                    {
                        getFieldDecorator('allowAccessTokensViaBrowser', {
                            initialValue: allowAccessTokensViaBrowser,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowedScopes', defaultMessage: "Allowed Scopes" })}>
                    {
                        getFieldDecorator('allowedScopes', {
                            initialValue: allowedScopes,
                        })(
                            <TagsInput newText={formatMessage({ id: 'pages.clients.edit.tabs.addscope', defaultMessage: 'Add Scope' })} />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.redirectUris', defaultMessage: "Redirect Uris" })}>
                    {
                        getFieldDecorator('redirectUris', {
                            initialValue: redirectUris
                        })(
                            <TagsInput longTagLength={25} newText={formatMessage({ id: 'pages.clients.edit.tabs.addredirecturi', defaultMessage: 'Add Redirect Uri' })} />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowedGrantTypes', defaultMessage: "Allowed Grant Types" })}>
                    {
                        getFieldDecorator('allowedGrantTypes', {
                            initialValue: allowedGrantTypes
                        })(
                            <Select mode="multiple">
                                <Select.Option value="implicit">implicit</Select.Option>
                                <Select.Option value="hybird">hybird</Select.Option>
                                <Select.Option value="client_credentials">client_credentials</Select.Option>
                                <Select.Option value="authorization_code">authorization_code</Select.Option>
                                <Select.Option value="password">password</Select.Option>
                            </Select>
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.requireConsentScreen', defaultMessage: "Require Consent Screen" })}>
                    {
                        getFieldDecorator('requireConsent', {
                            initialValue: requireConsent,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.clientSecrets', defaultMessage: "Client Secrets" })}>
                    <Link to={`/clients/secrets?id=${clientId}`}>
                        <Button type="primary" htmlType="button">
                            {formatMessage({ id: 'pages.clients.edit.tabs.panel.clientSecrets', defaultMessage: "Client Secrets" })}
                        </Button>
                    </Link>
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.properties', defaultMessage: "Properties" })}>
                    <Link to={`/clients/properties?id=${clientId}`}>
                        <Button type="primary" htmlType="button">
                            {formatMessage({ id: 'pages.clients.edit.tabs.panel.properties', defaultMessage: "Properties" })}
                        </Button>
                    </Link>
                </FormItem>

            </>
        )
    }
}