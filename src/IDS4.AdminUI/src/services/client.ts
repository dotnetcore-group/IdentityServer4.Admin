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

export const removeClient = (clientId: string) => {
    return request(`/api/v1.0/clients/${clientId}`, {
        method: 'delete'
    })
}

export const fetchClient = (id: string) => {
    return request(`/api/v1.0/clients/${id}`, {
        method: 'get'
    });
}

export const updateClient = (model: any) => {
    return request('/api/v1.0/clients', {
        method: 'put',
        data: {
            ...model
        }
    })
}


// Client Secrets
export const getSecrets = (id: string) => {
    return request(`/api/v1.0/clients/${id}/secrets`, {
        method: 'get'
    });
}