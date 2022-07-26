import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { AccountService } from 'src/app/account/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  ngOnInit() {}

  logout() {}

}
