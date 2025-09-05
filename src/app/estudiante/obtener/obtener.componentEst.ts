import { Component, OnInit } from '@angular/core';
import { ServicioEstudiante} from '../../servicios/Estudiante.Servicio'
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-obtener',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './obtener.component.html',
  styles: ``
})
export class ObtenerComponentEst implements OnInit{
  estudiantes: any[] = []

  constructor (private estudiantesr :ServicioEstudiante ){}

  ngOnInit(): void {
    this.estudiantesr.ObtenerEst().subscribe({
      next : (res) => {
        console.log("Estudiantes: ", res)
        this.estudiantes = res;
      },
      error: (err) => {
      console.error("Error al obtener los estudiantes", err)
    }
    },
)
  }

}
