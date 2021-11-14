import { Component, OnInit, ViewChild } from '@angular/core';
import { AccountService } from '../../account/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  constructor(private accountService: AccountService) {}

  user: any;
  logoutWrapperToggled = false;

  ngOnInit(): void {
    this.user = this.accountService.getUser();
  }
}
