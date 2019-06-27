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
export const addSecret = (payload: any) => {
    const { clientId, model } = payload;
    return request(`/api/v1.0/clients/${clientId}/secrets`, {
        method: 'post',
        data: model
    })
}
export const removeSecret = (payload: any) => {
    const { clientId, id } = payload;
    return request(`/api/v1.0/clients/${clientId}/secrets/${id}`, {
        method: 'delete'
    })
}

// Client property
export async function getProperties(clientId: string): Promise<any> {
    return request(`/api/v1.0/clients/${clientId}/properties`, {
        method: 'get'
    })
}