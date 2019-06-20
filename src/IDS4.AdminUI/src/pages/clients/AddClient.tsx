import React from 'react';
import { Card, Form, Input, Tooltip, Icon } from 'antd';
import Button from 'antd/es/button/button';
import { formatMessage } from 'umi-plugin-locale';
import { router } from 'umi';
import FormItem from 'antd/lib/form/FormItem';
import { ClientType } from '@/components/ClientType';
import TextArea from 'antd/lib/input/TextArea';
import { connect } from 'dva';
import { ConnectState } from '@/models/connect';
import { ConnectProps } from '../../models/connect';
import CreateClientViewModel from '@/@types/CreateClientViewModel';

const CreateClientForm = Form.create()((props: any) => {
    const formItemLayout = {
        labelCol: {
            xs: { span: 24 },
            sm: { span: 7 },
        },
        wrapperCol: {
            xs: { span: 24 },
            sm: { span: 12 },
            md: { span: 10 }
        },
    };

    const noLabelLayout = {
        wrapperCol: {
            xs: { span: 24, offset: 0 },
            sm: { span: 12, offset: 7 },
            md: { span: 10, offset: 7 }
        }
    }

    const { getFieldDecorator } = props.form;

    const renderLabel = (labelId: string, tipId: string, defLabel = '', defTip = '') => (
        <>
            {formatMessage({ id: labelId, defaultMessage: defLabel })}
            <span style={{ marginLeft: '5px' }}>
                < Tooltip placement="topLeft" title={formatMessage({ id: tipId, defaultMessage: defTip })} >
                    <Icon type="question-circle" />
                </Tooltip >
            </span>
        </>
    )

    return (
        <Form {...formItemLayout} onSubmit={e => {
            e.preventDefault();
            props.form.validateFields((err: any, values: any) => {
                if (!err) {
                    const { onSubmit } = props;
                    onSubmit && onSubmit(values);
                }
            });
        }}>
            <Form.Item label={renderLabel('pages.clients.add.form.clientid', 'pages.clients.add.form.clientid.tip', 'Client Id')}>
                {getFieldDecorator('clientId', {
                    rules: [{ required: true, message: formatMessage({ id: 'pages.clients.add.form.clientid.required' }) }]
                })(
                    <Input />
                )}
            </Form.Item>
            <Form.Item label={renderLabel('pages.clients.add.form.clientname', 'pages.clients.add.form.clientname.tip', 'Client Name')}>
                {getFieldDecorator('clientName', {
                    rules: [{ required: true, message: formatMessage({ id: 'pages.clients.add.form.clientname.required' }) }]
                })(
                    <Input />
                )}
            </Form.Item>
            <Form.Item label={renderLabel('pages.clients.add.form.clienturi', 'pages.clients.add.form.clienturi.tip', 'Client Uri')}>
                {getFieldDecorator('clientUri', {})(
                    <Input />
                )}
            </Form.Item>
            <Form.Item label={renderLabel('pages.clients.add.form.logouri', 'pages.clients.add.form.logouri.tip', 'Logo Uri')}>
                {getFieldDecorator('logoUri', {})(
                    <Input />
                )}
            </Form.Item>
            <Form.Item label={renderLabel('pages.clients.add.form.description', 'pages.clients.add.form.description.tip', 'Description')}>
                {getFieldDecorator('description', {})(
                    <TextArea />
                )}
            </Form.Item>
            <FormItem {...noLabelLayout}>
                {getFieldDecorator('clientType', {
                    initialValue: 0
                })(
                    <ClientType />
                )}
            </FormItem>
            <FormItem {...noLabelLayout}>
                <Button htmlType="submit"
                    loading={props.creating}
                    type="primary">
                    {formatMessage({ id: 'pages.clients.add.from.create', defaultMessage: 'Create' })}
                </Button>
            </FormItem>
        </Form>
    )
})

export interface IAddClientProps extends ConnectProps {
    creating?: boolean
}

class AddClient extends React.Component<IAddClientProps> {

    handleSubmit(values: any) {
        const { clientId, clientName, clientUri, logoUri, description, clientType: { type } } = values;
        const model = new CreateClientViewModel(clientId, clientName, type, clientUri, logoUri, description);
        const { dispatch } = this.props;
        dispatch && dispatch({
            type: 'client/create',
            payload: {
                ...model
            }
        })
    }

    render() {
        const { creating } = this.props;

        return (
            <Card>
                <div>
                    <Button icon="left" type="default" onClick={() => { router.goBack() }}>
                        {formatMessage({ id: 'pages.clients.add.goback', defaultMessage: 'Go Back' })}
                    </Button>
                </div>

                <CreateClientForm onSubmit={this.handleSubmit.bind(this)}
                    creating={creating} />
            </Card>
        )
    }
}

export default connect(({ client, loading }: ConnectState) => ({
    creating: loading.effects['client/create']
}))(AddClient);