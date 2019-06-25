import { Effect } from './connect';
import { query, create } from '@/services/user';
import PagingQueryViewModel from '@/@types/PagingQueryViewModel';
import { Reducer } from "redux";

export interface IUsersModelState {
    list?: {
        data?: Array<any>,
        total?: number
    }
}

export interface IUsersModelType {
    namespace: string;
    state: IUsersModelState,
    effects: {
        fetch: Effect,
        create: Effect
    },
    reducers: {
        save: Reducer<IUsersModelState>
    }
}

const UsersModelType: IUsersModelType = {
    namespace: 'users',
    state: {},
    effects: {
        *fetch({ payload }, { put, call }) {
            const { data: response } = yield call(query, payload as PagingQueryViewModel);
            const { success, data } = response;
            if (success) {
                yield put({
                    type: 'save',
                    payload: {
                        list: { ...data }
                    }
                })
            }
        },
        *create({ payload }, { call, put }) {
            const { data } = yield call(create, payload);
            if (data.success) {
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

export default UsersModelType;