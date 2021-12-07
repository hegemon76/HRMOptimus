import { Component, OnInit, Inject } from '@angular/core';
import { ProjectsService } from '../projects.service';
import { Router } from '@angular/router';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';

export interface DialogData {
  name: string;
}

@Component({
  selector: 'app-projects-list',
  templateUrl: './projects-list.component.html',
  styleUrls: ['./projects-list.component.scss']
})
export class ProjectsListComponent implements OnInit {
  projects: any;
  searchedProject: string;

  constructor(
    private projectsService: ProjectsService,
    private router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getProjects();
  }

  getProjects() {
    this.projectsService.getProjects().subscribe(res => {
      this.projects = res;
      console.log(this.projects);
    });
  }

  removeProject(id) {
    this.projectsService.removeProject(id).subscribe(res => {
      this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
        this.router.navigate(['/projects']);
      });
    });
  }

  openDialog(n, id) {
    const dialogRef = this.dialog.open(DeleteProjectDialog, {
      data: { name: n }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result == true) {
        this.projectsService.removeProject(id).subscribe(() => {
          this.router
            .navigateByUrl('', { skipLocationChange: true })
            .then(() => {
              this.router.navigate(['/projects']);
            });
        });
      }
    });
  }
}

@Component({
  selector: 'delete-project-dialog',
  templateUrl: 'delete-project-dialog.html',
  styleUrls: ['./projects-list.component.scss']
})
export class DeleteProjectDialog {
  constructor(
    public dialogRef: MatDialogRef<DeleteProjectDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
}
