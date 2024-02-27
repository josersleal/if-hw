import React from 'react'
import { ProductModel } from '../../models/ProductModel'

// function ProductList({ products }: { products: ProductModel[] }) {
  interface ProductsListProps { products: ProductModel[] };

const ProductList: React.FC<ProductsListProps> = ({ products }) => {

  return (
    <div>
      <h1>Products List</h1>
      {/* {products[0].title} */}
      <ul>
        {products.map(product => (
          <li key={product.id}>
            <div>{product.brand}</div>
            <div>{product.description}</div>
            <div>{product.images[0]}</div>
          </li>
        ))}
      </ul>
    </div>
  )
}

export default ProductList