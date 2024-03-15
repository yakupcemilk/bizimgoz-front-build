import { Component, Output, EventEmitter } from '@angular/core';
import { navbarData } from './nav-data';

export interface SidenavToggle {
  screenWidth: number;
  collapsed: boolean;
}

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.scss'
})
export class SidenavComponent {
  @Output() onToggleSidenav: EventEmitter<SidenavToggle> = new EventEmitter();

  collapsed = false;
  maxHeight = '350px';
  screenWidth = 0;
  navData = navbarData;

  toggleCollapse(): void {
    this.collapsed = !this.collapsed;
    this.onToggleSidenav.emit({collapsed: this.collapsed, screenWidth: this.screenWidth});
  }

  closeSidenav(): void {
    this.collapsed = false;
    this.onToggleSidenav.emit({collapsed: this.collapsed, screenWidth: this.screenWidth});
  }
}
