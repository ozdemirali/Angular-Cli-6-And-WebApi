
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './modules/app-routing.module';
import { HomeComponent } from './components/home/home.component';
import { CreateComponent } from './components/create/create.component';
import {DetailComponent} from './components/detail/detail.component'

import { ProductService } from './services/product.service';
import { KategoryService } from './services/kategory.service';
import { MarkService } from './services/mark.service';

import{HttpModule} from '@angular/http';
import {HttpClientModule} from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CreateComponent,
    DetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    HttpClientModule
  ],
  providers: [
    ProductService,
    KategoryService,
    MarkService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
