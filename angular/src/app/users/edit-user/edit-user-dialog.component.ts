// import {
//   Component,
//   Injector,
//   OnInit,
//   EventEmitter,
//   Output,
//   ChangeDetectorRef
// } from '@angular/core';
// import { BsModalRef } from 'ngx-bootstrap/modal';
// import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
// import { AppComponentBase } from '@shared/app-component-base';
// import {
//   UserServiceProxy,
//   UserDto,
//   RoleDto
// } from '@shared/service-proxies/service-proxies';

// @Component({
//   templateUrl: './edit-user-dialog.component.html'
// })
// export class EditUserDialogComponent extends AppComponentBase
//   implements OnInit {
//   saving = false;
//   user = new UserDto();
//   roles: RoleDto[] = [];
//   checkedRolesMap: { [key: string]: boolean } = {};
//   id: number;

//   @Output() onSave = new EventEmitter<any>();

//   constructor(
//     injector: Injector,
//     public _userService: UserServiceProxy,
//     public bsModalRef: BsModalRef,
//     private cd: ChangeDetectorRef
//   ) {
//     super(injector);
//   }

//   ngOnInit(): void {
//     this._userService.get(this.id).subscribe((result) => {
//       this.user = result;

//       this._userService.getRoles().subscribe((result2) => {
//         this.roles = result2.items;
//         this.setInitialRolesStatus();
//         this.cd.detectChanges();
//       });
//     });
//   }

//   setInitialRolesStatus(): void {
//     _map(this.roles, (item) => {
//       this.checkedRolesMap[item.normalizedName] = this.isRoleChecked(
//         item.normalizedName
//       );
//     });
//   }

//   isRoleChecked(normalizedName: string): boolean {
//     return _includes(this.user.roleNames, normalizedName);
//   }

//   onRoleChange(role: RoleDto, $event) {
//     this.checkedRolesMap[role.normalizedName] = $event.target.checked;
//   }

//   getCheckedRoles(): string[] {
//     const roles: string[] = [];
//     _forEach(this.checkedRolesMap, function (value, key) {
//       if (value) {
//         roles.push(key);
//       }
//     });
//     return roles;
//   }

//   save(): void {
//     this.saving = true;

//     this.user.roleNames = this.getCheckedRoles();

//     this._userService.update(this.user).subscribe(
//       () => {
//         this.notify.info(this.l('SavedSuccessfully'));
//         this.bsModalRef.hide();
//         this.onSave.emit();
//       },
import { Component, OnInit, EventEmitter, Output, ChangeDetectorRef, Injector, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  UserServiceProxy,
  UserDto,
  RoleDto
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-user-dialog',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    CheckboxModule,
    ToastModule
  ],
  template: `
    <p-toast></p-toast>
    <p-dialog [(visible)]="dialogVisible" [style]="{ width: '450px' }" header="Edit User" [modal]="true" (onHide)="hideDialog()">
      <ng-template pTemplate="content">
        <div class="flex flex-col gap-6">
          <div>
            <label for="name" class="block font-bold mb-3">Name</label>
            <input type="text" pInputText id="name" [(ngModel)]="user.name" required autofocus fluid />
            <small class="text-red-500" *ngIf="submitted && !user.name">Name is required.</small>
          </div>
          <div>
            <label for="surname" class="block font-bold mb-3">Surname</label>
            <input type="text" pInputText id="surname" [(ngModel)]="user.surname" required fluid />
            <small class="text-red-500" *ngIf="submitted && !user.surname">Surname is required.</small>
          </div>
          <div>
            <label for="email" class="block font-bold mb-3">Email Address</label>
            <input type="email" pInputText id="email" [(ngModel)]="user.emailAddress" required fluid />
            <small class="text-red-500" *ngIf="submitted && !user.emailAddress">Email is required.</small>
          </div>
          <div>
            <label class="block font-bold mb-3">Roles</label>
            <div class="flex flex-col gap-2">
              <div *ngFor="let role of roles" class="flex items-center">
                <p-checkbox [binary]="true" [ngModel]="checkedRolesMap[role.normalizedName]"
                            (ngModelChange)="onRoleChange(role, $event)"></p-checkbox>
                <label class="ml-2">{{ role.displayName }}</label>
              </div>
            </div>
          </div>
          <div class="flex items-center">
            <p-checkbox [binary]="true" [(ngModel)]="user.isActive" label="Is Active"></p-checkbox>
          </div>
        </div>
      </ng-template>
      <ng-template pTemplate="footer">
        <p-button label="Cancel" icon="pi pi-times" text (click)="hideDialog()" />
        <p-button label="Save" icon="pi pi-check" (click)="save()" [disabled]="saving" />
      </ng-template>
    </p-dialog>
  `,
  providers: [MessageService]
})
export class EditUserDialogComponent extends AppComponentBase implements OnInit {
  dialogVisible = false;

  saving = false;
  submitted = false;
  user = new UserDto();
  roles: RoleDto[] = [];
  checkedRolesMap: { [key: string]: boolean } = {};
  @Input() id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _userService: UserServiceProxy,
    private cd: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    if (this.id) {
      this.loadUserData();
    }
  }

  loadUserData(): void {
    this._userService.get(this.id).subscribe((result) => {
      this.user = result;
      this._userService.getRoles().subscribe((result2) => {
        this.roles = result2.items;
        this.setInitialRolesStatus();
        this.cd.detectChanges();
      });
    });
  }

  setInitialRolesStatus(): void {
    _map(this.roles, (item) => {
      this.checkedRolesMap[item.normalizedName] = this.isRoleChecked(item.normalizedName);
    });
  }

  isRoleChecked(normalizedName: string): boolean {
    return _includes(this.user.roleNames, normalizedName);
  }

  onRoleChange(role: RoleDto, checked: boolean) {
    this.checkedRolesMap[role.normalizedName] = checked;
  }

  getCheckedRoles(): string[] {
    const roles: string[] = [];
    _forEach(this.checkedRolesMap, (value, key) => {
      if (value) {
        roles.push(key);
      }
    });
    return roles;
  }

  save(): void {
    this.submitted = true;

    if (
      !this.user.name?.trim() ||
      !this.user.surname?.trim() ||
      !this.user.emailAddress?.trim()
    ) {
      return;
    }

    this.saving = true;
    this.user.roleNames = this.getCheckedRoles();

    this._userService.update(this.user).subscribe({
      next: () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.dialogVisible = false;
        this.onSave.emit();
        this.saving = false;
        this.cd.detectChanges();
      },
      error: () => {
        this.saving = false;
        this.cd.detectChanges();
      }
    });
  }

  show(): void {
    this.dialogVisible = true;
    this.submitted = false;
    this.user = new UserDto();
    this.checkedRolesMap = {};
    if (this.id) {
      this.loadUserData();
    }
    this.cd.detectChanges();
  }

  hideDialog(): void {
    this.dialogVisible = false;
    this.submitted = false;
    this.cd.markForCheck();
  }
}