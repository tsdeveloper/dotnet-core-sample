import {Component, OnInit, ViewChild, ElementRef, Input, Self, Output, EventEmitter} from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-number-input',
  templateUrl: './number-input.component.html',
  styleUrls: ['./number-input.component.scss']
})
export class NumberInputComponent implements OnInit, ControlValueAccessor {
  @ViewChild('input', { static: true }) input: ElementRef;
  @Input() type = 'number';
  @Input() label: string;
  @Output() itemSelected = new EventEmitter();
  @Input() id: string;

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

  onChange(event) {
    console.log('onChange:', event);
  }

  onTouched() {
    console.log('onChange:');
  }

  writeValue(obj: any): void {
    this.input.nativeElement.value = obj || '';
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  selectedValue($event: Event) {

    // if ($event.target.value) {
    //   this.controlDir.control.setValue($event.target.value);
    // } else {
    //   console.log('reset:');
    //   this.controlDir.reset();
    //   this.controlDir.control.setValue('');
    // }

  }

}
