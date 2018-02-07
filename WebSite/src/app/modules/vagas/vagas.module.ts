import { NgModule, Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, NavigationEnd, RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { VagasComponent } from './vagas.component';
import { VagaService } from '../../services/app.vaga.service';

const ROUTES: Routes = [
  {
    path: '',
    component: VagasComponent
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ROUTES),
    NgbModule.forRoot(),
    FormsModule
  ],
  providers: [VagaService],
  declarations: [
    VagasComponent,
  ],
  exports: [

  ]
})
  
export class VagasModule {

}
