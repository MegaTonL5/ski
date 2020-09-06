import { IProduct } from './../../shared/models/product';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-proudct-item',
  templateUrl: './proudct-item.component.html',
  styleUrls: ['./proudct-item.component.scss']
})
export class ProudctItemComponent implements OnInit {
  @Input() product: IProduct;
  constructor() { }

  ngOnInit(): void {
  }

}
