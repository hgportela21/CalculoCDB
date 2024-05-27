import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalculoCdbComponent } from './calculo-cdb/calculo-cdb.component';

const routes: Routes = [
  { path: '', redirectTo: 'calculadora-cdb', pathMatch: 'full' },
  { path: 'calculadora-cdb', component: CalculoCdbComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
