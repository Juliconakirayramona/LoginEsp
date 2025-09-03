import { Component } from '@angular/core';
import {servicioAu} from '../servicios/servicio.login'
import {NgForm} from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styles: ``
})
export class LoginComponent {
  Usuario = '';
  Password = '';

  constructor (
    private router : Router,
    private servicio : servicioAu) {}
  login (){
    const credentials = {Usuario: this.Usuario, Password : this.Password};

      this.servicio.login(credentials).subscribe({
    next : (res) => {
      this.router.navigate(['contenido'])
      console.log('login exitoso', res)
    },
    error: (err) =>{
      console.error('error', err.error?.message || err.message);
    }
  })
  };



}
