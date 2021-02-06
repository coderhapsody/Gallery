/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var EmployeeVisitCategoryClientProvider = (function (_super) {
    __extends(EmployeeVisitCategoryClientProvider, _super);
    function EmployeeVisitCategoryClientProvider() {
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
    return EmployeeVisitCategoryClientProvider;
}(ClientProvider));
$(function () {
    var visitCategory = new EmployeeVisitCategoryClientProvider();
    visitCategory.initializeWindow();
    $("#btnAddNew").on("click", visitCategory.addNewClick);
    $("#btnDelete").on("click", visitCategory.deleteClick);
    $("#grid").on("click", ".editRow", visitCategory.editClick);
    $("#addEditWindow").on("click", "#btnSave", visitCategory.saveClick);
    $("#addEditWindow").on("click", "#btnClose", visitCategory.closeClick);
});
//# sourceMappingURL=EmployeeVisitCategory.js.map