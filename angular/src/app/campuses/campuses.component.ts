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

//   



// import { Component, Injector, ChangeDetectorRef, OnInit } from '@angular/core';
// import { appModuleAnimation } from '@shared/animations/routerTransition';
// import { PagedListingComponentBase } from '@shared/paged-listing-component-base';
// import { CampusDto, CampusServiceProxy, CampusDtoPagedResultDto } from '@shared/service-proxies/service-proxies';

// import { LazyLoadEvent } from 'primeng/api';
// import { finalize } from 'rxjs/operators';

// @Component({
//   templateUrl: './campuses.component.html',
//   animations: [appModuleAnimation()],
// })
// export class CampusesComponent extends PagedListingComponentBase<CampusDto> implements OnInit {
//   campuses: CampusDto[] = [];
//   selectedCampuses: CampusDto[] = [];
//   createDialogVisible = false;
//   editDialogVisible = false;
//   selectedCampusId: number;
//   keyword = '';
//   isTableLoading = false;

//   constructor(
//     injector: Injector,
//     private _campusService: CampusServiceProxy,
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

//   refresh(): void {
//     this.list();
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

//   deleteSelectedCampuses(): void {
//     if (!this.selectedCampuses || this.selectedCampuses.length === 0) {
//       abp.message.warn(this.l('PleaseSelectAtLeastOneRecord'));
//       return;
//     }

//     abp.message.confirm(
//       this.l('CampusMultiDeleteWarningMessage', this.selectedCampuses.length),
//       undefined,
//       (result: boolean) => {
//         if (result) {
//           // Dummy loop to show intended delete flow
//           const deleteRequests = this.selectedCampuses.map((campus) =>
//             this._campusService.delete(campus.id)
//           );

//           Promise.all(deleteRequests.map((r) => r.toPromise())).then(() => {
//             abp.notify.success(this.l('SuccessfullyDeleted'));
//             this.selectedCampuses = [];
//             this.refresh();
//           });
//         }
//       }
//     );
//   }

//   createCampus(): void {
//     this.createDialogVisible = true;
//   }

//   editCampus(campus: CampusDto): void {
//     this.selectedCampusId = campus.id;
//     this.editDialogVisible = true;
//   }


// }


///Skai theme
// import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
// import { ConfirmationService, MessageService } from 'primeng/api';
// import { Table, TableModule } from 'primeng/table';
// import { CommonModule } from '@angular/common';
// import { FormsModule } from '@angular/forms';
// import { ButtonModule } from 'primeng/button';
// import { RippleModule } from 'primeng/ripple';
// import { ToastModule } from 'primeng/toast';
// import { ToolbarModule } from 'primeng/toolbar';
// import { InputTextModule } from 'primeng/inputtext';
// import { DialogModule } from 'primeng/dialog';
// import { ConfirmDialogModule } from 'primeng/confirmdialog';
// import { InputIconModule } from 'primeng/inputicon';
// import { IconFieldModule } from 'primeng/iconfield';
// import { InputTextarea } from 'primeng/inputtextarea';
// import { RatingModule } from 'primeng/rating';
// import { TextareaModule } from 'primeng/textarea';
// import { SelectModule } from 'primeng/select';
// import { RadioButtonModule } from 'primeng/radiobutton';
// import { InputNumberModule } from 'primeng/inputnumber';
// import { TagModule } from 'primeng/tag';
// import { CampusDto, CampusServiceProxy, CampusDtoPagedResultDto } from '@shared/service-proxies/service-proxies';
// import { finalize } from 'rxjs/operators'; // ← ADD THIS LINE


// @Component({
//     selector: 'app-campus',
//     standalone: true,
//     imports: [
//         TableModule,
//         CommonModule,
//         FormsModule,
//         ButtonModule,
//         RippleModule,
//         ToastModule,
//         ToolbarModule,
//         InputTextModule,
//         DialogModule,
//         ConfirmDialogModule,
//         InputIconModule,
//         IconFieldModule,
//         InputTextarea,
//         CommonModule,
//         FormsModule,
//         ButtonModule,
//         RippleModule,
//         ToastModule,
//         ToolbarModule,
//         RatingModule,
//         InputTextModule,
//         TextareaModule,
//         SelectModule,
//         RadioButtonModule,
//         InputNumberModule,
//         DialogModule,
//         TagModule,
//         InputIconModule,
//         IconFieldModule,
//         ConfirmDialogModule
//     ],
//     template: `
//         <p-toolbar styleClass="mb-6">
//             <ng-template #start>
//                 <p-button label="New" icon="pi pi-plus" (onClick)="openNew()" class="mr-2" />
//                 <p-button label="Delete" icon="pi pi-trash" (onClick)="deleteSelectedItems()" [disabled]="!selectedCampuses?.length" outlined />
//             </ng-template>
//         </p-toolbar>

