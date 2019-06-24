import { Form, Tooltip, Icon } from "antd";
import React from 'react';
import { FormItemProps } from "antd/lib/form";

export interface IFormItemProps extends FormItemProps {
    tip?: React.ReactNode;
}

export default class FormItem extends React.Component<IFormItemProps> {
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

        const { children } = this.props;

        return (
            <Form.Item {...this.props}
                {...formItemLayout}
                labelAlign="left"
                label={this.renderFormLabel()}>
                {children}
            </Form.Item>
        )
    }

    renderFormLabel() {
        const { label, tip } = this.props;
        return (
            <>
                {label}
                {
                    tip &&
                    <Tooltip title={tip}>
                        <span style={{ marginLeft: '5px' }}>
                            <Icon type="question-circle" />
                        </span>
                    </Tooltip>
                }
            </>
        )
    }
}