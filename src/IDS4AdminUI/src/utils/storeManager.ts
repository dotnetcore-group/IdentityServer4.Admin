const storage = localStorage;

export default {
    store: (key: string, value: any) => {
        storage.setItem(key, JSON.stringify(value));
    },
    retrieve: (key: string, defValue: any = null) => {
        let item = storage.getItem(key);
        if (item && item !== '') {
            return JSON.parse(item);
        }
        return defValue;
    }
}
