import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "src/app/components/login/login/login.component";

const loginRoutes: Routes = [
  {
    path: "",
    component: LoginComponent
  },
];
@NgModule({
  imports: [RouterModule.forChild(loginRoutes)],
  exports: [RouterModule],
})
export class LoginRoutingModule {

}
