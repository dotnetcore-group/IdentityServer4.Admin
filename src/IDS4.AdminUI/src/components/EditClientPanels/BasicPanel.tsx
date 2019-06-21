import React from 'react';
import { Input } from 'antd';
import IPanelPropsBase from './IPanelPropsBase';
import FormItem from './FormItem';
import { formatMessage } from 'umi-plugin-locale';

export interface IBasicPanelProps extends IPanelPropsBase {
    clientId?: string;
    clientName?: string;
    clientUri?: string;
    logoUri?: string;
    description?: string;
}

export default class BasicPanel extends React.Component<IBasicPanelProps> {
    render() {
        const { form: { getFieldDecorator }, clientId, clientName, clientUri, logoUri, description } = this.props;

        return (
            <>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.clientId', defaultMessage: 'Client Id' })}
                    tip="test">
                    {getFieldDecorator('clientId', {
                        initialValue: clientId
                    })(
                        <Input />
                    )}
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.clientName', defaultMessage: 'Client Name' })}>
                    {getFieldDecorator('clientName', {
                        initialValue: clientName
                    })(
                        <Input />
                    )}
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.clientUri', defaultMessage: 'Client Uri' })}>
                    {getFieldDecorator('clientUri', {
                        initialValue: clientUri
                    })(
                        <Input />
                    )}
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.logoUri', defaultMessage: 'Logo Uri' })}>
                    {getFieldDecorator('logoUri', {
                        initialValue: logoUri
                    })(
                        <Input />
                    )}
                </FormItem>
                <FormItem label={formatMessage({ id: 'pages.clients.edit.tabs.panel.description', defaultMessage: 'Description' })}>
                    {getFieldDecorator('description', {
                        initialValue: description
                    })(
                        <Input.TextArea />
                    )}
                </FormItem>
            </>
        )
    }
}