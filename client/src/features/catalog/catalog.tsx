import { useEffect, useState } from "react";
import agent from "../../app/api/agent";
import { Product } from "../../app/models/Product";
import ProductList from "./ProductList";


export default function Catalog(){
    // store product inside state
  const [products, setProducts ] = useState<Product[]>([]);

  useEffect(() => {
    agent.Catalog.list().then(products => setProducts(products))
    // fetch('https://localhost:7209/api/products')
    // .then (response => response.json())
    // .then(data => setProducts(data))
  }, []) // [] means that this useEffect will run only one time. failure to add it , useEffect will run anytime we run our component
  //eg , it will be calling the products all the time: endless loop
    return (
        <>
       <ProductList products = {products}/>
        </>
        
    )
}