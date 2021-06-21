import {IdentificationType} from "./IdentificationType";

export interface Company {
  id: string;
  nit: number;
  firstName: string;
  secondName: string;
  firstLastName: string;
  secondLastName: string;
  companyName: string;
  email: string;
  identificationType: IdentificationType;
  authorizeMessagesPhone: boolean;
  authorizeMessagesEmail: boolean;
  identificationTypeId: number;
}
