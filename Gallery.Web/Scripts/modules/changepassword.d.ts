/// <reference path="ClientProvider.d.ts" />
declare class ChangePassword extends ClientProvider {
    constructor();
    initializeValidations(): void;
    confirmChangePassword(e: JQueryEventObject): void;
}
