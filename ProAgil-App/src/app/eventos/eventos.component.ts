import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  _filter_list: string;

  get filterList() {
    return this._filter_list;
  }

  set filterList(value: string) {
    this._filter_list = value;
    this.eventosFiltrados = this.filterList ? this.filtrarEvento(this.filterList) : this.eventos;
  }

  eventosFiltrados: any = [];
  eventos: any = [];
  imgWidth = 50;
  imgMargin = 2;
  showImg = false;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  filtrarEvento(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  alternarImg() {
    this.showImg = !this.showImg;
  }
  getEventos() {
    this.http.get('http://localhost:5000/evento').subscribe(
      response => {
        this.eventos = response;
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }

}
