import { Component, OnInit } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import {
  trigger,
  style,
  state,
  transition,
  animate
} from '@angular/animations';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
  animations: [
    trigger('fadeTest', [
      state(
        'start',
        style({
          opacity: 0
        })
      ),
      state(
        'end',
        style({
          opacity: 1
        })
      ),
      transition('start => end', [animate('0.4s')])
    ])
  ]
})
export class MainComponent implements OnInit {
  test = false;
  constructor(private router: Router) {
    router.events.subscribe(val => {
      if (val instanceof NavigationStart) {
        this.test = !this.test;
        setTimeout(() => {
          this.test = !this.test;
        }, 400);
      }
    });
  }

  ngOnInit(): void {}

  change() {
    this.test = !this.test;
    setTimeout(() => {
      this.test = !this.test;
    }, 400);
  }
}
