import { Component } from '@angular/core';
import { CoffeeDay } from '../coffee-day';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  data: CoffeeDay[] = [];
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getCoffeeDays();
  }

  getCoffeeDays() {
    this.http.get<CoffeeDay[]>('https://localhost:7237/api/CoffeeDays')
      .subscribe(
        (resp: CoffeeDay[]) => {
          this.data = resp.slice(0, 5);
        }
      )
  }
}
