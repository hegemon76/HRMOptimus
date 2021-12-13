import { EntityBase } from "./entity-base.model"

  export class Project extends EntityBase {
    Name: string | undefined
    Description: string | undefined
    HoursBudget: number | undefined
    HoursWorked: number | undefined
    ColorLabel: string | undefined
    DateFrom: Date | undefined
    DateTo: Date | undefined
    Deadline: Date | undefined
  }
