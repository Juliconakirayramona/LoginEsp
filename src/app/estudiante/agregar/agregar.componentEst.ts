import { Component } from '@angular/core';
import {ServicioEstudiante} from '../../servicios/Estudiante.Servicio'
import { FormsModule } from '@angular/forms'; 
import { CommonModule } from '@angular/common';
import {ToastService} from '../../servicios/Toast.Servicio'

@Component({
  selector: 'app-agregar',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './agregar.component.html',
  styles: ``
})

export class AgregarComponentEst {
nombre : string = '';
toastVisible: boolean = false;

  constructor(
    private servicioest: ServicioEstudiante,
    public toast : ToastService){}

  agregar(){
      const nuevoest = {
        nombre : this.nombre
      }
    
    this.servicioest.AgregarEst(nuevoest).subscribe({
      
      next : (res) =>   {
          console.log("Estudiante agregado", res)
          this.toastVisible = true;
          this.toast.mostrar(`Estudiante Agregado`, 'success');
      }
      ,
      error: err => console.log("No se pudo agregar el estudiante", err)
    })
  }

}
