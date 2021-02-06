/// <reference path="ClientProvider.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ChangePassword = (function (_super) {
    __extends(ChangePassword, _super);
    function ChangePassword() {
        var _this = _super.call(this) || this;
        _this.initializeValidations();
        return _this;
    }
    ChangePassword.prototype.initializeValidations = function () {
        this.ValidationOptions = {
            rules: {
                checkConfirmPassword: function (input) {
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
    };
    ChangePassword.prototype.confirmChangePassword = function (e) {
        e.preventDefault();
        var validator = $("#ChangePasswordForm").kendoValidator(this.ValidationOptions).data("kendoValidator");
        if (validator.validate()) {
            $("#ChangePasswordForm").submit();
        }
        else {
            $("#OldPassword").focus();
        }
    };
    return ChangePassword;
}(ClientProvider));
$(function () {
    var changePassword = new ChangePassword();
    $("#btnSubmit").click(changePassword.confirmChangePassword);
});
//# sourceMappingURL=changepassword.js.map