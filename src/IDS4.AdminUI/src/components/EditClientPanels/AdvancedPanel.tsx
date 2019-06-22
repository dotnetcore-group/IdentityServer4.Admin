import React from 'react';
import IPanelPropsBase from './IPanelPropsBase';
import FormItem from './FormItem';
import { Switch, Select, Button } from 'antd';
import { Link } from 'umi';
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
    const {
      form: { getFieldDecorator },
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
      requireConsent,
    } = this.props;

    return (
      <>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.enabled',
            defaultMessage: 'Enabled',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.enabled.tip' })}
        >
          {getFieldDecorator('enabled', {
            initialValue: enabled,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.protocolType',
            defaultMessage: 'Protocol Type',
          })}
        >
          {getFieldDecorator('protocolType', {
            initialValue: protocolType,
          })(
            <Select>
              <Select.Option value="oidc">oidc</Select.Option>
            </Select>,
          )}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.requireClientSecret',
            defaultMessage: 'Require Client Secret',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.requireClientSecret.tip' })}
        >
          {getFieldDecorator('requireClientSecret', {
            initialValue: requireClientSecret,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.requirePkce',
            defaultMessage: 'Require Pkce',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.requirePkce.tip' })}
        >
          {getFieldDecorator('requirePkce', {
            initialValue: requirePkce,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.allowPlainTextPkce',
            defaultMessage: 'Allow Plain Text Pkce',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowPlainTextPkce.tip' })}
        >
          {getFieldDecorator('allowPlainTextPkce', {
            initialValue: allowPlainTextPkce,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.allowOfflineAccess',
            defaultMessage: 'Allow Offline Access',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowOfflineAccess.tip' })}
        >
          {getFieldDecorator('allowOfflineAccess', {
            initialValue: allowOfflineAccess,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.allowAccessTokensViaBrowser',
            defaultMessage: 'Allow Access Tokens Via Browser',
          })}
          tip={formatMessage({
            id: 'pages.clients.edit.tabs.panel.allowAccessTokensViaBrowser.tip',
          })}
        >
          {getFieldDecorator('allowAccessTokensViaBrowser', {
            initialValue: allowAccessTokensViaBrowser,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.allowedScopes',
            defaultMessage: 'Allowed Scopes',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowedScopes.tip' })}
        >
          {getFieldDecorator('allowedScopes', {
            initialValue: allowedScopes,
          })(
            <TagsInput
              newText={formatMessage({
                id: 'pages.clients.edit.tabs.addscope',
                defaultMessage: 'Add Scope',
              })}
            />,
          )}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.redirectUris',
            defaultMessage: 'Redirect Uris',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.redirectUris.tip' })}
        >
          {getFieldDecorator('redirectUris', {
            initialValue: redirectUris,
          })(
            <TagsInput
              longTagLength={25}
              newText={formatMessage({
                id: 'pages.clients.edit.tabs.addredirecturi',
                defaultMessage: 'Add Redirect Uri',
              })}
            />,
          )}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.allowedGrantTypes',
            defaultMessage: 'Allowed Grant Types',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.allowedGrantTypes.tip' })}
        >
          {getFieldDecorator('allowedGrantTypes', {
            initialValue: allowedGrantTypes,
          })(
            <Select mode="multiple">
              <Select.Option value="implicit">implicit</Select.Option>
              <Select.Option value="hybird">hybird</Select.Option>
              <Select.Option value="client_credentials">client_credentials</Select.Option>
              <Select.Option value="authorization_code">authorization_code</Select.Option>
              <Select.Option value="password">password</Select.Option>
            </Select>,
          )}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.requireConsentScreen',
            defaultMessage: 'Require Consent Screen',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.requireConsentScreen.tip' })}
        >
          {getFieldDecorator('requireConsent', {
            initialValue: requireConsent,
            valuePropName: 'checked',
          })(<Switch />)}
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.clientSecrets',
            defaultMessage: 'Client Secrets',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.clientSecrets.tip' })}
        >
          <Link to={`/clients/secrets?id=${clientId}`}>
            <Button type="primary" htmlType="button">
              {formatMessage({
                id: 'pages.clients.edit.tabs.panel.clientSecrets',
                defaultMessage: 'Client Secrets',
              })}
            </Button>
          </Link>
        </FormItem>
        <FormItem
          label={formatMessage({
            id: 'pages.clients.edit.tabs.panel.properties',
            defaultMessage: 'Properties',
          })}
          tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.properties.tip' })}
        >
          <Link to={`/clients/properties?id=${clientId}`}>
            <Button type="primary" htmlType="button">
              {formatMessage({
                id: 'pages.clients.edit.tabs.panel.properties',
                defaultMessage: 'Properties',
              })}
            </Button>
          </Link>
        </FormItem>
      </>
    );
  }
}
