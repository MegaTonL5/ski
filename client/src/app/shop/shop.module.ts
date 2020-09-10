import { ShopRoutingModule } from './shop-routing.module';
import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProudctItemComponent } from './proudct-item/proudct-item.component';
import { ProductDetailsComponent } from './product-details/product-details.component';



@NgModule({
  declarations: [ShopComponent, ProudctItemComponent, ProductDetailsComponent],
  imports: [
    CommonModule,
    SharedModule,
    ShopRoutingModule
  ]
})
export class ShopModule { }
