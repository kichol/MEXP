import { Component, EventEmitter, Output } from '@angular/core';
import { FormGroup,FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent {
  
  createForm: FormGroup = new FormGroup({
    code: new FormControl("",[Validators.required,]),
    name: new FormControl("",[Validators.required,]),
    price: new FormControl("",[Validators.required, Validators.pattern(/^(?:\d*\.\d{1,2}|\d+)$/)]),
  }); 

  @Output() productCreated = new EventEmitter();
  @Output() closeClicked = new EventEmitter();

  
  constructor(){}
  
  onSubmit(){
    if (!this.createForm.valid) {
      return;
    }

    this.productCreated.emit(this.createForm.value);
   
  }

  closeForm(){
    this.closeClicked.emit();
  }




}
