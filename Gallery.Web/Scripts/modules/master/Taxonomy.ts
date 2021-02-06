/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />

class TaxonomyClientProvider extends ClientProvider {
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
    let taxonomy: TaxonomyClientProvider = new TaxonomyClientProvider();
    taxonomy.initializeWindow();
    $("#btnAddNew").on("click", taxonomy.addNewClick);
    $("#btnDelete").on("click", taxonomy.deleteClick);
    $("#grid").on("click", ".editRow", taxonomy.editClick);
    $("#addEditWindow").on("click", "#btnSave", taxonomy.saveClick);
    $("#addEditWindow").on("click", "#btnClose", taxonomy.closeClick);
});