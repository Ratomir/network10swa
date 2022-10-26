import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = "Network10";
  messages: any[] = [];

  constructor(private http: HttpClient) {
    this.http.get('/api/messages')
      .subscribe((resp: any) => this.messages = resp);
  }
}
