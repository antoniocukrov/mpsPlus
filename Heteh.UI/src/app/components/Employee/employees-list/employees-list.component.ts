import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';
import { NgbDatepickerModule, NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})



export class EmployeesListComponent implements OnInit {
  closeResult= '';
  addEmployeeRequest: Employee = {
    id: '',
    name: '',
    email: '',
    phone: 0,
    salary: 0,
    department: ''
  }
  employeeDetails: Employee = {
    id: '',
    name: '',
    email: '',
    phone: 0,
    salary: 0,
    department: ''
  }
  employees: Employee[] = [];
  constructor(private employeeService: EmployeesService,private router: Router, private route: ActivatedRoute,private modalService:NgbModal) { }

  ngOnInit(): void {
    this.employeeService.getAllEmployees()
    .subscribe({
      next: (employees) => {
        this.employees = employees;
        },
      error: (response) => {
        console.log(response);
      }
    })
        
  }
  readEmployee(id: string){
      if(id) {
      // call API
      this.employeeService.getEmployee(id)
      .subscribe(
        {
          next: (response) => 
          {
            this.employeeDetails = response;
          }
        }
      )
    }
  }
  addEmployee() {
    this.employeeService.addEmployee(this.addEmployeeRequest)
  .subscribe({
    next: (employee) => {
      window.location.reload();
    }

  })
  }
  updateEmployee(id:string, employeeDetails: Employee) {
    if(id){
      this.employeeService.updateEmployee(id, employeeDetails)
      .subscribe(
        {
          next: (response) =>
          {
            this.employeeDetails = response;
            window.location.reload();
            
          }
        }
      )
    } 
  }
  deleteEmployee(id: string) {
    if(id){
      this.employeeService.deleteEmployee(id)
      .subscribe(
        {
          next: (response) =>
          {
            this.employeeDetails = response;
          }
        }
      )
    }
  }
  openAdd(content: any) {
		this.modalService.open(content, { ariaLabelledBy: 'modal-add-employee' }).result
			}
  openEdit(content: any) {
        this.modalService.open(content, { ariaLabelledBy: 'modal-edit-employee' }).result
          }    
  }

  