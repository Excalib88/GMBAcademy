import { Observable, throwError } from 'rxjs';

export class BaseService {
    public log(message: string) {
        console.log(`Service error: ${message}`);
    }
    
    public handleError(operation = 'operation') {
        return (error: any): Observable<any> => {

            this.log(`${operation} failed: ${error.message}`);

            return throwError(error);
        };
    }
}