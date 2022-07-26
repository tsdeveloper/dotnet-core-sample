import {Component, OnInit, ViewChild, ElementRef, Input, Self, Output, EventEmitter} from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-select-input',
  templateUrl: './select-input.component.html',
  styleUrls: ['./select-input.component.scss']
})
export class SelectInputComponent implements OnInit, ControlValueAccessor {
  @ViewChild('select', { static: true }) select: ElementRef;
  @Input() type = 'text';
  @Input() items: any[] = [];
  @Input() label: string;
  @Input() id: string;
  @Output() itemSelected = new EventEmitter();

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

  onTouched() { }

  writeValue(obj: any): void {
    if (obj) {
      this.select.nativeElement.value = obj || '';
    }
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
