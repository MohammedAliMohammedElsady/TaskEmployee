import { Routes } from '@angular/router';
import { Employee } from './employee/employee';
import {AddEditEmployee} from './employee/add-edit-employee/add-edit-employee'
import {ShowEmployee} from './employee/show-employee/show-employee'

export const routes: Routes = [
   { path: '', redirectTo: 'employee', pathMatch: 'full' },
  { path: 'employee', component: ShowEmployee },
  { path: 'employee/add', component: AddEditEmployee },
  { path: 'employee/edit/:id', component: AddEditEmployee },
  { path: '**', redirectTo: 'employee' }
      
];