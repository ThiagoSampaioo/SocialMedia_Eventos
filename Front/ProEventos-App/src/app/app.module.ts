import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { NavComponent } from './shared/nav/nav.component';
import { CollapseModule } from 'ngx-bootstrap/collapse'
import { FormsModule } from '@angular/forms';
import { EventoService } from './services/evento.service';
import { DataTimeFormatPipe } from './helpers/DataTimeFormat.pipe';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { TituloComponent } from './shared/titulo/titulo.component';
@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
    ContatosComponent,
    DashboardComponent,
    PerfilComponent,
      NavComponent,
      DataTimeFormatPipe,
      TituloComponent
    ],
    imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      BrowserAnimationsModule,
      FormsModule,
      CollapseModule.forRoot(),
      TooltipModule.forRoot(),
      BsDropdownModule.forRoot(),
      ModalModule.forRoot(),
      ToastrModule.forRoot({
        timeOut: 5000,
        positionClass: 'toast-bottom-right',
        preventDuplicates: true,
        progressBar:true,
      }),
      NgxSpinnerModule

  ],
  providers: [EventoService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
