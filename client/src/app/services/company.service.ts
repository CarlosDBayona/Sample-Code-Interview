import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {Company} from "../model/company";

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  endpoint = environment.api + 'Company'

  constructor(private http: HttpClient) { }

  getCompany(nit: number) : Observable<Company>{
    return this.http.get<Company>(this.endpoint, {params: {nit}});
  }

  addCompany(company: Partial<Company>){
    return this.http.post(this.endpoint, company);
  }
}
