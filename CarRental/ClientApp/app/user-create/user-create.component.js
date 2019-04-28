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
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../user';
var UserCreateComponent = /** @class */ (function () {
    function UserCreateComponent(userService, router) {
        this.userService = userService;
        this.router = router;
        this.user = new User(); // добавляемый объект
    }
    UserCreateComponent.prototype.save = function () {
        var _this = this;
        this.userService.createUser(this.user).subscribe(function (data) { return _this.router.navigateByUrl("/UserList"); });
    };
    UserCreateComponent = __decorate([
        Component({
            templateUrl: './user-create.component.html'
        }),
        __metadata("design:paramtypes", [UserService, Router])
    ], UserCreateComponent);
    return UserCreateComponent;
}());
export { UserCreateComponent };
//# sourceMappingURL=user-create.component.js.map