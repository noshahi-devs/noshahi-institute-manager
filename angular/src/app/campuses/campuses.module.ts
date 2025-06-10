import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { CampusesRoutingModule } from './campuses-routing.module';
import { CampusesComponent } from './campuses.component';
import { CreateCampusDialogComponent } from './create-campus/create-campus-dialog.component';
import { EditCampusDialogComponent } from './edit-campus/edit-campus-dialog.component';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
        CampusesComponent,
        CreateCampusDialogComponent,
        EditCampusDialogComponent
    ],
    imports: [SharedModule, CampusesRoutingModule, CommonModule],
})
export class CampusesModule {}
