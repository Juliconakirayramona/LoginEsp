import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class ToastService {
    toastVisible : boolean = false;
    toastMensaje : string = '';
    toastColor : 'success' | 'error' = 'success'

    mostrar(mensaje: string, tipo: 'success' | 'error' = 'success') {
        this.toastMensaje = mensaje;
        this.toastColor = tipo;
        this.toastVisible = true;

    setTimeout(() => {
      this.toastVisible = false;
    }, 3000);
    }
}
    