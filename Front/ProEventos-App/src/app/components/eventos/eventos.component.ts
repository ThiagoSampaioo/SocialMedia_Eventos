
import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../../services/evento.service';
import { Evento } from '../../model/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  public eventos : Evento[] = [];
  public eventosFiltrados : Evento[] =[];
  public widthImg = 150;
  public marginImg = 2;
  public viewImg = true;
  private filterListado: string = '';

  public get filterList(): string{
    return this.filterListado
  }
  public set filterList(value:string){
    this.filterListado= value;
    this.eventosFiltrados = this.filterList ? this.filterEvent(this.filterList) : this.eventos;
  }


  public filterEvent(FiltrarPor: string): Evento[]{
    FiltrarPor = FiltrarPor.toLocaleLowerCase();
   return this.eventos.filter(
     (  evento: { tema: string,  local: string} )=>
     evento.tema.toLocaleLowerCase().indexOf(FiltrarPor) !== -1
     ||
     evento.local.toLocaleLowerCase().indexOf(FiltrarPor) !== -1

    );
  }
  constructor(
    private eventoService: EventoService,
     private modalService: BsModalService,
     private toastr: ToastrService,
     private spinner: NgxSpinnerService) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
      /** spinner starts on init */

      // setTimeout(() => {
      //   /** spinner ends after 5 seconds */
      //  // this.spinner.hide();
      // }, 2000);
  }
  public handleViewImg (): void{
    this.viewImg = !this.viewImg;
  }

  public getEventos (): void{
    const observer = {
      next: (eventos : Evento[])=> {
        this.eventos = eventos;
        this.eventosFiltrados=this.eventos;
      },
      error: (error:any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar.', 'Error!');
      },
      complete: () => this.spinner.hide(),
    }
    this.eventoService.getEventos().subscribe(observer);

      // (eventos : Evento[]) => {
      //   this.eventos = eventos;
      //   this.eventosFiltrados=this.eventos;
      // },
      // error => console.log(error),
    //);


  }
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O Evento foi deletado com sucesso.', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
