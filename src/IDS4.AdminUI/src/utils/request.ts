import axios, { AxiosResponse } from 'axios';
import userManager from './userManager';
import { notification, message } from 'antd';
import { formatMessage } from 'umi-plugin-locale';

export interface IRequestOptions {
  method?: 'get' | 'post' | 'delete' | 'put';
  data?: any;
  params?: any;
  headers?: any;
}

const defaultOptions: IRequestOptions = {
  method: 'get',
};

// 添加请求拦截器
axios.interceptors.request.use(
  config => {
    let headers = config.headers;
    headers['authorization'] = userManager.getAccessToken();
    return {
      ...config,
      headers,
    };
  },
  error => {
    // 对请求错误做些什么
    return Promise.reject(error);
  },
);

axios.interceptors.response.use(
  (response: AxiosResponse) => response,
  async (error: any) => {
    const { response } = error;
    if (response) {
      const { status } = response;
      /** bad request */
      if (status === 400) {
        const { data } = response;
        if (data) {
          const { success, errors } = data;
          if (!success) {
            let description = errors;
            notification.error({
              message: 'Error!',
              description: description,
            });
          }
        }
        return response;
      } else if (status === 401) {
        /** unauthorized */
        // silent refresh token
        try {
          var user = await userManager.signinSilent();
          console.log('refresh access token successfully! resend the request...');
          message.success(formatMessage({ id: 'app.shared.refreshtoken.successfully' }));
          userManager.storeOidcUser(user);

          const { config } = error;
          return axios(config);
        } catch (err) {
          console.error('refresh token error! redirect to login page.');
          console.error(err);
          window.location.href = '/user/login';
        }
      }
      // todo : handler other status code
    }
    return { success: false, data: false, errors: ['error!'] };
  },
);

export default function request(url: string, options: IRequestOptions) {
  const newOptions = { ...defaultOptions, ...options };
  if (newOptions.method === 'get' && newOptions.params) {
    let paramsArray: Array<any> = [];
    Object.keys(newOptions.params).forEach(key =>
      paramsArray.push(key + '=' + newOptions.params[key]),
    );
    if (url.search(/\?/) === -1) {
      url += '?' + paramsArray.join('&');
    } else {
      url += '&' + paramsArray.join('&');
    }
  }

  return axios({
    ...newOptions,
    url,
  });
}
