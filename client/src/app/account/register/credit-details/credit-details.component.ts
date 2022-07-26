import {Component, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AccountService} from '../../account.service';
import {ActivatedRoute, Router} from '@angular/router';
import {CurrencyMaskInputMode} from 'ngx-currency';
import {ICreditDetails} from '../../../shared/models/creditDetails';

@Component({
  selector: 'app-credit-details',
  templateUrl: './credit-details.component.html',
  styleUrls: ['./credit-details.component.scss']
})
export class CreditDetailsComponent implements OnInit {
  registerForm: FormGroup;
  errors: string[];
  @Input() creditDetails: ICreditDetails;

  constructor(private fb: FormBuilder, private accountService: AccountService,
              private router: Router, private route: ActivatedRoute) {
    accountService.apiData$.subscribe(data => this.creditDetails = data);
    console.log(this.creditDetails);
  }

  ngOnInit() {  }

}
