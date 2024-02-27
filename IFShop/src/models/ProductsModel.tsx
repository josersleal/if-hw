import { ProductModel } from './ProductModel';

export interface ProductsModel {
  products: ProductModel[];
  total: number;
  skip: number;
  limit: number;
}