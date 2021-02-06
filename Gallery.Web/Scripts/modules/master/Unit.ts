/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />

class UnitClientProvider extends ClientProvider {
    private _windowOptions: kendo.ui.WindowOptions = {
        modal: true,
        width: 600,
        height: 250,
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
    let unit: UnitClientProvider = new UnitClientProvider();
    unit.initializeWindow();
    $("#btnAddNew").on("click", unit.addNewClick);
    $("#btnDelete").on("click", unit.deleteClick);
    $("#grid").on("click", ".editRow", unit.editClick);
    $("#addEditWindow").on("click", "#btnSave", unit.saveClick);
    $("#addEditWindow").on("click", "#btnClose", unit.closeClick);
});