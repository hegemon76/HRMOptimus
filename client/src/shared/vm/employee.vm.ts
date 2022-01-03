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
  items: any | undefined;
  address: {
    street: string | undefined;
    buildingNumber: string | undefined;
    houseNumber: string | undefined;
    zipCode: string | undefined;
    city: string | undefined;
    country: string | undefined;
  };
  contract: {
    contractName: string | undefined;
    contractType: number | undefined;
    leaveDays: number | undefined;
  };
  roles: string[] | undefined;
}
