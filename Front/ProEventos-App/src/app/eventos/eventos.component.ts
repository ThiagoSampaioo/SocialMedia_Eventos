
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos : any = [];
  public eventosFiltrados : any =[];
    widthImg: number=150;
  marginImg: number= 2;
  viewImg : boolean = true;
  private _filterList: string = '';

  public get filterList(): string{
    return this._filterList
  }
  public set filterList(value:string){
    this._filterList= value;
    this.eventosFiltrados = this.filterList ? this.filterEvent(this.filterList) : this.eventos;
  }


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.geteventos();
  }
  handleViewImg (){
    this.viewImg = !this.viewImg;
  }
  filterEvent(FiltrarPor: string): any{
    FiltrarPor = FiltrarPor.toLocaleLowerCase();
   return this.eventos.filter(
     (  evento: { tema: string,  local: string} )=>
     evento.tema.toLocaleLowerCase().indexOf(FiltrarPor) !== -1
     ||
     evento.local.toLocaleLowerCase().indexOf(FiltrarPor) !== -1

    )
  }
  public geteventos () : any{
    this.http.get('https://localhost:7236/api/eventos').subscribe(
      res => {
        this.eventos = res;
        this.eventosFiltrados=this.eventos;
      },
      error => console.log(error),
    );


  }

}
