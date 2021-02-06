/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var RoleClientProvider = (function (_super) {
    __extends(RoleClientProvider, _super);
    function RoleClientProvider() {
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
    return RoleClientProvider;
}(ClientProvider));
$(function () {
    var fee = new RoleClientProvider();
    fee.initializeWindow();
    $("#btnAddNew").on("click", fee.addNewClick);
    $("#btnDelete").on("click", fee.deleteClick);
    $("#grid").on("click", ".editRow", fee.editClick);
    $("#addEditWindow").on("click", "#btnSave", fee.saveClick);
    $("#addEditWindow").on("click", "#btnClose", fee.closeClick);
});
//# sourceMappingURL=Role.js.map