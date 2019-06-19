import request from '../utils/request';

export const fetchClients = () => {
    return request("/api/v1.0/clients", {
        method: 'get'
    });
}