import { NoticeIconData } from '@/components/NoticeIcon';
import { Reducer } from 'redux';
import { Subscription } from 'dva';

export interface NoticeItem extends NoticeIconData {
    id: string;
    type: string;
}

export interface GlobalModelState {
    collapsed: boolean;
    notices: NoticeItem[];
}

export interface GlobalModelType {
    namespace: 'global';
    state: GlobalModelState;
    reducers: {
        changeLayoutCollapsed: Reducer<GlobalModelState>;
    };
    subscriptions: { setup: Subscription };
}

const GlobalModel: GlobalModelType = {
    namespace: 'global',

    state: {
        collapsed: false,
        notices: [],
    },

    
    reducers: {
        changeLayoutCollapsed(state = { notices: [], collapsed: true }, { payload }): GlobalModelState {
            return {
                ...state,
                collapsed: payload,
            };
        },
        
    },

    subscriptions: {
        setup({ history }): void {
            // Subscribe history(url) change, trigger `load` action if pathname is `/`
            history.listen(({ pathname, search }): void => {
                if (typeof (window as any).ga !== 'undefined') {
                    (window as any).ga('send', 'pageview', pathname + search);
                }
            });
        },
    },
};

export default GlobalModel;
