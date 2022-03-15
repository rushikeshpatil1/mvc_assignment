import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxGalleryImage } from '@kolkov/ngx-gallery';
import { NgxGalleryAnimation, NgxGalleryOptions } from '@kolkov/ngx-gallery';


import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/models/member';
import { User } from 'src/app/models/user';
import { AccountService } from 'src/app/services/account.service';
import { MembersService } from 'src/app/services/members.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {

  // @ViewChild('memberTabs', {static: true}) memberTabs: TabsetComponent;
  member: Member;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  // activeTab: TabDirective;
  // messages: Message[] = [];
  user: User;

   

  constructor( private route: ActivatedRoute, 
    private accountService: AccountService, public memberservice:MembersService,
    public router: Router) { 
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    }

  ngOnInit(): void {
    this.loadMember();

  
  
    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ]
    
  }
 
  getImages(): NgxGalleryImage[] {
    console.log("imageUrls");
    const imageUrls = [];
    for(const photo of this.member.photos) {
      console.log("imageUrls");
      imageUrls.push({

        small: photo?.url,
        medium: photo?.url,
        big: photo?.url
      })
    }
    console.log(imageUrls);
    return imageUrls;
  }


   
  loadMember(){
 this.memberservice.getMember(this.route.snapshot.paramMap.get('username')||'{}')
.subscribe((member: Member)=>{this.member=member;this.galleryImages = this.getImages();
})


  }

 

  // ngOnDestroy(): void { }

}
