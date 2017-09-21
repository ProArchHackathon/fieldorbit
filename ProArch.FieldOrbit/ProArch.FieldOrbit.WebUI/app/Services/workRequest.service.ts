import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class WorkRequestService {
    constructor(private httpClient: HttpClient) { }
    
}