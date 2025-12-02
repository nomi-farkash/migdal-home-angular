import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { GaragesComponent } from './components/garages/garages.component';

// Angular Material
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule }      from '@angular/material/input';
import { MatSelectModule }     from '@angular/material/select';
import { MatTableModule }      from '@angular/material/table';
import { MatButtonModule }     from '@angular/material/button';
import { MatIconModule }       from '@angular/material/icon';
import { RouterModule, RouterOutlet } from '@angular/router'; 

@NgModule({
  declarations: [
    AppComponent,
    GaragesComponent,
    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,  
    FormsModule,
    HttpClientModule,
    RouterModule, 

    // Material
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }