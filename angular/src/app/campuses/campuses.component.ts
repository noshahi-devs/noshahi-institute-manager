import { Component, Injector, ChangeDetectorRef, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,  } from '@shared/paged-listing-component-base';
import { CampusDto, CampusServiceProxy, CampusDtoPagedResultDto } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateCampusDialogComponent } from './create-campus/create-campus-dialog.component';
import { EditCampusDialogComponent } from './edit-campus/edit-campus-dialog.component';
import { LazyLoadEvent } from 'primeng/api';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: './campuses.component.html',
  animations: [appModuleAnimation()],
  // styleUrls: ['./campuses.component.css']
})
export class CampusesComponent extends PagedListingComponentBase<CampusDto> implements OnInit {
  campuses: CampusDto[] = [];
  keyword = '';
  isTableLoading = false;

  constructor(
    injector: Injector,
    private _campusService: CampusServiceProxy,
    private _modalService: BsModalService,
    cd: ChangeDetectorRef
  ) {
    super(injector, cd);
  }

  ngOnInit(): void {
    this.list();
  }

  list(event?: LazyLoadEvent): void {
    this.isTableLoading = true;
    this.cd.detectChanges();

    const skipCount = event ? event.first : 0;
    const maxResultCount = event ? event.rows : this.pageSize;

    this._campusService
      .getAll(this.keyword, undefined, skipCount, maxResultCount)
      .pipe(
        finalize(() => {
          this.isTableLoading = false;
          this.cd.detectChanges();
        })
      )
      .subscribe((result: CampusDtoPagedResultDto) => {
        this.totalItems = result.totalCount;
        this.campuses = result.items;
      });
  }

  delete(campus: CampusDto): void {
    abp.message.confirm(
      this.l('CampusDeleteWarningMessage', campus.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._campusService.delete(campus.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  createCampus(): void {
    this.showCreateOrEditCampusDialog();
  }

  editCampus(campus: CampusDto): void {
    this.showCreateOrEditCampusDialog(campus.id);
  }

  private showCreateOrEditCampusDialog(id?: number): void {
    let createOrEditDialog: BsModalRef;
    if (!id) {
      createOrEditDialog = this._modalService.show(
        CreateCampusDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditDialog = this._modalService.show(
        EditCampusDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
