import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../../_services/account.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { UserVm } from '../../../../shared/vm/user.vm';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  constructor(
    private accountService: AccountService,
    private breakpointObserver: BreakpointObserver
  ) { }

  user: UserVm;
  logoutWrapperToggled = false;
  fullName = localStorage.getItem('fullName');

  ngOnInit(): void {
    this.user = this.accountService.getUser();
  }
  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
}
