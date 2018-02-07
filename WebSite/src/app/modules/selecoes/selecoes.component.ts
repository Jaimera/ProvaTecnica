import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { Router } from '@angular/router';

import { CandidatoService } from '../../services/app.candidato.service';
import { TecnologiaService } from '../../services/app.tecnologia.service';
import { VagaService } from '../../services/app.vaga.service';
import { SelecaoService } from '../../services/app.selecao.service';

import { Candidato } from '../../models/Candidato';
import { Vaga } from '../../models/Vaga';
import { Tecnologia, TecnologiaPeso } from '../../models/Tecnologia';

@Component({
  selector: 'app-selecao',
  templateUrl: './selecoes.component.html',
  styleUrls: ['./selecoes.component.css']
})
export class SelecoesComponent implements OnInit {

  public candidatos: Candidato[] = [];
  public vagas: Vaga[] = [];
  public tecnologiasPeso: TecnologiaPeso[] = [];

  public nome: string;
  public vagaSelecionada: Vaga = null;

  public candidatoEdicao: Candidato;

  constructor(private router: Router,
    private candidatoSvc: CandidatoService,
    private vagaSvc: VagaService,
    private tecnologiaSvc: TecnologiaService,
    private selecaoSvc: SelecaoService) { }

  ngOnInit() {
    this.listar();
  }

  private listar() {
    this.vagaSvc.get().then(vagas => {
      this.vagas = vagas;
    });
    this.tecnologiaSvc.get().then(tecnologias => {
      tecnologias.forEach(ea => {
        this.tecnologiasPeso.push(ea as TecnologiaPeso);
      })
    });
  }

  listarCandidatos() {
    let promises: Promise<string>[] = [];

    this.selecaoSvc.post(this.vagaSelecionada.id).then(resp => {

      this.tecnologiasPeso.forEach(ea => {
        promises.push(this.selecaoSvc.postPeso(resp, ea.id, ea.peso || 0));
      })

      Promise.all(promises).then(t => {
        this.selecaoSvc.getCandidatosPorPeso(resp).then(cands => {
          this.candidatos = cands;
        });
      });
    })
  }
}
