import React from 'react';
import IPanelPropsBase from './IPanelPropsBase';
import { Switch, Select, Input, Button, InputNumber } from 'antd';
import FormItem from './FormItem';
import { Link } from 'umi';
import { formatMessage } from 'umi-plugin-locale';

export interface ITokenPanelProps extends IPanelPropsBase {
  clientId?: string;
  identityTokenLifetime?: number;
  accessTokenLifetime?: number;
  accessTokenType?: number;
  authorizationCodeLifetime?: number;
  absoluteRefreshTokenLifetime?: number;
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
    const {
      form: { getFieldDecorator },
      clientId,
      identityTokenLifetime,
      accessTokenLifetime,
      accessTokenType,
      authorizationCodeLifetime,
      absoluteRefreshTokenLifetime,
      slidingRefreshTokenLifetime,
      refreshTokenUsage,
      refreshTokenExpiration,
      updateAccessTokenClaimsOnRefresh,
      includeJwtId,
      alwaysSendClientClaims,
      alwaysIncludeUserClaimsInIdToken,
      pairWiseSubjectSalt,
      clientClaimsPrefix,
    } = this.props;

    return (
      <>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.identityTokenLifetime',
            defaultMessage: 'Identity Token Lifetime',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.identityTokenLifetime.tip' })}
        >
          {getFieldDecorator('identityTokenLifetime', {
            initialValue: identityTokenLifetime,
          })(<InputNumber />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.accessTokenLifetime',
            defaultMessage: 'Access Token Lifetime',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.accessTokenLifetime.tip' })}
        >
          {getFieldDecorator('accessTokenLifetime', {
            initialValue: accessTokenLifetime,
          })(<InputNumber />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.accessTokenType',
            defaultMessage: 'Access Token Type',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.accessTokenType.tip' })}
        >
          {getFieldDecorator('accessTokenType', {
            initialValue: accessTokenType,
          })(
            <Select>
              <Select.Option value={0}>Jwt</Select.Option>
              <Select.Option value={1}>Reference</Select.Option>
            </Select>,
          )}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.authorizationCodeLifetime',
            defaultMessage: 'Authorization Code Lifetime',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.authorizationCodeLifetime.tip' })}
        >
          {getFieldDecorator('authorizationCodeLifetime', {
            initialValue: authorizationCodeLifetime,
          })(<InputNumber />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.absoluteRefreshTokenLifetime',
            defaultMessage: 'Absolute Refresh Token Lifetime',
          })}
          tip={formatMessage({
            id: 'pages.clients.edit.tabs.panel.absoluteRefreshTokenLifetime.tip',
          })}
        >
          {getFieldDecorator('absoluteRefreshTokenLifetime', {
            initialValue: absoluteRefreshTokenLifetime,
          })(<InputNumber />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.slidingRefreshTokenLifetime',
            defaultMessage: 'Sliding Refresh Token Lifetime',
          })}
          tip={formatMessage({
            id: 'pages.clients.edit.tabs.panel.slidingRefreshTokenLifetime.tip',
          })}
        >
          {getFieldDecorator('slidingRefreshTokenLifetime', {
            initialValue: slidingRefreshTokenLifetime,
          })(<InputNumber />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.refreshTokenUsage',
            defaultMessage: 'Refresh Token Usage',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.refreshTokenUsage.tip' })}
        >
          {getFieldDecorator('refreshTokenUsage', {
            initialValue: refreshTokenUsage,
          })(
            <Select>
              <Select.Option
                title={formatMessage({
                  id: 'pages.clients.edit.tabs.panel.refreshTokenUsage.reuse.tip',
                })}
                value={0}
              >
                {formatMessage({
                  id: 'pages.clients.edit.tabs.panel.refreshTokenUsage.reuse',
                  defaultMessage: 'ReUse',
                })}
              </Select.Option>
              <Select.Option
                title={formatMessage({
                  id: 'pages.clients.edit.tabs.panel.refreshTokenUsage.onetimeonly.tip',
                })}
                value={1}
              >
                {formatMessage({
                  id: 'pages.clients.edit.tabs.panel.refreshTokenUsage.onetimeonly',
                  defaultMessage: 'One Time Only',
                })}
              </Select.Option>
            </Select>,
          )}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.refreshTokenExpiration',
            defaultMessage: 'Refresh Token Expiration',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.refreshTokenExpiration.tip' })}
        >
          {getFieldDecorator('refreshTokenExpiration', {
            initialValue: refreshTokenExpiration,
          })(
            <Select>
              <Select.Option value={0}>
                {formatMessage({
                  id: 'pages.clients.edit.tabs.panel.refreshTokenExpiration.sliding',
                  defaultMessage: 'Sliding',
                })}
              </Select.Option>
              <Select.Option value={1}>
                {formatMessage({
                  id: 'pages.clients.edit.tabs.panel.refreshTokenExpiration.absolute',
                  defaultMessage: 'Absolute',
                })}
              </Select.Option>
            </Select>,
          )}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.updateAccessTokenClaimsOnRefresh',
            defaultMessage: 'Update Access Token Claims On Refresh',
          })}
          tip={formatMessage({
            id: 'pages.clients.edit.tabs.panel.updateAccessTokenClaimsOnRefresh.tip',
          })}
        >
          {getFieldDecorator('updateAccessTokenClaimsOnRefresh', {
            initialValue: updateAccessTokenClaimsOnRefresh,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.includeJwtId',
            defaultMessage: 'Include Jwt Id',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.includeJwtId.tip' })}
        >
          {getFieldDecorator('includeJwtId', {
            initialValue: includeJwtId,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.alwaysSendClientClaims',
            defaultMessage: 'Always Send Client Claims',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.alwaysSendClientClaims.tip' })}
        >
          {getFieldDecorator('alwaysSendClientClaims', {
            initialValue: alwaysSendClientClaims,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.alwaysIncludeUserClaimsInIdToken',
            defaultMessage: 'Always Include User Claims In IdToken',
          })}
          tip={formatMessage({
            id: 'pages.clients.edit.tabs.panel.alwaysIncludeUserClaimsInIdToken.tip',
          })}
        >
          {getFieldDecorator('alwaysIncludeUserClaimsInIdToken', {
            initialValue: alwaysIncludeUserClaimsInIdToken,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.pairWiseSubjectSalt',
            defaultMessage: 'Pair Wise Subject Salt',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.pairWiseSubjectSalt.tip' })}
        >
          {getFieldDecorator('pairWiseSubjectSalt', {
            initialValue: pairWiseSubjectSalt,
          })(<Input />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.clientClaimsPrefix',
            defaultMessage: 'Client Claims Prefix',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.clientClaimsPrefix.tip' })}
        >
          {getFieldDecorator('clientClaimsPrefix', {
            initialValue: clientClaimsPrefix,
          })(<Input />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.claims',
            defaultMessage: 'Claims',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.claims.tip' })}
        >
          <Link to={`/clients/claims?id=${clientId}`}>
            <Button type="primary" htmlType="button">
              {formatMessage({
                id: 'pages.clients.edit.tabs.panel.claims',
                defaultMessage: 'Claims',
              })}
            </Button>
          </Link>
        </FormItem>
      </>
    );
  }
}
