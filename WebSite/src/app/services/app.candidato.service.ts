import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Candidato } from '../models/Candidato';

@Injectable()
export class CandidatoService {

  private endPoint = 'http://localhost:53986/v1/candidatos';

  constructor(private http: Http) {

  }

  get(): Promise<Candidato[]> {

    return this.http.get(this.endPoint, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as Candidato[])
      .catch(this.handleError);
  }

  getById(id: string): Promise<Candidato> {
    let url = this.endPoint + '/' + id;

    return this.http.get(url, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as Candidato[])
      .catch(this.handleError);
  }

  post(nome: string, ocupacaoId: string): Promise<string> {

    var data = JSON.stringify({ nome, ocupacaoId });
    return this.http.post(this.endPoint, data, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as string)
      .catch(this.handleError);
  }

  postTecnologias(idCandidato: string, tecnologias: string[]): Promise<string> {

    var url = this.endPoint + '/' + idCandidato + '/tecnologias';
    //var data = JSON.stringify(tecnologias);
    return this.http.post(url, tecnologias, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as string)
      .catch(this.handleError);
  }

  put(id: string, nome: string): Promise<boolean> {
    let url = this.endPoint + '/' + id;

    return this.http.put(url, nome, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as boolean)
      .catch(this.handleError);
  }
  
  private getHeader(): RequestOptions {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    return options;
  }
  
  private handleError(error) {
    console.log(error);
    return null;
  }

}
