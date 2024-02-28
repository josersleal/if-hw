import { useEffect, useState } from 'react'
import ProductList from './ProductList';
import { ProductModel } from '../../models/ProductModel';
import ProductsDataService from '../../services/ProductsDataService';

const API_URL = "http://localhost:5000/products";
const headers = {
  'Content-Type': 'application/json'
}
function Products() {

  const [data, setData] = useState<ProductModel[]>([]);
  const [error, setError] = useState<any|null>(null);

  useEffect(() => {
    fetchProductsData();
  }, []);

  async function fetchProductsData() {
    console.log('fetching products data');
    
    const res = await ProductsDataService.getAll();

    console.log('products data fetched: ', res);
    setData(res);

  }

  return (
    <div>
      <ProductList products={data} />
    </div>
  )
}

export default Products