//         <p-table #dt [value]="campuses" [(selection)]="selectedCampuses" dataKey="id" [paginator]="true" [rows]="10" [globalFilterFields]="['name']" [lazy]="true" (onLazyLoad)="loadItems($event)">
//             <ng-template #caption>
//                 <div class="flex items-center justify-between">
//                     <h5 class="m-0">Manage Campuses</h5>
//                     <p-iconfield>
//                         <p-inputicon styleClass="pi pi-search" />
//                         <input pInputText type="text" (input)="onGlobalFilter(dt, $event)" placeholder="Search..." />
//                     </p-iconfield>
//                 </div>
//             </ng-template>

//             <ng-template pTemplate="header">
//                 <tr>
//                     <th style="width: 3rem">
//                         <p-tableHeaderCheckbox></p-tableHeaderCheckbox>
//                     </th>
//                     <th>Name</th>
//                     <th style="width: 10rem"></th>
//                 </tr>
//             </ng-template>

//             <ng-template pTemplate="body" let-campus>
//                 <tr>
//                     <td>
//                         <p-tableCheckbox [value]="campus"></p-tableCheckbox>
//                     </td>
//                     <td>{{ campus.name }}</td>
//                     <td>
//                         <p-button icon="pi pi-pencil" class="mr-2" (click)="editItem(campus)" outlined></p-button>
//                         <p-button icon="pi pi-trash" severity="danger" (click)="deleteItem(campus)" outlined></p-button>
//                     </td>
//                 </tr>
//             </ng-template>
//         </p-table>



//                 <p-dialog [(visible)]="adeelDialog" [style]="{ width: '450px' }"  header="Campus Details"  [modal]="true">
//             <ng-template #content>
//                 <div class="flex flex-col gap-6">
//                     <div>
//                         <label for="name" class="block font-bold mb-3">Campus Name</label>
//                         <input type="text" pInputText id="name" [(ngModel)]="item.name" required autofocus fluid />
//                         <small class="text-red-500" *ngIf="submitted && !item.name">Name is required.</small>
//                     </div>
//                     <div>
//                         <label for="description" class="block font-bold mb-3">Address</label>
//                         <textarea id="description" pTextarea [(ngModel)]="item.address" required rows="3" cols="20" fluid></textarea>
//                     </div>

                  

//                 </div>
//             </ng-template>

//             <ng-template #footer>
//                 <p-button label="Cancel" icon="pi pi-times" text (click)="hideDialog()" />
//                 <p-button label="Save" icon="pi pi-check" (click)="saveItem()" />
//             </ng-template>
//         </p-dialog>






//         <p-confirmdialog></p-confirmdialog>

//         <pre style="margin-top:2rem;background:#f8f8f8;padding:1rem;border-radius:5px;max-height:300px;overflow:auto;">
//             {{ campuses | json }}
//         </pre>
//     `,
//     providers: [MessageService, ConfirmationService, CampusServiceProxy]
// })
// export class CampusesComponent implements OnInit {
//     adeelDialog:boolean=false;
//     saving = false;
//     campuses: CampusDto[] = [];
//     selectedCampuses: CampusDto[] = [];
//     private _itemDialog = false;
//   get itemDialog() {
//     return this._itemDialog;
//   }

  
//     submitted = false;
//     item: CampusDto = new CampusDto();

//     createDialogVisible: boolean = false;
//     editDialogVisible: boolean = false;

//     keyword = '';
//     totalItems = 0;
//     isTableLoading = false;

//     @ViewChild('dt') dt!: Table;

//     constructor(
//         private _campusService: CampusServiceProxy,
//         private messageService: MessageService,
//         private confirmationService: ConfirmationService,
//         private cdr: ChangeDetectorRef
//     ) {


