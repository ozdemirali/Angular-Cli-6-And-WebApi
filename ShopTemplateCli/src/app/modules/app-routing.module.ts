import { DetailComponent } from './../components/detail/detail.component';
import { CreateComponent } from './../components/create/create.component';
import { HomeComponent } from './../components/home/home.component';


import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'create', component: CreateComponent },
  { path: 'detail/:productId', component: DetailComponent },

];

@NgModule({
 imports: [ RouterModule.forRoot(routes) ],
 exports:[RouterModule]
})
export class AppRoutingModule { }