// import { Component, Injector, ChangeDetectorRef, OnInit } from '@angular/core';
// import { appModuleAnimation } from '@shared/animations/routerTransition';
// import { PagedListingComponentBase,  } from '@shared/paged-listing-component-base';
// import { CampusDto, CampusServiceProxy, CampusDtoPagedResultDto } from '@shared/service-proxies/service-proxies';
// import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
// import { CreateCampusDialogComponent } from './create-campus/create-campus-dialog.component';
// import { EditCampusDialogComponent } from './edit-campus/edit-campus-dialog.component';
// import { LazyLoadEvent } from 'primeng/api';
// import { finalize } from 'rxjs/operators';

// @Component({
//   templateUrl: './campuses.component.html',
//   animations: [appModuleAnimation()],
//   // styleUrls: ['./campuses.component.css']
// })
// export class CampusesComponent extends PagedListingComponentBase<CampusDto> implements OnInit {
//   campuses: CampusDto[] = [];
//   keyword = '';
//   isTableLoading = false;

//   constructor(
//     injector: Injector,
//     private _campusService: CampusServiceProxy,
//     private _modalService: BsModalService,
//     cd: ChangeDetectorRef
//   ) {
//     super(injector, cd);
//   }

//   ngOnInit(): void {
//     this.list();
//   }

//   list(event?: LazyLoadEvent): void {
//     this.isTableLoading = true;
//     this.cd.detectChanges();

//     const skipCount = event ? event.first : 0;
//     const maxResultCount = event ? event.rows : this.pageSize;

//     this._campusService
//       .getAll(this.keyword, undefined, skipCount, maxResultCount)
//       .pipe(
//         finalize(() => {
//           this.isTableLoading = false;
//           this.cd.detectChanges();
//         })
//       )
//       .subscribe((result: CampusDtoPagedResultDto) => {
//         this.totalItems = result.totalCount;
//         this.campuses = result.items;
//       });
//   }

//   delete(campus: CampusDto): void {
//     abp.message.confirm(
//       this.l('CampusDeleteWarningMessage', campus.name),
//       undefined,
//       (result: boolean) => {
//         if (result) {
//           this._campusService.delete(campus.id).subscribe(() => {
//             abp.notify.success(this.l('SuccessfullyDeleted'));
//             this.refresh();
//           });
//         }
//       }
//     );
//   }

//   createCampus(): void {
//     this.showCreateOrEditCampusDialog();
//   }

//   editCampus(campus: CampusDto): void {
//     this.showCreateOrEditCampusDialog(campus.id);
//   }

//   private showCreateOrEditCampusDialog(id?: number): void {
//     let createOrEditDialog: BsModalRef;
//     if (!id) {
//       createOrEditDialog = this._modalService.show(
//         CreateCampusDialogComponent,
//         {
//           class: 'modal-lg',
//         }
//       );
//     } else {
//       createOrEditDialog = this._modalService.show(
//         EditCampusDialogComponent,
//         {
//           class: 'modal-lg',
//           initialState: {
//             id: id,
//           },
//         }
//       );
//     }



//     createOrEditDialog.content.onSave.subscribe(() => {
//       this.refresh();
//     });
//   }
//   deleteSelectedCampuses() {
//     console.log('deleteSelectedCampuses');
//   }
// }



import { Component, Injector, ChangeDetectorRef, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { CampusDto, CampusServiceProxy, CampusDtoPagedResultDto } from '@shared/service-proxies/service-proxies';

import { LazyLoadEvent } from 'primeng/api';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: './campuses.component.html',
  animations: [appModuleAnimation()],
})
export class CampusesComponent extends PagedListingComponentBase<CampusDto> implements OnInit {
  campuses: CampusDto[] = [];
  selectedCampuses: CampusDto[] = [];
  createDialogVisible = false;
  editDialogVisible = false;
  selectedCampusId: number;
  keyword = '';
  isTableLoading = false;

  constructor(
    injector: Injector,
    private _campusService: CampusServiceProxy,
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

  refresh(): void {
    this.list();
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

  deleteSelectedCampuses(): void {
    if (!this.selectedCampuses || this.selectedCampuses.length === 0) {
      abp.message.warn(this.l('PleaseSelectAtLeastOneRecord'));
      return;
    }

    abp.message.confirm(
      this.l('CampusMultiDeleteWarningMessage', this.selectedCampuses.length),
      undefined,
      (result: boolean) => {
        if (result) {
          // Dummy loop to show intended delete flow
          const deleteRequests = this.selectedCampuses.map((campus) =>
            this._campusService.delete(campus.id)
          );

          Promise.all(deleteRequests.map((r) => r.toPromise())).then(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.selectedCampuses = [];
            this.refresh();
          });
        }
      }
    );
  }

  createCampus(): void {
    this.createDialogVisible = true;
  }

  editCampus(campus: CampusDto): void {
    this.selectedCampusId = campus.id;
    this.editDialogVisible = true;
  }


}
