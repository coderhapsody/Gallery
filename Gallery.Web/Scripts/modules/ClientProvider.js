var ClientProvider = (function () {
    function ClientProvider() {
        this.windowOptions = {
            modal: true,
            width: 600,
            height: 250,
            visible: false,
            title: false,
            animation: false,
            resizable: false,
        };
        this.validationOptions = {};
    }
    ClientProvider.prototype.initializeWindow = function (selector) {
        if (selector === void 0) { selector = "#addEditWindow"; }
        var domWindow = $(selector);
        domWindow.kendoWindow(this.WindowOptions);
        domWindow.keydown(function (event) {
            if (event.keyCode === 27) {
                domWindow.data("kendoWindow").close();
            }
        });
    };
    Object.defineProperty(ClientProvider.prototype, "WindowOptions", {
        get: function () {
            return this.windowOptions;
        },
        set: function (options) {
            this.windowOptions = options;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ClientProvider.prototype, "ValidationOptions", {
        get: function () {
            return this.validationOptions;
        },
        set: function (options) {
            this.validationOptions = options;
        },
        enumerable: true,
        configurable: true
    });
    ClientProvider.prototype.addNewClick = function (e) {
        e.preventDefault();
        ClientProvider.currentServiceUrl = $(e.target).data("createurl");
        $("#addEditWindow").html(Gallery.loadingTemplate);
        $("#addEditWindow").data("kendoWindow").refresh({
            url: ClientProvider.currentServiceUrl
        }).center().open();
    };
    ClientProvider.prototype.editClick = function (e) {
        e.preventDefault();
        ClientProvider.currentServiceUrl = $("#grid").data("editurl");
        $("#addEditWindow").html(Gallery.loadingTemplate);
        $("#addEditWindow").data("kendoWindow").refresh({
            url: ClientProvider.currentServiceUrl,
            data: {
                id: $(e.target).closest("a").attr("data-id")
            }
        }).center().open();
    };
    ClientProvider.prototype.closeClick = function (e) {
        e.preventDefault();
        $("#addEditWindow").data("kendoWindow").close();
    };
    ClientProvider.prototype.deleteClick = function (e) {
        e.preventDefault();
        var data = [];
        $("input[name='chkDelete']:checked").each(function (index, el) {
            data.push(el.value);
        });
        if (data.length > 0) {
            $.ajax({
                type: "POST",
                url: $(e.target).data("deleteurl"),
                data: {
                    arrayOfId: data
                },
                success: function (result) {
                    if (result.IsSuccess) {
                        Gallery.refreshGrid();
                    }
                    else {
                        alert(result.Message);
                    }
                },
                error: function (result) {
                    alert(result.statusText);
                }
            });
        }
    };
    ClientProvider.prototype.saveClick = function (e) {
        e.preventDefault();
        var validator = $("#addEditForm").kendoValidator(this.validationOptions).data("kendoValidator");
        if (validator.validate()) {
            var serializedData = $("#addEditForm").serialize();
            $("#btnSave").addClass("k-state-disabled");
            $.ajax({
                type: "POST",
                url: ClientProvider.currentServiceUrl,
                data: serializedData,
                success: function (result) {
                    if (result.IsSuccess) {
                        Gallery.refreshGrid();
                        $("#addEditWindow").data("kendoWindow").close();
                    }
                    else {
                        alert(result.Message);
                        $("#btnSave").removeClass("k-state-disabled");
                    }
                },
                error: function (err) {
                    alert(err.statusText);
                    $("#btnSave").removeClass("k-state-disabled");
                }
            });
        }
    };
    ClientProvider.prototype.onDataBound = function (e) {
        var rows = e.sender.tbody.children();
        $(rows).each(function (index, row) {
            var dataItem = e.sender.dataItem(row);
            if (!dataItem.get("IsActive")) {
                $(row).addClass("gridInactiveData");
            }
        });
    };
    return ClientProvider;
}());
//# sourceMappingURL=ClientProvider.js.map