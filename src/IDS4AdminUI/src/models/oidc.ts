import storeManager from '@/utils/storeManager';

const getInitialState = () => {
    
    const value = storeManager.retrieve("oidc", {});
    
    return value;
}

const initialState = getInitialState();

export default {
    namespace: 'oidc',
    state: {
        ...initialState
    },
    reducers: {
        'save'(state: any, action: any) {
            const { payload } = action;
            storeManager.store('oidc', payload);
            return ({ ...payload })
        }
    }
}
