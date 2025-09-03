import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, Router } from '@angular/router';
import {ServicioPromedio} from '../../servicios/Promedio.Servicio'
import { FormsModule } from '@angular/forms';
import {ToastService} from '../../servicios/Toast.Servicio'

@Component({
  selector: 'app-promedio',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './promedio.component.html',
  styles: ``
})
export class PromedioComponent implements OnInit{
  estuid : number = 0;
  promedios : number | null = null;
  error : string = '';
  estudiantes: { id: number; nombre: string }[] = [];
  constructor(private Promedios: ServicioPromedio,
    public toast : ToastService
  ) {}
ngOnInit(): void {
  this.Promedios.ObtenerEst().subscribe({
next: (res) => {
      this.estudiantes = res;
      console.log('Estudiantes:', res);
    },
    error: (err) => {
      console.error('Error al obtener estudiantes', err);  
    }
  })
}
  ConsultarP(){
    this.promedios= null;
    this.error = ''

    if (!this.estuid){
      this.error = "Ingrese un ID valido";
      return
    }

    this.Promedios.Promedio(this.estuid).subscribe({
      next: (res) => {
        this.promedios = res.promedio;
        this.toast.mostrar(`📊 Promedio: ${this.promedios}`, 'success');
      },
      error: (err) => {
        this.error = 'No se pudo obtener el promedio.';
        console.error(err);
        this.toast.mostrar("Error al obtener promedio", 'error');
      }
    })
  }

  
  }


