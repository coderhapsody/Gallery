/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />

class EmployeeVisitResponseClientProvider extends ClientProvider {
    private _windowOptions: kendo.ui.WindowOptions = {
        modal: true,
        width: 650,
        height: 350,
        visible: false,
        title: false,
        animation: false,
        resizable: false
    };

    constructor() {
        super();
        this.WindowOptions = this._windowOptions;
    }
}


$(() => {
    let visitResponse: EmployeeVisitResponseClientProvider = new EmployeeVisitResponseClientProvider();
    visitResponse.initializeWindow();
    $("#btnAddNew").on("click", visitResponse.addNewClick);
    $("#btnDelete").on("click", visitResponse.deleteClick);
    $("#grid").on("click", ".editRow", visitResponse.editClick);
    $("#addEditWindow").on("click", "#btnSave", visitResponse.saveClick);
    $("#addEditWindow").on("click", "#btnClose", visitResponse.closeClick);
});