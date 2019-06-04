import { Injectable } from '@angular/core';
import {Http} from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpAddress } from '../interfaces/httpAddress';

@Injectable({
  providedIn: 'root'
})
export class KategoryService {

  constructor(private http:Http) { }

  getKategoryies(){
    return this.http.get(HttpAddress.kategories.toString())
      .pipe(map(res=>res.json()));
  }
}
