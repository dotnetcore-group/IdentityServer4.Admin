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
        const {
            form: { getFieldDecorator },
            clientId,
            clientName,
            clientUri,
            logoUri,
            description,
        } = this.props;

        return (
            <>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.clientId',
                        defaultMessage: 'Client Id',
                    })}
                    tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.clientId.tip' })}
                >
                    {getFieldDecorator('clientId', {
                        initialValue: clientId,
                    })(<Input />)}
                </FormItem>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.clientName',
                        defaultMessage: 'Client Name',
                    })}
                    tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.clientName.tip' })}
                >
                    {getFieldDecorator('clientName', {
                        initialValue: clientName,
                    })(<Input />)}
                </FormItem>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.clientUri',
                        defaultMessage: 'Client Uri',
                    })}
                    tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.clientUri.tip' })}
                >
                    {getFieldDecorator('clientUri', {
                        initialValue: clientUri,
                    })(<Input />)}
                </FormItem>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.logoUri',
                        defaultMessage: 'Logo Uri',
                    })}
                    tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.logoUri.tip' })}
                >
                    {getFieldDecorator('logoUri', {
                        initialValue: logoUri,
                    })(<Input />)}
                </FormItem>
                <FormItem
                    label={formatMessage({
                        id: 'pages.clients.edit.tabs.panel.description',
                        defaultMessage: 'Description',
                    })}
                    tip={formatMessage({ id: 'pages.clients.edit.tabs.panel.description.tip' })}
                >
                    {getFieldDecorator('description', {
                        initialValue: description,
                    })(<Input.TextArea />)}
                </FormItem>
            </>
        );
    }
}
