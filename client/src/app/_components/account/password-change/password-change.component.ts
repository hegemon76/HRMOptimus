import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../../_services/account.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-password-change',
  templateUrl: './password-change.component.html',
  styleUrls: ['./password-change.component.scss']
})
export class PasswordChangeComponent implements OnInit {
  constructor(
    private accountService: AccountService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.accountService
      .confirmPassword(this.route.snapshot.paramMap.get('passwordToken'))
      .subscribe(res => {
        this.accountService.logoutUser();
        this.router.navigate(['/']);
      });
  }
}
