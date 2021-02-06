/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var UnitClientProvider = (function (_super) {
    __extends(UnitClientProvider, _super);
    function UnitClientProvider() {
        var _this = _super.call(this) || this;
        _this._windowOptions = {
            modal: true,
            width: 600,
            height: 250,
            visible: false,
            title: false,
            animation: false,
            resizable: false,
        };
        _this.WindowOptions = _this._windowOptions;
        return _this;
    }
    return UnitClientProvider;
}(ClientProvider));
$(function () {
    var unit = new UnitClientProvider();
    unit.initializeWindow();
    $("#btnAddNew").on("click", unit.addNewClick);
    $("#btnDelete").on("click", unit.deleteClick);
    $("#grid").on("click", ".editRow", unit.editClick);
    $("#addEditWindow").on("click", "#btnSave", unit.saveClick);
    $("#addEditWindow").on("click", "#btnClose", unit.closeClick);
});
//# sourceMappingURL=Unit.js.map