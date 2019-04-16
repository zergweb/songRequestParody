import { Component, OnInit } from '@angular/core';
//import { StoreDataService } from '../../services/store.service'; 
//import { Product} from '../../model/Product';
@Component({
  selector: 'server-log-page',
  templateUrl: './server-log-page.component.html',
  styleUrls: ['./server-log-page.component.css']
})
export class ServerLogPageComponent implements OnInit {
  //Products: Product[]=[];
  constructor(
   // private store:StoreDataService
  ) { }

  ngOnInit() {
   // this.Products = this.store.MyProductList;
  }
  public RemoveProduct(id: number) {
   // this.store.removeProduct(id);
  }
  public getTestData() {
    //this.store.getTest2().subscribe(
    //  (r) => { console.log(r); },
    //  (e) => { console.log(e); },
    //);
  }
}
