import { IConfig } from 'umi-types';

const routes = [{
    path: '/login',
    component: "./Login.tsx"
},{
    path: '/signin-callback-oidc',
    component: "./Callback.tsx"
}, {
    path: '/',
    component: "../layouts/index.tsx",
    Routes: ['src/components/Authoirze'],
    routes: [{
        path: '/',
        component: './index.tsx'
    }]
}];


// ref: https://umijs.org/config/
const config: IConfig = {
    treeShaking: true,
    routes,
    plugins: [
        // ref: https://umijs.org/plugin/umi-plugin-react.html
        ['umi-plugin-react', {
            antd: true,
            dva: true,
            dynamicImport: { webpackChunkName: true },
            title: 'IDS4AdminUI',
            dll: false,
            locale: {
                enable: true,
                default: 'en-US',
            },
            routes: {
                exclude: [
                    /models\//,
                    /services\//,
                    /model\.(t|j)sx?$/,
                    /service\.(t|j)sx?$/,
                    /components\//,
                ],
            },
        }],
    ],
}

export default config;
