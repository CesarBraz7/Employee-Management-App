import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent implements OnInit{

  btnAction = "Update";
  btnTitle = "Edit employee";
  employee! : Employee;

  constructor(private employeeService : EmployeeService, private router : Router, private route : ActivatedRoute){}

  ngOnInit(): void{
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.employeeService.GetEmployeeById(id).subscribe((data)=>{
      this.employee = data.data;
    })
  }

  updateEmployee(employee : Employee){
    this.employeeService.UpdateEmployee(employee).subscribe((data) => {
      this.router.navigate(['/'])
    });
  }

}
