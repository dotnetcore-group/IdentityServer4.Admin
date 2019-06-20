import React from 'react';
import { Form, Input } from 'antd';

export default class BasicPanel extends React.Component<any> {
    render() {
        const { form: { getFieldDecorator }, detail = {} } = this.props;
        console.log(detail);
        return (
            <div>
                <Form.Item label="Client Id">
                    {getFieldDecorator('clientId', {
                        initialValue: detail.clientId
                    })(
                        <Input />
                    )}
                </Form.Item>
                <Form.Item label="Client Name">
                    {getFieldDecorator('clientName', {
                        initialValue: detail.clientName
                    })(
                        <Input />
                    )}
                </Form.Item>
                <Form.Item label="Client Uri">
                    {getFieldDecorator('clientUri', {
                        initialValue: detail.clientUri
                    })(
                        <Input />
                    )}
                </Form.Item>
                <Form.Item label="Logo Uri">
                    {getFieldDecorator('logoUri', {
                        initialValue: detail.logoUri
                    })(
                        <Input />
                    )}
                </Form.Item>
                <Form.Item label="Description">
                    {getFieldDecorator('description', {
                        initialValue: detail.description
                    })(
                        <Input />
                    )}
                </Form.Item>
            </div>
        )
    }
}