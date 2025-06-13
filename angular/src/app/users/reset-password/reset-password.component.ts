// import { Component, OnInit, Injector } from '@angular/core';
// import { AppComponentBase } from '@shared/app-component-base';
// import {
//   UserServiceProxy,
//   ResetPasswordDto
// } from '@shared/service-proxies/service-proxies';
// import { BsModalRef } from 'ngx-bootstrap/modal';

// @Component({
//   selector: 'app-reset-password',
//   templateUrl: './reset-password.component.html'
// })
// export class ResetPasswordDialogComponent extends AppComponentBase
//   implements OnInit {
//   public isLoading = false;
//   public resetPasswordDto: ResetPasswordDto;
//   id: number;

//   constructor(
//     injector: Injector,
//     private _userService: UserServiceProxy,
//     public bsModalRef: BsModalRef
//   ) {
//     super(injector);
//   }

//   ngOnInit() {
//     this.isLoading = true;
//     this.resetPasswordDto = new ResetPasswordDto();
//     this.resetPasswordDto.userId = this.id;
//     this.resetPasswordDto.newPassword = Math.random()
//       .toString(36)
//       .substr(2, 10);
//     this.isLoading = false;
//   }

//   public resetPassword(): void {
//     this.isLoading = true;
//     this._userService.resetPassword(this.resetPasswordDto).subscribe(
//       () => {
//         this.notify.info('Password Reset');
//         this.bsModalRef.hide();
//       },
//       () => {
//         this.isLoading = false;
//       }
//     );
//   }
// }
import { Component, OnInit, Injector, Input, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { AppComponentBase } from '@shared/app-component-base';
import {
  UserServiceProxy,
  ResetPasswordDto
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-reset-password',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    ToastModule
  ],
  template: `
    <p-toast></p-toast>
    <p-dialog [(visible)]="dialogVisible" [style]="{ width: '450px' }" header="Reset Password" [modal]="true" (onHide)="hideDialog()">
      <ng-template pTemplate="content">
        <form autocomplete="off">
          <div class="flex flex-col gap-6 p-3">
            <div>
              <label for="newPassword" class="block font-bold mb-3">New Password</label>
              <input type="password" pInputText id="newPassword" name="newPassword" [(ngModel)]="resetPasswordDto.newPassword" 
                     required minlength="8" pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$" fluid autofocus />
              <small class="text-red-500" *ngIf="submitted && (!resetPasswordDto.newPassword || resetPasswordDto.newPassword.length < 8)">
                Password is required and must be at least 8 characters.
              </small>
            </div>
          </div>
        </form>
      </ng-template>
      <ng-template pTemplate="footer">
        <p-button label="Cancel" icon="pi pi-times" text (click)="hideDialog()" [disabled]="isLoading" />
        <p-button label="Reset" icon="pi pi-check" (click)="resetPassword()" [disabled]="isLoading || !resetPasswordDto.newPassword || resetPasswordDto.newPassword.length < 8" />
      </ng-template>
    </p-dialog>
  `,
  providers: [MessageService]
})
export class ResetPasswordDialogComponent extends AppComponentBase implements OnInit {
  dialogVisible = false;
  isLoading = false;
  submitted = false;
  resetPasswordDto = new ResetPasswordDto();
  @Input() id: number;

  constructor(
    injector: Injector,
    private _userService: UserServiceProxy,
    private cd: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(): void {
    this.isLoading = true;
    this.resetPasswordDto = new ResetPasswordDto();
    this.resetPasswordDto.userId = this.id;
    this.resetPasswordDto.newPassword = Math.random().toString(36).substr(2, 10);
    this.isLoading = false;
    this.cd.detectChanges();
  }

  resetPassword(): void {
    this.submitted = true;

    if (!this.resetPasswordDto.newPassword?.trim()) {
      return;
    }

    this.isLoading = true;
    this._userService.resetPassword(this.resetPasswordDto).subscribe({
      next: () => {
        this.notify.info(this.l('Password Reset'));
        this.dialogVisible = false;
        this.isLoading = false;
        this.cd.detectChanges();
      },
      error: () => {
        this.isLoading = false;
        this.cd.detectChanges();
      }
    });
  }

  show(): void {
    this.dialogVisible = true;
    this.submitted = false;
    this.initializeForm();
    this.cd.detectChanges();
  }

  hideDialog(): void {
    this.dialogVisible = false;
    this.submitted = false;
    this.cd.markForCheck();
  }
}