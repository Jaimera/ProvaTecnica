import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { Router } from '@angular/router';
import { TecnologiaService } from '../../services/app.tecnologia.service';
import { Tecnologia } from '../../models/Tecnologia';

@Component({
  selector: 'app-tecnologia',
  templateUrl: './tecnologias.component.html',
  styleUrls: ['./tecnologias.component.css']
})
export class TecnologiasComponent implements OnInit {

  public tecnologias: Tecnologia[] = [];
  public nome: string;

  public tecnologiaEdicao: Tecnologia;

  constructor(private router: Router,
    private tecnologiaSvc: TecnologiaService) { }

  ngOnInit() {
    this.listar();
  }

  private listar() {
    this.tecnologiaSvc.get().then(tecnologias => {
      this.tecnologias = tecnologias;
    });
  }

  adicionar() {
    this.tecnologiaSvc.post(this.nome).then(resp => {
      var tecnologia = new Tecnologia();

      tecnologia.id = resp;
      tecnologia.nome = this.nome;

      this.tecnologias.push(tecnologia);

      this.nome = "";
    });
  }

  atualizar() {
    this.tecnologiaSvc.put(this.tecnologiaEdicao.id, this.nome).then(resp => {
      this.tecnologiaEdicao.nome = this.nome;
      this.nome = '';
      this.tecnologiaEdicao = null;
    });
  }

  editar(tec: Tecnologia) {
    this.tecnologiaEdicao = tec;
    this.nome = tec.nome;
  }

  remover(id: string) {
    this.tecnologiaSvc.delete(id).then(resp => {
      this.listar();
    });
  }
}
