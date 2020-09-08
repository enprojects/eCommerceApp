import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {

  constructor(private httpServ: HttpClient) { }
  validationErrors: any;
  ngOnInit(): void {


  }

  get404Error() {
    this.httpServ.get(environment.url_product + '/42').subscribe(res => {
      console.log(res);

    }, err => console.log( err));
  }

  get500Error() {
    this.httpServ.get(environment.base_url + 'buggy/servererror').subscribe(res => {
      console.log(res);

    }, err => {

      console.log(err);
    });
  }

  get400Error() {
    this.httpServ.get(environment.base_url + 'buggy/badrequest').subscribe(res => {
      console.log(res);

    }, err => {
      console.log( err);
    });
  }


  get400ValidationError() {
    this.httpServ.get(environment.base_url + 'products/fortytwo').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
      this.validationErrors = error.errors;
    });
  }

}
