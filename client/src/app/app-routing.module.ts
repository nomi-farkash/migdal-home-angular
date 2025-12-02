import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GaragesComponent } from './components/garages/garages.component';

const routes: Routes = [
  { path: '', component: GaragesComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }