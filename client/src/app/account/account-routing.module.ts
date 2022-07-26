import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegisterComponent } from './register/register.component';
import {CreditDetailsComponent} from './register/credit-details/credit-details.component';

const routes: Routes = [
    {path: '', component: RegisterComponent},
    {path: 'success', component: CreditDetailsComponent,  data: {}}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
