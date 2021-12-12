import { EntityBase } from './entity-base.model';
import { Gender } from '../enums/gender';

export class Employee extends EntityBase {
  firstName: string | undefined;
  lastName: string | undefined;
  fullName: string | undefined;
  gender: Gender | undefined;
  birthDate: Date | undefined;
  leaveDaysLeft: number | undefined;
  workingTime: number | undefined;
  contractId: number | undefined;
  addressId: number | undefined;
  applicationUser: string | undefined;
}
