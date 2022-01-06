import { Component, OnInit } from '@angular/core';
import { UserVm } from '../../../../shared/vm/user.vm';
import { AccountService } from '../../../_services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  checked = false;
  darkMode = true;
  user: UserVm;

  constructor(private accountService: AccountService, private router: Router) {}

  ngOnInit(): void {
    this.checkWebsiteMode();
    this.user = this.accountService.getUser();
  }

  changeWebsiteMode() {
    if (document.querySelector('html').dataset.theme == 'light') {
      localStorage.setItem('theme', 'dark');
      document.querySelector('html').dataset.theme = localStorage.getItem(
        'theme'
      );
    } else {
      localStorage.setItem('theme', 'light');
      document.querySelector('html').dataset.theme = localStorage.getItem(
        'theme'
      );
    }
  }

  checkWebsiteMode() {
    if (localStorage.getItem('theme') != null) {
      document.querySelector('html').dataset.theme = localStorage.getItem(
        'theme'
      );
      if (localStorage.getItem('theme') == 'dark') {
        this.checked = true;
      }
    }
  }

  openSubmenu(e) {
    e.target.parentElement.parentElement.classList.toggle('opened');
  }

  changeRoute(path: string) {
    setTimeout(() => {
      this.router.navigate([path]);
    }, 400);
  }
}
