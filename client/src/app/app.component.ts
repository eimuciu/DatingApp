import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Hello World!';

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    // JSON.parse() complains because we are not guaranteed that there is an item in local storage
    // We can switch the safety off by using ! at the end of localStorage.getItem('user')! method like so
    // This switches off the safety since we as developers tell that we know exactly that the item exists
    // const user: User = JSON.parse(localStorage.getItem('user'));

    // Alternative approach is as follow
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
