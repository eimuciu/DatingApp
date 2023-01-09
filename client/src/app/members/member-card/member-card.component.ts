import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { Member } from 'src/app/_models/member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css'],
  // encapsulation: ViewEncapsulation.Emulated, --> This is a default setting that uses angular naming to specify styling only for this component
  // encapsulation: ViewEncapsulation.None --> This encapsulation sets a global styling
})
export class MemberCardComponent implements OnInit {
  @Input() member: Member | undefined;

  constructor() {}

  ngOnInit(): void {}
}
