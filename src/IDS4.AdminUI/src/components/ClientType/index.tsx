import {  Col, Row, Icon } from "antd";
import React from "react";
import styles from './index.less';
import classNames from 'classnames';

const clientTypes = [{
    id: 0,
    name: 'Empty',
    desc: 'Default',
    icon: ''
}, {
    id: 1,
    name: 'Web App (MVC)',
    desc: 'Implicity Flow',
    icon: ''
}, {
    id: 2,
    name: 'Web App (MVC)',
    desc: 'Hybrid Flow',
    icon: ''
}, {
    id: 3,
    name: 'SPA (React, Angular...)',
    desc: 'Implicity Flow',
    icon: ''
}, {
    id: 4,
    name: 'Native App',
    desc: 'Hybrid Flow',
    icon: ''
}, {
    id: 5,
    name: 'Server',
    desc: 'Resource Owner Password & Client Credentials flow',
    icon: ''
}, {
    id: 6,
    name: 'Devices',
    desc: 'Device Flow',
    icon: ''
}]

export class ClientType extends React.Component<any, any> {
    static getDerivedStateFromProps(nextProps: any) {
        // Should be a controlled component.
        if ('value' in nextProps) {
            return {
                ...(nextProps.value || 0),
            };
        }
        return null;
    }

    constructor(props: any) {
        super(props);

        const value = props.value || 0;
        this.state = {
            type: value
        };
    }

    handleChange = (type: number) => {
        const onChange = this.props.onChange;
        if (Number.isNaN(type)) {
            return;
        }

        if (!('value' in this.props)) {
            this.setState({ type });
        }

        const data = Object.assign({}, this.state, { type });

        onChange && onChange(data);
    }

    render() {
        const { type } = this.state;
        return (
            <Row gutter={24}>
                {clientTypes.map(clientType => (
                    <Col key={clientType.id} lg={8} xs={24}>
                        <div className={classNames(styles.clienttype, type === clientType.id ? styles.active : '')}
                            onClick={this.handleChange.bind(this, clientType.id)}>
                            <Icon type="check" className={styles.check} />
                            <h2 className={styles.name}>{clientType.name}</h2>
                            <p className={styles.desc}>{clientType.desc}</p>
                        </div>
                    </Col>
                ))}
            </Row>
        )
    }
}