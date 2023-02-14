import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  
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
}
