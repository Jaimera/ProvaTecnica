import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpModule, Headers, RequestOptions } from '@angular/http';

import { APP_ROUTES } from './routes/app.routes';
import { AppComponent } from './app.component';
import { CustomPreloadingStrategy } from './helpers/preoload.strategy';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(APP_ROUTES, { preloadingStrategy: CustomPreloadingStrategy }),
    NgbModule.forRoot(),
    HttpModule
  ],
  providers: [CustomPreloadingStrategy],
  bootstrap: [AppComponent]
})
export class AppModule { }
