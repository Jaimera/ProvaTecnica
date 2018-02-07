import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { Router } from '@angular/router';
import { CandidatoService } from '../../services/app.candidato.service';
import { TecnologiaService } from '../../services/app.tecnologia.service';
import { VagaService } from '../../services/app.vaga.service';
import { Candidato } from '../../models/Candidato';
import { Vaga } from '../../models/Vaga';
import { Tecnologia } from '../../models/Tecnologia';

@Component({
  selector: 'app-entrevista',
  templateUrl: './entrevistas.component.html',
  styleUrls: ['./entrevistas.component.css']
})
export class EntrevistasComponent implements OnInit {

  public candidatos: Candidato[] = [];
  public vagas: Vaga[] = [];
  public tecnologias: Tecnologia[] = [];
  public nome: string;
  public vagaSelecionada: Vaga = null;

  public candidatoEdicao: Candidato;

  constructor(private router: Router,
    private candidatoSvc: CandidatoService,
    private vagaSvc: VagaService,
    private tecnologiaSvc: TecnologiaService) { }

  ngOnInit() {
    this.listar();
  }

  private listar() {
    this.candidatoSvc.get().then(candidatos => {
      this.candidatos = candidatos;
    });
    this.vagaSvc.get().then(vagas => {
      this.vagas = vagas;
    });
    this.tecnologiaSvc.get().then(tecnologias => {
      tecnologias.forEach(ea => {
        ea.selecionado = false;
        this.tecnologias.push(ea);
      })
    });
  }

  adicionar() {
    if (this.nome == "") {
      alert("Por favor, preencher o nome do candidato");
      return;
    }
    if (this.vagaSelecionada == null) {
      alert("Por favor, selecionar a vaga para o candidato");
      return;
    }
    if (!this.tecnologias.some(s => s.selecionado)) {
      alert("Selecione ao menos uma tecnologia");
      return;
    }

    this.candidatoSvc.post(this.nome, this.vagaSelecionada.id).then(resp => {
      this.candidatoSvc.postTecnologias(resp, this.tecnologias.filter(f => f.selecionado).map(m => m.id)).then(r => {
        this.tecnologias.forEach(ea => {
          ea.selecionado = false;
        })
      });

      this.candidatoSvc.get().then(candidatos => {
        this.candidatos = candidatos;
      });

      this.nome = "";
      this.vagaSelecionada = null;
    });
  }

  atualizar() {
    this.candidatoSvc.put(this.candidatoEdicao.id, this.nome).then(resp => {
      this.candidatoEdicao.nome = this.nome;
      this.nome = '';
      this.candidatoEdicao = null;
    });
  }

  editar(can: Candidato) {
    this.candidatoEdicao = can;
    this.nome = can.nome;
  }
}
