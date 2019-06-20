import IClientViewModel from "@/@types/IClientViewModel";
import { Reducer } from "redux";
import { Effect } from "dva";
import { fetchClients, createClient } from "@/services/client";
import { message } from "antd";
import { router } from "umi";

export interface IClientModelState {
    list?: Array<IClientViewModel>;
}

export interface IClientModelType {
    namespace: 'client';
    state: IClientModelState;
    effects: {
        fetchList: Effect,
        create: Effect
    };
    reducers: {
        save: Reducer<IClientModelState>
    };
}

const ClientModel: IClientModelType = {
    namespace: 'client',
    state: {},
    effects: {
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
        *create({ payload }, { call, put }) {
            const response = yield call(createClient, payload);
            const { data } = response;
            if (data.success) {
                message.success("create success!");
                router.push('/clients');
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