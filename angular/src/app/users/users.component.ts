// import {
//   ChangeDetectorRef,
//   Component,
//   Injector,
//   ViewChild,
// } from "@angular/core";
// import { finalize } from "rxjs/operators";
// import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
// import { appModuleAnimation } from "@shared/animations/routerTransition";
// import { PagedListingComponentBase } from "shared/paged-listing-component-base";
// import {
//   UserServiceProxy,
//   UserDto,
//   UserDtoPagedResultDto,
// } from "@shared/service-proxies/service-proxies";
// import { CreateUserDialogComponent } from "./create-user/create-user-dialog.component";
// import { EditUserDialogComponent } from "./edit-user/edit-user-dialog.component";
// import { ResetPasswordDialogComponent } from "./reset-password/reset-password.component";
// import { Table } from "primeng/table";
// import { LazyLoadEvent } from "primeng/api";
// import { ActivatedRoute } from "@angular/router";
// import { Paginator } from "primeng/paginator";

// @Component({
//   templateUrl: "./users.component.html",
//   animations: [appModuleAnimation()],
// })
// export class UsersComponent extends PagedListingComponentBase<UserDto> {
//   users: UserDto[] = [];
//   keyword = "";
//   isActive: boolean | null;
//   advancedFiltersVisible = false;
//   @ViewChild("dataTable", { static: true }) dataTable: Table;
//   @ViewChild("paginator", { static: true }) paginator: Paginator;

//   constructor(
//     injector: Injector,
//     private _userService: UserServiceProxy,
//     private _modalService: BsModalService,
//     private _activatedRoute: ActivatedRoute,
//     cd: ChangeDetectorRef
//   ) {
//     super(injector, cd);
//     this.keyword =
//       this._activatedRoute.snapshot.queryParams["filterText"] || "";
//   }

//   createUser(): void {
//     this.showCreateOrEditUserDialog();
//   }

//   editUser(user: UserDto): void {
//     this.showCreateOrEditUserDialog(user.id);
//   }

//   public resetPassword(user: UserDto): void {
//     this.showResetPasswordUserDialog(user.id);
//   }

//   clearFilters(): void {
//     this.keyword = "";
//     this.isActive = undefined;
//   }

//   list(event?: LazyLoadEvent): void {
//     if (this.primengTableHelper.shouldResetPaging(event)) {
//       this.paginator.changePage(0);

//       if (
//         this.primengTableHelper.records &&
//         this.primengTableHelper.records.length > 0
//       ) {
//         return;
//       }
//     }

//     this.primengTableHelper.showLoadingIndicator();

//     this._userService
//       .getAll(
//         this.keyword,
//         this.isActive,
//         this.primengTableHelper.getSorting(this.dataTable),
//         this.primengTableHelper.getSkipCount(this.paginator, event),
//         this.primengTableHelper.getMaxResultCount(this.paginator, event)
//       )
//       .pipe(
//         finalize(() => {
//           this.primengTableHelper.hideLoadingIndicator();
//         })
//       )
//       .subscribe((result: UserDtoPagedResultDto) => {
//         this.primengTableHelper.records = result.items;
//         this.primengTableHelper.totalRecordsCount = result.totalCount;
//         this.primengTableHelper.hideLoadingIndicator();
//         this.cd.detectChanges();
//       });
//   }

//   delete(user: UserDto): void {
//     abp.message.confirm(
//       this.l("UserDeleteWarningMessage", user.fullName),
//       undefined,
//       (result: boolean) => {
//         if (result) {
//           this._userService.delete(user.id).subscribe(() => {
//             abp.notify.success(this.l("SuccessfullyDeleted"));
//             this.refresh();
//           });
//         }
//       }
//     );
//   }

//   private showResetPasswordUserDialog(id?: number): void {
//     this._modalService.show(ResetPasswordDialogComponent, {
//       class: "modal-lg",
//       initialState: {
//         id: id,
//       },
//     });
//   }

