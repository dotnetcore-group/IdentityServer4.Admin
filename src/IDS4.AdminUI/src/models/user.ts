import { query as queryUsers } from '@/services/user';

import { Effect } from 'dva';
import { Reducer } from 'redux';
import UserProfile from '@/@types/userProfile';
import userManager from '@/utils/userManager';
import { router } from 'umi';

export interface UserModelState {
    currentUser?: UserProfile;
}

export interface UserModelType {
    namespace: 'user';
    state: UserModelState;
    effects: {
        fetch: Effect;
        saveOidcResponse: Effect;
    };
    reducers: {
        saveCurrentUser: Reducer<UserModelState>;
    };
}

const UserModel: UserModelType = {
    namespace: 'user',

    state: {
        currentUser: userManager.currentUser,
    },

    effects: {
        *fetch(_, { call, put }) {
            const response = yield call(queryUsers);
            yield put({
                type: 'save',
                payload: response,
            });
        },
        *saveOidcResponse({ payload }, { put }) {
            userManager.storeOidcUser(payload);
            const { profile } = payload;
            
            yield put({
                type: 'saveCurrentUser',
                payload: profile
            })

            router.push("/")
        }
    },

    reducers: {
        saveCurrentUser(state, action) {
            console.log(action.payload);
            return {
                ...state,
                currentUser: action.payload || {},
            };
        }
    },
};

export default UserModel;
