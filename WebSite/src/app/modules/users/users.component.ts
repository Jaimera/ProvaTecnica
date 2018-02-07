import { Component, OnInit } from '@angular/core';
import { GitHubService } from '../../services/app.github.service';
import { User } from '../../models/User';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  public users: User[];

  constructor(private router: Router,
              private gitHubSvc: GitHubService) { }

  ngOnInit() {
    this.gitHubSvc.getUsers().then(users => {
      this.users = users;
    });
  }
}
