import { Component } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';

@Component({
    selector: 'dialog-result-dialog',
    templateUrl: 'dialog.component.html',
})

export class DialogResultDialog {
    constructor(public dialogRef: MdDialogRef<DialogResultDialog>) {
    }
}