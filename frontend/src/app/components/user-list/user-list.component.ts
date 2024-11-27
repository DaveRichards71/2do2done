import { Component, inject, OnInit, signal } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';


@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit {
  userService = inject(UserService);
  users = signal<Array<User>>([]);



  ngOnInit(): void {
    this.userService
      .getUsers()
      .subscribe((users) => {
        this.users.set(users);
      });
  }
}
