import { Product } from './../../interfaces/product';
import { ProductService } from './../../services/product.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  products:Product[];

  constructor(private productService:ProductService) { }

  ngOnInit() {

    this.getProductList();
  }


  private getProductList() {
    this.productService.getProducts().subscribe((data) => {
      this.products=data;
      //console.log(this.products);
    });
  }
}
