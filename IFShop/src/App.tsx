import { useState } from 'react'
import { Link, Route, BrowserRouter as Router, Routes } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import Products from './components/products/Products';


// import './App.css'

function App() {

  return (
    <Router>
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <a href="/products" className="navbar-brand px-2">
          IF
        </a>
        <div className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to={"/products"} className="nav-link">
              Products
            </Link>
          </li>
        </div>
      </nav>
      <div className="container-fluid">
        <Routes>
          <Route path="/" element={<Products />} />
          <Route path="/products" element={<Products />} />
        </Routes>
      </div>
    </Router>
  )
}



export default App
