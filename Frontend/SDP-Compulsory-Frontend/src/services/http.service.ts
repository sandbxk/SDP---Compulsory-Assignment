import { Injectable } from '@angular/core';
import axios from "axios";
import {catchError} from "rxjs";
import {MatSnackBar} from "@angular/material/snack-bar";

export const axiosConfig = axios.create({
  baseURL: 'https://localhost:7069/'
});

@Injectable({
  providedIn: 'root'
})


export class HttpService {

  constructor(private matSnackbar: MatSnackBar) {
    axiosConfig.interceptors.response.use(
      response => {
        if(response.status==201) {
          this.matSnackbar.open("Great success")
        }
        return response;
      }, rejected => {
        if(rejected.response.status >=400 && rejected.response.status <500) {
          matSnackbar.open(rejected.response.data);
        }
        else if (rejected.response.status>499) {
          this.matSnackbar.open("Something went wrong")
        }
        catchError(rejected);
      }
    )
  }

  async getBoxes() {
    const httpResponse = await axiosConfig.get<any>('Box');
    return httpResponse.data;
  }

  async createBox(dto: { contents: string; xWidth: number; zHeight: number; yLength: number; weight: number; }) {
    const httpResult = await axiosConfig.post('box', dto);
    return httpResult.data;
  }

  async deleteProduct(id: any) {
    const httpsResult = await axiosConfig.delete('box/' + id);
    return httpsResult.data;
  }

  async updateProduct(id: any, dto: {contents: string; xWidth: number; zHeight: number; yLength: number; weight: number; }) {
    const httpsResult = await axiosConfig.put('box/'+id, dto);
    return httpsResult.data;
  }

}