//   private showCreateOrEditUserDialog(id?: number): void {
//     let createOrEditUserDialog: BsModalRef;
//     if (!id) {
//       createOrEditUserDialog = this._modalService.show(
//         CreateUserDialogComponent,
//         {
//           class: "modal-lg",
//         }
//       );
//     } else {
//       createOrEditUserDialog = this._modalService.show(
//         EditUserDialogComponent,
//         {
//           class: "modal-lg",
//           initialState: {
//             id: id,
//           },
//         }
//       );
//     }

//     createOrEditUserDialog.content.onSave.subscribe(() => {
//       this.refresh();
//     });
//   }
// }


import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table, TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { InputTextModule } from 'primeng/inputtext';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { InputIconModule } from 'primeng/inputicon';
import { IconFieldModule } from 'primeng/iconfield';
import { TagModule } from 'primeng/tag';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  UserServiceProxy,
  UserDto,
  UserDtoPagedResultDto,
} from '@shared/service-proxies/service-proxies';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { CreateUserDialogComponent } from './create-user/create-user-dialog.component';
import { EditUserDialogComponent } from './edit-user/edit-user-dialog.component';
import { ResetPasswordDialogComponent } from './reset-password/reset-password.component';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [
    TableModule,
    CommonModule,
    FormsModule,
    ButtonModule,
    RippleModule,
    ToastModule,
    ToolbarModule,
    InputTextModule,
    DialogModule,
    ConfirmDialogModule,
    InputIconModule,
    IconFieldModule,
    TagModule,
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ResetPasswordDialogComponent,
  ],
  template: `
    <p-toast></p-toast>
    <p-toolbar styleClass="mb-6">
      <ng-template pTemplate="start">
        <p-button label="New" icon="pi pi-plus" (onClick)="createUser()" class="mr-2" />
        <p-button label="Delete" icon="pi pi-trash" (onClick)="deleteSelectedUsers()" [disabled]="!selectedUsers?.length" outlined />
      </ng-template>
    </p-toolbar>

    <p-table #dt [value]="users" [(selection)]="selectedUsers" dataKey="id" [paginator]="true" [rows]="10" 
             [globalFilterFields]="['fullName', 'emailAddress']" [lazy]="true" (onLazyLoad)="loadUsers($event)"
             [loading]="isTableLoading">
      <ng-template pTemplate="caption">
        <div class="flex items-center justify-between">
          <h5 class="m-0">Manage Users</h5>
          <p-iconfield>
            <p-inputicon styleClass="pi pi-search" />
            <input pInputText type="text" [(ngModel)]="keyword" (input)="onGlobalFilter(dt, $event)" placeholder="Search by name or email..." />
          </p-iconfield>
        </div>
      </ng-template>

      <ng-template pTemplate="header">
        <tr>
          <th style="width: 3rem">
            <p-tableHeaderCheckbox></p-tableHeaderCheckbox>
          </th>
          <th>Full Name</th>
          <th>Email</th>
          <th>Status</th>
          <th style="width: 12rem">Actions</th>
        </tr>
      </ng-template>

      <ng-template pTemplate="body" let-user>
        <tr>
          <td>
            <p-tableCheckbox [value]="user"></p-tableCheckbox>
          </td>
          <td>{{ user.fullName }}</td>
          <td>{{ user.emailAddress }}</td>
          <td>
            <p-tag [value]="user.isActive ? 'Active' : 'Inactive'" [severity]="user.isActive ? 'success' : 'danger'"></p-tag>
          </td>
          <td>
            <p-button icon="pi pi-pencil" class="mr-2" (click)="editUser(user)" outlined></p-button>
            <p-button icon="pi pi-key" class="mr-2" (click)="resetPassword(user)" outlined></p-button>
            <p-button icon="pi pi-trash" severity="danger" (click)="deleteUser(user)" outlined></p-button>
          </td>
        </tr>
      </ng-template>
    </p-table>

    <p-confirmdialog></p-confirmdialog>

    <app-create-user-dialog #createUserDialog (onSave)="loadUsers()"></app-create-user-dialog>
    <app-edit-user-dialog #editUserDialog (onSave)="loadUsers()"></app-edit-user-dialog>
    <app-reset-password #resetPasswordDialog></app-reset-password>

    <pre style="margin-top:2rem;background:#f8f8f8;padding:1rem;border-radius:5px;max-height:300px;overflow:auto;">
      {{ users | json }}
    </pre>
  `,
  animations: [appModuleAnimation()],
  providers: [MessageService, ConfirmationService, UserServiceProxy, BsModalService]
})
export class UsersComponent implements OnInit {
  users: UserDto[] = [];
  selectedUsers: UserDto[] = [];
  keyword = '';
  isActive: boolean | null = null;
  isTableLoading = false;

