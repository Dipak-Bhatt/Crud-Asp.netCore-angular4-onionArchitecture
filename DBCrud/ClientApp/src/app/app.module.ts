import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchTestimonialsComponent } from './fetch-data/fetch-testimonials.component';
import { InsertDataComponent } from './insert/insert-data.component';
import { ApiService } from './sharedServices/api.service';
import { MessageService } from './sharedservices/messageservice';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchTestimonialsComponent,
    InsertDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule, HttpModule,
    FormsModule, ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: FetchTestimonialsComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'insert', component: InsertDataComponent },
      { path: 'edit/:id', component: InsertDataComponent },  
      { path: 'fetch-data', component: FetchTestimonialsComponent }
    ])
  ],
  providers: [
    ApiService,MessageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
