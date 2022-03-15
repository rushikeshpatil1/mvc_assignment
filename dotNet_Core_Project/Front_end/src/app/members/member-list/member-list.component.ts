import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/models/member';
import { Pagination } from 'src/app/models/pagination';
import { User } from 'src/app/models/user';
import { UserParams } from 'src/app/models/userParams';
import { AccountService } from 'src/app/services/account.service';
import { MembersService } from 'src/app/services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  members:Observable< Member[]>;
  pagination: Pagination;
  pageNumber=1;
  pageSize=5;
  userParams: UserParams;
  user: User;
  genderList = [{ value: 'male', display: 'Males' }, { value: 'female', display: 'Females' }];

  constructor(private memberService: MembersService,private accountService:AccountService) {
    // this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
    //   this.user = user;
    //   this.userParams = new UserParams(user);
    // })
  
    this.userParams = this.memberService.getUserParams();
    // this.members=this.memberService.getMembers();
  }

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers() {
   this.memberService.setUserParams(this.userParams);
    return this.memberService.getMembers(this.userParams).subscribe((response: any)=>{this.members=response.result;
    this.pagination=response.pagination;
    })
  }

  resetFilters() {
    this.userParams = this.memberService.resetUserParams();
    this.loadMembers();
  }

  pageChanged(event: any) {
    this.userParams.pageNumber = event.page;
    this.memberService.setUserParams(this.userParams);
    this.loadMembers();
  }
}