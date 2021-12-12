import { Gender } from '../enums/gender';
export class UserVm {
  employeeId: number | undefined;
  fullName: string | undefined;
  gender: Gender | undefined;
  token: string | undefined;
  role: string | undefined;
}
