import { NgModule, Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, NavigationEnd, RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { SelecoesComponent } from './selecoes.component';
import { CandidatoService } from '../../services/app.candidato.service';
import { VagaService } from '../../services/app.vaga.service';
import { TecnologiaService } from '../../services/app.tecnologia.service';
import { SelecaoService } from '../../services/app.selecao.service';

const ROUTES: Routes = [
  {
    path: '',
    component: SelecoesComponent
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ROUTES),
    NgbModule.forRoot(),
    FormsModule
  ],
  providers: [CandidatoService, VagaService, TecnologiaService, SelecaoService],
  declarations: [
    SelecoesComponent,
  ],
  exports: [

  ]
})
  
export class SelecoesModule {

}
