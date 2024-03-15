import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-coupens',
  templateUrl: './coupens.component.html',
  styleUrl: './coupens.component.scss'
})
export class CoupensComponent {
  @Input() collapsed: boolean = false;
}