//         console.log('global  adeelDialog set to', this.adeelDialog);
//         // Check if PrimeNG DialogModule is loaded
//         if (window && (window as any).PrimeNG) {
//             console.log('[constructor] PrimeNG loaded:', (window as any).PrimeNG);
//         } else {
//             console.warn('[constructor] PrimeNG not found on window');
//         }
//     }

//     ngOnInit(): void {
//         console.log('[ngOnInit] Component initialized');
//         // Lazy loading will trigger loadItems automatically
//     }

//     loadItems(event?: any): void {
//         console.log('[loadItems] Called with event:', event);
//         const skipCount = event ? event.first : 0;
//         const maxResultCount = event ? event.rows : 10;
//         console.log('[loadItems] skipCount:', skipCount, 'maxResultCount:', maxResultCount, 'keyword:', this.keyword);
//         console.log('[loadItems] Subscribing to _campusService.getAll...');
//         this._campusService.getAll(this.keyword, undefined, skipCount, maxResultCount).subscribe({
//             next: (result: CampusDtoPagedResultDto) => {
//                 console.log('[loadItems] Service result:', result);
//                 console.log('[loadItems] About to set campuses');
//                 this.campuses = result.items;
//                 this.totalItems = result.totalCount;
//                 console.log('[loadItems] campuses set:', this.campuses, 'totalItems:', this.totalItems);
//                 this.cdr.detectChanges();
//                 console.log('[loadItems] detectChanges called');
//                 if (this.campuses.length > 0) {
//                     console.log('[loadItems] first campus:', this.campuses[0]);
//                     console.log('[loadItems] typeof first campus:', typeof this.campuses[0]);
//                     console.log('[loadItems] keys of first campus:', Object.keys(this.campuses[0]));
//                 }
//             },
//             error: (error) => {
//                 console.error('[loadItems] Error:', error);
//             },
//             complete: () => {
//                 console.log('[loadItems] Observable complete');
//             }
//         });
//     }

//     openNew() {
//         console.log('[openNew] called');
//         this.item = new CampusDto();
//         this.submitted = false;
//         this.adeelDialog=true;
//         console.log('[openNew] adeelDialog set to', this.adeelDialog);
//     }

//     editItem(campus: CampusDto): void {
//         console.log('[editItem] called with', campus);
//         this.item = CampusDto.fromJS(campus);
//         this.adeelDialog=true;
//         console.log('[editItem] adeelDialog set to', this.adeelDialog);
//     }
//     hideDialog() {
//         this.adeelDialog = false;
//         this.submitted = false;
//         console.log('[hideDialog] adeelDialog set to', this.adeelDialog);
//     }

//     saveItem(): void {
//         this.submitted = true;
//         if (!this.item.name?.trim() || !this.item.address?.trim()) {
//             console.warn('[saveItem] Validation failed:', this.item);
//             return;
//         }
//         this.saving = true;
//         const createDto = new CampusDto();
//         createDto.init(this.item);
//         console.log('[saveItem] Creating campus:', createDto);
//         this._campusService
//           .create(createDto)
//           .pipe(finalize(() => {
//             this.saving = false;
//             console.log('[saveItem] Done saving');
//           }))
//           .subscribe(() => {
//             this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Campus created successfully' });
//             console.log('[saveItem] Campus created, closing dialog and reloading items');
//             this.loadItems();
//           }, error => {
//             console.error('[saveItem] Error creating campus:', error);
//           });
//           this.adeelDialog=false;
//           console.log('[saveItem] adeelDialog set to', this.adeelDialog);
//     }
    

//     deleteItem(campus: CampusDto): void {
//         this.confirmationService.confirm({
//             message: `Are you sure you want to delete ${campus.name}?`,
//             accept: () => {
//                 this._campusService.delete(campus.id).subscribe(() => {
//                     this.messageService.add({ severity: 'success', summary: 'Deleted', detail: `${campus.name} deleted` });
//                     this.loadItems();
//                 });
//             }
//         });
//     }

