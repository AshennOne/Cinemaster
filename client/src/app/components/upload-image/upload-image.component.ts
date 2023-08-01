import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.css']
})
export class UploadImageComponent {
  @Output() filesEmitter = new EventEmitter<any>();
  @Input() file?:File 
  @Input() imgUrl?:string
  sendFilesToParent(event:any) {
    
    this.filesEmitter.emit(event.addedFiles[0]);
  }
}
