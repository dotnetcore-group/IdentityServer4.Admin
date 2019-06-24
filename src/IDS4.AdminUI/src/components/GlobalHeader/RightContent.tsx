import { ConnectProps, ConnectState } from '@/models/connect';

import Avatar from './AvatarDropdown';
import React from 'react';
import SelectLang from '../SelectLang';
import { connect } from 'dva';
import styles from './index.less';

export type SiderTheme = 'light' | 'dark';
export interface GlobalHeaderRightProps extends ConnectProps {
    theme?: SiderTheme;
    layout: 'sidemenu' | 'topmenu';
}

const GlobalHeaderRight: React.SFC<GlobalHeaderRightProps> = props => {
    const { theme, layout } = props;
    let className = styles.right;

    if (theme === 'dark' && layout === 'topmenu') {
        className = `${styles.right}  ${styles.dark}`;
    }

    return (
        <div className={className}>
            <Avatar />
            <SelectLang className={styles.action} />
        </div>
    );
};

export default connect(({ settings }: ConnectState) => ({
    theme: settings.navTheme,
    layout: settings.layout,
}))(GlobalHeaderRight);
