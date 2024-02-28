import { ProductModel } from '../../models/ProductModel';
import { Card } from "react-bootstrap";

const ProductCard: React.FC<{ product: ProductModel }> = ({ product }) => {
  return (
    < Card key={product.id} style={{ width: '18rem', marginBottom: '1rem', flex: '1 0 30%' }
    }>
      <Card.Img className='img-thumbnail'
        variant="top"
        src={product.images[0]}
        style={{ height: 'calc(100% / 2)' }}
      />
      <Card.Body className='text-center'>
        <Card.Title>{product.title}</Card.Title>
        <Card.Text>{product.description}</Card.Text>
        <Card.Text className='card-footer'>{product.price} €</Card.Text>
      </Card.Body>
    </Card >
  );
}
export default ProductCard
