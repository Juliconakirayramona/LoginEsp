import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {environment} from '../../enviroments/enviroment.development'
import { Observable } from 'rxjs';

@Injectable ({
    providedIn: 'root'
})

export class ServicioEstudiante {
    private url = environment.apiURL
    toastVisible: boolean = false;

    constructor (private http: HttpClient){}

    AgregarEst(estudiante : any) : Observable <any> {
        return this.http.post (`${this.url}/api/estudiante/agregar`, estudiante)
    }
    ObtenerEst(): Observable<any> {
        return this.http.get(`${this.url}/api/estudiante/obtener`)
    }

}