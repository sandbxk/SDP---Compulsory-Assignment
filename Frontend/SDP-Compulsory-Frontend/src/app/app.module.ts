import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BoxComponent } from './box/box.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatInputModule} from "@angular/material/input";
import {MatFormFieldModule} from "@angular/material/form-field";
import {FormsModule} from "@angular/forms";
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatExpansionModule} from "@angular/material/expansion";
import {MatDialogModule} from "@angular/material/dialog";
import { NewBoxPopupComponent } from './newBoxPopup/new-box-popup/new-box-popup.component';
import { UpdateBoxPopupComponent } from './updateBoxPopup/update-box-popup/update-box-popup.component';
import {MatSnackBar} from "@angular/material/snack-bar";

@NgModule({
  declarations: [
    AppComponent,
    BoxComponent,
    NewBoxPopupComponent,
    UpdateBoxPopupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatExpansionModule,
    MatDialogModule
  ],
  providers: [MatSnackBar],
  bootstrap: [AppComponent]
})
export class AppModule { }
