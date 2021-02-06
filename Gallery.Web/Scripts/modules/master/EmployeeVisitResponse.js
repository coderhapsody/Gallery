/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var EmployeeVisitResponseClientProvider = (function (_super) {
    __extends(EmployeeVisitResponseClientProvider, _super);
    function EmployeeVisitResponseClientProvider() {
        var _this = _super.call(this) || this;
        _this._windowOptions = {
            modal: true,
            width: 650,
            height: 350,
            visible: false,
            title: false,
            animation: false,
            resizable: false
        };
        _this.WindowOptions = _this._windowOptions;
        return _this;
    }
    return EmployeeVisitResponseClientProvider;
}(ClientProvider));
$(function () {
    var visitResponse = new EmployeeVisitResponseClientProvider();
    visitResponse.initializeWindow();
    $("#btnAddNew").on("click", visitResponse.addNewClick);
    $("#btnDelete").on("click", visitResponse.deleteClick);
    $("#grid").on("click", ".editRow", visitResponse.editClick);
    $("#addEditWindow").on("click", "#btnSave", visitResponse.saveClick);
    $("#addEditWindow").on("click", "#btnClose", visitResponse.closeClick);
});
//# sourceMappingURL=EmployeeVisitResponse.js.map