import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../account/account.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  checked = false;
  darkMode = true;
  user: any;

  constructor(private accountService: AccountService) {}

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

  destroyUser() {
    localStorage.removeItem('user');
    window.location.reload();
  }
}