//     deleteSelectedItems(): void {
//         this.confirmationService.confirm({
//             message: 'Are you sure you want to delete the selected campuses?',
//             accept: () => {
//                 const deletes = this.selectedCampuses.map(c => this._campusService.delete(c.id));
//                 Promise.all(deletes.map(d => d.toPromise())).then(() => {
//                     this.messageService.add({ severity: 'success', summary: 'Deleted', detail: 'Selected campuses deleted' });
//                     this.selectedCampuses = [];
//                     this.loadItems();
//                 });
//             }
//         });
//     }



//     onGlobalFilter(table: Table, event: Event): void {
//         table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
//     }
// }


//Grok

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
import { InputTextarea } from 'primeng/inputtextarea';
import { RatingModule } from 'primeng/rating';
import { TextareaModule } from 'primeng/textarea';
import { SelectModule } from 'primeng/select';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputNumberModule } from 'primeng/inputnumber';
import { TagModule } from 'primeng/tag';
import { CampusDto, CampusServiceProxy, CampusDtoPagedResultDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'app-campus',
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
        InputTextarea,
        RatingModule,
        TextareaModule,
        SelectModule,
        RadioButtonModule,
        InputNumberModule,
        TagModule,
        ConfirmDialogModule
    ],
    template: `
        <p-toolbar styleClass="mb-6">
            <ng-template pTemplate="start">
                <p-button label="New" icon="pi pi-plus" (onClick)="openNew()" class="mr-2" />
                <p-button label="Delete" icon="pi pi-trash" (onClick)="deleteSelectedItems()" [disabled]="!selectedCampuses?.length" outlined />
            </ng-template>
        </p-toolbar>

        <p-table #dt [value]="campuses" [(selection)]="selectedCampuses" dataKey="id" [paginator]="true" [rows]="10" [globalFilterFields]="['name']" [lazy]="true" (onLazyLoad)="loadItems($event)">
            <ng-template pTemplate="caption">
                <div class="flex items-center justify-between">
                    <h5 class="m-0">Manage Campuses</h5>
                    <p-iconfield>
                        <p-inputicon styleClass="pi pi-search" />
                        <input pInputText type="text" (input)="onGlobalFilter(dt, $event)" placeholder="Search..." />
                    </p-iconfield>
                </div>
            </ng-template>

            <ng-template pTemplate="header">
                <tr>
                    <th style="width: 3rem">
                        <p-tableHeaderCheckbox></p-tableHeaderCheckbox>
                    </th>
                    <th>Campus Name</th>
                    <th>Address</th>
                    <th>Action</th>
                </tr>
            </ng-template>

            <ng-template pTemplate="body" let-campus>
                <tr>
                    <td>
                        <p-tableCheckbox [value]="campus"></p-tableCheckbox>
                    </td>
                    <td>{{ campus.name }}</td>
                    <td>{{ campus.address }}</td>
                    <td>
                        <p-button icon="pi pi-pencil" class="mr-2" (click)="editItem(campus)" outlined></p-button>
                        <p-button icon="pi pi-trash" severity="danger" (click)="deleteItem(campus)" outlined></p-button>
                    </td>
                </tr>
            </ng-template>
        </p-table>

        <p-dialog [(visible)]="itemDialog" [style]="{ width: '450px' }" header="Campus Details" [modal]="true" (onHide)="hideDialog()" (visibleChange)="onVisibleChange($event)">
            <ng-template pTemplate="content">
                <div class="flex flex-col gap-6">
                    <div>
                        <label for="name" class="block font-bold mb-3">Campus Name</label>
                        <input type="text" pInputText id="name" [(ngModel)]="item.name" required autofocus fluid />
                        <small class="text-red-500" *ngIf="submitted && !item.name">Name is required.</small>
                    </div>
                    <div>
                        <label for="description" class="block font-bold mb-3">Address</label>
                        <textarea id="description" pTextarea [(ngModel)]="item.address" required rows="3" cols="20" fluid></textarea>
                    </div>
                </div>
            </ng-template>

            <ng-template pTemplate="footer">
                <p-button label="Cancel" icon="pi pi-times" text (click)="hideDialog()" />
                <p-button label="Save" icon="pi pi-check" (click)="saveItem()" />
                <p-button label="Test Close" (click)="testClose()" text /> <!-- Added for debugging -->
            </ng-template>
        </p-dialog>

        <p-confirmdialog></p-confirmdialog>

        <pre style="margin-top:2rem;background:#f8f8f8;padding:1rem;border-radius:5px;max-height:300px;overflow:auto;">
            {{ campuses | json }}
        </pre>
    `,
    providers: [MessageService, ConfirmationService, CampusServiceProxy]
})
export class CampusesComponent implements OnInit {
    saving = false;
    campuses: CampusDto[] = [];
    selectedCampuses: CampusDto[] = [];
    itemDialog = false;
    submitted = false;
    item: CampusDto = new CampusDto();

