import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArticlesListComponent } from './components/Article/articles-list/articles-list.component';
import { EmployeesListComponent } from './components/Employee/employees-list/employees-list.component';
import { HomeComponentComponent } from './components/home-component/home-component.component';
import { LoginComponent } from './components/Legon/login/login.component';
import { SignupComponent } from './components/Legon/signup/signup.component';
import { ShoppingListComponent } from './components/Shop/shopping-list/shopping-list.component';

const routes: Routes = [
  {
  path: '',
  component: HomeComponentComponent
  },
  {
    path: 'employees',
    component: EmployeesListComponent 
  },
  {
    path: 'articles',
    component: ArticlesListComponent
  },
  {
    path: 'shop',
    component: ShoppingListComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'signup',
    component: SignupComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
