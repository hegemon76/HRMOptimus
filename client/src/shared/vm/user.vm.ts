import { Gender } from '../enums/gender';
export class UserVm {
  nameid: number | undefined;
  unique_name: string | undefined;
  gender: Gender | undefined;
  token: string | undefined;
  role: string | undefined;
}
