import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from 'src/interfaces/product';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {
  
  @Input() product: Product;
  @Output() productEdited = new EventEmitter();

  editForm: FormGroup;

  ngOnInit(){
    const { productId, code, name, price } = this.product;
   
    this.editForm = new FormGroup({
      productId: new FormControl(productId,[Validators.required,]),
      code: new FormControl(code,[Validators.required,]),
      name: new FormControl(name,[Validators.required,]),
      price: new FormControl(price,[Validators.required, Validators.pattern(/^(?:\d*\.\d{1,2}|\d+)$/)]),
    }); 
  }

  @Output() closeClicked = new EventEmitter();
  constructor(){}
  
  onSubmit(){
    if (!this.editForm.valid) {
      return;
    }

    this.productEdited.emit(this.editForm.value);
    
  }

  closeForm(){
    this.closeClicked.emit();

  }
}
