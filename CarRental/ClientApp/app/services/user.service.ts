import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../user';

@Injectable()
export class UserService {

    private userUrl = "/api/users";

    constructor(private http: HttpClient) {
    }

    // методы для работы с пользователем
    getUsers() {
        return this.http.get(this.userUrl);
    }

    getUsersWithUniqueFirstnames() {
        return this.http.get(this.userUrl + '/' + encodeURIComponent('UniqueFirstName'));
    }

    getUser(id: number) {
        return this.http.get(this.userUrl + '/' + id);
    }

    createUser(user: User) {
        return this.http.post(this.userUrl, user);
    }

    updateUser(user: User) {
        return this.http.put(this.userUrl + '/' + user.id, user);
    }

    deleteUser(id: number) {
        return this.http.delete(this.userUrl + '/' + id);
    }
}