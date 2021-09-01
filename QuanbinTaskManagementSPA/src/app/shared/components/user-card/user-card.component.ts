import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Users } from '../../models/user';


@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {

  @Input() user!:Users;
  constructor() { }

  ngOnInit(): void {
  }

}
