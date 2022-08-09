import { IAddress } from './IAddress';

export interface ISeller {
  id: number;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  shopName: string;
  address: IAddress;
}
