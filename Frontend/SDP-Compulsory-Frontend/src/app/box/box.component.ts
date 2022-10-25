import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";
import {catchError} from "rxjs";
import {MatDialog} from "@angular/material/dialog";
import {NewBoxPopupComponent} from "../newBoxPopup/new-box-popup/new-box-popup.component";

@Component({
  selector: 'app-box',
  templateUrl: './box.component.html',
  styleUrls: ['./box.component.scss']
})
export class BoxComponent implements OnInit {

  constructor(
    private http: HttpService,
    private dialogue: MatDialog
    ) { }

  id: number = -1;
  contents: string = "";
  xWidth: number = 0;
  yLength: number = 0;
  zHeight: number = 0;
  weight: number = 0;

  volume: number = 0;
  density: number = 0;

  boxes: any[] = [];


  async ngOnInit() {
    const boxes = await this.http.getBoxes();
    this.boxes = boxes;
  }

  openNewBoxDialogue() {
    this.dialogue.open(NewBoxPopupComponent, {
      data: {
        boxes: this.boxes
      }
    });

    this.dialogue.afterAllClosed.subscribe(() => {
      this.ngOnInit();
      }
    )
  }


  async createDTO() {
    let dto = {
      id: 0,
      contents: this.contents,
      xWidth: this.xWidth,
      yLength: this.yLength,
      zHeight: this.zHeight,
      weight: this.weight
    }
    return dto;
  }


  private calculateVolume() {
    this.volume = this.xWidth * this.yLength * this.zHeight;
  }

  private calculateDensity() {
    this.density = this.volume / this.weight;
  }

  async createBox() {
    const dto = await this.createDTO();
    const box = await this.http.createBox(dto);
    this.boxes.push(box);
  }

  async deleteBox(id: number) {
    await this.http.deleteProduct(id);
    this.boxes = this.boxes.filter(box => box.id != id);
  }

}
