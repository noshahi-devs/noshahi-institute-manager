import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CampusServiceProxy,
  CampusDto,
  CreateCampusDto,
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-campus-dialog.component.html'
})
export class CreateCampusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  campus = new CampusDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _campusService: CampusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    const campus = new CreateCampusDto();
    campus.init(this.campus);

    this._campusService
      .create(campus)
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
