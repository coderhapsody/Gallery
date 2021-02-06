interface IClientProvider {
    addNewClick(e: JQueryEventObject): void;
    editClick(e: JQueryEventObject): void;
    deleteClick(e: JQueryEventObject): void;
    saveClick(e: JQueryEventObject): void;
    ValidationOptions: kendo.ui.ValidatorOptions;
    WindowOptions: kendo.ui.WindowOptions;
}
interface AjaxViewModel {
    IsSuccess: boolean;
    Data: any;
    Message: string;
}
declare abstract class ClientProvider implements IClientProvider {
    static currentServiceUrl: string;
    private windowOptions;
    private validationOptions;
    initializeWindow(selector?: string): void;
    WindowOptions: kendo.ui.WindowOptions;
    ValidationOptions: kendo.ui.ValidatorOptions;
    addNewClick(e: JQueryEventObject): void;
    editClick(e: JQueryEventObject): void;
    closeClick(e: JQueryEventObject): void;
    deleteClick(e: JQueryEventObject): void;
    saveClick(e: JQueryEventObject): void;
    onDataBound(e: kendo.ui.GridEvent): void;
}
