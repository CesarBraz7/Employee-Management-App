import { Component } from '@angular/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent { 

  btnAction = "Register";
  btnTitle = "Register employee";

  constructor(private employeeService : EmployeeService, private router : Router){}

  createEmployee(employee : Employee){
    this.employeeService.CreateEmployee(employee).subscribe((data) => {
      this.router.navigate(['/'])
    });
  }

}
