import { Effect } from './connect';
import { query, create, remove } from '@/services/user';
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
        create: Effect,
        remove: Effect
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
        *create({ payload }, { call, put, take }) {
            const { data } = yield call(create, payload);
            if (data.success) {
                yield put({ type: 'fetch', payload: {} });
            }
        },
        *remove({ payload }, { call, put }) {
            const { data } = yield call(remove, payload);
            if (data.success) {
                yield put({ type: 'fetch', payload: {} });
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