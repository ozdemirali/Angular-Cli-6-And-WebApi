import { DetailProduct } from './../../interfaces/detailProduct';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { ProductService } from './../../services/product.service';
import { MarkService } from './../../services/mark.service';
import { KategoryService } from './../../services/kategory.service';
import { Mark } from './../../interfaces/mark';
import { Kategory } from './../../interfaces/kategory';
import { HttpAddress } from './../../interfaces/httpAddress';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  productId:number;
  selected:string=null;
  selectedFile:File=null;
  kategories:Kategory[];
  marks:Mark[];
  product:DetailProduct={
    Id:0,
    Ad:"",
    Fiyat:0,
    KategoriId:0,
    MarkaId:0,
    ResimYolu:"",
    Yeni:true
  }
 

  constructor( 
    private router: ActivatedRoute,
    private navigate:Router,
    private kategoryService:KategoryService, 
    private markService:MarkService,
    private productService:ProductService,
    private http:HttpClient) { }

  ngOnInit() {
    this.router.paramMap.subscribe(params => {
       this.productId=Number(params.get("productId"));     
    });
    
    this.getKategoryList();
    this.getMarkList();
    this.getProductById();
  }

  private getKategoryList() {
    this.kategoryService.getKategoryies().subscribe((data=>{
       this.kategories=data;
    }));
  }

  private getMarkList(){
   this.markService.getMarks().subscribe((data=>{
     this.marks=data
   }));
  }

  private getProductById(){
    this.productService.getProductById(this.productId).subscribe((data=>{
      this.product=data;
    }))
  }

  private updateProduct(){
    
    const fd=new FormData();
   
     if(this.selected!=null){
      fd.append("Image",this.selectedFile,this.selectedFile.name);
      this.http.post(HttpAddress.postImage.toString(),fd)
      .subscribe(res=>{
        this.productService.putProduct(this.product)
          .subscribe((data=>{
            this.navigate.navigateByUrl("");
          }));
      })
     } 
     else{
      this.productService.putProduct(this.product)
      .subscribe((data=>{
        this.navigate.navigateByUrl("");
      }));
     }
  }

  private deleteProduct(){
    this.productService.deleteProduct(this.product.Id).subscribe((data=>{ 
      this.navigate.navigateByUrl("");
    }))
  }


  private onFileSelected(event){
    this.selectedFile=<File>event.target.files[0];
    
     this.product.ResimYolu=this.selectedFile.name;
   }
}
