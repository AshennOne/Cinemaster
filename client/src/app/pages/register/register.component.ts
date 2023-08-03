import { Component } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  registerForm = this.CreateForm();

  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router
  ) {}
  CreateForm() {
    return new FormGroup(
      {
        userName: new FormControl('', [
          Validators.required,
          Validators.maxLength(18),
          Validators.minLength(4),
        ]),
        password: new FormControl('', [
          Validators.required,
          Validators.maxLength(25),
          Validators.minLength(6),
          this.containsNumber,
        ]),
        email: new FormControl('', [
          Validators.required,
          Validators.email,
          Validators.minLength(6),
        ]),
        confirmPassword: new FormControl('', [Validators.required]),
      },
      { validators: this.passwordMatchValidator }
    );
  }

  passwordMatchValidator(control: AbstractControl) {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    if (password !== confirmPassword) {
      control.get('confirmPassword')?.setErrors({ passwordMismatch: true });
    } else {
      control.get('confirmPassword')?.setErrors(null);
    }

    return null;
  }
  redirect() {
    this.router.navigateByUrl('/');
  }
  onSubmit() {
    var user = this.createRegisterObj();
    this.accountService.register(user).subscribe({
      next: (res) => {
        if (res.token) {
          this.accountService.setToken(res.token);
          this.toastr.success('successfuly registered');
          this.router.navigateByUrl('/movies');
        }
      },
      error: (err) => this.toastr.error(err),
    });
  }
  createRegisterObj(): User {
    return {
      userName: this.registerForm.get('userName')?.value,
      email: this.registerForm.get('email')?.value,
      password: this.registerForm.get('password')?.value,
    } as User;
  }
  containsNumber(control: AbstractControl) {
    const password = control.value;
    if (!/\d/.test(password)) {
      return { noNumber: true };
    }
    return null;
  }
}
