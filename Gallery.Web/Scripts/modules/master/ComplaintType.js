/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ComplaintTypeClientProvider = (function (_super) {
    __extends(ComplaintTypeClientProvider, _super);
    function ComplaintTypeClientProvider() {
        var _this = _super.call(this) || this;
        _this._windowOptions = {
            modal: true,
            width: 650,
            height: 350,
            visible: false,
            title: false,
            animation: false,
            resizable: false,
        };
        _this.WindowOptions = _this._windowOptions;
        return _this;
    }
    return ComplaintTypeClientProvider;
}(ClientProvider));
$(function () {
    var complaintType = new ComplaintTypeClientProvider();
    complaintType.initializeWindow();
    $("#btnAddNew").on("click", complaintType.addNewClick);
    $("#btnDelete").on("click", complaintType.deleteClick);
    $("#grid").on("click", ".editRow", complaintType.editClick);
    $("#addEditWindow").on("click", "#btnSave", complaintType.saveClick);
    $("#addEditWindow").on("click", "#btnClose", complaintType.closeClick);
});
//# sourceMappingURL=ComplaintType.js.map