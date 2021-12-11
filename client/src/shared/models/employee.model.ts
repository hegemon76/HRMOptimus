import { EntityBase } from "./entity-base.model"

  export class Employee extends EntityBase {
    FirstName: string | undefined
    LastName: string | undefined
    FullName: string | undefined
    Gender: Gender | undefined
    BirthDate: Date | undefined
    LeaveDaysLeft: number | undefined
    WorkingTime: number | undefined
    ContractId: number | undefined
    AddressId: number | undefined
    ApplicationUser: string | undefined
  }

