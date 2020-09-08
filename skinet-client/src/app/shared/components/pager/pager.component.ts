import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnInit {

  constructor() { }

  @Input() totalNumberOfRecord: number;
  @Input() pageNumber: number;
  @Input() pageSize: number;
  @Output() pageChanged = new EventEmitter<number>();

  ngOnInit(): void {
  }

  onPageChanged(event: any) {
    this.pageChanged.emit(event.page);
  }

}
