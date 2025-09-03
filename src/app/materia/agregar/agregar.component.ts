import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import {ServicioMaterias} from '../../servicios/Materias.Servicio'
import { CommonModule } from '@angular/common';
import {ToastService} from '../../servicios/Toast.Servicio'

@Component({
  selector: 'app-agregar',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './agregar.component.html',
  styles: ``
})
export class AgregarComponentM {
  Nombre : string = '';
  Nota = '';
 EstudianteId= '';
  mensaje : string = '';
  toastVisible: boolean = false;

    constructor(
      private servicioM: ServicioMaterias,
      public toast : ToastService){}
  AgregarMateria (){
    const nuevaM = {
      nombre : this.Nombre,
      nota : this.Nota,
      EstudianteId : this.EstudianteId
    }

    this.servicioM.AgregarM(nuevaM).subscribe({
      next : (res) => {
        console.log("Nueva Materia inscrita", res)
        this.toastVisible = true;
        this.toast.mostrar(`Materia Agregada`, 'success');
      },
      error : err => {
        console.log ("No se ha podido inscribir la materia", err)
        this.mensaje = "Hubo un error al agregarlo"
      }
    })
  }



}
