import {Component, OnInit} from '@angular/core';
import {HttpService} from "../../services/http.service";
import {MatDialog} from "@angular/material/dialog";
import {NewBoxPopupComponent} from "../newBoxPopup/new-box-popup/new-box-popup.component";
import {UpdateBoxPopupComponent} from "../updateBoxPopup/update-box-popup/update-box-popup.component";


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
  contents: string = "(Empty box)";
  xWidth: number = 0;
  zHeight: number = 0;
  yLength: number = 0;
  weight: number = 0;

  volume: number = 0;
  density: number = 0;

  boxes: any[] = [];


  async ngOnInit() {
    this.boxes = await this.http.getBoxes();
  }

  openNewBoxDialogue() {
    let dialogueRef = this.dialogue.open(NewBoxPopupComponent, {
      data: {
        boxes: this.boxes
      }
    });

    dialogueRef.afterClosed().subscribe(result => {
      console.log("Dialogue closed");
      if (result != null) {
        this.boxes.push(result);
      }
      });
    }


    openEditBoxDialogue(box: any) {
    let dialogueRef = this.dialogue.open(UpdateBoxPopupComponent, {
      data: {
        boxes: this.boxes,
        box: box
      }
    });

    dialogueRef.afterClosed().subscribe(result => {
      console.log("Dialogue closed");
      if (result != null) {
        this.boxes[this.boxes.findIndex(box => box.id == result.id)] = result;
      }
    });
  }


  async createDTO() {
    let dto = {
      id: 0,
      contents: this.contents,
      xWidth: this.xWidth,
      zHeight: this.zHeight,
      yLength: this.yLength,
      weight: this.weight
    }
    return dto;
  }


  calculateVolume(box: any) : number {
    let volume = box.xWidth * box.yLength * box.zHeight;
    return volume;
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
