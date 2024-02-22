import { Component, Inject, OnInit } from '@angular/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../services/employee.service';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-employee',
  templateUrl: './delete-employee.component.html',
  styleUrl: './delete-employee.component.css'
})
export class DeleteEmployeeComponent implements OnInit{

  inputData : any;
  employee! : Employee;

  constructor(private employeeService : EmployeeService, private router : Router, @Inject(MAT_DIALOG_DATA) public data: any, private ref : MatDialogRef<DeleteEmployeeComponent>) { }

  ngOnInit(): void {
    this.inputData = this.data;

    this.employeeService.GetEmployeeById(this.inputData.id).subscribe((data) => {
      this.employee = data.data
    });

  }

  onClickBack() {
    this.ref.close();
  }

  onClickDelete() {
    this.employeeService.DeleteEmployee(this.inputData.id).subscribe((data) => {
      this.ref.close();
      window.location.reload();
    });
  }
}
