import { Component } from '@angular/core';
import { CatalogService } from './catalog.service';
import { Product } from '../interfaces/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  products: Product[];
  editedProduct: Product;
  editing = false;
  creating = false;

  constructor(private catalogService: CatalogService) { }

  ngOnInit(){
    this.catalogService.getProducts().subscribe(response => {
      this.products = response;

    });
  }
  onSubmitCreate(value: Product){
    this.catalogService.createProduct(value).subscribe(response => {
      if (response.product) {
        this.products = [...this.products, response.product];
        this.creating = false;
      }
      
   },);
      
  }
  
  onSubmitEdit(value: Product){
    this.catalogService.editProduct(value).subscribe(response => {
      this.catalogService.getProducts().subscribe(response => {
        this.products = response;
        this.editing = false; 
      });
      });

  }

  onDeleteProduct(id: string){
    if (this.editing || this.creating) {
      return;
    }
    if(confirm("Are you sure to delete "+name)) {
      this.catalogService.deleteProduct(id).subscribe(response => {
        this.catalogService.getProducts().subscribe(response => {
          this.products = response;
          
        });
      });
    }
    
  } 
  onEditProduct(product: Product){
    this.editedProduct = product;
    this.editing = !this.creating;
   
  } 
  onCancelEdit(){
    console.log("close clicked");
    this.editing = false;
  }
  onCancelCreate(){
    this.creating = false;
  }

}
 


