import { BaseRequest } from './BaseRequest';


export class ShopParams extends BaseRequest {
  brandId: number | null = null;
  typeId: number | null = null;
}
