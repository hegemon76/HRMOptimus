import { EntityBase } from "./entity-base.model"

  export class Contract extends EntityBase {
    ContractName: string | undefined
    ContractType: ContractType | undefined
    LeaveDays: number | undefined
    Payment: number | undefined
    Rate: number | undefined
    WorkTime: number | undefined
  }
