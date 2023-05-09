
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos : any ;



  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.geteventos();
  }
  public geteventos () : any{
    this.http.get('https://localhost:7236/api/eventos').subscribe(
      res => this.eventos = res,
      error => console.log(error),
    );


  }

}
