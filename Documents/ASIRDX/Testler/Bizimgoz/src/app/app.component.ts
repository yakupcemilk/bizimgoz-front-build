import { Component } from '@angular/core';
import { SidenavToggle } from './sidenav/sidenav.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Bizimgoz';
  isSidenavCollapsed = false;
  screenWidth = 0;

  onToggleSidenav(data: SidenavToggle): void {
    this.screenWidth = data.screenWidth;
    this.isSidenavCollapsed = data.collapsed;
  }
}
