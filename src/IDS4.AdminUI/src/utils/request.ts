import axios, { AxiosResponse } from 'axios';
import userManager from './userManager';
import moment from 'moment';
import oidcResponse from '../@types/oidcResponse';
import { router } from 'umi';

export interface IRequestOptions {
    method?: "get" | "post" | "delete" | "put";
    data?: any;
    params?: any;
    headers?: any
}

const defaultOptions: IRequestOptions = {
    method: 'get'
}

const codeMessage: any = {
    200: '服务器成功返回请求的数据。',
    201: '新建或修改数据成功。',
    202: '一个请求已经进入后台排队（异步任务）。',
    204: '删除数据成功。',
    400: '发出的请求有错误，服务器没有进行新建或修改数据的操作。',
    401: '用户没有权限（令牌、用户名、密码错误）。',
    403: '用户得到授权，但是访问是被禁止的。',
    404: '发出的请求针对的是不存在的记录，服务器没有进行操作。',
    406: '请求的格式不可得。',
    410: '请求的资源被永久删除，且不会再得到的。',
    422: '当创建一个对象时，发生一个验证错误。',
    500: '服务器发生错误，请检查服务器。',
    502: '网关错误。',
    503: '服务不可用，服务器暂时过载或维护。',
    504: '网关超时。',
};

const checkStatus = function (response: AxiosResponse<any>) {
    if (response.status >= 200 && response.status < 300) {
        return response;
    }
    const errortext = codeMessage[response.status] || response.statusText;
    const error = new Error(errortext);
    error.name = response.status + "";
    throw error;
}

// 添加请求拦截器
axios.interceptors.request.use((config) => {
    let headers = config.headers;
    headers['authorization'] = userManager.getAccessToken();
    return {
        ...config,
        headers
    };
}, (error) => {
    // 对请求错误做些什么
    return Promise.reject(error);
});

axios.interceptors.response.use(
    (response: AxiosResponse) => response,
    (error: any) => {
        const { response } = error;
        if (response) {
            const { status } = response;
            console.log(status === 401);
            if (status === 401) {
                var refreshTime = userManager.oidcUser.expires_at;
                var currentTime = moment().unix().valueOf();

                if (currentTime >= refreshTime) {
                    // todo : refresh access token
                }else{
                    window.location.href = "/user/login";
                }

            }
            return error;
        }

    }
)


export default function request(url: string, options: IRequestOptions) {

    const newOptions = { ...defaultOptions, ...options };
    if (newOptions.method === 'get' && newOptions.params) {
        let paramsArray: Array<any> = [];
        Object.keys(newOptions.params).forEach(key => paramsArray.push(key + '=' + newOptions.params[key]))
        if (url.search(/\?/) === -1) {
            url += '?' + paramsArray.join('&')
        } else {
            url += '&' + paramsArray.join('&')
        }
    }

    return axios({
        ...newOptions,
        url
    }).then(checkStatus)
}
