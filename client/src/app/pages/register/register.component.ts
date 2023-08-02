import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/User';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm = this.CreateForm();

  constructor(private userService:UserService, private toastr:ToastrService, private router:Router){

  }
  CreateForm() {
    return new FormGroup({
      userName: new FormControl('', [
        Validators.required,
        Validators.maxLength(15),
        Validators.minLength(4),
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(6),
      ]),
      email: new FormControl('', [
        Validators.required,
        Validators.email,
        Validators.minLength(6),
      ]),
      confirmPassword: new FormControl('', [Validators.required]),
    }, { validators: this.passwordMatchValidator });
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
  onSubmit(){
    this.userService.register(this.createRegisterObj()).subscribe({
      next: () => this.userService.toggleLoggedIn(),
      error: (err) => this.toastr.error(err.message)
    })
  }
  createRegisterObj(): User {
    return {
      userName: this.registerForm.get('userName')?.value,
      email: this.registerForm.get('email')?.value,
      password: this.registerForm.get('password')?.value
    } as User;
  }
}
