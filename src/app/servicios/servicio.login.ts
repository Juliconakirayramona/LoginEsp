import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../../enviroments/enviroment.development'
import { Observable } from 'rxjs';

@Injectable ({
    providedIn : 'root'

})

export class servicioAu {
    private url = environment.apiURL

    constructor (private http: HttpClient){}

    login(credentials: {Usuario: string, Password: string}) : Observable<any>{
        return this.http.post(`${this.url}/api/User/login`,credentials );
    }



}