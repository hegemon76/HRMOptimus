import { Timestamp } from "rxjs/internal/operators/timestamp"

export class WorkRecordDetailsVm  {
  Id: number | undefined
  Name: string | undefined
  WorkStart: Gender | undefined
  WorkStop: string | undefined
  //Duration: Timestamp<Date> | undefined
  ProjectName: string | undefined
}
