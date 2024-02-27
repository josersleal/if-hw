import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import ProductsDataService from '../services/ProductsDataService';

interface ProductState {
  value: number; // change to product type
}
const initialState: ProductState = { value: 0 };

export const getProducts = createAsyncThunk(
  "products/retrieved",
  async () => {
    const res = await ProductsDataService.getAll();
    return res.data;
  }
);

/* const productsSlice = createSlice({
  name: 'products',
  initialState,
  // reducers: {},
  extraReducers: {
    [getProducts.fulfilled]: (state, action) => {
      state.push(action.payload)
    },
  },
}); */
