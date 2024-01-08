import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product } from 'src/interfaces/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
@Input() products: Product[] = [];
@Output() productEdited = new EventEmitter();
@Output() productDeleted = new EventEmitter();


editClicked(index: number){
  const product = this.products[index];
  this.productEdited.emit(product);

}

deleteClicked(event:any){
  
  const productId = this.products[event].productId;
  this.productDeleted.emit(productId);

}

}
