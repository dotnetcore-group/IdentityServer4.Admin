import React from 'react';
import styles from './index.css';
import Header from '@/components/Header/Header';
import classNames from 'classnames'
import MainNav from '@/components/MainNav/MainNav';

const BasicLayout: React.FC = (props) => {
    return (
        <div className={styles.wrapper}>
            <Header />
            <div className={classNames("container", styles.container)}>
                <div className={styles.nav}>
                    <MainNav />
                </div>
                <div className={styles.content}>
                    {props.children}
                </div>
            </div>
        </div>
    );
};

export default BasicLayout;
