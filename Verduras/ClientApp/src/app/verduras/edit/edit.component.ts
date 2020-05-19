import { Component, OnInit } from '@angular/core';
import { Fruta } from '../models/fruta';

import { FrutaService } from '../services/fruta.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ClientService } from 'src/app/services/client.service';
import { Location } from '@angular/common';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  form:FormGroup;
  fruta:Fruta;

  constructor(
    private frutaSe:FrutaService, 
    private _form:FormBuilder, 
    private cS:ClientService, 
    private location:Location,
    private modalService: NgbModal) {    
    this.fruta = new Fruta();
  }

  ngOnInit() {
    this.form = this._form.group(
      {
        id:['', Validators.required],
        nombre:['', Validators.required],
        cantidad:['', Validators.required],
        unidad:['', Validators.required],
        proveedor:['', Validators.required]
      }
    );
    this.fruta = this.cS.read();
  }

  update():void{
    this.frutaSe.put(this.fruta).subscribe(
      (data) => {
        if(data!=null) {
          this.cS.clear();
          this.openMB('Resultado Operación','Se ha actualizado');
          location.pathname = 'search';
        }
        else
          this.openMB('Resultado Operación','Error id no existe');
      },
      (data) => {
        this.openMB('Resultado Operación','Error id no existe');
      }
    );
  }

  openMB(title:string, desc:string):void {
    const MESSAGE_BOX = this.modalService.open(AlertModalComponent);
    MESSAGE_BOX.componentInstance.title = title;
    MESSAGE_BOX.componentInstance.message = desc;
  }

  get control() { return this.form.controls; }

  back():void{
    this.location.back();
  }
}
