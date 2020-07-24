import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
  clientes: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getClientes();
  }
  getClientes() {
    this.http.get('http://localhost:5000/api/Clientes/ObtenerClientes')
      .subscribe(response => {
        this.clientes = response;
      }, error => {
        console.log(error);
      });
  }

}
