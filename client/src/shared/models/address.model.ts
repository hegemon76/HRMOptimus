import { EntityBase } from "./entity-base.model"

  export class Address extends EntityBase {
    ZipCode: string | undefined
    Street: string | undefined
    City: string | undefined
    BuildingNumber: string | undefined
    HouseNumber: string | undefined
    Country: string | undefined
  }
