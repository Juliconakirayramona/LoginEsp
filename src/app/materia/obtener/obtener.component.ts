import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ServicioMaterias} from '../../servicios/Materias.Servicio'

@Component({
  selector: 'app-obtenerM',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './obtener.component.html',
  styles: ``
})
export class ObtenerComponentM implements OnInit{
  materias : any [] = [];


  constructor (private materiasM : ServicioMaterias){}
  ngOnInit(): void {
    this.materiasM.ObtenerM().subscribe({
      next  : (res) => {
        console.log("Materias encontradas", res),
        this.materias = res
      },
      error : err =>{
        console.log ("Error, no hay materias", err)
      }
    })
  }
}
