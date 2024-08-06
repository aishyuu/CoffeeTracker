import { Component } from '@angular/core';
import { CoffeeDay } from '../coffee-day';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-display-all',
  templateUrl: './display-all.component.html',
  styleUrls: ['./display-all.component.css']
})
export class DisplayAllComponent {
  data: CoffeeDay[] = [];
  
  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit() {
    this.getCoffeeDays();
  }

  getCoffeeDays() {
    this.http.get<CoffeeDay[]>('https://localhost:7237/api/CoffeeDays')
      .subscribe(
        (resp: CoffeeDay[]) => {
          this.data = resp;
        }
      )
  }

  deleteDay(id: number) : void {
    this.http.delete(`https://localhost:7237/api/CoffeeDays/${id}`)
      .subscribe(
        () => {
          window.location.reload();
        }
      )
  }
}
