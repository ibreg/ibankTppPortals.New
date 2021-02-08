import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

export const appRoutes: Routes = [
  {
    path: "",
    redirectTo: "login",
    pathMatch: "full",
  },
  {
    path: "login",
    loadChildren: () =>
      import(
        "../modules/login/login.module"
      ).then((mod) => mod.LoginModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes, {useHash: true})],
  exports: [RouterModule],
})
export class AppRoutingModule {

}
