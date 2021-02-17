import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
@Component({
  selector: 'app-student-data',
  templateUrl: './student-data.component.html'
})
export class StudentDataComponent {
  allStudents: IStudent[];
  private _serviceUrl = "https://localhost:44319/api/student";



  constructor(private http: HttpClient) {
    this.getAllStudents().subscribe(result => {
      this.allStudents = result;
    }, error => console.error(error));
  }
  getAllStudents(): Observable<IStudent[]> {
    return this.http.get<IStudent[]>(this._serviceUrl)
      .pipe(map(allstudents => <IStudent[]>allstudents),
        catchError(() => {
          return throwError("Something Went Wrong..!")
        }))
  }
}



interface IStudent {
  sid: number;
  name: string;
  email: string;
  class: number;
  schoolName: string;
  city: string;
}
