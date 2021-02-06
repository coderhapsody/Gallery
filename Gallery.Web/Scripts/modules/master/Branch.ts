/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />

class BranchClientProvider extends ClientProvider {
    private _windowOptions: kendo.ui.WindowOptions = {
        modal: true,
        width: 650,
        height: 550,
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
    let branch: BranchClientProvider = new BranchClientProvider();
    branch.initializeWindow();
    $("#btnAddNew").on("click", branch.addNewClick);
    $("#btnDelete").on("click", branch.deleteClick);
    $("#grid").on("click", ".editRow", branch.editClick);
    $("#addEditWindow").on("click", "#btnSave", branch.saveClick);
    $("#addEditWindow").on("click", "#btnClose", branch.closeClick);
});