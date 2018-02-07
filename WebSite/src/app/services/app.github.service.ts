import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { User } from '../models/User';
import { Detail } from '../models/Detail';
import { Repository } from '../models/Repository';

@Injectable()
export class GitHubService {


  constructor(private http: Http) {
    
  }

  getHeader(): RequestOptions {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    return options;
  }

  getUsers(): Promise<User[]> {
    
    let url = 'https://api.github.com/users'

    return this.http.get(url, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as User[])
      .catch(this.handleError);
  }

  getUserByName(username: string): Promise<Detail> {

    let url = 'https://api.github.com/users/' + username;

    return this.http.get(url, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as Detail)
      .catch(this.handleError);
  }

  getReposByUser(username: string): Promise<Repository[]> {

    let url = 'https://api.github.com/users/' + username + '/repos';
    
    return this.http.get(url, this.getHeader())
      .toPromise()
      .then(resp => resp.json() as Repository[])
      .catch(this.handleError);
  }

  handleError(error) {
    console.log(error);
    return null;
  }

}
