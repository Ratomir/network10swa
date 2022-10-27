import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-configuration',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit {
  configs: any[] = [];

  constructor(private http: HttpClient) {
    this.getConfigs();
  }

  ngOnInit(): void {
  }

  getConfigs(): void {
    this.http.get('/api/configurations')
      .subscribe((resp: any) => this.configs = resp);

  }

}
