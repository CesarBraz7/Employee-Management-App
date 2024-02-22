import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { RegisterComponent } from './pages/register/register.component';
import { FormEmployeeComponent } from './components/form-employee/form-employee.component';
import { EditComponent } from './pages/edit/edit.component';
import { DetailsComponent } from './pages/details/details.component';
import { DeleteEmployeeComponent } from './components/delete-employee/delete-employee.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsModalService } from 'ngx-bootstrap/modal';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegisterComponent,
    FormEmployeeComponent,
    EditComponent,
    DetailsComponent,
    DeleteEmployeeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatDialogModule,
  ],
  providers: [
    provideClientHydration(),
    provideHttpClient(withFetch()),
    BsModalService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
