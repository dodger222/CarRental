import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../user';

@Component({
    templateUrl: './user-create.component.html'
})
export class UserCreateComponent {

    user: User = new User();    // добавляемый объект
    constructor(private userService: UserService, private router: Router) { }
    save() {
        this.userService.createUser(this.user).subscribe(data => this.router.navigateByUrl("/UserList"));
    }
}
