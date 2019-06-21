import React from 'react';
import IPanelPropsBase from './IPanelPropsBase';
import { Switch, Select, Input, Button, InputNumber } from 'antd';
import FormItem from './FormItem';
import { Link } from 'umi';
import { formatMessage } from 'umi-plugin-locale';

export interface ITokenPanelProps extends IPanelPropsBase {
    identityTokenLifetime?: number;
    accessTokenLifetime?: number;
    accessTokenType?: number;
    authorizationCodeLifetime?: number;
    absoluteRefeshTokenLifetime?: number;
    slidingRefreshTokenLifetime?: number;
    refreshTokenUsage?: number;
    refreshTokenExpiration?: number;
    updateAccessTokenClaimsOnRefresh?: boolean;
    includeJwtId?: boolean;
    alwaysSendClientClaims?: boolean;
    alwaysIncludeUserClaimsInIdToken?: boolean;
    pairWiseSubjectSalt?: string;
    clientClaimsPrefix?: string;
}

export default class TokenPanel extends React.Component<ITokenPanelProps> {
    render() {
        const { form: { getFieldDecorator },
            identityTokenLifetime,
            accessTokenLifetime,
            accessTokenType,
            authorizationCodeLifetime,
            absoluteRefeshTokenLifetime,
            slidingRefreshTokenLifetime,
            refreshTokenUsage,
            refreshTokenExpiration,
            updateAccessTokenClaimsOnRefresh,
            includeJwtId,
            alwaysSendClientClaims,
            alwaysIncludeUserClaimsInIdToken,
            pairWiseSubjectSalt,
            clientClaimsPrefix
        } = this.props;

        return (
            <>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.identityTokenLifetime', defaultMessage: "Identity Token Lifetime" })}>
                    {
                        getFieldDecorator('identityTokenLifetime', {
                            initialValue: identityTokenLifetime
                        })(
                            <InputNumber />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.accessTokenLifetime', defaultMessage: "Access Token Lifetime" })}>
                    {
                        getFieldDecorator('accessTokenLifetime', {
                            initialValue: accessTokenLifetime
                        })(
                            <InputNumber />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.accessTokenType', defaultMessage: "Access Token Type" })}>
                    {
                        getFieldDecorator('accessTokenType', {
                            initialValue: accessTokenType
                        })(
                            <Select>
                                <Select.Option value={0}>Jwt</Select.Option>
                                <Select.Option value={1}>Reference</Select.Option>
                            </Select>
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.authorizationCodeLifetime', defaultMessage: "Authorization Code Lifetime" })}>
                    {
                        getFieldDecorator('authorizationCodeLifetime', {
                            initialValue: authorizationCodeLifetime
                        })(
                            <InputNumber />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.absoluteRefeshTokenLifetime', defaultMessage: "Absolute Refresh Token Lifetime" })}>
                    {
                        getFieldDecorator('absoluteRefeshTokenLifetime', {
                            initialValue: absoluteRefeshTokenLifetime
                        })(
                            <InputNumber />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.slidingRefreshTokenLifetime', defaultMessage: "Sliding Refresh Token Lifetime" })}>
                    {
                        getFieldDecorator('slidingRefreshTokenLifetime', {
                            initialValue: slidingRefreshTokenLifetime
                        })(
                            <InputNumber />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.refreshTokenUsage', defaultMessage: "Refresh Token Usage" })}>
                    {
                        getFieldDecorator('refreshTokenUsage', {
                            initialValue: refreshTokenUsage
                        })(
                            <Select>
                                <Select.Option value={0}>{formatMessage({ id: 'pages.clients.edit.tabs.panel.refreshTokenUsage.reuse', defaultMessage: "ReUse" })}</Select.Option>
                                <Select.Option value={1}>{formatMessage({ id: 'pages.clients.edit.tabs.panel.refreshTokenUsage.onetimeonly', defaultMessage: "One Time Only" })}</Select.Option>
                            </Select>
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.refreshTokenExpiration', defaultMessage: "Refresh Token Expiration" })}>
                    {
                        getFieldDecorator('refreshTokenExpiration', {
                            initialValue: refreshTokenExpiration
                        })(
                            <Select>
                                <Select.Option value={0}>{formatMessage({ id: 'pages.clients.edit.tabs.panel.refreshTokenExpiration.sliding', defaultMessage: "Sliding" })}</Select.Option>
                                <Select.Option value={1}>{formatMessage({ id: 'pages.clients.edit.tabs.panel.refreshTokenExpiration.absolute', defaultMessage: "Absolute" })}</Select.Option>
                            </Select>
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.updateAccessTokenClaimsOnRefresh', defaultMessage: "Update Access Token Claims On Refresh" })}>
                    {
                        getFieldDecorator('updateAccessTokenClaimsOnRefresh', {
                            initialValue: updateAccessTokenClaimsOnRefresh,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.includeJwtId', defaultMessage: "Include Jwt Id" })}>
                    {
                        getFieldDecorator('includeJwtId', {
                            initialValue: includeJwtId,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.alwaysSendClientClaims', defaultMessage: "Always Send Client Claims" })}>
                    {
                        getFieldDecorator('alwaysSendClientClaims', {
                            initialValue: alwaysSendClientClaims,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.alwaysIncludeUserClaimsInIdToken', defaultMessage: "Always Include User Claims In IdToken" })}>
                    {
                        getFieldDecorator('alwaysIncludeUserClaimsInIdToken', {
                            initialValue: alwaysIncludeUserClaimsInIdToken,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.pairWiseSubjectSalt', defaultMessage: "Pair Wise Subject Salt" })}>
                    {
                        getFieldDecorator('pairWiseSubjectSalt', {
                            initialValue: pairWiseSubjectSalt
                        })(
                            <Input />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.clientClaimsPrefix', defaultMessage: "Client Claims Prefix" })}>
                    {
                        getFieldDecorator('clientClaimsPrefix', {
                            initialValue: clientClaimsPrefix
                        })(
                            <Input />
                        )
                    }
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.claims', defaultMessage: "Claims" })}>
                    <Link to="">
                        <Button type="primary" htmlType="button">{formatMessage({ id: 'pages.clients.edit.tabs.panel.claims', defaultMessage: "Claims" })}</Button>
                    </Link>
                </FormItem>
            </>
        )
    }
}