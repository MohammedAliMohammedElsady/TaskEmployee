import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, RouterModule, Router } from '@angular/router';
import { EmployeeService, EmployeeModel } from '../../services/employee-service';
import { MatSnackBarModule, MatSnackBar } from '@angular/material/snack-bar';


@Component({
  standalone: true,
  selector: 'app-add-edit-employee',
  imports: [CommonModule, ReactiveFormsModule, RouterModule,MatSnackBarModule],
  templateUrl: './add-edit-employee.html',
  styleUrls: ['./add-edit-employee.css']
})

export class AddEditEmployee implements OnInit {
  private fb = inject(FormBuilder);
  private empService: EmployeeService = inject(EmployeeService);
  
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  submitted = false;
  id : number = 0; 
   employeeForm: FormGroup = this.fb.group({
    id: [],
    firstName: ['', Validators.required],
   lastName: ['', Validators.required],
   email: ['', [Validators.required, Validators.email]],
   position: ['', Validators.required]
  });

  employees: EmployeeModel[] = [];  
  private snackBar = inject(MatSnackBar);

   ngOnInit(): void {
    this.resetForm();

    const idParam = this.route.snapshot.paramMap.get('id');
    
    if (idParam) {
      this.id = +idParam;
      this.empService.getById(+idParam).subscribe(responseData =>{
       this.employeeForm.patchValue( responseData.data );
      });
    }
  }
   onSubmit() {
    this.submitted = true;
    if (this.employeeForm.invalid) {
     this.employeeForm.markAllAsTouched();
      return;
    }

    const data = this.employeeForm.value;

    if (this.id > 0) {
      // update
     this.empService.update(data).subscribe(response =>{
      console.log(response.message);
      this.snackBar.open(response.message, 'Close', {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top',
        panelClass: ['snackbar-success']
      });
     });

     this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
       this.router.navigate(['/employee']);
      });
    
    } else {
      // create
      
      this.empService.create(data).subscribe(response => {
        console.log(response.message);
         this.snackBar.open(response.message, 'Close', {
         duration: 3000,
         horizontalPosition: 'right',
         verticalPosition: 'top',
         panelClass: ['snackbar-success']
        });
      });    
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
       this.router.navigate(['/employee']);
      });
    }
  }
  resetForm() {
    this.id = 0;
    this.employeeForm.reset({ id: 0, firstName:'',lastName:'',email:'',position:'' });
  }
}
