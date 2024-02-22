import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../../models/employee';

@Component({
  selector: 'app-form-employee',
  templateUrl: './form-employee.component.html',
  styleUrl: './form-employee.component.css'
})
export class FormEmployeeComponent implements OnInit{
  @Output() onSubmit = new EventEmitter<Employee>();
  @Input() btnAction! : string;
  @Input() btnTitle! : string;
  @Input() dataEmployee : Employee | null = null;

  employeeForm!: FormGroup; 

  constructor() {
    
  }

  ngOnInit(): void {
    
    this.employeeForm = new FormGroup({
      id: new FormControl(this.dataEmployee ? this.dataEmployee.id : 0),
      firstName: new FormControl(this.dataEmployee ? this.dataEmployee.firstName : '', [Validators.required]),
      lastName: new FormControl(this.dataEmployee ? this.dataEmployee.lastName : '', [Validators.required]),
      department: new FormControl(this.dataEmployee ? this.dataEmployee.department : '', [Validators.required]),
      shift: new FormControl(this.dataEmployee ? this.dataEmployee.shift : '', [Validators.required]),
      isActive: new FormControl(this.dataEmployee ? this.dataEmployee.isActive : true),
      createDate: new FormControl(new Date()),
      updateDate: new FormControl(new Date()),
    })

  }

  submit(){
    this.onSubmit.emit(this.employeeForm.value);
  }
}
