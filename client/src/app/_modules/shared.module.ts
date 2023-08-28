import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { ToastrModule } from 'ngx-toastr';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { RatingModule } from 'ngx-bootstrap/rating';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgxLoadingModule, ngxLoadingAnimationTypes } from 'ngx-loading';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import { TimeagoModule } from "ngx-timeago";
import { TabsModule } from 'ngx-bootstrap/tabs';
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NgxDropzoneModule,
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 4000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    RatingModule.forRoot(),
    ProgressbarModule.forRoot(),
    PaginationModule.forRoot(),
    NgxLoadingModule.forRoot({
      animationType: ngxLoadingAnimationTypes.wanderingCubes,
      backdropBackgroundColour: 'rgba(0,0,0,0.5)',
      backdropBorderRadius: '4px',
      primaryColour: '#ffffff',
      secondaryColour: '#ffffff',
      tertiaryColour: '#ffffff',
      fullScreenBackdrop: false,
    }),
    TypeaheadModule.forRoot(),
    TabsModule.forRoot(),
    TimeagoModule.forRoot()
  ],
  exports: [
    NgxDropzoneModule,
    ModalModule,
    ToastrModule,
    BsDatepickerModule,
    BsDropdownModule,
    RatingModule,
    ProgressbarModule,
    PaginationModule,
    NgxLoadingModule,
    TypeaheadModule,
    TabsModule,
    TimeagoModule
  ],
})
export class SharedModule {}
