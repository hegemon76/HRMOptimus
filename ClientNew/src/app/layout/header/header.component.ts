import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../account/account.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  constructor(
    private accountService: AccountService,
    private breakpointObserver: BreakpointObserver
  ) {}

  user: any;
  logoutWrapperToggled = false;

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
