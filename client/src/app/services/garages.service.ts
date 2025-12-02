import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Garage } from '../models/garage';

@Injectable({
  providedIn: 'root'
})
export class GaragesService {

  private baseUrl = 'http://localhost:5000/api/garages'; 

  constructor(private http: HttpClient) {}

  // add data from government API to our DB
  syncFromGov(): Observable<Garage[]> {
    return this.http.get<Garage[]>(`${this.baseUrl}/sync-from-gov`);
  }

  // get all garages
  getAll(): Observable<Garage[]> {
    return this.http.get<Garage[]>(this.baseUrl);
  }

  // add a new garage
  addGarage(garage: Garage): Observable<Garage> {
    return this.http.post<Garage>(this.baseUrl, garage);
  }
}