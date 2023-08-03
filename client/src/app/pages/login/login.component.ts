import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  registerForm = this.CreateForm();

  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router
  ) {}
  CreateForm() {
    return new FormGroup({
      userName: new FormControl('', [
        Validators.required,
        Validators.maxLength(18),
        Validators.minLength(4),
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.maxLength(25),
        Validators.minLength(6),
      ]),
    });
  }
  redirect() {
    this.router.navigateByUrl('/');
  }
  onSubmit() {
    var user = this.createLoginObj();
    this.accountService.login(user).subscribe({
      next: (res) => {
        if (res.token) {
          this.accountService.setToken(res.token);
          this.toastr.success('successfuly logged');
          this.accountService.getToken != null;
          this.router.navigateByUrl('/movies');
          
        }
      },
      error: (err) => this.toastr.error(err),
    });
  }
  createLoginObj(): User {
    return {
      userName: this.registerForm.get('userName')?.value,
      password: this.registerForm.get('password')?.value,
    } as User;
  }
}
