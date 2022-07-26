import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, ReplaySubject, of } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { Router } from '@angular/router';
import {IEmprestimo} from '../shared/models/emprestimo';
import {ICreditDetails} from '../shared/models/creditDetails';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<IEmprestimo>(1);
  currentUser$ = this.currentUserSource.asObservable();
// don't use "any", type your data instead!
  private apiData = new BehaviorSubject<ICreditDetails>(null);
  public apiData$ = this.apiData.asObservable();

  constructor(private http: HttpClient, private router: Router) { }


  register(values: any) {
    console.log(values);
    return this.http.post(this.baseUrl + 'emprestimos/register', values);
  }

  setCreditDetails(creditDetails: ICreditDetails) {
    this.apiData.next(creditDetails);
  }
}
