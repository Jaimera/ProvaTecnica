import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';

import { Detail } from '../../../models/Detail';
import { GitHubService } from '../../../services/app.github.service';
import { Repository } from '../../../models/Repository';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  public detail: Detail;
  public repos: Repository[];
  public showOverview: boolean = true;
  public showRepos: boolean = false;

  constructor(private route: ActivatedRoute,
              private gitHubSvc: GitHubService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.getUser(params.username);
      this.getRepos(params.username);
    })
  }

  getUser(username: string) {
    this.gitHubSvc.getUserByName(username).then(detail => {
      this.detail = detail;
    })
  }

  getRepos(userName: string) {
    this.gitHubSvc.getReposByUser(userName).then(repos => {
      this.repos = repos;
    })
  }

  navOver() {
    this.showOverview = true;
    this.showRepos = false;
  }

  navRepos() {
    this.showRepos = true;
    this.showOverview = false;
  }
}
