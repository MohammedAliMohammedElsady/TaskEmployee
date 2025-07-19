import { Component,inject ,OnInit, ViewChild, AfterViewInit  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeService, EmployeeModel } from '../../services/employee-service';
import { RouterModule, Router } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBarModule, MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-show-employee',
  imports: [CommonModule, RouterModule,MatTableModule,MatSnackBarModule],
  standalone:true,
  templateUrl: './show-employee.html',
  styleUrls: ['./show-employee.css']
})

export class ShowEmployee implements OnInit, AfterViewInit {
   private empService = inject(EmployeeService);
   private router = inject(Router);

   displayedColumns: string[] = ['id','firstName', 'lastName', 'email','position', 'actions'];

  employees = new MatTableDataSource<EmployeeModel>();
 private snackBar = inject(MatSnackBar);
 private dialog = inject(MatDialog);
  

   ngOnInit(): void {
    this.loadEmployees();
  }

  ngAfterViewInit(): void {
  }

  loadEmployees(): void {
    this.empService.getAll().subscribe(resp => {
      const data = resp.data as EmployeeModel[];
      this.employees.data = data;
    });
  }

  deleteEmployee(id: number) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { message: 'Are You Sure Delete This Employee ?'}
     });
    dialogRef.afterClosed().subscribe(result => {
      if(result){
          this.empService.delete(id).subscribe((response) =>{
            this.loadEmployees();
            this.snackBar.open(response.message, 'Close', {
            duration: 3000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
            panelClass: ['snackbar-error']
            });
          });
       }
     });
    
  }
  
  
  editEmployee(id: number) {
     this.router.navigate(['/employee/edit', id]);
  }

  addEmployee() {
    this.router.navigate(['/employee/add']);
  }
  applyFilter(event: Event) {
   const filterValue = (event.target as HTMLInputElement).value;
   this.employees.filter = filterValue.trim().toLowerCase();
  }
}
