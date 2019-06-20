export default class CreateClientViewModel {
    clientId?: string;
    clientName?: string;
    clientUri?: string;
    logoUri?: string;
    description?: string;
    clientTypeId?: number;

    /**
     *
     */
    constructor(clientId: string, clientName: string, clientType: number, clientUri: string, logoUri: string, description: string) {
        this.clientId = clientId;
        this.clientName = clientName;
        this.clientUri = clientUri;
        this.logoUri = logoUri;
        this.clientTypeId = clientType;
        this.description = description;
    }
}