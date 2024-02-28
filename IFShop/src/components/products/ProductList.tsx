import React, { useState } from 'react'
import { ProductModel } from '../../models/ProductModel'
import { CardGroup, Container, FormControl, InputGroup } from 'react-bootstrap'
import './ProductList.css';
import ProductCard from './ProductCard';

// function ProductList({ products }: { products: ProductModel[] }) {
interface ProductsListProps { products: ProductModel[] };

const ProductList: React.FC<ProductsListProps> = ({ products }: ProductsListProps) => {

  const [searchTerm, setSearchTerm] = useState('');

  const filteredProducts = products.filter(product => {
    return product.title.toLowerCase().includes(searchTerm.toLowerCase());
  })

  return (
    <Container className="product-list">
      <h2 className='text-center'>Products List</h2>
      <div className='row'>
        <div className="col">
          
        </div>
        <div className='col justify-content-end'>
          <InputGroup className="mb-2 pt-1 float-right">
            <FormControl
              placeholder="Search products"
              value={searchTerm}
              onChange={e => setSearchTerm(e.target.value)}
            />
          </InputGroup>
        </div>
      </div>

      <CardGroup className='product-list'>

        {filteredProducts.map(product => (
          <ProductCard key={product.id} product={product} />
        ))}
      </CardGroup>

    </Container>
  )
}

export default ProductList

