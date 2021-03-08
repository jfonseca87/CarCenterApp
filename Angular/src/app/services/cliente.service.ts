import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente';
import { ApiResponse } from '../models/apiResponse';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) { }

  obtenerClientes(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(`${environment.url}/Cliente`);
  }

  obtenerClientePorId(clienteId: number): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(`${environment.url}/cliente/${clienteId}`)
  }

  crearCliente(cliente: Cliente): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(`${environment.url}/cliente`, cliente);
  }

  modificarCliente(cliente: Cliente): Observable<ApiResponse> {
    return this.http.put<ApiResponse>(`${environment.url}/cliente`, cliente);
  }

  eliminarCliente(clienteId: number): Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(`${environment.url}/cliente/${clienteId}`)
  }
}
