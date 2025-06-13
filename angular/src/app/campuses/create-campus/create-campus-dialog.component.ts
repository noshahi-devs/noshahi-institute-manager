import { Component, OnInit, EventEmitter, Output, ChangeDetectorRef, Injector } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { CampusServiceProxy, CreateCampusDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-create-campus-dialog',
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
    <p-dialog [(visible)]="dialogVisible" [style]="{ width: '450px' }" header="Create User" [modal]="true" (onHide)="hideDialog()">
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
            <label for="password" class="block font-bold mb-3">Password</label>
            <input type="password" pInputText id="password" [(ngModel)]="user.password" required fluid
                   pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$" />
            <small class="text-red-500" *ngIf="submitted && !user.password">
              Password is required.
            </small>
            <small class="text-red-500" *ngIf="passwordInvalid">
              {{ passwordValidationErrors[0].localizationKey | abpLocalization }}
            </small>
          </div>
          <div>
            <label for="confirmPassword" class="block font-bold mb-3">Confirm Password</label>
            <input type="password" pInputText id="confirmPassword" [(ngModel)]="confirmPassword" required fluid />
            <small class="text-red-500" *ngIf="submitted && !confirmPassword">
              Confirm Password is required.
            </small>
            <small class="text-red-500" *ngIf="passwordsDoNotMatch">
              {{ confirmPasswordValidationErrors[0].localizationKey | abpLocalization }}
            </small>
          </div>
          <div>
            <label class="block font-bold mb-3">Roles</label>
            <div class="flex flex-col gap-2">
              <div *ngFor="let role of roles" class="flex items-center">
                <p-checkbox [binary]="true" [ngModel]="checkedRolesMap[role.normalizedName]"
                            (ngModelChange)="onRoleChange(role, $event)" [label]="role.displayName"></p-checkbox>
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
export class CreateUserDialogComponent extends AppComponentBase implements OnInit {
  dialogVisible = false;
  saving = false;
  submitted = false;
  user = new CreateUserDto();
  roles: RoleDto[] = [];
  checkedRolesMap: { [key: string]: boolean } = {};
  defaultRoleCheckedStatus = false;
  confirmPassword = '';
  passwordInvalid = false;
  passwordsDoNotMatch = false;

  passwordValidationErrors: Partial<AbpValidationError>[] = [
    {
      name: 'pattern',
      localizationKey: 'PasswordsMustBeAtLeast8CharactersContainLowercaseUppercaseNumber',
    },
  ];
  confirmPasswordValidationErrors: Partial<AbpValidationError>[] = [
    {
      name: 'validateEqual',
      localizationKey: 'PasswordsDoNotMatch',
    },
  ];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _userService: UserServiceProxy,
    private cd: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.user.isActive = true;
    this._userService.getRoles().subscribe((result) => {
      this.roles = result.items;
      this.setInitialRolesStatus();
      this.cd.detectChanges();
    });
  }

  setInitialRolesStatus(): void {
    _map(this.roles, (item) => {
      this.checkedRolesMap[item.normalizedName] = this.isRoleChecked(item.normalizedName);
    });
  }

  isRoleChecked(normalizedName: string): boolean {
    return this.defaultRoleCheckedStatus;
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

    // Validate password pattern
    const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$/;
    this.passwordInvalid = this.user.password ? !passwordRegex.test(this.user.password) : true;

    // Validate confirm password
    this.passwordsDoNotMatch = this.user.password !== this.confirmPassword;

    if (
      !this.user.name?.trim() ||
      !this.user.surname?.trim() ||
      !this.user.emailAddress?.trim() ||
      !this.user.password?.trim() ||
      !this.confirmPassword?.trim() ||
      this.passwordInvalid ||
      this.passwordsDoNotMatch
    ) {
      return;
    }

    this.saving = true;
    this.user.roleNames = this.getCheckedRoles();

    this._userService.create(this.user).subscribe({
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
    this.user = new CreateUserDto();
    this.user.isActive = true;
    this.confirmPassword = '';
    this.checkedRolesMap = {};
    this.setInitialRolesStatus();
    this.cd.detectChanges();
  }

  hideDialog(): void {
    this.dialogVisible = false;
    this.submitted = false;
    this.cd.markForCheck();
  }