    keyword = '';
    totalItems = 0;
    isTableLoading = false;

    @ViewChild('dt') dt!: Table;

    constructor(
        private _campusService: CampusServiceProxy,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private cdr: ChangeDetectorRef
    ) {
        console.log('[Constructor] CampusesComponent instantiated');
        console.log('[Constructor] PrimeNG DialogModule imported:', !!DialogModule);
        console.log('[Constructor] Initial itemDialog state:', this.itemDialog);
        // Check if PrimeNG is available
        try {
            console.log('[Constructor] PrimeNG version:', require('primeng/package.json').version);
            console.log('[Constructor] PrimeIcons version:', require('primeicons/package.json').version);
        } catch (e) {
            console.error('[Constructor] PrimeNG or PrimeIcons not found:', e);
        }
    }

    ngOnInit(): void {
        console.log('[ngOnInit] Component initialized');
        console.log('[ngOnInit] Initial item state:', this.item);
        console.log('[ngOnInit] Initial campuses array:', this.campuses);
        console.log('[ngOnInit] Initial selectedCampuses:', this.selectedCampuses);
        this.loadItems();
    }

    loadItems(event?: any): void {
        console.log('[loadItems] Called with event:', event);
        this.isTableLoading = true;
        console.log('[loadItems] isTableLoading set to true');
        const skipCount = event ? event.first : 0;
        const maxResultCount = event ? event.rows : 10;
        console.log('[loadItems] skipCount:', skipCount, 'maxResultCount:', maxResultCount, 'keyword:', this.keyword);
        console.log('[loadItems] Subscribing to _campusService.getAll...');

        this._campusService.getAll(this.keyword, undefined, skipCount, maxResultCount)
            .pipe(
                finalize(() => {
                    console.log('[loadItems] finalize: Setting isTableLoading to false');
                    this.isTableLoading = false;
                    this.cdr.detectChanges();
                    console.log('[loadItems] finalize: detectChanges called');
                })
            )
            .subscribe({
                next: (result: CampusDtoPagedResultDto) => {
                    console.log('[loadItems] Service result:', result);
                    console.log('[loadItems] Setting campuses and totalItems');
                    this.campuses = result.items;
                    this.totalItems = result.totalCount;
                    console.log('[loadItems] campuses:', this.campuses, 'totalItems:', this.totalItems);
                    this.cdr.detectChanges();
                    console.log('[loadItems] detectChanges called after setting data');
                    if (this.campuses.length > 0) {
                        console.log('[loadItems] First campus:', this.campuses[0]);
                        console.log('[loadItems] Type of first campus:', typeof this.campuses[0]);
                        console.log('[loadItems] Keys of first campus:', Object.keys(this.campuses[0]));
                    }
                },
                error: (error) => {
                    console.error('[loadItems] Error:', error);
                },
                complete: () => {
                    console.log('[loadItems] Observable complete');
                }
            });
    }

    openNew() {
        console.log('[openNew] Opening new campus dialog');
        console.log('[openNew] Current itemDialog state:', this.itemDialog);
        this.item = new CampusDto();
        this.submitted = false;
        this.itemDialog = true;
        console.log('[openNew] itemDialog set to:', this.itemDialog);
        console.log('[openNew] New item initialized:', this.item);
        this.cdr.detectChanges();
        console.log('[openNew] detectChanges called');
    }

    editItem(campus: CampusDto): void {
        console.log('[editItem] Editing campus:', campus);
        console.log('[editItem] Current itemDialog state:', this.itemDialog);
        this.item = CampusDto.fromJS(campus);
        this.itemDialog = true;
        console.log('[editItem] itemDialog set to:', this.itemDialog);
        console.log('[editItem] Item set to:', this.item);
        this.cdr.detectChanges();
        console.log('[editItem] detectChanges called');
    }

