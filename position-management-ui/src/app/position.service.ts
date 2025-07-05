import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PositionService {
  private apiUrl = 'https://localhost:5001/api'; // Update if your API URL changes

  constructor(private http: HttpClient) {}

  getPositions(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/positions`);
  }

  submitTransaction(transaction: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/transactions`, transaction);
  }
}
