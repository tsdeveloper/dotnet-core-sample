import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule, CarouselModule, BsDropdownModule} from 'ngx-bootstrap';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { TextInputComponent } from './components/text-input/text-input.component';
import {CdkStepperModule} from '@angular/cdk/stepper';
import { StepperComponent } from './components/stepper/stepper.component';

import { RouterModule } from '@angular/router';
import {SelectInputComponent} from './components/select-input/select-input.component';
import {NumberInputComponent} from './components/number-input/number-input.component';
import {DatepickerInputComponent} from './components/datepicker-input/datepicker-input.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import {CurrencyInputComponent} from './components/currency-input/currency-input.component';
import {NgxCurrencyModule} from 'ngx-currency';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [PagingHeaderComponent, PagerComponent,
    TextInputComponent, StepperComponent,
    SelectInputComponent, NumberInputComponent, DatepickerInputComponent,
    CurrencyInputComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    CdkStepperModule,
    RouterModule,
    BsDatepickerModule.forRoot(),
    NgxCurrencyModule,
  ],
  exports: [
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    CarouselModule,
    ReactiveFormsModule,
    FormsModule,
    BsDropdownModule,
    TextInputComponent,
    CdkStepperModule,
    StepperComponent,
    SelectInputComponent,
    NumberInputComponent,
    DatepickerInputComponent,
    BsDatepickerModule,
    CurrencyInputComponent,
    NgxCurrencyModule,

  ],
  providers: [
    DatePipe,
  ]
})
export class SharedModule { }
