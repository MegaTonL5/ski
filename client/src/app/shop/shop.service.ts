import { ShopParams } from './../shared/models/shopParams';
import { IType } from './../shared/models/productTypes';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams} from '@angular/common/http';
import { IPagination} from '../shared/models/pagination';
import { Observable } from 'rxjs';
import {IBrand} from '../shared/models/brands';
import {map} from 'rxjs/operators';
import { IProduct } from '../shared/models/product';
@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';


  constructor(private http: HttpClient) { }

  getPrducts(shopParams: ShopParams): Observable<IPagination>{
    let params = new HttpParams();

    if (shopParams.brandId !== 0 ){
      params = params.append('brandId', shopParams.brandId.toString());
    }

    if (shopParams.typeId !== 0){
      params = params.append('typeID', shopParams.typeId.toString());
    }

    if (shopParams.search){
    params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageIndex', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
    .pipe(
      map(response => {

        return response.body;
      })
    );
  }
  getBrands(): Observable<IBrand[]>{
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  getTypes(): Observable<IType[]>{
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
  getProduct(id: number): Observable<IProduct> {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }

}
