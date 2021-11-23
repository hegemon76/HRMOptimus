export interface Employee {
  id?: number;
  firstName?: string;
  lastName?: string;
  fullName?: string;
  gender?: number;
  birthDate?: Date;
  leaveDaysLeft?: number;
  workingTime?: number;
  contract?: {
    createdBy?: string;
    createdOn?: Date;
    lastModifiedBy?: string;
    lastModifiedOn?: Date;
    inactivatedBy?: string;
    inactivatedOn?: Date;
    enabled?: true;
    id?: number;
    contractName?: string;
    leaveDays?: number;
    payment?: number;
    rate?: number;
    workTime?: number;
    contractType?: number;
  };
  address?: {
    createdBy?: string;
    createdOn?: Date;
    lastModifiedBy?: string;
    lastModifiedOn?: Date;
    inactivatedBy?: string;
    inactivatedOn?: Date;
    enabled?: true;
    id?: 0;
    zipCode?: string;
    city?: string;
    street?: string;
    buildingNumber?: string;
    houseNumber?: string;
    country?: string;
  };
  email?: string;
  phoneNumber?: string;
}
