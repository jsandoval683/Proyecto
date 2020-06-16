import { Component, OnInit } from '@angular/core';
import { Signup } from '../models/signup.model';
import { AuthService } from '../services/auth.service';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  // loginUser(event) {
  //   event.preventDefault()
  //   const target = event.target
  //   var user: Login = new Login();
  //   user.email = target.querySelector('#email').value
  //   user.password = target.querySelector('#password').value
  //   this.auth.loginUser(user)
    
  // }

}
