import {Component, Inject, OnInit} from '@angular/core';
import {HttpService} from "../../../services/http.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-new-box-popup',
  templateUrl: './new-box-popup.component.html',
  styleUrls: ['./new-box-popup.component.scss']
})
export class NewBoxPopupComponent implements OnInit {

  contents: string = "";
  xWidth: number = 0;
  yLength: number = 0;
  zHeight: number = 0;
  weight: number = 0;

  boxes: any[] = [];

  // https://www.youtube.com/watch?v=FThtv9iorao
  constructor(
    public dialogRef: MatDialogRef<NewBoxPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data : any,
    private http: HttpService
  )
  {
    this.boxes = data.boxes;
  }

  ngOnInit(): void {
  }

  async createBox() {
    const dto = await this.createDTO();
    const box = await this.http.createBox(dto);
    this.boxes.push(box);
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

  close() {
    this.dialogRef.close();
  }
}
