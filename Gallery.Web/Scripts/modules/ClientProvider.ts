interface IClientProvider {
    addNewClick(e: JQueryEventObject): void;
    editClick(e: JQueryEventObject): void;
    deleteClick(e: JQueryEventObject): void;
    saveClick(e: JQueryEventObject): void;
    ValidationOptions: kendo.ui.ValidatorOptions;
    WindowOptions: kendo.ui.WindowOptions;
}

interface AjaxViewModel {
    IsSuccess: boolean;
    Data: any;
    Message: string;
}

abstract class ClientProvider implements IClientProvider {
    static currentServiceUrl: string;

    private windowOptions: kendo.ui.WindowOptions = {
        modal: true,
        width: 600,
        height: 250,
        visible: false,
        title: false,
        animation: false,
        resizable: false,
    };

    private validationOptions: kendo.ui.ValidatorOptions = {};

    public initializeWindow(selector: string = "#addEditWindow"): void {
        let domWindow = $(selector);
        domWindow.kendoWindow(this.WindowOptions);
        domWindow.keydown(event => {
            if (event.keyCode === 27) {
                domWindow.data("kendoWindow").close();
            }
        });
    }

    public get WindowOptions(): kendo.ui.WindowOptions {
        return this.windowOptions;
    }

    public set WindowOptions(options: kendo.ui.WindowOptions) {
        this.windowOptions = options;
    }

    public get ValidationOptions(): kendo.ui.ValidatorOptions {
        return this.validationOptions;
    }

    public set ValidationOptions(options: kendo.ui.ValidatorOptions) {
        this.validationOptions = options;
    }

    public addNewClick(e: JQueryEventObject) : void {
        e.preventDefault();
        ClientProvider.currentServiceUrl = $(e.target).data("createurl");
        $("#addEditWindow").html(Gallery.loadingTemplate);
        $("#addEditWindow").data("kendoWindow").refresh({
            url: ClientProvider.currentServiceUrl
        }).center().open();
    }

    public editClick(e: JQueryEventObject) : void {
        e.preventDefault();
        ClientProvider.currentServiceUrl = $("#grid").data("editurl");
        $("#addEditWindow").html(Gallery.loadingTemplate);
        $("#addEditWindow").data("kendoWindow").refresh({
            url: ClientProvider.currentServiceUrl,
            data: {
                id: $(e.target).closest("a").attr("data-id")
            }
        }).center().open();
    }

    public closeClick(e: JQueryEventObject) : void {
        e.preventDefault();
        $("#addEditWindow").data("kendoWindow").close();
    }

    public deleteClick(e: JQueryEventObject) : void {
        e.preventDefault();
        let data: string[] = [];
        $("input[name='chkDelete']:checked").each((index: number, el: HTMLInputElement) => {
            data.push(el.value);
        });
        if (data.length > 0) {
            $.ajax({
                type: "POST",
                url: $(e.target).data("deleteurl"),
                data: {
                    arrayOfId: data
                },
                success: (result: AjaxViewModel) => {
                    if (result.IsSuccess) {
                        Gallery.refreshGrid();
                    } else {
                        alert(result.Message);
                    }
                },
                error: result => {
                    alert(result.statusText);
                }
            });
        }
    }

    public saveClick(e: JQueryEventObject): void {
        e.preventDefault();

        let validator = $("#addEditForm").kendoValidator(this.validationOptions).data("kendoValidator");        
        if (validator.validate()) {
            let serializedData: string = $("#addEditForm").serialize();

            $("#btnSave").addClass("k-state-disabled");
            $.ajax({
                type: "POST",
                url: ClientProvider.currentServiceUrl,
                data: serializedData,
                success: (result: AjaxViewModel) => {
                    if (result.IsSuccess) {
                        Gallery.refreshGrid();
                        $("#addEditWindow").data("kendoWindow").close();
                    }
                    else {
                        alert(result.Message);
                        $("#btnSave").removeClass("k-state-disabled");
                    }
                },
                error: err => {
                    alert(err.statusText);
                    $("#btnSave").removeClass("k-state-disabled");
                }
            });
        }
    }

    public onDataBound(e: kendo.ui.GridEvent) : void {
        let rows = e.sender.tbody.children();
        $(rows).each((index, row) => {
            let dataItem: kendo.data.ObservableObject = e.sender.dataItem(row);
           
            if (!<boolean>dataItem.get("IsActive")) {
                $(row).addClass("gridInactiveData");
            }
    });
}
}