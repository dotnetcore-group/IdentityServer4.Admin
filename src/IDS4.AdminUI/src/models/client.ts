import IClientViewModel from "@/@types/IClientViewModel";
import { Reducer } from "redux";
import { Effect } from "dva";
import { fetchClients, createClient, removeClient, updateClient, getSecrets, removeSecret, getProperties } from "@/services/client";
import { message } from "antd";
import { router } from "umi";
import { fetchClient, addSecret } from '../services/client';

export interface IClientModelState {
    list?: Array<IClientViewModel>;
    detail?: any;
    secrets?: Array<any>;
    properties?: Array<any>
}

export interface IClientModelType {
    namespace: 'client';
    state: IClientModelState;
    effects: {
        fetchList: Effect,
        fetchDetail: Effect,
        create: Effect,
        remove: Effect,
        update: Effect,
        fetchSecrets: Effect,
        createSecret: Effect,
        removeSecret: Effect,
        fetchProperties: Effect
    };
    reducers: {
        save: Reducer<IClientModelState>
    };
}

const ClientModel: IClientModelType = {
    namespace: 'client',
    state: {
        list: [],
        detail: {},
        secrets: [],
        properties: []
    },
    effects: {
        /**Client */
        *fetchList(_, { call, put }) {
            const response = yield call(fetchClients);
            const { data: { data: list } } = response;
            yield put({
                type: 'save',
                payload: {
                    list
                }
            })
        },
        *fetchDetail({ payload }, { call, put }) {
            const response = yield call(fetchClient, payload);
            const { data } = response;
            if (data && data.success) {
                const { data: detail } = data;
                yield put({
                    type: 'save',
                    payload: {
                        detail
                    }
                })
            }
        },
        *create({ payload }, { call }) {
            const { clientId } = payload;
            const response = yield call(createClient, payload);
            const { data } = response;
            if (data.success) {
                message.success("create success!");
                router.push(`/clients/edit?id=${clientId}`);
            }
        },
        *remove({ payload }, { call, put }) {
            yield call(removeClient, payload);

            const response = yield call(fetchClients);
            const { data: { data: list } } = response;
            yield put({
                type: 'save',
                payload: {
                    list
                }
            })
        },
        *update({ payload }, { call, put }) {
            const response = yield call(updateClient, payload);
            const { data } = response;
            if (data.success) {
                message.success("update success!");
                router.push('/clients');
            }
        },


        /**Secret */
        *fetchSecrets({ payload }, { call, put }) {
            const response = yield call(getSecrets, payload);
            const { data } = response;
            if (data.success) {
                const secrets = data.data;
                yield put({
                    type: 'save',
                    payload: {
                        secrets
                    }
                })
            }
        },
        *createSecret({ payload }, { call, put }) {
            const { clientId } = payload;
            const response = yield call(addSecret, { ...payload });
            const { data } = response;
            if (data.success) {
                const { data: { data: secrets } } = yield call(getSecrets, clientId);
                yield put({
                    type: 'save',
                    payload: {
                        secrets
                    }
                })
            }
        },
        *removeSecret({ payload }, { call, put }) {
            const { clientId } = payload;
            const { data } = yield call(removeSecret, { ...payload });
            if (data.success) {
                const { data: { data: secrets } } = yield call(getSecrets, clientId);
                yield put({
                    type: 'save',
                    payload: {
                        secrets
                    }
                })
            }
        },


        /**Property */
        *fetchProperties({ payload }, { call, put }) {
            const { data } = yield call(getProperties, payload);
            if (data.success) {
                const { data: properties } = data;
                yield put({
                    type: 'save',
                    payload: {
                        properties
                    }
                });
            }
        }
    },
    reducers: {
        save(state, { payload }) {
            return ({
                ...state,
                ...payload
            })
        }
    }
}

export default ClientModel;