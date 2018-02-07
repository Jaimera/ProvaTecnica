import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { CandidatoPeso } from '../models/CandidatoPeso';


@Injectable()
export class SelecaoService {

  private endPoint = 'http://localhost:53986/v1/selecoes';

  constructor(private http: Http) {

  }

  post(vagaId: string): Promise<string> {

    var data = JSON.stringify(vagaId)
    return this.http.post(this.endPoint, data, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as string)
      .catch(this.handleError);
  }

  postPeso(id: string, tecnologiaId: string, peso: number) {

    var url = this.endPoint + '/' + id + '/peso';
    var data = JSON.stringify({ tecnologiaId, peso });

    return this.http.post(url, data, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as string)
      .catch(this.handleError);
  }

  getCandidatosPorPeso(id: string) {
    
    let url = this.endPoint + '/' + id + '/candidatos';

    return this.http.get(url, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as CandidatoPeso[])
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
