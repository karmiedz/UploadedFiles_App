export class UploadedFileVM {

    id: string;
    name: string;
    size: number;
    uploadedDate: Date;

    constructor(){
        this.uploadedDate = new Date();
    }
}
