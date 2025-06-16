// import {
//   Component,
//   OnInit,
//   EventEmitter,
//   Output,
//   Input,
//   OnChanges,
//   SimpleChanges,
//   ViewChild,
// } from '@angular/core';
// import { NgForm } from '@angular/forms';
// import {
//   CampusServiceProxy,
//   CampusDto,
// } from '@shared/service-proxies/service-proxies';
// import { MessageService } from 'primeng/api';
// import { finalize } from 'rxjs/operators';

// @Component({
//   selector: 'app-edit-campus-dialog',
//   templateUrl: 'edit-campus-dialog.component.html',
// })
// export class EditCampusDialogComponent implements OnInit, OnChanges {
//   @ViewChild('editCampusForm', { static: false }) editCampusForm: NgForm;
//   @Input() visible = false;
//   @Output() visibleChange = new EventEmitter<boolean>();
//   @Input() id: number;
//   @Output() onSave = new EventEmitter<void>();

//   saving = false;
//   campus = new CampusDto();

//   constructor(
//     private _campusService: CampusServiceProxy,
//     private _messageService: MessageService
//   ) {}

//   ngOnInit(): void {}

//   ngOnChanges(changes: SimpleChanges): void {
//     if (changes['visible'] && changes['visible'].currentValue && this.id) {
//       this._campusService.get(this.id).subscribe((result) => {
//         this.campus = result;
//       });
//     }
//   }

//   save(): void {
//     this.saving = true;
//     this._campusService
//       .update(this.campus)
//       .pipe(
//         finalize(() => {
//           this.saving = false;
//         })
//       )
//       .subscribe(() => {
//         this._messageService.add({ severity: 'success', summary: 'Success', detail: 'Campus updated successfully' });
//         this.closeDialog();
//         this.onSave.emit();
//       });
//   }

//   closeDialog(): void {
//     this.visible = false;
//     this.visibleChange.emit(this.visible);
//   }
// }
