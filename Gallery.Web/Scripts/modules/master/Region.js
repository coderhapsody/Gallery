/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var RegionClientProvider = (function (_super) {
    __extends(RegionClientProvider, _super);
    function RegionClientProvider() {
        var _this = _super.call(this) || this;
        _this._windowOptions = {
            modal: true,
            width: 650,
            height: 300,
            visible: false,
            title: false,
            animation: false,
            resizable: false,
        };
        _this.WindowOptions = _this._windowOptions;
        return _this;
    }
    return RegionClientProvider;
}(ClientProvider));
$(function () {
    var region = new RegionClientProvider();
    region.initializeWindow();
    $("#btnAddNew").on("click", region.addNewClick);
    $("#btnDelete").on("click", region.deleteClick);
    $("#grid").on("click", ".editRow", region.editClick);
    $("#addEditWindow").on("click", "#btnSave", region.saveClick);
    $("#addEditWindow").on("click", "#btnClose", region.closeClick);
});
//# sourceMappingURL=Region.js.map