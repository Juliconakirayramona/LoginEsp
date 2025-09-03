import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {environment} from '../../enviroments/enviroment.development'
import { Observable } from 'rxjs';

@Injectable ({
    providedIn : 'root'
})
export class ServicioPromedio{
    private url = environment.apiURL

    constructor (private http: HttpClient){}

       Promedio(estuid : number): Observable<any> {
        return this.http.get<number>(`${this.url}/api/materia/promedio/${estuid}`)
    }
        ObtenerEst(): Observable<any> {
        return this.http.get(`${this.url}/api/estudiante/obtener`)
    }
}