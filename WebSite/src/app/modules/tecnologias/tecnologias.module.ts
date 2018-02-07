import { NgModule, Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, NavigationEnd, RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { TecnologiasComponent } from './tecnologias.component';
import { TecnologiaService } from '../../services/app.tecnologia.service';

const ROUTES: Routes = [
  {
    path: '',
    component: TecnologiasComponent
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ROUTES),
    NgbModule.forRoot(),
    FormsModule
  ],
  providers: [TecnologiaService],
  declarations: [
    TecnologiasComponent,
  ],
  exports: [

  ]
})
  
export class TecnologiasModule {

}
