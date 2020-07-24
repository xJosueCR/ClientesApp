import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { ClienteComponent } from './cliente/cliente.component';

@NgModule({
   declarations: [
      AppComponent,
      ClienteComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule, 
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
