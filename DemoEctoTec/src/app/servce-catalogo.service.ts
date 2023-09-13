import { Injectable } from '@angular/core';
import { Catalogo } from './models/catalogo';
import { environment } from 'src/assets/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';

@Injectable({
  providedIn: 'root'
})
export class ServceCatalogoService {

  constructor(private http: HttpClient,
    public dialog: MatDialog 
    ){ }  


    getCatalogo(): Observable<Catalogo[]> {  
    let headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.get<Catalogo[]>(environment.UrlApi + 'catalogo/GetEstados',{headers: headers });  
  } 

  
  EnviarCorreo( articulo:any){
    console.log("obejto");
    console.log(articulo);
    let headers = new HttpHeaders().set("Content-Type", "application/json");
      return this.http.post<any>(environment.UrlApi + 'catalogo/EnviarCorreo',articulo,{headers: headers });
  
    }

}
