import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { Vaga } from '../models/Vaga';


@Injectable()
export class VagaService {

  private endPoint = 'http://localhost:53986/v1/vagas';

  constructor(private http: Http) {

  }

  get(): Promise<Vaga[]> {

    return this.http.get(this.endPoint, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as Vaga[])
      .catch(this.handleError);
  }

  getById(id: string): Promise<Vaga> {
    let url = this.endPoint + '/' + id;

    return this.http.get(url, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as Vaga[])
      .catch(this.handleError);
  }

  post(nome: string): Promise<string> {

    var data = JSON.stringify(nome)
    return this.http.post(this.endPoint, data, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as string)
      .catch(this.handleError);
  }

  put(id: string, nome: string): Promise<boolean> {
    let url = this.endPoint + '/' + id;

    var data = JSON.stringify(nome)
    return this.http.put(url, data, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as boolean)
      .catch(this.handleError);
  }

  delete(id: string): Promise<boolean> {
    let url = this.endPoint + '/' + id;

    return this.http.delete(url, this.getHeader())
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
