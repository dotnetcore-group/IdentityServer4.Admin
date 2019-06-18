import React from 'react';
import { Link } from 'react-router-dom';
import styles from './Header.less'
import HeaderNav from './HeaderNav';

export default class Header extends React.Component {
    render() {
        return (
            <div className={styles.header}>
                <div className="container">
                    <Link className={styles.logo} to="/">IDS4·A</Link>
                </div>
            </div>
        )
    }
}
