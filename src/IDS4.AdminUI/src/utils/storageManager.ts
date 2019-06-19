class storageManager {
    _storage = localStorage;

    store(key: string, value: any) {

        this._storage.setItem(key, JSON.stringify(value));

    }
    retrieve(key: string, defValue: any = null) {

        let item = this._storage.getItem(key);
        if (item && item !== '') {
            return JSON.parse(item);
        }

        return defValue;
    }
}

export default new storageManager();