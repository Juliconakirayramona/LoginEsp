import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {environment} from '../../enviroments/enviroment.development'
import { Observable } from 'rxjs';

@Injectable ({
    providedIn: 'root'
})

export class ServicioMaterias{

    private url = environment.apiURL

    constructor (private http : HttpClient ){}

    AgregarM(materia : any) : Observable <any>{
        return this.http.post( `${this.url}/api/materia/agregarM`, materia)
    }
    ObtenerM(): Observable <any> {
        return this.http.get(`${this.url}/api/materia/obtenerM`)
    }
    
}