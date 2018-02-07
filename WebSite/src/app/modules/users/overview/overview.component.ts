import { Component, OnInit, Input } from '@angular/core';

import { Detail } from '../../../models/Detail';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {

  @Input()
  private detail: Detail; 

  constructor() { }

  ngOnInit() {
  }
}
