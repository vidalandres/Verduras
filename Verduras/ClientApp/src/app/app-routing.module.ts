import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SearchComponent } from './verduras/search/search.component';
import { RecordComponent } from './verduras/record/record.component';
import { EditComponent } from './verduras/edit/edit.component';

import { Routes, RouterModule } from '@angular/router';
import { SellComponent } from './verduras/sell/sell.component';
import { SoldComponent } from './verduras/sold/sold.component';

const routes: Routes = [
  {
    path: 'record',
    component: RecordComponent
  },
  {
    path: 'search',
    component: SearchComponent
  },
  { 
    path: '', 
    component: RecordComponent
  },
  { 
    path: 'edit', 
    component: EditComponent
  },
  { 
    path: 'sell', 
    component: SellComponent
  },
  { 
    path: 'sold', 
    component: SoldComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
