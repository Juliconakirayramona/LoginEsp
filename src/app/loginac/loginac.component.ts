import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { RouterLink, Router } from '@angular/router';


@Component({
  selector: 'app-loginac',
  standalone: true,
  imports: [],
  templateUrl: './loginac.component.html',
  styles: ``
})


@Injectable ({
  providedIn: 'root'
})

export class LoginacComponent {
  constructor(private router: Router) {}

  irAgregar() {
    this.router.navigate(['agg']);
  }
  Obtener(){
    this.router.navigate(['obb'])
  }
  AgregarM(){
    this.router.navigate (['aggm'])
  }
  ObetenerM(){
    this.router.navigate (['obbm'])
  }
  PromedioEst(){
    this.router.navigate (['promedio'])
  }
}
