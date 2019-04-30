var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../user';
var UserFormComponent = /** @class */ (function () {
    function UserFormComponent(userService, router, activeRoute) {
        this.userService = userService;
        this.router = router;
        this.user = new User();
        this.loaded = false;
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }
    UserFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        if (this.id)
            this.userService.getUser(this.id)
                .subscribe(function (data) {
                _this.user = data;
                if (_this.user != null)
                    _this.loaded = true;
            });
    };
    UserFormComponent.prototype.save = function () {
        var _this = this;
        if (this.id) {
            this.userService.updateUser(this.user).subscribe(function (data) { return _this.router.navigateByUrl("/UserList"); });
        }
        else {
            this.userService.createUser(this.user).subscribe(function (data) { return _this.router.navigateByUrl("/UserList"); });
        }
    };
    UserFormComponent = __decorate([
        Component({
            templateUrl: './user-form.component.html'
        }),
        __metadata("design:paramtypes", [UserService, Router, ActivatedRoute])
    ], UserFormComponent);
    return UserFormComponent;
}());
export { UserFormComponent };
//# sourceMappingURL=user-form.component.js.map