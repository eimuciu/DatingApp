import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css'],
  // encapsulation: ViewEncapsulation.Emulated, --> This is a default setting that uses angular naming to specify styling only for this component
  // encapsulation: ViewEncapsulation.None --> This encapsulation sets a global styling
})
export class MemberCardComponent implements OnInit {
  @Input() member: Member | undefined;

  constructor(
    private memberService: MembersService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  addLike(member: Member) {
    this.memberService.addLike(member.userName).subscribe({
      next: () => this.toastr.success('You have liked ' + member.knownAs),
    });
  }
}
