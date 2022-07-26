import {Component, OnInit, ViewChild, ElementRef, Input, Self, Output, EventEmitter} from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-currency-input',
  templateUrl: './currency-input.component.html',
  styleUrls: ['./currency-input.component.scss']
})
export class CurrencyInputComponent implements OnInit, ControlValueAccessor {
  @ViewChild('input', { static: true }) input: ElementRef;
  @Input() type = 'text';
  @Input() label: string;
  @Input() value: string;
  @Output() valueChange = new EventEmitter();
  constructor(@Self() public controlDir: NgControl) {
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



  onTouched() { }
  onChange($event: any) {
    console.log('onChange:', $event);
  }

  setValue($event: any) {
    console.log('onChange:', $event);
  }

  writeValue(obj: any): void {
    console.log('onChange:', obj);
    this.input.nativeElement.value = obj || '';
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  onKeyDown($event: any) {

  }
  onKeyUp($event: any) {

  }
  onFocusInput($event: any) {

  }
}
