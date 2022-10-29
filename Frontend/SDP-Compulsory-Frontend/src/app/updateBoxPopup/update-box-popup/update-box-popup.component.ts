import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {HttpService} from "../../../services/http.service";

@Component({
  selector: 'app-update-box-popup',
  templateUrl: './update-box-popup.component.html',
  styleUrls: ['./update-box-popup.component.scss']
})
export class UpdateBoxPopupComponent implements OnInit {

  id: number = 0;
  contents: string = "";
  xWidth: number = 0;
  yLength: number = 0;
  zHeight: number = 0;
  weight: number = 0;

  boxes: any[] = [];

  // https://www.youtube.com/watch?v=FThtv9iorao
  constructor(
    public dialogRef: MatDialogRef<UpdateBoxPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data : any,
    private http: HttpService
  )
  {
    this.boxes = data.boxes;

    this.id = data.box.id;
    this.contents = data.box.contents;
    this.xWidth = data.box.xWidth;
    this.yLength = data.box.yLength;
    this.zHeight = data.box.zHeight;
    this.weight = data.box.weight;
  }

  ngOnInit(): void {
  }

  async updateBox() {
    const dto = await this.createDTO();
    console.log(dto);
    const box = await this.http.updateProduct(this.id, dto);
    this.dialogRef.close(box);
  }

  async createDTO() {
    let dto = {
      id: this.id,
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
