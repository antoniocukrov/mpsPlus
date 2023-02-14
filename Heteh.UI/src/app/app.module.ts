import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EmployeesListComponent } from './components/Employee/employees-list/employees-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HomeComponentComponent } from './components/home-component/home-component.component';
import { ArticlesListComponent } from './components/Article/articles-list/articles-list.component';
import { ShoppingListComponent } from './components/Shop/shopping-list/shopping-list.component';
import { RouterOutlet } from "@angular/router";
import { LoginComponent } from './components/Legon/login/login.component';
import { SignupComponent } from './components/Legon/signup/signup.component';


@NgModule({
    declarations: [
        AppComponent,
        EmployeesListComponent,
        HomeComponentComponent,
        ArticlesListComponent,
        ShoppingListComponent,
        LoginComponent,
        SignupComponent
    ],
    providers: [
        NgbActiveModal
    ],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        NgbModule,
        HttpClientModule,
        FormsModule,
        RouterOutlet
    ]
})
export class AppModule { }
