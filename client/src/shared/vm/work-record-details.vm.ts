import { Timestamp } from 'rxjs/internal/operators/timestamp';
import { Gender } from '../enums/gender';

export class WorkRecordDetailsVm {
  Id: number | undefined;
  Name: string | undefined;
  WorkStart: Gender | undefined;
  WorkStop: string | undefined;
  //Duration: Timestamp<Date> | undefined
  ProjectName: string | undefined;
}
