/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../typings/bootbox/index.d.ts" />
declare module Gallery {
    var loadingTemplate: string;
    var validationHelper: kendo.ui.ValidatorOptions;
    var reportWindowOptions: kendo.ui.WindowOptions;
    function refreshGrid(gridId?: string): void;
    function onLogout(e: any): void;
    function kendoPrint(reportPreviewUrl: string): void;
}
interface JQuery {
    focusEnd(): JQuery;
}
