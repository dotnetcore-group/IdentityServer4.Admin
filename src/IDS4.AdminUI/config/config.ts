import { IConfig, IPlugin } from 'umi-types';

import defaultSettings from './defaultSettings';
// https://umijs.org/config/
import os from 'os';
import slash from 'slash2';
import webpackPlugin from './plugin.config';
import routes from './route.config';

const { pwa, primaryColor } = defaultSettings;

// preview.pro.ant.design only do not use in your production ;
// preview.pro.ant.design 专用环境变量，请不要在你的项目中使用它。

const { TEST, NODE_ENV } = process.env;
const plugins: IPlugin[] = [
    [
        'umi-plugin-react',
        {
            antd: true,
            dva: {
                hmr: true,
            },
            locale: {
                // default false
                enable: true,
                // default zh-CN
                default: 'zh-CN',
                // default true, when it is true, will use `navigator.language` overwrite default
                baseNavigator: true,
            },
            dynamicImport: {
                loadingComponent: './components/PageLoading/index',
                webpackChunkName: true,
                level: 3,
            },
            pwa: pwa
                ? {
                    workboxPluginMode: 'InjectManifest',
                    workboxOptions: {
                        importWorkboxFrom: 'local',
                    },
                }
                : false,
            ...(!TEST && os.platform() === 'darwin'
                ? {
                    dll: {
                        include: ['dva', 'dva/router', 'dva/saga', 'dva/fetch'],
                        exclude: ['@babel/runtime', 'netlify-lambda'],
                    },
                    hardSource: false,
                }
                : {}),
        },
    ],
    [
        'umi-plugin-pro-block',
        {
            moveMock: false,
            moveService: false,
            modifyRequest: true,
            autoAddMenu: true,
        },
    ],
]; // 针对 preview.pro.ant.design 的 GA 统计代码
// preview.pro.ant.design only do not use in your production ; preview.pro.ant.design 专用环境变量，请不要在你的项目中使用它。

const uglifyJSOptions =
    NODE_ENV === 'production'
        ? {
            uglifyOptions: {
                // remove console.* except console.error
                compress: {
                    drop_console: true,
                    pure_funcs: ['console.error'],
                },
            },
        }
        : {};
export default {
    // add for transfer to umi
    plugins,
    define: {
        // sso endpoint
        "AUTHORITY_ENDPOINT": 'http://localhost:5006',
        // this website endpoint
        "DOMAIN_ENDPOINT": 'http://localhost:8000',
    },
    block: {
    },
    treeShaking: true,
    targets: {
        ie: 11,
    },
    devtool: false,
    // 路由配置
    routes,
    // Theme for antd
    // https://ant.design/docs/react/customize-theme-cn
    theme: {
        'primary-color': primaryColor,
    },
    proxy: {
        "/api": {
            "target": `http://localhost:5004/api`,
            "changeOrigin": true,
            "pathRewrite": { "^/api": "" }
        }
    },
    ignoreMomentLocale: true,
    lessLoaderOptions: {
        javascriptEnabled: true,
    },
    disableRedirectHoist: true,
    cssLoaderOptions: {
        modules: true,
        getLocalIdent: (
            context: {
                resourcePath: string;
            },
            localIdentName: string,
            localName: string,
        ) => {
            if (
                context.resourcePath.includes('node_modules') ||
                context.resourcePath.includes('ant.design.pro.less') ||
                context.resourcePath.includes('global.less')
            ) {
                return localName;
            }

            const match = context.resourcePath.match(/src(.*)/);

            if (match && match[1]) {
                const antdProPath = match[1].replace('.less', '');
                const arr = slash(antdProPath)
                    .split('/')
                    .map((a: string) => a.replace(/([A-Z])/g, '-$1'))
                    .map((a: string) => a.toLowerCase());
                return `antd-pro${arr.join('-')}-${localName}`.replace(/--/g, '-');
            }

            return localName;
        },
    },
    manifest: {
        basePath: '/',
    },
    uglifyJSOptions,
    chainWebpack: webpackPlugin,
} as IConfig;
