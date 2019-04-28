﻿import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../user';

@Component({
    templateUrl: './user-edit.component.html'
})
export class UserEditComponent implements OnInit {

    id: number;
    user: User;    // изменяемый объект
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
        this.userService.updateUser(this.user).subscribe(data => this.router.navigateByUrl("/"));
    }
}