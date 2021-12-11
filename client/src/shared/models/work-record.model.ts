import { EntityBase } from "./entity-base.model"

  export class WorkRecord extends EntityBase {
    Name: string | undefined
    WorkStart: string | undefined
    WorkEnd: string | undefined
    //Duration: Date | undefined
    ProjectId: number | undefined
    EmployeeId: number | undefined
  }

