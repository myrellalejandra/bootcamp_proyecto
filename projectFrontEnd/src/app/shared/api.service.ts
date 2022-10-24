import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import {map} from 'rxjs/operators'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http : HttpClient) { }

  postProducto(ProductoModel:any): Observable<any>{
    console.log(ProductoModel);
    return this.http.post<any>("https://appmyrellamasbula.azurewebsites.net/api/Producto/Create",ProductoModel)
    .pipe(map((res : any) => {
      return res;
      //console.log(res);
    }))  
  }
  //https://localhost:7156/api/Producto/GetAll
//https://appmyrellamasbula.azurewebsites.net/api/Producto/GetAll
  getProducto(){
    return this.http.get<any>("https://appmyrellamasbula.azurewebsites.net/api/Producto/GetAll")
    .pipe(map((res : any) => {
      return res;
    }))  
  }
  //return this.http.put<any>("https://localhost:7156/api/Producto/Update/"+ProductoModel.productoId,ProductoModel)
  updateProducto(ProductoModel:any): Observable<any>{
    console.log(ProductoModel);
    return this.http.put<any>("https://appmyrellamasbula.azurewebsites.net/api/Producto/Update",ProductoModel)
    .pipe(map((res : any) => {
      return res;
    }))  
  }
//https://localhost:7156/api/Producto/5
  deleteProducto(id : number){
    return this.http.delete<any>("https://appmyrellamasbula.azurewebsites.net/api/Producto/"+id)
    .pipe(map((res : any) => {
      return res;
    }))  
  }
  
}
