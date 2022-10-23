export class BoxEntity {
  id: number = -1;
  contents: string = "";
  xWidth: number = 0;
  yLength: number = 0;
  zHeight: number = 0;

  volume: number = 0;
  density: number = 0;

  constructor(
    id: number,
    contents: string,
    xWidth: number,
    yLength: number,
    zHeight: number
  )
  {
    this.id = id;
    this.contents = contents;
    this.xWidth = xWidth;
    this.yLength = yLength;
    this.zHeight = zHeight;
    this.calculateVolume();
    this.calculateDensity();
  }

  calculateVolume() {
    this.volume = this.xWidth * this.yLength * this.zHeight;
  }

  calculateDensity() {
    this.density = this.volume / this.zHeight;
  }

}
