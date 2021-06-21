import {MatSnackBar} from "@angular/material/snack-bar";

export function snackbarAlert(snackbar: MatSnackBar, message: string,action: string, duration: number){
  snackbar.open(message, action, {duration});
}
