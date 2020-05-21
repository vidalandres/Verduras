import { Component, OnInit } from '@angular/core';
import { Producto } from '../models/producto';

import { ProductoService } from '../services/producto.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-record',
  templateUrl: './record.component.html',
  styleUrls: ['./record.component.css']
})
export class RecordComponent implements OnInit {

  form:FormGroup;
  producto:Producto;

  constructor(
    private productoSe:ProductoService, 
    private _form:FormBuilder,
    private modalService: NgbModal
    ) {    
    this.producto = new Producto();
  }

  ngOnInit() {
    this.form = this._form.group(
      {
        //id:['', Validators.required],
        nombre:['', Validators.required],
        costo:['', Validators.required],
        margen:['', Validators.required],
        cantidad:['', Validators.required],
        unidad:['', Validators.required],
        proveedor:['', Validators.required]
      }
    );
  }

  add():void{
    if(this.form.invalid){
      this.openMB("Resultado Operacion", "Rellene todos los campos");
      return;
    }
    this.productoSe.post(this.producto).subscribe(
      (data) => {
        if(data!=null) {
          this.openMB("Resultado Operacion", "Se ha registrado con exito");
          this.producto = data;
        }
        else
          this.openMB("Resultado Operacion", "El id ya se ha registrado");
      },
      (data) => {
        this.openMB("Resultado Operacion", "El id ya se ha registrado");
      }
    );
  }

  openMB(title:string, desc:string):void {
    const MESSAGE_BOX = this.modalService.open(AlertModalComponent);
    MESSAGE_BOX.componentInstance.title = title;
    MESSAGE_BOX.componentInstance.message = desc;
  }

  get control() { return this.form.controls; }

  clear():void{
    this.producto = new Producto();
  }

}
