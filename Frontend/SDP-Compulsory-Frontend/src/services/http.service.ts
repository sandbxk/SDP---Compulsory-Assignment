import { Injectable } from '@angular/core';
import axios from "axios";

export const axiosConfig = axios.create({
  baseURL: 'http://localhost:5069/box'
});

@Injectable({
  providedIn: 'root'
})


export class HttpService {

  constructor() { }


}
