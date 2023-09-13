import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ServceCatalogoService } from '../servce-catalogo.service';
import { Catalogo, StateGroup } from '../models/catalogo';
import { Observable, map, startWith } from 'rxjs';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-nevo-registro',
  templateUrl: './nevo-registro.component.html',
  styleUrls: ['./nevo-registro.component.css']
})
export class NevoRegistroComponent  implements OnInit  {

  stateGroupOptions!: Observable<Catalogo[]>;
  form!:FormGroup;
  pipe = new DatePipe('en-US')
  Ocultaformulario: boolean=true;

  myControl = new FormControl('');
  filteredOptions!: Catalogo[];
  Gatalofgo: Catalogo[]=[];
  constructor(
    private service:ServceCatalogoService,
    private spinner: NgxSpinnerService,
    private _fb: FormBuilder,
   
  ) {


  }


  ngOnInit(): void {
 
 this.getCatalogos();
    this.form = this._fb.group({

      
      Id: [0],
      nombre: ['', [Validators.required]],
      email: ['', [Validators.required,Validators.email]],
      telefono: ['', [Validators.required,Validators.maxLength(10)]],
      fecha: ['', [Validators.required]],
      ciudadEstado: ['']
      
      

  });

  


}




// private _filter(value: string): string[] {
//   const filterValue = value.toLowerCase();

//   return this.Gatalofgo.filter(option => option.descripcion.toLowerCase().includes(filterValue));
// }




getCatalogos(){

  this.service.getCatalogo().subscribe({
    next:(rest)=>{
      console.log(rest);
   
     this.filteredOptions=rest;

     this.stateGroupOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => typeof value==="string"? value:value),
     // map(value => this._filter(value || '')),
      map(op => op ? this._filter(op ):this.filteredOptions.slice()),
      
    );
  

     console.log(this.stateGroupOptions);
    }
  });  

}


private _filter(value: string): Catalogo[] {
  if (value) {
    return this.filteredOptions
      
      .filter(group => group.descripcion.toLocaleLowerCase().includes(value.toLocaleLowerCase()));
  }

  return this.filteredOptions;
}


  

  save(Form:any) {
    debugger
    
    const myFormattedDate = this.pipe.transform(this.form.value.fecha, 'longDate');
    this.form.value.ciudadEstado=this.myControl.value;
    this.form.value.fecha=myFormattedDate;

  console.log(this.myControl);
     
    this.service.EnviarCorreo(this.form.value).subscribe({
      next:(rest)=>{
        console.log(rest);
         this.Ocultaformulario=false;

     
       
      }
    });  
  

}
}



export const _filter = (opt: string[], value: string): string[] => {
  const filterValue = value.toLowerCase();

  return opt.filter(item => item.toLowerCase().includes(filterValue));
};
