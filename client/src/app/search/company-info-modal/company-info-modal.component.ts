import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {Company} from "../../model/company";

@Component({
  selector: 'app-company-info-modal',
  templateUrl: './company-info-modal.component.html',
  styleUrls: ['./company-info-modal.component.scss']
})
export class CompanyInfoModalComponent implements OnInit {

  constructor( public dialogRef: MatDialogRef<CompanyInfoModalComponent>,
                  @Inject(MAT_DIALOG_DATA) public data: Company) { }

  ngOnInit(): void {
  }

  close() {
    this.dialogRef.close();
  }
}
