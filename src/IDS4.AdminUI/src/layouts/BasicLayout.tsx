/**
 * Ant Design Pro v4 use `@ant-design/pro-layout` to handle Layout.
 * You can view component api by:
 * https://github.com/ant-design/ant-design-pro-layout
 */

import { ConnectProps, ConnectState } from '@/models/connect';
import ProLayout, {
    MenuDataItem,
    BasicLayoutProps as ProLayoutProps,
    Settings,
} from '@ant-design/pro-layout';
import React, { useState } from 'react';

import Authorized from '@/utils/Authorized';
import Link from 'umi/link';
import RightContent from '@/components/GlobalHeader/RightContent';
import { connect } from 'dva';
import { formatMessage } from 'umi-plugin-react/locale';
import logo from '../assets/logo.png';
import { Icon } from 'antd';

export interface BasicLayoutProps extends ProLayoutProps, ConnectProps {
    breadcrumbNameMap: {
        [path: string]: MenuDataItem;
    };
    settings: Settings;
}
export type BasicLayoutContext = { [K in 'location']: BasicLayoutProps[K] } & {
    breadcrumbNameMap: {
        [path: string]: MenuDataItem;
    };
};

/**
 * use Authorized check all menu item
 */
const menuDataRender = (menuList: MenuDataItem[]): MenuDataItem[] =>
    menuList.map(item => {
        const localItem = {
            ...item,
            children: item.children ? menuDataRender(item.children) : [],
        };
        return Authorized.check(item.authority, localItem, null) as MenuDataItem;
    });

const footerRender: BasicLayoutProps['footerRender'] = (_, defaultDom) => {
    return (
        <div style={{textAlign:'center',padding:'15px',color:'rgb(146, 146, 146)'}}>
            IdentityServer4 AdminUI <Icon type="copyright"/> 2019
        </div>
    )
};

const BasicLayout: React.FC<BasicLayoutProps> = props => {
    const { dispatch, children, settings } = props;
    /**
     * constructor
     */

    useState(() => {
        if (dispatch) {
            dispatch({
                type: 'user/fetchCurrent',
            });
            dispatch({
                type: 'settings/getSetting',
            });
        }
    });

    /**
     * init variables
     */
    const handleMenuCollapse = (payload: boolean): void =>
        dispatch &&
        dispatch({
            type: 'global/changeLayoutCollapsed',
            payload,
        });

    return (
        <ProLayout
            logo={logo}
            onCollapse={handleMenuCollapse}
            menuItemRender={(menuItemProps, defaultDom) => (
                <Link to={menuItemProps.path}>{defaultDom}</Link>
            )}
            breadcrumbRender={(routers = []) => [
                {
                    path: '/',
                    breadcrumbName: formatMessage({
                        id: 'menu.home',
                        defaultMessage: 'Home',
                    }),
                },
                ...routers,
            ]}
            footerRender={footerRender}
            menuDataRender={menuDataRender}
            formatMessage={formatMessage}
            rightContentRender={rightProps => <RightContent {...rightProps} />}
            {...props}
            {...settings}
        >
            {children}
        </ProLayout>
    );
};

export default connect(({ global, settings }: ConnectState) => ({
    collapsed: global.collapsed,
    settings,
}))(BasicLayout);
