import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarAltComponent } from './sidebar-alt.component';

describe('SidebarAltComponent', () => {
  let component: SidebarAltComponent;
  let fixture: ComponentFixture<SidebarAltComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SidebarAltComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SidebarAltComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
