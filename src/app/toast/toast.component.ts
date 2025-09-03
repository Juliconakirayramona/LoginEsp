import { Component } from '@angular/core';
import {ToastService } from '../servicios/Toast.Servicio'
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-toast',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './toast.component.html',
  styles: ``
})
export class ToastComponent {
  constructor (public toast : ToastService){}
}
