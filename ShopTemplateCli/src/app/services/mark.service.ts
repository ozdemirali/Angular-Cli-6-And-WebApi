import { Injectable } from '@angular/core';
import {Http} from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpAddress } from '../interfaces/httpAddress';

@Injectable({
  providedIn: 'root'
})
export class MarkService {

  constructor(private http:Http) { }

  getMarks(){
    return this.http.get(HttpAddress.marks.toString())
      .pipe(map(res=>res.json()));
  }
}
