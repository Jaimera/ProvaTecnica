import { NgModule, Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, NavigationEnd, RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { EntrevistasComponent } from './entrevistas.component';
import { CandidatoService } from '../../services/app.candidato.service';
import { VagaService } from '../../services/app.vaga.service';
import { TecnologiaService } from '../../services/app.tecnologia.service';

const ROUTES: Routes = [
  {
    path: '',
    component: EntrevistasComponent
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ROUTES),
    NgbModule.forRoot(),
    FormsModule
  ],
  providers: [CandidatoService, VagaService, TecnologiaService],
  declarations: [
    EntrevistasComponent,
  ],
  exports: [

  ]
})
  
export class EntrevistasModule {

}
