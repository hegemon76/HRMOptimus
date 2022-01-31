import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../../_services/account.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-email-change',
  templateUrl: './email-change.component.html',
  styleUrls: ['./email-change.component.scss']
})
export class EmailChangeComponent implements OnInit {
  constructor(
    private accountService: AccountService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = function() {
      return false;
    };
  }

  ngOnInit(): void {
    this.accountService
      .confirmEmail(this.route.snapshot.paramMap.get('emailToken'))
      .subscribe(res => {
        this.accountService.logoutUser();
        this.router.navigate(['/']);
      });
  }
}
