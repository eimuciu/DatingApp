import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
// *1.1 All commented out fields are commented because observables will be used directly in ng html file provided by ng which will automatically unsubscribe observable upon completion

// *1.2 Removing the line so accountService can be used directly inside html
export class NavComponent implements OnInit {
  model: any = {};
  // *1.2
  // currentUser$: Observable<User | null> = of(null);
  //*1.1
  // loggedIn = false;

  //*1.2 chancing from private to public so accountService can be used directly inside html
  constructor(public accountService: AccountService) {}

  ngOnInit(): void {
    //*1.1
    // this.getCurrentUser();
    //*1.2 Removing the line so accountService can be used directly inside html
    // this.currentUser$ = this.accountService.currentUser$;
  }

  // *1.1
  // getCurrentUser() {
  //   this.accountService.currentUser$.subscribe({
  //     next: (user) => (this.loggedIn = !!user),
  //     error: (error) => console.log(error),
  //   });
  // }

  login() {
    this.accountService.login(this.model).subscribe({
      next: (response) => {
        console.log(response);
        //*1.1
        // this.loggedIn = true;
      },
      error: (error) => console.log(error),
    });
  }

  logout() {
    this.accountService.logout();
    //*1.1
    // this.loggedIn = false;
  }
}
