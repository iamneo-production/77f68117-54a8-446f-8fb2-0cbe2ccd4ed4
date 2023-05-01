import { HttpClient, HttpEventType, HttpResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent {

  public fileData: File | null = null;
  public filename?: string = '';
  public showProgress = false;
  errorMessage: string | null = null;

  constructor(private http: HttpClient, private toastr : ToastrService, private router : Router) { }

  public onFileSelected(event: any): void {

    this.fileData = event.target.files[0];
    this.filename = this.fileData?.name;
  }

  public onFileDropped(event: any): void {
    this.fileData = event.files[0];
    this.filename = this.fileData?.name;
  }

  public onDragOver(event: any): void {
    event.preventDefault();
    event.stopPropagation();
    event.currentTarget.classList.add('drag-over');
  }

  public onDragLeave(event: any): void {
    event.preventDefault();
    event.stopPropagation();
    event.currentTarget.classList.remove('drag-over');
  }

   public removeFile(): void {
     this.fileData = null;
     this.filename = '';
   }

  public formmatFileSize(size: number): string {
    if (size === 0) {
      return '0 B';
    }

    const units = ['B', 'KB', 'MB', 'GB', 'TB']
    const i = Math.floor(Math.log(size) / Math.log(1024));
    const formmatFileSize = (size / Math.pow(1024, i)).toFixed(2);
    return `${formmatFileSize} ${units[i]}`


  }

  public uploadFile(): void {
    if (this.fileData) {
      const formData = new FormData();
      formData.append('file', this.fileData);
      this.showProgress = true;
      this.http.post('https://8080-dbbffecaaccbbacaddcceebceaacefafebd.project.examly.io/api/Document/upload', formData, {
        reportProgress: true,
        observe: 'events'
      }).subscribe((event) => {

        
        
        if (event.type === HttpEventType.UploadProgress) {
          if (event.total !== undefined) {
            const progress = Math.round((event.loaded / event.total) * 100);

            const progressBar = document.querySelector('.progress-bar') as HTMLElement;
            progressBar.style.width = `${progress}%`;
            this.toastr.success('File Uploaded successfully!'); 
          }
        }

        // else if (event instanceof HttpResponse) {
        //   this.showProgress = false;
        //   if (event.status === HttpStatusCode.Created) {
        //     console.log('File uploaded successfully!');
            
        //     this.fileData = null;
        //     this.filename = '';
        //              }
        // }
      }, (error) => {
        this.showProgress = false;
        console.error(`Error uploading file: ${error.message}`);
      });
    }
  }

  public fileChange(event: any): void {

    const fileList: FileList = event.target.files;

    if (fileList.length > 0) {
      const file: File = fileList[0];

      const fileNameParts: string[] = file.name.split('.');

      if (fileNameParts.length > 1)
       {

        const fileExtension: string | undefined = fileNameParts.pop()?.toLowerCase();

        if (fileExtension !== 'jpg' && fileExtension !== 'jpeg' && fileExtension !== 'png' && fileExtension !== 'pdf') {
          this.errorMessage = 'please select a Image or Pdf file';
          this.fileData = null;
          this.filename = this.filename;
        } else if(file.size > 2 *1024 *1024){
              this.errorMessage = 'Please upload a file less than 2MB !!';
              this.fileData = null;
              this.filename ='';
        }else {
          
          this.fileData = file;
          this.filename = file.name;
        }
      }
    }
  }
}

