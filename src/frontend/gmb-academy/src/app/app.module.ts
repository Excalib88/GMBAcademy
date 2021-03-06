import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatButtonModule, MatFormFieldModule, MatInputModule } from '@angular/material';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/header/header.component';
import { MiddleComponent } from './components/middle/middle.component';
import { FooterComponent } from './components/footer/footer.component';
import { RegistrationFormComponent } from './components/registration-form/registration-form.component';
import { WorkComponent } from './work/work.component';
import { HeroesComponent } from './heroes/heroes.component';
import { WorksComponent } from './components/works/works.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MiddleComponent,
    FooterComponent,
    RegistrationFormComponent,
    WorkComponent,
    HeroesComponent,
    WorksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
