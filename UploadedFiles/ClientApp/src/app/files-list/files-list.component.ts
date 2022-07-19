import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FileUploadService } from '../services/file-upload-service.service';
import { UploadedFileVM} from '../view-models/UploadedFileVM';

@Component({
    selector: 'app-files-list',
    templateUrl: './files-list.component.html',
    styleUrls: ['./files-list.component.css']
})

export class FilesListComponent {

    Files: UploadedFileVM[];

    constructor(private http: HttpClient, private fileUploadService: FileUploadService ) {
    }

    showFiles() {
        this.fileUploadService.getFiles().subscribe(result => {
            this.Files = result;
        }, error => console.error(error));
    }
}

