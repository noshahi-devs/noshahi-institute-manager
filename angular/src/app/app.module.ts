import { AppLayout } from './layout/component/app.layout';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// 3rd party and shared modules
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { NgxPaginationModule } from 'ngx-pagination';
import { SharedModule } from '@shared/shared.module';

// PrimeNG modules
import { Table, TableModule } from 'primeng/table';
import { FileUploadModule } from 'primeng/fileupload';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { InputTextModule } from 'primeng/inputtext';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { TagModule } from 'primeng/tag';

// PrimeNG config and animation
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeng/themes/aura';
import { SchoolsModule } from './schools/schools.module';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        SchoolsModule,
        AppRoutingModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        HttpClientJsonpModule,
        ModalModule.forChild(),
        BsDropdownModule,
        CollapseModule,
        TabsModule,
        ServiceProxyModule,
        NgxPaginationModule,
        SharedModule,
        TableModule,
        FileUploadModule,
        ButtonModule,
        ToastModule,
        ToolbarModule,
        InputTextModule,
        IconFieldModule,
        InputIconModule,
        DialogModule,
        DropdownModule,
        ConfirmDialogModule,
        TagModule,
        ToolbarModule,
        InputTextModule,
        IconFieldModule,
        InputIconModule,
        DialogModule,
        DropdownModule,
        ConfirmDialogModule,
        TagModule,
        ToolbarModule,
        InputTextModule,
        TableModule,
        AppLayout
    ],
    providers: []
})
export class AppModule {}
