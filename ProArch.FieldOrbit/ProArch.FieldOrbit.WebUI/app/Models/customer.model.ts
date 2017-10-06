import { Address } from './address.model';
import { Name } from './name.model';

export interface Customer {
  CustomerId: number;
  Name?: Name;
  Address?: Array<Address>;
  Phone?: string;
  SSN?: string;
  Email?: string;
  Active?: boolean;
  DeviceId?: string;
  AssetId?: string;
}
