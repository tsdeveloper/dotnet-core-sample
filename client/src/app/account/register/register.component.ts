import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormGroup, FormBuilder, Validators, AsyncValidatorFn} from '@angular/forms';
import {AccountService} from '../account.service';
import {Router} from '@angular/router';
import {timer, of, BehaviorSubject} from 'rxjs';
import {switchMap, map} from 'rxjs/operators';
import {CreditType} from '../../shared/models/credit-type';
import {CurrencyMaskInputMode} from 'ngx-currency';
import {IEmprestimo} from '../../shared/models/emprestimo';
import {DatePipe} from '@angular/common';
import {ICreditDetails} from '../../shared/models/creditDetails';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  errors: string[];
  listCreditType: CreditType[] = [];
  @Output() listItems: EventEmitter<any> = new EventEmitter<any>();
  private itemsList = new BehaviorSubject<FormBuilder>(null);
  items$ = this.itemsList.asObservable();
  private emprestimo: IEmprestimo;
  options = {prefix: 'R$ ', thousands: '.', decimal: ',', inputMode: CurrencyMaskInputMode.NATURAL};
  date: { year: number, month: number };
  listNumInstallments: any[] = [];


  constructor(private fb: FormBuilder, private accountService: AccountService,
              private router: Router, private datepipe: DatePipe) {
  }

  ngOnInit() {
    this.createRegisterForm();
    this.populateCreditType();
    this.populateNumInstallments();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      creditValue: [null, [Validators.required]],
      creditType: [null, [Validators.required]],
      numInstallments: [null, [Validators.required]],
      expDay: [null, [Validators.required]]
    });

  }

  changeCreditType(e: any) {

    this.creditType?.setValue(e.target.value, {
      onlySelf: true,
    });

    console.log('valor do creditType usando o método do componente Pai');
    console.log(this.creditType?.value);
  }


  changgeCreditValue(e: any) {
    console.log('creditValue componente Pai');
  }

  get creditType() {
    return this.registerForm.get('creditType');
  }

  changeExpDay(e: any) {
    console.log('valor do expDay usando o método do componente Pai');
    this.expDay?.setValue(e.target.value, {
      onlySelf: true,
    });

    console.log('valor do expDay usando o método do componente Pai');
    // console.log(this.expDay?.value);
  }

  get expDay() {
    return this.registerForm.get('expDay');
  }

  populateCreditType() {

    let index = 0;
    [
      'Crédito Consignado',
      'Crédito Direto',
      'Crédito Imobiliário',
      'Crédito Pessoa Física',
      'Crédito Pessoa Jurídica',
    ].map((arr) => {
      const creditType: CreditType = {
        id: index++,
        description: arr
      };

      this.listCreditType.push(creditType);
    });
  }

  populateNumInstallments() {

    const minParcelas = 5;
    const maxParcelas = 72;
    for (let i = 5; i <= minParcelas || i <= maxParcelas; i++) {
      this.listNumInstallments.push({
        id: i,
        description: `Parcelamento em ${i}x`
      });
    }
  }

  onSubmit() {
    this.emprestimo = {...this.emprestimo, ...this.registerForm.value};
    this.accountService.register(this.emprestimo).subscribe((response: any) => {
      console.log(response);
      const creditDetails  = {
        status: 'Aprovado',
        valorTotal: response.data.creditValue,
        valorJuros: response.data.creditValueFee
      };
      this.accountService.setCreditDetails(creditDetails);
      this.router.navigateByUrl('success');
    }, error => {
      console.log(error);
      this.errors = error.errors;
    });
  }

}
