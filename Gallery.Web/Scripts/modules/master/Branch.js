/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var BranchClientProvider = (function (_super) {
    __extends(BranchClientProvider, _super);
    function BranchClientProvider() {
        var _this = _super.call(this) || this;
        _this._windowOptions = {
            modal: true,
            width: 650,
            height: 550,
            visible: false,
            title: false,
            animation: false,
            resizable: false,
        };
        _this.WindowOptions = _this._windowOptions;
        return _this;
    }
    return BranchClientProvider;
}(ClientProvider));
$(function () {
    var branch = new BranchClientProvider();
    branch.initializeWindow();
    $("#btnAddNew").on("click", branch.addNewClick);
    $("#btnDelete").on("click", branch.deleteClick);
    $("#grid").on("click", ".editRow", branch.editClick);
    $("#addEditWindow").on("click", "#btnSave", branch.saveClick);
    $("#addEditWindow").on("click", "#btnClose", branch.closeClick);
});
//# sourceMappingURL=Branch.js.map