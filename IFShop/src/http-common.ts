import axios from 'axios';

export default axios.create({
  baseURL: 'http://localhost:5022/products',
  headers: {
    "Content-Type": "application/json"
  }
})