import { Form } from "antd";
import React from 'react';

export default class FormItem extends Form.Item {
    render() {

        const formItemLayout = {
            labelCol: {
                xs: { span: 24 },
                sm: { span: 4 },
            },
            wrapperCol: {
                xs: { span: 24 },
                sm: { span: 12 },
            },
        }

        return (
            <Form.Item {...this.props} {...formItemLayout} labelAlign="left">

            </Form.Item>
        )
    }
}