import { Routes } from "@angular/router";
import { DetailsComponent } from "../modules/users/details/details.component";
import { OverviewComponent } from "../modules/users/overview/overview.component";
import { RepositoryComponent } from "../modules/users/repository/repository.component";
import { UsersComponent } from "../modules/users/users.component";

export const USER_ROUTES: Routes = [
  {
    path: '',
    component: UsersComponent
  },
  {
    path: ':username',
    component: DetailsComponent
  }
]
