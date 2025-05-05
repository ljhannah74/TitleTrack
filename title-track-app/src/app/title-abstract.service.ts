import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { TitleAbstract } from '../models/title-abstract';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TitleAbstractService {
  private apiUrl = `${environment.apiUrl}/titleabstract`;

  constructor(private http: HttpClient) {}

  getTitleAbstracts(): Observable<TitleAbstract[]> {
    return this.http.get<TitleAbstract[]>(this.apiUrl);
  }
}
