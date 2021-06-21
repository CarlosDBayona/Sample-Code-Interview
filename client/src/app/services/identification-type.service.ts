import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {IdentificationType} from "../model/IdentificationType";

@Injectable({
  providedIn: 'root'
})
export class IdentificationTypeService {
  endpoint = environment.api + 'IdentificationType'

  constructor(private http: HttpClient) { }

  public getAllIdentificationTypes(){
    return this.http.get<Array<IdentificationType>>(this.endpoint);
  }

}
