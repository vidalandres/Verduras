import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
//import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppRoutingModule } from './app-routing.module';
import { RecordComponent } from './verduras/record/record.component';
import { SearchComponent } from './verduras/search/search.component';
import { VerduraPipe } from './pipes/verdura.pipe';
import { EditComponent } from './verduras/edit/edit.component';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { SellComponent } from './verduras/sell/sell.component';
import { SoldComponent } from './verduras/sold/sold.component';
import { LoginComponent } from './login/login.component';
import { JwtInterceptor } from './services/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RecordComponent,
    SearchComponent,
    VerduraPipe,
    EditComponent,
    AlertModalComponent,
    SellComponent,
    SoldComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgbModule
  ],
  entryComponents:[AlertModalComponent],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass:JwtInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
