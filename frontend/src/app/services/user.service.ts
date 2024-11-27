import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  http = inject(HttpClient);

  getUsers() {
    const apiUrl = 'https://localhost:7224/users';
    return this.http.get<Array<User>>(apiUrl);
  }
}
