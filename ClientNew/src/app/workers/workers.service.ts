import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
interface Worker {
  login: string;
  password: string;
  name: string;
  surname: string;
  isAdmin: boolean;
}
@Injectable({
  providedIn: 'root'
})
export class WorkersService {
  private subject = new Subject<any>();

  workers: Array<Worker> = [
    {
      login: 'jakub',
      password: 'jakub',
      name: 'Jakub',
      surname: 'Bahrynowski',
      isAdmin: false
    },
    {
      login: 'damian',
      password: 'damian',
      name: 'Damian',
      surname: 'Czerwiński',
      isAdmin: false
    },
    {
      login: 'karol',
      password: 'karol',
      name: 'Karol',
      surname: 'Dura',
      isAdmin: false
    },
    {
      login: 'adrian',
      password: 'adrian',
      name: 'Adrian',
      surname: 'Dawid',
      isAdmin: false
    }
  ];
  constructor() {}
  checkIfUserExists(user) {
    this.workers.map(worker => {
      if (worker.login == user.login && worker.password == user.password) {
        localStorage.setItem('user', worker.name);
        window.location.reload();
      }
    });
  }
}
