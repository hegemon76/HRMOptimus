import { EntityBase } from "./entity-base.model"

  export class LeaveRegister extends EntityBase {
    IsApproved: IsApproved | undefined
    LeaveRegisterType: LeaveRegisterType | undefined
    DateFrom: Date | undefined
    DateTo: Date | undefined
    Duration: number | undefined
    EmployeeId: number | undefined
  }

