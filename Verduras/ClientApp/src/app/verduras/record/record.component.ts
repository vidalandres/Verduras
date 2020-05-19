import { Component, OnInit } from '@angular/core';
import { Fruta } from '../models/fruta';

import { FrutaService } from '../services/fruta.service';
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
  fruta:Fruta;

  constructor(
    private frutaSe:FrutaService, 
    private _form:FormBuilder,
    private modalService: NgbModal
    ) {    
    this.fruta = new Fruta();
  }

  ngOnInit() {
    this.form = this._form.group(
      {
        //id:['', Validators.required],
        nombre:['', Validators.required],
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
    this.frutaSe.post(this.fruta).subscribe(
      (data) => {
        if(data!=null) {
          this.openMB("Resultado Operacion", "Se ha registrado con exito");
          this.fruta = data;
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
    this.fruta = new Fruta();
  }

}
