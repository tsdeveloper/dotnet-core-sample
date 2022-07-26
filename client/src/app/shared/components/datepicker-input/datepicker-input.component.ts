import {Component, OnInit, ViewChild, ElementRef, Input, Self, Output, EventEmitter} from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';
import {BsDatepickerDirective, BsLocaleService} from 'ngx-bootstrap';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-datepicker-input',
  templateUrl: './datepicker-input.component.html',
  styleUrls: ['./datepicker-input.component.scss']
})
export class DatepickerInputComponent implements OnInit, ControlValueAccessor {
  @ViewChild(BsDatepickerDirective, { static: false }) datepicker?: BsDatepickerDirective;
  @ViewChild('input', { static: true }) input: ElementRef;
  @Input() label: string;
  @Output() dateSelected = new EventEmitter();
  bsValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  @Input() id: string;
  constructor(@Self() public controlDir: NgControl, private localeService: BsLocaleService) {
    localeService.use('pt-br');
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsValue, this.maxDate];
    this.controlDir.valueAccessor = this;

  }

  ngOnInit() {
    const control = this.controlDir.control;
    const validators = control.validator ? [control.validator] : [];
    const asyncValidators = control.asyncValidator ? [control.asyncValidator] : [];

    control.setValidators(validators);
    control.setAsyncValidators(asyncValidators);
    control.updateValueAndValidity();
  }

  onChange(event) {
    console.log('onChange:', event);
  }

  valueChange($event: any) {
    console.log($event);
    if ($event) {
      this.controlDir.control.setValue($event);
    }
  }

  onTouched() {
    console.log('onChange:');
  }
  writeValue(obj: any): void {
    // this.input.nativeElement.value = obj || '';
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

}
