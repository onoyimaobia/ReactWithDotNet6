import {Grid, List } from "@mui/material";
import { Product } from "../../app/models/Product";
import ProductCard from "./ProductCard";

interface Props{
    products: Product[];
}

export default function ProductList({products}: Props){
    return(
        <Grid container spacing={4}>
            {/* index is use for unique identity so that you can have products with same name */}
            {products.map(products=> (
                <Grid item xs={3} key={products.productId}>
                    <ProductCard product={products}/>
                </Grid>
            ))}
      </Grid>
    )
}