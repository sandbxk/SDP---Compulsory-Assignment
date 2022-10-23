import {Box} from "./boxEntity";

export class BOXES {

  public static getBoxes(): Box[] {
    return [new Box(1, "Box 1", 1, 1, 1), new Box(2, "Box 2", 2, 2, 2), new Box(3, "Box 3", 3, 3, 3)];
  }

}
