import { AppConfig } from '../app.config';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Customer } from '../models/customer';
import { tap, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
    providedIn: 'root'
})

export class CustomerService extends BaseService {
    constructor(private config: AppConfig, private http: HttpClient){
        super();
    }

    getAll(): Observable<Customer[]>{
        return this.http.get<Customer[]>(this.config.urls.GetCustomer).pipe(
            tap(_ => this.log(`fetched Customers: ${JSON.stringify(_)}`)),
            catchError(this.handleError('getAll'))
        );
    }

    getCustomer(): Observable<Customer>{
        return this.http.get<Customer>(this.config.urls.GetCustomer).pipe(
            tap(_ => this.log(`fetched customer: ${JSON.stringify(_)}`)),
            catchError(this.handleError('getCustomer'))
        );
    }
    
    createCustomer(customer: Customer): Observable<Customer> {
        return this.http.post<Customer>(this.config.urls.CreateCustomer, customer, httpOptions).pipe(
            tap(_ => this.log(`Customer was added`)),
            catchError(this.handleError('createCustomer'))
        );
    }
}