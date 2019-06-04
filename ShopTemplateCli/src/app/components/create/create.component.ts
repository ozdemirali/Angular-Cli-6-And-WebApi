import { ProductService } from './../../services/product.service';
import { MarkService } from './../../services/mark.service';
import { KategoryService } from './../../services/kategory.service';
import { Mark } from './../../interfaces/mark';
import { Kategory } from './../../interfaces/kategory';
import { HttpAddress } from './../../interfaces/httpAddress';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';



@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {


  kategories:Kategory[];
  marks:Mark[];
  clearFile:string;
  selectedFile:File=null;
  newProduct={
    Ad:"",
    Yeni:0,
    MarkaId:1,
    KategoriId:1,
    ResimYolu:"",
    Fiyat:null,
  };
  


  constructor(
    private kategoryService:KategoryService, 
    private markService:MarkService,
    private productService:ProductService,
    private http:HttpClient) { 

    }



  ngOnInit() {
     
    


    this.getKategoryList();
    this.getMarkList();
    //console.log(this.newProduct);
  }
 
   
  private getKategoryList() {
    this.kategoryService.getKategoryies().subscribe((data=>{
       this.kategories=data;
       //console.log(this.kategories);  
    }));
  }

  private getMarkList(){
   this.markService.getMarks().subscribe((data=>{
     this.marks=data
     //console.log(this.marks);
   }));
    
  }
 
   private onFileSelected(event){
    this.selectedFile=<File>event.target.files[0];
    this.newProduct.ResimYolu=this.selectedFile.name;
    //console.log(this.newProduct);

   }

  private saveProduct(){
    const fd=new FormData();
    fd.append("Image",this.selectedFile,this.selectedFile.name);
    
    this.http.post(HttpAddress.postImage.toString(),fd)
      .subscribe(res=>{
        //console.log(res);
        this.productService.postProducts(this.newProduct)
          .subscribe((data=>{
            //console.log(data);
            this.cleanForm();
             //location.reload();
          }));
      })
  }


  private cleanForm(){
    this.newProduct.Ad="";
    this.newProduct.KategoriId=1;
    this.newProduct.MarkaId=1;
    this.newProduct.Yeni=0;
    this.newProduct.Fiyat=null;
    this.newProduct.ResimYolu=null;
    this.clearFile=null;
  }
}
