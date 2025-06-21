import { CommonModule } from '@angular/common';
import { Component, OnInit, signal, ViewChild, ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { FileUploadModule } from 'primeng/fileupload';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { InputTextModule } from 'primeng/inputtext';
import { Table, TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';

interface SchoolModel {
    id: string;
    name: string;
    code: string;
    address: string;
    contactNumber: string;
    email?: string;
    principalName: string;
    principalContact?: string;
    status: 'Active' | 'Inactive';
}

@Component({
    selector: 'app-school',
    template: `
    <div class="grid grid-cols-12 gap-4 mb-6">
  <div class="col-span-12 lg:col-span-6 xl:col-span-3">
    <div class="card mb-0">
      <div class="flex justify-between mb-4">
        <div>
          <span class="block text-muted-color font-medium mb-4">Active Schools</span>
          <div class="text-surface-900 dark:text-surface-0 font-medium text-xl">12</div>
        </div>
        <div class="flex items-center justify-center bg-green-100 dark:bg-green-400/10 rounded-border" style="width: 2.5rem; height: 2.5rem">
          <i class="pi pi-building text-green-500 !text-xl"></i>
        </div>
      </div>
      <span class="text-primary font-medium">3 newly activated</span>
      <span class="text-muted-color">since last update</span>
    </div>
  </div>

  <div class="col-span-12 lg:col-span-6 xl:col-span-3">
    <div class="card mb-0">
      <div class="flex justify-between mb-4">
        <div>
          <span class="block text-muted-color font-medium mb-4">Updated Schools</span>
          <div class="text-surface-900 dark:text-surface-0 font-medium text-xl">5</div>
        </div>
        <div class="flex items-center justify-center bg-yellow-100 dark:bg-yellow-400/10 rounded-border" style="width: 2.5rem; height: 2.5rem">
          <i class="pi pi-refresh text-yellow-500 !text-xl"></i>
        </div>
      </div>
      <span class="text-primary font-medium">2 just now</span>
      <span class="text-muted-color">manually updated</span>
    </div>
  </div>

  <div class="col-span-12 lg:col-span-6 xl:col-span-3">
    <div class="card mb-0">
      <div class="flex justify-between mb-4">
        <div>
          <span class="block text-muted-color font-medium mb-4">Total Schools</span>
          <div class="text-surface-900 dark:text-surface-0 font-medium text-xl">20</div>
        </div>
        <div class="flex items-center justify-center bg-blue-100 dark:bg-blue-400/10 rounded-border" style="width: 2.5rem; height: 2.5rem">
          <i class="pi pi-database text-blue-500 !text-xl"></i>
        </div>
      </div>
      <span class="text-primary font-medium">+1</span>
      <span class="text-muted-color">added today</span>
    </div>
  </div>

  <div class="col-span-12 lg:col-span-6 xl:col-span-3">
    <div class="card mb-0">
      <div class="flex justify-between mb-4">
        <div>
          <span class="block text-muted-color font-medium mb-4">Pending Approval</span>
          <div class="text-surface-900 dark:text-surface-0 font-medium text-xl">3</div>
        </div>
        <div class="flex items-center justify-center bg-red-100 dark:bg-red-400/10 rounded-border" style="width: 2.5rem; height: 2.5rem">
          <i class="pi pi-clock text-red-500 !text-xl"></i>
        </div>
      </div>
      <span class="text-primary font-medium">Waiting</span>
      <span class="text-muted-color">for admin review</span>
    </div>
  </div>
</div>

  <p-toolbar styleClass="mb-6">
  <ng-template #start>
    <p-button label="New" icon="pi pi-plus" severity="secondary" class="mr-2" (onClick)="openNew()" />
    <p-button label="Delete" icon="pi pi-trash" severity="danger" outlined class="mr-2" (onClick)="deleteSelectedSchools()" [disabled]="!selectedSchools || !selectedSchools.length" />
  </ng-template>
  <ng-template #end>
    <p-button label="Export" icon="pi pi-upload" severity="secondary" (onClick)="exportCSV()" />
  </ng-template>
</p-toolbar>

<p-table
  #dt
  [value]="schools"
  [rows]="10"
  [paginator]="true"
  [globalFilterFields]="['name', 'address', 'contactNumber', 'email']"
  [(selection)]="selectedSchools"
  [rowHover]="true"
  dataKey="id"
  currentPageReportTemplate="Showing {first} to {last} of {totalRecords} schools"
  [showCurrentPageReport]="true"
  [rowsPerPageOptions]="[10, 20, 30]"
  (selectionChange)="onSelectionChange($event)"
>
  <ng-template #caption>
    <div class="flex items-center justify-between">
      <h5 class="m-0">Manage Schools</h5>
      <p-iconfield>
        <p-inputicon styleClass="pi pi-search" />
        <input pInputText type="text" (input)="onGlobalFilter(dt, $event)" placeholder="Search..." />
      </p-iconfield>
    </div>
  </ng-template>
  <ng-template #header>
    <tr>
      <th style="width: 3rem"><p-tableHeaderCheckbox /></th>
      <th>School Name</th>
      <th>Address</th>
      <th>Contact Number</th>
      <th>Email</th>
      <th>Status</th>
      <th style="min-width: 10rem">Actions</th>
    </tr>
  </ng-template>
  <ng-template #body let-school>
    <tr (click)="viewSchool(school)" style="cursor:pointer;">
      <td (click)="$event.stopPropagation()"><p-tableCheckbox [value]="school" /></td>
      <td>{{ school.name }}</td>
      <td>{{ school.address }}</td>
      <td>{{ school.contactNumber }}</td>
      <td>{{ school.email }}</td>
      <td><p-tag [value]="school.status" [severity]="school.status === 'Active' ? 'success' : 'danger'" /></td>
      <td>
        <p-button icon="pi pi-eye" class="mr-2" [rounded]="true" [outlined]="true" (click)="viewSchool(school); $event.stopPropagation()" />
      </td>
    </tr>
  </ng-template>
</p-table>

<p-dialog [(visible)]="schoolDialog" [style]="{ width: '500px' }" header="School Details" [modal]="true" (onHide)="cancelDialog()">
  <ng-template #content>
    <div class="flex flex-col gap-6">
      <div class="flex justify-between items-center mb-3">
        <p-button *ngIf="dialogMode === 'view'" icon="pi pi-pencil" label="Edit" (click)="enableEdit()" />
      </div>
      <div>
        <label for="name" class="block font-bold mb-3">School Name</label>
        <input pInputText type="text" id="name" [(ngModel)]="selectedSchool.name" [readonly]="dialogMode === 'view'" required autofocus style="width:100%" [ngClass]="{'border-red-500': submitted && !selectedSchool.name?.trim()}" />
        <small class="text-red-500" *ngIf="submitted && !selectedSchool.name?.trim()">School name is required.</small>
      </div>
      <div>
        <label for="address" class="block font-bold mb-3">Address</label>
        <textarea pTextarea id="address" [(ngModel)]="selectedSchool.address" [readonly]="dialogMode === 'view'" required rows="3" style="width:100%" [ngClass]="{'border-red-500': submitted && !selectedSchool.address?.trim()}"></textarea>
        <small class="text-red-500" *ngIf="submitted && !selectedSchool.address?.trim()">Address is required.</small>
      </div>
      <div>
        <label for="contactNumber" class="block font-bold mb-3">Contact Number</label>
        <input pInputText type="text" id="contactNumber" [(ngModel)]="selectedSchool.contactNumber" [readonly]="dialogMode === 'view'" required style="width:100%" [ngClass]="{'border-red-500': submitted && !selectedSchool.contactNumber?.trim()}" />
        <small class="text-red-500" *ngIf="submitted && !selectedSchool.contactNumber?.trim()">Contact number is required.</small>
      </div>
      <div>
        <label for="email" class="block font-bold mb-3">Email</label>
        <input pInputText type="email" id="email" [(ngModel)]="selectedSchool.email" [readonly]="dialogMode === 'view'" style="width:100%" />
      </div>
      <div>
        <label for="status" class="block font-bold mb-3">Status</label>
        <p-dropdown id="status" [(ngModel)]="selectedSchool.status" [options]="statuses" optionLabel="label" [optionValue]="'value'" placeholder="Select Status" [disabled]="dialogMode === 'view'" appendTo="body" required [ngClass]="{'border-red-500': submitted && !selectedSchool.status?.trim()}"></p-dropdown>
        <small class="text-red-500" *ngIf="submitted && !selectedSchool.status?.trim()">Status is required.</small>
      </div>
    </div>
  </ng-template>
  <ng-template #footer>
    <p-button label="Cancel" icon="pi pi-times" text (click)="cancelDialog()"></p-button>
    <p-button *ngIf="dialogMode === 'edit'" label="Save" icon="pi pi-check" (click)="saveSchool()"></p-button>
    <p-button *ngIf="selectedSchool.id" label="Delete" icon="pi pi-trash" severity="danger" (click)="deleteSchool(selectedSchool)"></p-button>
  </ng-template>
</p-dialog>

<p-confirmdialog [style]="{ width: '450px' }" />
<p-toast position="top-right" />

    `,
    styles: [`
        .pdf-style-view {
            font-family: 'Times New Roman', Times, serif;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        .pdf-style-view .field {
            margin-bottom: 15px;
        }
        .pdf-style-view label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }
    `],
    providers: [MessageService, ConfirmationService]
})
export class SchoolsComponent {
    constructor(
      private confirmationService: ConfirmationService,
      private messageService: MessageService
    ) {}
  
    schools: any[] = [
      {
        id: 's1',
        name: 'Noshahi Public School',
        address: 'Gulberg, Lahore',
        contactNumber: '03001234567',
        email: 'info@nps.edu.pk',
        status: 'Active',
      },
      {
        id: 's2',
        name: 'City Model High',
        address: 'DHA, Lahore',
        contactNumber: '03007654321',
        email: 'admin@citymodel.edu.pk',
        status: 'Inactive',
      },
    ];
  
    selectedSchools: any[] = [];
    selectedSchool: any = {};
    schoolDialog = false;
    dialogMode: 'view' | 'edit' = 'view';
    submitted = false;
  
    statuses = [
      { label: 'Active', value: 'Active' },
      { label: 'Inactive', value: 'Inactive' },
    ];
  
    openNew() {
      this.selectedSchool = {};
      this.dialogMode = 'edit';
      this.submitted = false;
      this.schoolDialog = true;
    }
  
    viewSchool(school: any) {
      this.selectedSchool = { ...school };
      this.dialogMode = 'view';
      this.schoolDialog = true;
    }
  
    enableEdit() {
      this.confirmationService.confirm({
        message: 'Do you want to edit this school?',
        header: 'Confirm Edit',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.dialogMode = 'edit';
        },
      });
    }
  
    cancelDialog() {
      this.schoolDialog = false;
      this.selectedSchool = {};
    }
  
    saveSchool() {
      this.submitted = true;
  
      if (
        !this.selectedSchool.name?.trim() ||
        !this.selectedSchool.address?.trim() ||
        !this.selectedSchool.contactNumber?.trim() ||
        !this.selectedSchool.status?.trim()
      ) {
        this.messageService.add({
          severity: 'error',
          summary: 'Validation Error',
          detail: 'Please fill in all required fields.',
        });
        return;
      }
  
      this.confirmationService.confirm({
        message: 'Do you want to save this school?',
        header: 'Confirm Save',
        icon: 'pi pi-check-circle',
        accept: () => {
          if (this.selectedSchool.id) {
            const index = this.schools.findIndex((s) => s.id === this.selectedSchool.id);
            this.schools[index] = this.selectedSchool;
            this.messageService.add({ severity: 'success', summary: 'Updated', detail: 'School updated successfully' });
          } else {
            this.selectedSchool.id = this.createId();
            this.schools.push(this.selectedSchool);
            this.messageService.add({ severity: 'success', summary: 'Saved', detail: 'School saved successfully' });
          }
  
          this.schoolDialog = false;
          this.selectedSchool = {};
        },
      });
    }
  
    deleteSelectedSchools() {
      if (!this.selectedSchools || this.selectedSchools.length === 0) {
        this.messageService.add({ severity: 'warn', summary: 'No Selection', detail: 'Please select schools to delete.' });
        return;
      }
  
      this.confirmationService.confirm({
        message: 'Are you sure you want to delete selected schools?',
        header: 'Confirm Bulk Delete',
        icon: 'pi pi-trash',
        accept: () => {
          this.schools = this.schools.filter((s) => !this.selectedSchools.includes(s));
          this.selectedSchools = [];
          this.messageService.add({ severity: 'success', summary: 'Deleted', detail: 'Selected schools deleted' });
        },
      });
    }
  
    deleteSchool(school: any) {
      this.confirmationService.confirm({
        message: 'Are you sure you want to delete this school?',
        header: 'Confirm Delete',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.schools = this.schools.filter((s) => s.id !== school.id);
          this.messageService.add({ severity: 'success', summary: 'Deleted', detail: 'School deleted' });
          this.schoolDialog = false;
          this.selectedSchool = {};
        },
      });
    }
  
    onGlobalFilter(table: any, event: any) {
      table.filterGlobal(event.target.value, 'contains');
    }
  
    onSelectionChange(event: any) {
      this.selectedSchools = event.value;
    }
  
    exportCSV() {
      this.confirmationService.confirm({
        message: 'Do you want to export schools to CSV?',
        header: 'Confirm Export',
        icon: 'pi pi-upload',
        accept: () => {
          console.log('Exported!');
          this.messageService.add({ severity: 'success', summary: 'Exported', detail: 'Schools exported to CSV' });
        },
      });
    }
  
    private createId(): string {
      return Math.random().toString(36).substring(2, 9);
    }
  }
  
