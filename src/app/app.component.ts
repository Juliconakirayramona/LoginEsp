import { Component, inject,OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import {ToastComponent} from './toast/toast.component'
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ FormsModule, RouterOutlet,ToastComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent{
  message: string = '';


  }