    saveItem(): void {
        console.log('[saveItem] Saving item:', this.item);
        this.submitted = true;
        if (!this.item.name?.trim() || !this.item.address?.trim()) {
            console.warn('[saveItem] Validation failed:', this.item);
            return;
        }
        this.saving = true;
        console.log('[saveItem] saving set to:', this.saving);
        const createDto = new CampusDto();
        createDto.init(this.item);
        console.log('[saveItem] Creating campus with DTO:', createDto);
        this._campusService
            .create(createDto)
            .pipe(
                finalize(() => {
                    console.log('[saveItem] finalize: Setting saving to false');
                    this.saving = false;
                    this.cdr.detectChanges();
                    console.log('[saveItem] finalize: detectChanges called');
                })
            )
            .subscribe({
                next: () => {
                    console.log('[saveItem] Campus created successfully');
                    this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Campus created successfully' });
                    this.itemDialog = false;
                    console.log('[saveItem] itemDialog set to:', this.itemDialog);
                    this.loadItems();
                    console.log('[saveItem] loadItems called');
                    this.cdr.detectChanges();
                    console.log('[saveItem] detectChanges called');
                },
                error: (error) => {
                    console.error('[saveItem] Error creating campus:', error);
                },
                complete: () => {
                    console.log('[saveItem] Observable complete');
                }
            });
    }

    deleteItem(campus: CampusDto): void {
        console.log('[deleteItem] Deleting campus:', campus);
        this.confirmationService.confirm({
            message: `Are you sure you want to delete ${campus.name}?`,
            accept: () => {
                console.log('[deleteItem] Delete confirmed for campus:', campus);
                this._campusService.delete(campus.id).subscribe({
                    next: () => {
                        console.log('[deleteItem] Campus deleted successfully');
                        this.messageService.add({ severity: 'success', summary: 'Deleted', detail: `${campus.name} deleted` });
                        this.loadItems();
                        console.log('[deleteItem] loadItems called');
                    },
                    error: (error) => {
                        console.error('[deleteItem] Error deleting campus:', error);
                    }
                });
            },
            reject: () => {
                console.log('[deleteItem] Delete cancelled for campus:', campus);
            }
        });
    }

    deleteSelectedItems(): void {
        console.log('[deleteSelectedItems] Deleting selected campuses:', this.selectedCampuses);
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete the selected campuses?',
            accept: () => {
                console.log('[deleteSelectedItems] Delete confirmed for campuses:', this.selectedCampuses);
                const deletes = this.selectedCampuses.map(c => this._campusService.delete(c.id));
                Promise.all(deletes.map(d => d.toPromise())).then(() => {
                    console.log('[deleteSelectedItems] Selected campuses deleted successfully');
                    this.messageService.add({ severity: 'success', summary: 'Deleted', detail: 'Selected campuses deleted' });
                    this.selectedCampuses = [];
                    this.loadItems();
                    console.log('[deleteSelectedItems] loadItems called');
                });
            },
            reject: () => {
                console.log('[deleteSelectedItems] Delete cancelled');
            }
        });
    }

    hideDialog(): void {
        console.log('[hideDialog] Called');
        console.log('[hideDialog] Current itemDialog state:', this.itemDialog);
        this.itemDialog = false;
        this.submitted = false;
        console.log('[hideDialog] itemDialog set to:', this.itemDialog);
        console.log('[hideDialog] submitted set to:', this.submitted);
        this.cdr.markForCheck();
        console.log('[hideDialog] markForCheck called');
    }

    testClose(): void {
        console.log('[testClose] Manual close triggered');
        this.hideDialog();
    }

    onVisibleChange(visible: boolean): void {
        console.log('[onVisibleChange] Dialog visibility changed to:', visible);
        console.log('[onVisibleChange] Current itemDialog state:', this.itemDialog);
    }

    onGlobalFilter(table: Table, event: Event): void {
        console.log('[onGlobalFilter] Filtering with value:', (event.target as HTMLInputElement).value);
        table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
    }

    ngAfterViewInit(): void {
        console.log('[ngAfterViewInit] View initialized');
        console.log('[ngAfterViewInit] Table reference:', this.dt);
    }

    ngOnDestroy(): void {
        console.log('[ngOnDestroy] Component destroying');
    }
}