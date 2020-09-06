import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnInit {
@Input() totalCount: number;
@Input() pageSize: number; // input takes in an input from other compoment 
@Output() pageChanged = new EventEmitter<number>(); // passing a componment to another component
  constructor() { }

  ngOnInit(): void {
  }
  OnPagerChange(event:any){
    this.pageChanged.emit(event.page)
  }

}
