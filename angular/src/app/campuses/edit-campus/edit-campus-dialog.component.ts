import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
  ChangeDetectorRef,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CampusServiceProxy,
  CampusDto,
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-campus-dialog.component.html'
})
export class EditCampusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  campus = new CampusDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _campusService: CampusServiceProxy,
    public bsModalRef: BsModalRef,
    private _cdr: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._campusService.get(this.id).subscribe((result) => {
      this.campus = result;
      this._cdr.detectChanges();
    });
  }

  save(): void {
    this.saving = true;

    this._campusService
      .update(this.campus)
      .subscribe(
        () => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit(null);
        },
        () => {
          this.saving = false;
        }
      );
  }
}
