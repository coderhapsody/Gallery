/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />

class RoleClientProvider extends ClientProvider {
    private _windowOptions: kendo.ui.WindowOptions = {
        modal: true,
        width: 650,
        height: 350,
        visible: false,
        title: false,
        animation: false,
        resizable: false,
    };

    constructor() {
        super();
        this.WindowOptions = this._windowOptions;
    }
}


$(() => {
    let fee: RoleClientProvider = new RoleClientProvider();
    fee.initializeWindow();
    $("#btnAddNew").on("click", fee.addNewClick);
    $("#btnDelete").on("click", fee.deleteClick);
    $("#grid").on("click", ".editRow", fee.editClick);
    $("#addEditWindow").on("click", "#btnSave", fee.saveClick);
    $("#addEditWindow").on("click", "#btnClose", fee.closeClick);
});