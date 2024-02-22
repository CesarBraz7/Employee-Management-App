import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent implements OnInit{
  employee? : Employee;
  id! : number;

  constructor(private employeeService : EmployeeService, private router : Router, private route : ActivatedRoute){}

  ngOnInit(): void{
    this.id = Number(this.route.snapshot.paramMap.get('id'));

    this.employeeService.GetEmployeeById(this.id).subscribe((data)=>{
      const employeeData = data.data;

      employeeData.createDate = new Date(employeeData.createDate!).toLocaleDateString('pt-br');
      employeeData.updateDate = new Date(employeeData.updateDate!).toLocaleDateString('pt-br');

      this.employee = data.data;
    })
  }

  InactiveEmployee(){
    this.employeeService.InactiveEmployee(this.id).subscribe((data) => {
      this.router.navigate(['']);
    })
  }

  ActiveEmployee(){
    this.employeeService.ActiveEmployee(this.id).subscribe((data) => {
      this.router.navigate(['']);
    })
  }
}
