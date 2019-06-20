import request from '../utils/request';
import CreateClientViewModel from '@/@types/CreateClientViewModel';

export const fetchClients = () => {
    return request("/api/v1.0/clients", {
        method: 'get'
    });
}

export const createClient = (model: CreateClientViewModel) => {
    return request('/api/v1.0/clients', {
        method: 'post',
        data: {
            ...model
        }
    })
}