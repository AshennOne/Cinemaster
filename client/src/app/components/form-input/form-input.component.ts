import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-form-input',
  templateUrl: './form-input.component.html',
  styleUrls: ['./form-input.component.css']
})
export class FormInputComponent {
  @Input() isTextArea = false;
  @Input() isDate =false;
  @Input() fieldName = ''
  @Input() control = new FormControl();
  @Input() label = ''
  @Input() type = 'text'
  public bsConfig: Partial<BsDatepickerConfig>;
  constructor(){
    this.bsConfig = {
      maxDate: new Date(),
    };
  }
}
