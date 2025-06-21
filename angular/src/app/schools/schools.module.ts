import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '@shared/shared.module';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SchoolsRoutingModule } from './schools-routing.module';
import { SchoolsComponent } from './schools.component';

// PrimeNG Modules
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { CardModule } from 'primeng/card';
import { CheckboxModule } from 'primeng/checkbox';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { FloatLabelModule } from 'primeng/floatlabel';
import { IconFieldModule } from 'primeng/iconfield';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputIconModule } from 'primeng/inputicon';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextarea } from 'primeng/inputtextarea';
import { PaginatorModule } from 'primeng/paginator';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';

// PrimeNG Services
import { ConfirmationService, MessageService } from 'primeng/api';

@NgModule({
    declarations: [
        SchoolsComponent,
        // CreateCampusDialogComponent,
        // EditCampusDialogComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        SharedModule,
        ServiceProxyModule,
        SchoolsRoutingModule,

        // PrimeNG
        ButtonModule,
        CalendarModule,
        CardModule,
        CheckboxModule,
        ConfirmDialogModule,
        DialogModule,
        DropdownModule,
        FloatLabelModule,
        IconFieldModule,
        InputGroupModule,
        InputIconModule,
        InputTextModule,
        InputTextarea,
        PaginatorModule,
        TableModule,
        TagModule,
        ToastModule,
        ToolbarModule,
    ],
    providers: [
        MessageService,
        ConfirmationService
    ]
})
export class SchoolsModule {}
