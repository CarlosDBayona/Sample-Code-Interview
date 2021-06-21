import {Component, OnInit} from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {CompanyService} from "../services/company.service";
import {HttpErrorResponse} from "@angular/common/http";
import {MatSnackBar} from "@angular/material/snack-bar";
import {snackbarAlert} from "../util/alert";
import {MatDialog} from "@angular/material/dialog";
import {CompanyInfoModalComponent} from "./company-info-modal/company-info-modal.component";
import {Company} from "../model/company";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  searchForm = this.fb.group(
    {
      nit: ['', [Validators.required]]
    }
  )

  constructor(
    private fb: FormBuilder,
    private companyService: CompanyService,
    private snackbar: MatSnackBar,
    private dialog: MatDialog) {
  }

  ngOnInit(): void {
  }

  search() {
    this.companyService.getCompany(this.searchForm.value.nit).subscribe(
      (company:Company) => {
          const dialogRef = this.dialog.open(CompanyInfoModalComponent, {
            data: company
          });
      },
      (res: HttpErrorResponse) => {
        if (res.error.status == 404) {
          snackbarAlert(this.snackbar, 'Not Found, Register!', 'Ok', 500);
        }

      }
    );
  }
}
