import { Component } from '@angular/core';
import { Router, ActivatedRoute  } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../user';

@Component({
    templateUrl: './user-form.component.html'
})
export class UserFormComponent {

    id: number;
    user: User = new User();
    loaded: boolean = false;

    constructor(private userService: UserService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.userService.getUser(this.id)
                .subscribe((data: User) => {
                    this.user = data;
                    if (this.user != null) this.loaded = true;
                });
    }

    save() {
        if (this.id) {
            this.userService.updateUser(this.user).subscribe(data => this.router.navigateByUrl("/UserList"));
        }
        else {
            this.userService.createUser(this.user).subscribe(data => this.router.navigateByUrl("/UserList"));
        }
    }
}
