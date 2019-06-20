import axios, { AxiosResponse } from 'axios';
import userManager from './userManager';
import moment from 'moment';
import { message, notification } from 'antd';

export interface IRequestOptions {
    method?: "get" | "post" | "delete" | "put";
    data?: any;
    params?: any;
    headers?: any
}

const defaultOptions: IRequestOptions = {
    method: 'get'
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
                // var refreshTime = userManager.oidcUser.expires_at;
                // var currentTime = moment().unix().valueOf();
                
                // if (currentTime >= refreshTime) {
                    // todo : refresh access token
                // } else {
                    window.location.href = "/user/login";
                // }

            }
            // todo : handler other status code
        }
        return { success: false, data: false, errors: ["error!"] };

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
    }).then(checkResponse)
}

const checkResponse = (response: AxiosResponse) => {
    const { data } = response;
    if (data) {
        const { success, errors } = data;
        if (!success) {
            let description = errors;
            notification.error({
                message: 'Error!',
                description: description
            })
        }
    }
    return response;
}
