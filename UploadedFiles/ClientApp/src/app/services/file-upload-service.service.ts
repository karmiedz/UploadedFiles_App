import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UploadedFileVM } from '../view-models/UploadedFileVM';

@Injectable({
    providedIn: 'root'
})
export class FileUploadService {

    private apiUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.apiUrl = baseUrl + "api/files";
    }

    getFiles(): Observable<any> {
        return this.http.get<UploadedFileVM[]>(this.apiUrl);
    }

    uploadFile(uploadedfile: File): Observable<any> {

        let newFile= new UploadedFileVM();
        newFile.name = uploadedfile.name;
        newFile.size = uploadedfile.size;
        newFile.uploadedDate = new Date();

        return this.http.post(this.apiUrl, newFile);
    }
}