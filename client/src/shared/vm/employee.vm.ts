import { Gender } from '../enums/gender';
export class EmployeeVm {
  id: number | undefined;
  employeeId: number | undefined;
  firstName: string | undefined;
  lastName: string | undefined;
  fullName: string | undefined;
  gender: Gender | undefined;
  birthDate: string | undefined;
  email: string | undefined;
  phoneNumber: string | undefined;
  contractName: string | undefined;
  items: any | undefined;
}
