import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { Router } from '@angular/router';
import { VagaService } from '../../services/app.vaga.service';
import { Vaga } from '../../models/Vaga';

@Component({
  selector: 'app-vaga',
  templateUrl: './vagas.component.html',
  styleUrls: ['./vagas.component.css']
})
export class VagasComponent implements OnInit {

  public vagas: Vaga[] = [];
  public nome: string;

  public vagaEdicao: Vaga;

  constructor(private router: Router,
    private vagaSvc: VagaService) { }

  ngOnInit() {
    this.listar();
  }

  private listar() {
    this.vagaSvc.get().then(vagas => {
      this.vagas = vagas;
    });
  }

  adicionar() {
    this.vagaSvc.post(this.nome).then(resp => {
      var vaga = new Vaga();

      vaga.id = resp;
      vaga.nome = this.nome;

      this.vagas.push(vaga);

      this.nome = "";
    });
  }

  atualizar() {
    this.vagaSvc.put(this.vagaEdicao.id, this.nome).then(resp => {
      this.vagaEdicao.nome = this.nome;
      this.nome = '';
      this.vagaEdicao = null;
    });
  }

  editar(tec: Vaga) {
    this.vagaEdicao = tec;
    this.nome = tec.nome;
  }

  remover(id: string) {
    this.vagaSvc.delete(id).then(resp => {
      this.listar();
    });
  }
}
