/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../ClientProvider.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var TaxonomyClientProvider = (function (_super) {
    __extends(TaxonomyClientProvider, _super);
    function TaxonomyClientProvider() {
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
    return TaxonomyClientProvider;
}(ClientProvider));
$(function () {
    var taxonomy = new TaxonomyClientProvider();
    taxonomy.initializeWindow();
    $("#btnAddNew").on("click", taxonomy.addNewClick);
    $("#btnDelete").on("click", taxonomy.deleteClick);
    $("#grid").on("click", ".editRow", taxonomy.editClick);
    $("#addEditWindow").on("click", "#btnSave", taxonomy.saveClick);
    $("#addEditWindow").on("click", "#btnClose", taxonomy.closeClick);
});
//# sourceMappingURL=Taxonomy.js.map