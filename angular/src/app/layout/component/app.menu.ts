import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { AppMenuitem } from './app.menuitem';

@Component({
    selector: 'app-menu',
    standalone: true,
    imports: [CommonModule, AppMenuitem, RouterModule],
    template: `<ul class="layout-menu">
        <ng-container *ngFor="let item of model; let i = index">
            <li app-menuitem *ngIf="!item.separator" [item]="item" [index]="i" [root]="true"></li>
            <li *ngIf="item.separator" class="menu-separator"></li>
        </ng-container>
    </ul> `
})
export class AppMenu {
    model: MenuItem[] = [];

    ngOnInit() {
        // Custom static menu – ABP menu bypassed
        this.model = [
            {
                label: 'Navigation',
                items: [
                    {
                        label: 'Dashboard',
                        icon: 'pi pi-fw pi-home',
                        routerLink: ['/app', 'dashboard'],
                        command: () => console.log('Menu click => Dashboard')
                    },
                    {
                        label: 'Campuses',
                        icon: 'pi pi-fw pi-building',
                        routerLink: ['/app', 'campuses'],
                        command: () => console.log('Menu click => Campuses')
                    },
                    {
                        label: 'Users',
                        icon: 'pi pi-fw pi-users',
                        routerLink: ['/app', 'users'],
                        command: () => console.log('Menu click => Users')
                    },
                    {
                        label: 'Settings',
                        icon: 'pi pi-fw pi-cog',
                        routerLink: ['/app', 'settings'],
                        command: () => console.log('Menu click => Settings')
                    }
                ]
            }
        ];

        console.log('Custom menu model initialised:', this.model);
    }
}
