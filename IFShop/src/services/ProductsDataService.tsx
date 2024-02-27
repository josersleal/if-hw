import { AxiosResponse } from 'axios';
import http from '../http-common';

const getAll = async () => {
  try {
    const res: AxiosResponse = await http.get('/');
    console.log("axios call: ", res);
    return res.data;
    // return http.get('/');
  } catch (err) {
    console.log("err: ", err);;
  }
}

const ProductsDataService = {
  getAll,
}

export default ProductsDataService;