import { Injectable } from '@angular/core';
import { CompleteNews } from './CompleteNews';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class CompleteNewsService {

  constructor(private http: HttpClient) { }

  getAll()
  {
    return this.http.get<CompleteNews[]>("http://localhost:5134/News/")
  }
}
