import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar-alt',
  templateUrl: './sidebar-alt.component.html',
  styleUrls: ['./sidebar-alt.component.scss']
})
export class SidebarAltComponent implements OnInit {
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
