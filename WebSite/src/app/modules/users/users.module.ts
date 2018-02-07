import { NgModule, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, NavigationEnd, RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { GitHubService } from '../../services/app.github.service';
import { UsersComponent } from './users.component';
import { DetailsComponent } from './details/details.component';
import { OverviewComponent } from './overview/overview.component';
import { RepositoryComponent } from './repository/repository.component';
import { USER_ROUTES } from '../../routes/users.routes';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(USER_ROUTES),
    NgbModule.forRoot()
  ],
  providers: [GitHubService],
  declarations: [
    UsersComponent,
    DetailsComponent,
    OverviewComponent,
    RepositoryComponent
  ],
  exports: [

  ]
})
  
export class UsersModule {

}
