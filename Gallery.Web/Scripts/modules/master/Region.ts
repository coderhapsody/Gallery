/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />

class RegionClientProvider extends ClientProvider {
    private _windowOptions: kendo.ui.WindowOptions = {
        modal: true,
        width: 650,
        height: 300,
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
    let region: RegionClientProvider = new RegionClientProvider();
    region.initializeWindow();
    $("#btnAddNew").on("click", region.addNewClick);
    $("#btnDelete").on("click", region.deleteClick);
    $("#grid").on("click", ".editRow", region.editClick);
    $("#addEditWindow").on("click", "#btnSave", region.saveClick);
    $("#addEditWindow").on("click", "#btnClose", region.closeClick);
});