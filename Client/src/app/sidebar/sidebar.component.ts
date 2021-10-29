import { Component, OnInit } from '@angular/core';
import { AppRoutingModule } from '../app-routing.module';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {
    const navItems = document.querySelectorAll('nav a');
    navItems.forEach(item => {
      item.addEventListener('click', () => {
        item.classList.toggle('opened');
      });
    });
  }
}
