import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrl: './statistics.component.scss'
})
export class StatisticsComponent {
  @Input() collapsed: boolean = false;

}
