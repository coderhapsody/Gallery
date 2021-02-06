/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />

class ComplaintTypeClientProvider extends ClientProvider {
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
    let complaintType: ComplaintTypeClientProvider = new ComplaintTypeClientProvider();
    complaintType.initializeWindow();
    $("#btnAddNew").on("click", complaintType.addNewClick);
    $("#btnDelete").on("click", complaintType.deleteClick);
    $("#grid").on("click", ".editRow", complaintType.editClick);
    $("#addEditWindow").on("click", "#btnSave", complaintType.saveClick);
    $("#addEditWindow").on("click", "#btnClose", complaintType.closeClick);
});