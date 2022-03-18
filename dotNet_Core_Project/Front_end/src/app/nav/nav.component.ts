import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';

import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';
import { ToastrService } from 'ngx-toastr';



@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  logg: boolean = false;

  constructor( private router: Router, public accountService : AccountService, public toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model).subscribe(response =>{this.router.navigateByUrl('/members');
    this.logg=true;}, 
  
      )
 


  }

  logout() {
this.accountService.logout();
this.router.navigateByUrl('/home')
  }
}
