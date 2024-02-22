import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../services/employee.service';
import { DeleteEmployeeComponent } from '../../components/delete-employee/delete-employee.component';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  employees: Employee[] = [];
  generalEmployees: Employee[] = [];
  selectedEmployeeId: number | null = null;
  columnsToDisplay = ['active', 'firstname', 'lastname', 'department', 'shift', 'actions'];

  constructor(private employeeService : EmployeeService, private modalService: BsModalService, public dialog: MatDialog){}
  

  ngOnInit(): void {
      this.employeeService.GetEmployee().subscribe(data => {
        const responseData = data.data;

        responseData.map((item) => {
          item.createDate = new Date(item.createDate!).toLocaleDateString('pt-br')
          item.updateDate = new Date(item.updateDate!).toLocaleDateString('pt-br')
        })

        this.employees = data.data;
        this.generalEmployees = data.data;

      })
  }
  search(event : Event){
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();  

    this.employees = this.generalEmployees.filter(employee => {
      return employee.firstName.toLowerCase().includes(value) && employee.lastName.toLowerCase().includes(value);
    })
  }

  openDialog(id : number) : void{
    this.dialog.open(DeleteEmployeeComponent, {
      data: {
        id: id,
      }
    });
  }
}
