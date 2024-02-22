import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './pages/register/register.component';
import { HomeComponent } from './pages/home/home.component';
import { EditComponent } from './pages/edit/edit.component';
import { DetailsComponent } from './pages/details/details.component';

const routes: Routes = [
  {path: 'details/:id', component: DetailsComponent},
  {path: 'edit/:id', component: EditComponent},
  {path: 'register', component: RegisterComponent},
  {path: '', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  
 }
