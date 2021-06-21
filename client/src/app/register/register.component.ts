import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {IdentificationTypeService} from "../services/identification-type.service";
import {IdentificationType} from "../model/IdentificationType";
import {Company} from "../model/company";
import {CompanyService} from "../services/company.service";
import {snackbarAlert} from "../util/alert";
import {MatSnackBar} from "@angular/material/snack-bar";
import {Router} from "@angular/router";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  typesOfDocuments: Array<IdentificationType> = [];
  companyForm = false;


  registerForm: any;

  get identificationType() {
    return this.registerForm.get('identificationType');
  }
  get nit() {
    return this.registerForm.get('nit');
  }

  get companyName() {
    return this.registerForm.get('companyName');
  }

  get firstName() {
    return this.registerForm.get('firstName');
  }

  get secondName() {
    return this.registerForm.get('secondName');
  }

  get firstLastName() {
    return this.registerForm.get('firstLastName');
  }

  get secondLastName() {
    return this.registerForm.get('firstLastName');
  }

  get email() {
    return this.registerForm.get('email');
  }
  get authorizeMessagesPhone() {
    return this.registerForm.get('authorizeMessagesPhone');
  }
  get authorizeMessagesEmail() {
    return this.registerForm.get('authorizeMessagesEmail');
  }

  constructor(private fb: FormBuilder, private identificationTypeService: IdentificationTypeService,
              private companyService: CompanyService, private  snackbar: MatSnackBar,
              private router: Router) {
    this.identificationTypeService.getAllIdentificationTypes().subscribe(
      (identificationTypes: Array<IdentificationType>) => {
        this.typesOfDocuments = identificationTypes;
      }
    );
  }

  ngOnInit(): void {
    this.registerForm = this.fb.group(
      {
        identificationType: ['', [Validators.required]],
        nit: ['', [Validators.required, Validators.min(0)]],
        companyName: ['', [Validators.pattern('^[a-zA-Z ]*$')]],
        firstName: ['', [Validators.pattern('^[a-zA-Z ]*$')]],
        secondName: ['', [Validators.pattern('^[a-zA-Z ]*$')]],
        firstLastName: ['', [Validators.pattern('^[a-zA-Z ]*$')]],
        secondLastName: ['', [Validators.pattern('^[a-zA-Z ]*$')]],
        email: ['', [Validators.required, Validators.email]],
        authorizeMessagesPhone: [false],
        authorizeMessagesEmail: [false],
      }
    )
  }

  register() {
    let company: Partial<Company> = {
      nit: this.nit.value,
      companyName: this.companyName.value,
      firstName: this.firstName.value,
      secondName: this.secondName.value,
      firstLastName: this.firstLastName.value,
      secondLastName: this.secondLastName.value,
      email: this.email.value,
      authorizeMessagesPhone: this.authorizeMessagesPhone.value,
      authorizeMessagesEmail: this.authorizeMessagesEmail.value,
      identificationTypeId: this.identificationType.value
    }
    this.companyService.addCompany(company).subscribe(
      () => {
        snackbarAlert(this.snackbar, 'Registered successfully', 'Ok', 1000);
        this.router.navigate(['']);
      },
      (err: HttpErrorResponse) => {
        if(err.status == 400){
          snackbarAlert(this.snackbar, err.error, 'Ok', 1000)
        }else {
          snackbarAlert(this.snackbar, 'An error has occurred try again later', 'Ok', 1000)

        }
      }
    );
  }

  changeIdType() {
    let val = this.registerForm.controls['identificationType'].value as number;
    if (val == 2 || val == 3) {
      this.companyForm = true;
      this.registerForm.controls['companyName'].setValidators([Validators.required, Validators.pattern('^[a-zA-Z ]*$')]);
      this.registerForm.controls['firstName'].clearValidators();
      this.registerForm.controls['secondName'].clearValidators();
      this.registerForm.controls['firstLastName'].clearValidators()
      this.registerForm.controls['secondLastName'].clearValidators();
      this.registerForm.controls['firstName'].setValue('');
      this.registerForm.controls['secondName'].setValue('');
      this.registerForm.controls['firstLastName'].setValue('');
      this.registerForm.controls['secondLastName'].setValue('');
    } else {
      this.companyForm = false;
      this.registerForm.controls['companyName'].clearValidators();
      this.registerForm.controls['companyName'].setValue('');
      this.registerForm.controls['firstName'].setValidators([Validators.required, Validators.pattern('^[a-zA-Z ]*$')]);
      this.registerForm.controls['secondName'].setValidators([Validators.required, Validators.pattern('^[a-zA-Z ]*$')]);
      this.registerForm.controls['firstLastName'].setValidators([Validators.required, Validators.pattern('^[a-zA-Z ]*$')]);
      this.registerForm.controls['secondLastName'].setValidators([Validators.required, Validators.pattern('^[a-zA-Z ]*$')]);
    }
    this.registerForm.updateValueAndValidity();
  }
}
