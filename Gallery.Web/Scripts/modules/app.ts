/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/kendo-ui/kendo-ui.d.ts" />
/// <reference path="../typings/bootbox/index.d.ts" />

module Gallery {
    export var loadingTemplate: string = "<div style='width:100%; text-align:center;'><div class='fa fa-4x fa-spin fa-refresh'></div></div>";
    export var validationHelper: kendo.ui.ValidatorOptions = {
        errorTemplate: "<span class='label label-danger'>#=message#</span>"        
    };

    export var reportWindowOptions: kendo.ui.WindowOptions = {
        actions: ["Maximize", "Close"],
        height: window.screen.availHeight - 200,
        width: window.screen.availWidth - 400,
        modal: true,
        iframe: true,
        animation: false,
        visible: false,
        title: "Print Preview"
    };

    export function refreshGrid(gridId?: string) {        
        if (gridId == null) {
            $("#grid").data("kendoGrid").dataSource.read();
            $("#grid").data("kendoGrid").dataSource.page(1);
            $("#grid").data("kendoGrid").refresh();
        }
        else {
            $(gridId).data("kendoGrid").dataSource.read();
            $(gridId).data("kendoGrid").dataSource.page(1);
            $(gridId).data("kendoGrid").refresh();
        }
    }

    export function onLogout(e) {
        e.preventDefault();
        let logoutUrl = $(this).attr("href");
        bootbox.confirm('Are you sure want to logout?', result => {
            if (result) {
                document.location.href = logoutUrl;
            }
        });
    }

    //export function kendoAlert(msg: string, title?: string) {
    //    var defaultIcon = "<i class='fa fa-coffee'></i>";
    //    var dfrd;
    //    var html = "<div id='kendoAlert' style='min-height:100px; width:400px; text-align: center; vertical-align:center;' />";
    //    // create modal window on the fly
    //    var win = $(html).kendoWindow({
    //        modal: true,
    //        animation: false,
    //        deactivate: function () {
    //            // when the deactivate event fires,
    //            // resolve the promise
    //            dfrd.resolve();
    //        }
    //    }).data("kendoWindow");

    //    return (msg, title) => {
    //        if (title == undefined)
    //            title = defaultIcon + " Point of Sales";
    //        else
    //            title = defaultIcon + " " + title;
    //        msg = "&nbsp;&nbsp;&nbsp;" + msg + "&nbsp;&nbsp;&nbsp;";
    //        // create a new deferred
    //        dfrd = $.Deferred();

    //        // set the content
    //        win.content(msg);
    //        win.element.append($('<div style="vertical-align:bottom; padding-top:50px;"><a id="kendoAlertClose" class="k-button"><i class="fa fa-check"></i> OK</a></div>'));

    //        $("#kendoAlertClose", "#kendoAlert").on('click', function () {
    //            $(this).closest("[data-role=window]").data("kendoWindow").close();
    //        });

    //        // center it and open it
    //        win.center().title(title).open();

    //        // return the deferred object
    //        return dfrd;
    //    };
    //}

    export function kendoPrint(reportPreviewUrl: string) {
        let html: string = "<div />";
        let win: kendo.ui.Window = $(html).kendoWindow(Gallery.reportWindowOptions).data("kendoWindow");
        win.refresh(reportPreviewUrl);
        win.center().open();
    }
}

$(function () {
    $("#logout").click(Gallery.onLogout);
    $("#aboutMenu").click(e => {
        let windowOptions: kendo.ui.WindowOptions = {
            modal: true,
            width: 500,
            height: 200,
            title: "About",
            content: $(e.target).data("abouturl")
        };
        $("#about").html(Gallery.loadingTemplate);
        $("#about").kendoWindow(windowOptions).data("kendoWindow").open().center();
    });
});


// JQuery extension
(($) => {
    $.fn.focusEnd = function () {
        this.focus();
        var $thisVal = this.val();
        this.val('').val($thisVal);
        return this;
    };
})($);

interface JQuery {
    focusEnd(): JQuery;
}