import { Injectable } from '@angular/core';
import {Http} from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpAddress } from '../interfaces/httpAddress';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:Http) { }

  getProducts(){
    return this.http.get(HttpAddress.products.toString())
      .pipe(map(res=>res.json()));
  }
  
  postProducts(item){
      return this.http.post(HttpAddress.products.toString(),item)
        .pipe(map(res=>res.json()));
  }

  getProductById(id:number){
    return this.http.get(HttpAddress.products.toString()+"/"+id)
    .pipe(map(res=>res.json()));
  }

  putProduct(item){
    return this.http.put(HttpAddress.products.toString(),item)
      .pipe(map(res=>res.json()));
  }  

  deleteProduct(id:number){
    return this.http.delete(HttpAddress.products.toString()+"/"+id)
      .pipe(map(res=>res.json()));
  }
  

  


}