  @ViewChild('dt') dt!: Table;

  @ViewChild('createUserDialog') createUserDialog!: CreateUserDialogComponent;
  @ViewChild('editUserDialog') editUserDialog!: EditUserDialogComponent;
  @ViewChild('resetPasswordDialog') resetPasswordDialog!: ResetPasswordDialogComponent;

  constructor(
    private _userService: UserServiceProxy,
    private _modalService: BsModalService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private _activatedRoute: ActivatedRoute,
    private cdr: ChangeDetectorRef
  ) {
    this.keyword = this._activatedRoute.snapshot.queryParams["filterText"] || '';
  }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(event?: any): void {
    this.isTableLoading = true;
    const skipCount = event ? event.first : 0;
    const maxResultCount = event ? event.rows : 10;

    const isActiveParam = this.isActive === null ? undefined : this.isActive;
    this._userService
      .getAll(
        this.keyword,
        isActiveParam,
        undefined,
        skipCount,
        maxResultCount
      )
      .pipe(
        finalize(() => {
          this.isTableLoading = false;
          this.cdr.detectChanges();
        })
      )
      .subscribe({
        next: (result: UserDtoPagedResultDto) => {
          this.users = result.items;
          this.dt.totalRecords = result.totalCount;
          this.cdr.detectChanges();
        },
        error: (error) => {
          console.error('[loadUsers] Error:', error);
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Failed to load users' });
        }
      });
  }

  createUser(): void {
    this.createUserDialog.show();
  }

  editUser(user: UserDto): void {
    this.editUserDialog.id = user.id;
    this.editUserDialog.show();
  }

  resetPassword(user: UserDto): void {
    this.resetPasswordDialog.id = user.id;
    this.resetPasswordDialog.show();
  }

  deleteUser(user: UserDto): void {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete ${user.fullName}?`,
      accept: () => {
        this._userService.delete(user.id).subscribe({
          next: () => {
            this.messageService.add({ severity: 'success', summary: 'Deleted', detail: `${user.fullName} deleted` });
            this.loadUsers();
          },
          error: (error) => {
            console.error('[deleteUser] Error:', error);
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Failed to delete user' });
          }
        });
      }
    });
  }

  deleteSelectedUsers(): void {
    if (!this.selectedUsers.length) {
      this.messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Please select at least one user' });
      return;
    }

    this.confirmationService.confirm({
      message: `Are you sure you want to delete ${this.selectedUsers.length} selected users?`,
      accept: () => {
        const deletes = this.selectedUsers.map(user => this._userService.delete(user.id));
        Promise.all(deletes.map(d => d.toPromise())).then(() => {
          this.messageService.add({ severity: 'success', summary: 'Deleted', detail: 'Selected users deleted' });
          this.selectedUsers = [];
          this.loadUsers();
        }).catch(error => {
          console.error('[deleteSelectedUsers] Error:', error);
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Failed to delete selected users' });
        });
      }
    });
  }

  onGlobalFilter(table: Table, event: Event): void {
    this.keyword = (event.target as HTMLInputElement).value;
    table.filterGlobal(this.keyword, 'contains');
    this.loadUsers();
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.dt.filterGlobal('', 'contains');
    this.loadUsers();
  }
}