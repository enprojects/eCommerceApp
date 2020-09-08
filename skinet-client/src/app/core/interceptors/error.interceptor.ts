import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, delay } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastr: ToastrService) {

  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(catchError(error => {
      if (error) {
        this.toastr.error(error.error.title, error.status);
        if (error.status === 404) {
          this.router.navigateByUrl('/not-found');
        }

        if (error.status === 500) {
          this.router.navigateByUrl('/sever-error');
        }

        return throwError(error);
      }
    }));

  }
}
