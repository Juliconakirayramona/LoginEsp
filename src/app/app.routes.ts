import { Routes } from '@angular/router';
import {LoginComponent} from './login/login.component'
import {LoginacComponent} from './loginac/loginac.component'
import {AgregarComponentEst } from './estudiante/agregar/agregar.componentEst'
import {ObtenerComponentEst} from './estudiante/obtener/obtener.componentEst'
import {AgregarComponentM} from './materia/agregar/agregar.component'
import {ObtenerComponentM} from './materia/obtener/obtener.component'
import {PromedioComponent} from './materia/promedio/promedio.component'

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'contenido', component: LoginacComponent },
  { path : 'agg', component: AgregarComponentEst },
  { path : 'obb', component :ObtenerComponentEst },
  { path: 'aggm', component : AgregarComponentM},
  { path : 'obbm', component : ObtenerComponentM },
  { path : 'promedio', component :PromedioComponent }
];
