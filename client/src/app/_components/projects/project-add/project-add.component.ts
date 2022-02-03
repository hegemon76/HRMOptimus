import { Component, OnInit, Inject } from '@angular/core';
import {
  ComponentFactoryResolver,
  ViewChild,
  ViewContainerRef
} from '@angular/core';
import { ProjectAddSingleFormComponent } from './project-add-single-form/project-add-single-form.component';
import { ProjectsService } from '../../../_services/projects.service';
import { formatDate } from '@angular/common';
import { Router } from '@angular/router';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';

export interface DialogData {}

@Component({
  selector: 'app-project-add',
  templateUrl: './project-add.component.html',
  styleUrls: ['./project-add.component.scss']
})
export class ProjectAddComponent implements OnInit {
  @ViewChild('container', { read: ViewContainerRef })
  container: ViewContainerRef;
  addProjectRow = ProjectAddSingleFormComponent;
  components = [];
  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private projectsService: ProjectsService,
    private router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    var checkContainerLoaded = setInterval(() => {
      if (this.container) {
        clearInterval(checkContainerLoaded);
        this.addComponent();
      }
    }, 100);
  }

  ngAfterContentInit() {}

  addComponent() {
    if (
      this.components.length > 0 &&
      this.components[this.components.length - 1].instance.form.status ==
        'INVALID'
    ) {
      this.openDialog();
    } else {
      const componentFactory = this.componentFactoryResolver.resolveComponentFactory(
        ProjectAddSingleFormComponent
      );
      const component = this.container.createComponent(componentFactory);
      component.instance.rm.subscribe(r => {
        this.removeComponent(component);
      });
      this.components.push(component);
    }
  }
  removeComponent(component) {
    const componentIndex = this.components.indexOf(component);

    if (componentIndex !== -1 && this.components.length > 1) {
      this.container.remove(componentIndex);
      this.components.splice(componentIndex, 1);
    }
  }

  addProjects() {
    this.components.map(c => {
      console.log(c.instance.form.getRawValue());
      if (c.instance.form.status == 'VALID') {
        const formData = c.instance.form.getRawValue();
        formData.dateFrom =
          formatDate(formData.dateFrom, 'YYYY-MM-dd', 'en-US') +
          'T00:00:00.000Z';
        formData.dateTo =
          formatDate(formData.dateTo, 'YYYY-MM-dd', 'en-US') + 'T00:00:00.000Z';
        formData.deadline =
          formatDate(formData.dateTo, 'YYYY-MM-dd', 'en-US') + 'T00:00:00.000Z';

        this.projectsService.addProject(formData).subscribe(res => {
          formData.employees.map(e => {
            this.projectsService
              .addEmployeesToProject(res, e)
              .subscribe(res => {
                console.log(res);
              });
          });
          this.router.navigate(['/projects']);
        });
      }
    });
  }

  openDialog() {
    const dialogRef = this.dialog.open(FillProjectsFormDialog);
  }
}

@Component({
  selector: 'fill-projects-form-dialog',
  templateUrl: 'fill-projects-form-dialog.html',
  styleUrls: ['./project-add.component.scss']
})
export class FillProjectsFormDialog {
  constructor(
    public dialogRef: MatDialogRef<FillProjectsFormDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
}
