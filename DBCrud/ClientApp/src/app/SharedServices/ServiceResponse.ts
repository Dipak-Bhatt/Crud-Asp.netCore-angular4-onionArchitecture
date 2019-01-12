export class ServiceResponse {
    messageType: string;
    data: any;
    status: boolean;
    messages: Messages[];
}

export class Messages {
    code: string;
    description: string;
}
