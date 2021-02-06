/// <reference path="ClientProvider.ts" />

class ChangePassword extends ClientProvider {    
    constructor() {
        super();        
        this.initializeValidations();
    }

    initializeValidations() : void {
        this.ValidationOptions = {
            rules: {
                checkConfirmPassword: input => {
                    if ($(input).attr("id") === "ConfirmPassword") {
                        return $(input).val() === $("#NewPassword").val();
                    }

                    return true;
                }
            },

            messages: {
                checkConfirmPassword: "Invalid password confirmation"
            }
        };
    }


    confirmChangePassword(e: JQueryEventObject): void {
        e.preventDefault();
        let validator: kendo.ui.Validator = $("#ChangePasswordForm").kendoValidator(this.ValidationOptions).data("kendoValidator");
        if (validator.validate()) {
            $("#ChangePasswordForm").submit();
        }
        else {
            $("#OldPassword").focus();
        }
    }
}


$(() => {
    let changePassword: ChangePassword = new ChangePassword();
    $("#btnSubmit").click(changePassword.confirmChangePassword);
});