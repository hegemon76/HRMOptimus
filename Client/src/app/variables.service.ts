import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VariablesService {
  toggleWorktime: boolean = true;
  constructor() {}
  getToggleWorktime() {
    return this.toggleWorktime;
  }
  setToggleWorktime() {
    if (!this.toggleWorktime) {
      this.toggleWorktime = true;
    } else {
      this.toggleWorktime = false;
    }
    console.log(this.toggleWorktime);
  }
}
