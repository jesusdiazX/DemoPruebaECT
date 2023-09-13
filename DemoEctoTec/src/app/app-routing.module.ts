import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NevoRegistroComponent } from './nevo-registro/nevo-registro.component';

const routes: Routes = [
  { path: 'Nuevo', pathMatch: 'full', component:NevoRegistroComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
