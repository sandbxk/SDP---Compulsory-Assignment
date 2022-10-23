import { Component, OnInit } from '@angular/core';
import {BoxEntity} from "../core/boxEntity";

@Component({
  selector: 'app-box',
  templateUrl: './box.component.html',
  styleUrls: ['./box.component.scss']
})
export class BoxComponent implements OnInit {

  constructor() { }

  id: number = -1;
  contents: string = "";
  xWidth: number = 0;
  yLength: number = 0;
  zHeight: number = 0;
  weight: number = 0;

  volume: number = 0;
  density: number = 0;

  boxes: any[] = [];


  ngOnInit(): void {
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
  }


  calculateVolume() {
    this.volume = this.xWidth * this.yLength * this.zHeight;
  }

  calculateDensity() {
    this.density = this.volume / this.weight;
  }

}
