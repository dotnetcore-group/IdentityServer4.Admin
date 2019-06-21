import React from 'react';
import IPanelPropsBase from './IPanelPropsBase';
import { Switch, Select, Input, Button, InputNumber } from 'antd';
import FormItem from './FormItem';
import { Link } from 'umi';

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
                <FormItem label="Identity Token Lifetime">
                    {
                        getFieldDecorator('identityTokenLifetime', {
                            initialValue: identityTokenLifetime
                        })(
                            <InputNumber />
                        )
                    }
                </FormItem>
                <FormItem label="Access Token Lifetime">
                    {
                        getFieldDecorator('accessTokenLifetime', {
                            initialValue: accessTokenLifetime
                        })(
                            <InputNumber />
                        )
                    }
                </FormItem>
                <FormItem label="Access Token Type">
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
                <FormItem label="Authorization Code Lifetime">
                    {
                        getFieldDecorator('authorizationCodeLifetime', {
                            initialValue: authorizationCodeLifetime
                        })(
                            <InputNumber />
                        )
                    }
                </FormItem>
                <FormItem label="Absolute Refresh Token Lifetime">
                    {
                        getFieldDecorator('absoluteRefeshTokenLifetime', {
                            initialValue: absoluteRefeshTokenLifetime
                        })(
                            <InputNumber />
                        )
                    }
                </FormItem>
                <FormItem label="Sliding Refresh Token Lifetime">
                    {
                        getFieldDecorator('slidingRefreshTokenLifetime', {
                            initialValue: slidingRefreshTokenLifetime
                        })(
                            <InputNumber />
                        )
                    }
                </FormItem>
                <FormItem label="Refresh Token Usage">
                    {
                        getFieldDecorator('refreshTokenUsage', {
                            initialValue: refreshTokenUsage
                        })(
                            <Select>
                                <Select.Option value={0}>Reuse</Select.Option>
                                <Select.Option value={1}>One Time Only</Select.Option>
                            </Select>
                        )
                    }
                </FormItem>
                <FormItem label="Refresh Token Expiration">
                    {
                        getFieldDecorator('refreshTokenExpiration', {
                            initialValue: refreshTokenExpiration
                        })(
                            <Select>
                                <Select.Option value={0}>Sliding</Select.Option>
                                <Select.Option value={1}>Absolute</Select.Option>
                            </Select>
                        )
                    }
                </FormItem>
                <FormItem label="Update Access Token Claims On Refresh">
                    {
                        getFieldDecorator('updateAccessTokenClaimsOnRefresh', {
                            initialValue: updateAccessTokenClaimsOnRefresh,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label="Include Jwt Id">
                    {
                        getFieldDecorator('includeJwtId', {
                            initialValue: includeJwtId,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label="Always Send Client Claims">
                    {
                        getFieldDecorator('alwaysSendClientClaims', {
                            initialValue: alwaysSendClientClaims,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label="Always Include User Claims In IdToken">
                    {
                        getFieldDecorator('alwaysIncludeUserClaimsInIdToken', {
                            initialValue: alwaysIncludeUserClaimsInIdToken,
                            valuePropName: 'checked'
                        })(
                            <Switch />
                        )
                    }
                </FormItem>
                <FormItem label="Pair Wise Subject Salt">
                    {
                        getFieldDecorator('pairWiseSubjectSalt', {
                            initialValue: pairWiseSubjectSalt
                        })(
                            <Input />
                        )
                    }
                </FormItem>
                <FormItem label="Client Claims Prefix">
                    {
                        getFieldDecorator('clientClaimsPrefix', {
                            initialValue: clientClaimsPrefix
                        })(
                            <Input />
                        )
                    }
                </FormItem>
                <FormItem label="Claims">
                    <Link to="">
                        <Button type="primary" htmlType="button">Claims</Button>
                    </Link>
                </FormItem>
            </>
        )
    }
}