import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../interfaces/product';
import { ProductResponse } from '../interfaces/productResponse';


 @Injectable({
  providedIn: 'root'
})
export class CatalogService {

  rootDirectory = 'https://localhost:7056/api';
  
  constructor(private http : HttpClient) { }


 getProducts() {
    return this.http.get<Product[]>(`${this.rootDirectory}/products`);
}


createProduct(product: Product) {
  return this.http.post<ProductResponse>(`${this.rootDirectory}/products`,product);
}

editProduct(product: Product) {
  return this.http.put(`${this.rootDirectory}/products`,product);
}

deleteProduct(productId: string){
  return this.http.delete(`${this.rootDirectory}/products/${productId}`);
}


}