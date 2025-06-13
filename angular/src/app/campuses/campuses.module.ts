import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { CampusesRoutingModule } from './campuses-routing.module';
import { CampusesComponent } from './campuses.component';
// import { CreateCampusDialogComponent } from './create-campus/create-campus-dialog.component';
// import { EditCampusDialogComponent } from './edit-campus/edit-campus-dialog.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';
import { CardModule } from 'primeng/card';
import { PaginatorModule } from 'primeng/paginator';
import { InputGroupModule } from 'primeng/inputgroup';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { ToolbarModule } from 'primeng/toolbar';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { MessageService } from 'primeng/api';
import { InputTextarea } from 'primeng/inputtextarea';
import { FloatLabelModule } from 'primeng/floatlabel';




@NgModule({
    declarations: [
        // CreateCampusDialogComponent,
        // EditCampusDialogComponent
    ],
    imports: [
        CampusesComponent,
        SharedModule, 
        CampusesRoutingModule, 
        CommonModule, 
        FormsModule,
        TableModule,
        ButtonModule,
        InputTextModule,
        DropdownModule,
        CalendarModule,
        DialogModule,
        ToastModule,
        CardModule,
        PaginatorModule,
        InputGroupModule,
        IconFieldModule,
        InputIconModule,
        ToolbarModule,
        ServiceProxyModule,
        InputTextarea,
        FloatLabelModule,
    
    ],
    providers: [ MessageService ]
})
export class CampusesModule {}
