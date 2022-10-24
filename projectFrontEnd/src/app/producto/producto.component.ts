import { Component, OnInit } from '@angular/core';
import {} from '@angular/core';
import { FormBuilder,FormGroup } from '@angular/forms';
import { ApiService } from '../shared/api.service';
import { ProductoModel } from './producto.model';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {
  formValue !: FormGroup;
  productoModelObject : ProductoModel = new ProductoModel();
  productoData !: any;
  showAdd !: boolean;
  showUpdate !: boolean;
  constructor(private formbuilder : FormBuilder,
    private api : ApiService) { }

  ngOnInit(): void {
    this.formValue = this.formbuilder.group({
      nombre : [''],
      precio : [''],
      categoria : [''],
      descripcion : [''],
      stock : [''],
    })
    this.getAllProducto();
  }
  clickAddProducto(){
    this.formValue.reset();
    this.showAdd = true;
    this.showUpdate = false;
  }
  postEmployeeDetails(){
    this.productoModelObject.nombre = this.formValue.value.nombre;
    this.productoModelObject.precio = this.formValue.value.precio;
    this.productoModelObject.descripcion = this.formValue.value.descripcion;
    this.productoModelObject.categoria = this.formValue.value.categoria;
    this.productoModelObject.stock = this.formValue.value.stock;

    this.api.postProducto(this.productoModelObject)
    .subscribe({
      next : (res) =>{
        console.log(res);
        alert("Producto se añadio existosamente")
        let ref = document.getElementById('cancel')
        ref?.click();
        this.formValue.reset();
        this.getAllProducto();
      //this.dialogRef.close('Guardar');
      },
      error : () =>{
        alert("Sucedio un error inesperado")
        console.log('error');
      }
    })
  }
  
  getAllProducto(){
    this.api.getProducto()
    .subscribe(res=>{
      this.productoData = res;
    })
  }

  deleteProducto(row : any){
    this.api.deleteProducto(row.productoId)
    .subscribe(res=>{
      console.log(row.productoId)
      alert("Producto eliminado");
      this.getAllProducto(); //to refresh data after deleting
    })
  }

  onEdit(row:any){
    this.showAdd = false;
    this.showUpdate = true;
    this.productoModelObject.productoId = row.productoId;
    this.formValue.controls['nombre'].setValue(row.nombre)
    this.formValue.controls['precio'].setValue(row.precio)
    this.formValue.controls['categoria'].setValue(row.categoria)
    this.formValue.controls['descripcion'].setValue(row.descripcion)
    this.formValue.controls['stock'].setValue(row.stock)
  }

  updateProducto(){
    this.productoModelObject.nombre = this.formValue.value.nombre;
    this.productoModelObject.precio = this.formValue.value.precio;
    this.productoModelObject.descripcion = this.formValue.value.descripcion;
    this.productoModelObject.categoria = this.formValue.value.categoria;
    this.productoModelObject.stock = this.formValue.value.stock;
    this.api.updateProducto(this.productoModelObject)
    .subscribe(res=>{
      alert("Producto Modificado");
      let ref = document.getElementById('cancel')
      ref?.click();
      this.formValue.reset();
      this.getAllProducto();
    })  
  }
}
