import { Component, OnInit } from '@angular/core';
import { FileUploadService } from '../services/file-upload-service.service';

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.css']
})
export class FileUploaderComponent {

    File: File;
    LoadedMsg: string;
    SelectedFileName: string;

    constructor(private fileUploadService: FileUploadService) {
    }

    onChange(event) : void {
        const selectedFile = event.target.files[0];
        if (selectedFile) {
            this.File = selectedFile;
            this.SelectedFileName = this.File.name;
        }
     }
        

    onUpload() : void{
        this.fileUploadService.uploadFile(this.File).subscribe(
            event => {
                this.LoadedMsg = "The file '" + this.File.name + "' has been successfully uploaded.";
                this.SelectedFileName = "";
            }
        );
    }

}
