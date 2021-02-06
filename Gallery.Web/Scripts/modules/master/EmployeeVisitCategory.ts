/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />

class EmployeeVisitCategoryClientProvider extends ClientProvider {
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
    let visitCategory: EmployeeVisitCategoryClientProvider = new EmployeeVisitCategoryClientProvider();
    visitCategory.initializeWindow();
    $("#btnAddNew").on("click", visitCategory.addNewClick);
    $("#btnDelete").on("click", visitCategory.deleteClick);
    $("#grid").on("click", ".editRow", visitCategory.editClick);
    $("#addEditWindow").on("click", "#btnSave", visitCategory.saveClick);
    $("#addEditWindow").on("click", "#btnClose", visitCategory.closeClick);
});