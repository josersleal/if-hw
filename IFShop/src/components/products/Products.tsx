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
    /* fetch(API_URL)
    .then(res => res.json())
    .then(data => setData(data))
    .then(error=> setError(error)); */

    const res = await ProductsDataService.getAll();


    console.log('products data fetched: ', res);
    setData(res);

    const productsData: ProductModel[] = [
      {
        "id": 1,
        "title": "iPhone 9",
        "description": "An apple mobile which is nothing like apple",
        "price": 549,
        "discountPercentage": 12.96,
        "rating": 4.69,
        "stock": 94,
        "brand": "Apple",
        "category": "smartphones",
        "thumbnail": "https://cdn.dummyjson.com/product-images/1/thumbnail.jpg",
        "images": [
          "https://cdn.dummyjson.com/product-images/1/1.jpg",
          "https://cdn.dummyjson.com/product-images/1/2.jpg",
          "https://cdn.dummyjson.com/product-images/1/3.jpg",
          "https://cdn.dummyjson.com/product-images/1/4.jpg",
          "https://cdn.dummyjson.com/product-images/1/thumbnail.jpg"
        ]
      },
      {
        "id": 2,
        "title": "iPhone X",
        "description": "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...",
        "price": 899,
        "discountPercentage": 17.94,
        "rating": 4.44,
        "stock": 34,
        "brand": "Apple",
        "category": "smartphones",
        "thumbnail": "https://cdn.dummyjson.com/product-images/2/thumbnail.jpg",
        "images": [
          "https://cdn.dummyjson.com/product-images/2/1.jpg",
          "https://cdn.dummyjson.com/product-images/2/2.jpg",
          "https://cdn.dummyjson.com/product-images/2/3.jpg",
          "https://cdn.dummyjson.com/product-images/2/thumbnail.jpg"
        ]
      },
      {
        "id": 3,
        "title": "Samsung Universe 9",
        "description": "Samsung's new variant which goes beyond Galaxy to the Universe",
        "price": 1249,
        "discountPercentage": 15.46,
        "rating": 4.09,
        "stock": 36,
        "brand": "Samsung",
        "category": "smartphones",
        "thumbnail": "https://cdn.dummyjson.com/product-images/3/thumbnail.jpg",
        "images": [
          "https://cdn.dummyjson.com/product-images/3/1.jpg"
        ]
      },
      {
        "id": 4,
        "title": "OPPOF19",
        "description": "OPPO F19 is officially announced on April 2021.",
        "price": 280,
        "discountPercentage": 17.91,
        "rating": 4.3,
        "stock": 123,
        "brand": "OPPO",
        "category": "smartphones",
        "thumbnail": "https://cdn.dummyjson.com/product-images/4/thumbnail.jpg",
        "images": [
          "https://cdn.dummyjson.com/product-images/4/1.jpg",
          "https://cdn.dummyjson.com/product-images/4/2.jpg",
          "https://cdn.dummyjson.com/product-images/4/3.jpg",
          "https://cdn.dummyjson.com/product-images/4/4.jpg",
          "https://cdn.dummyjson.com/product-images/4/thumbnail.jpg"
        ]
      }
    ];

    // setData(productsData);
  }

  return (
    <div>
      <ProductList products={data} />
    </div>
  )
}

export default Products