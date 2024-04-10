import { Injectable } from '@angular/core';
import { NavBarService } from 'projects/simple-cms/src/lib/services/navBar/nav-bar.service';

@Injectable()
export class RouteConfigurator {
  constructor(private readonly navBarService: NavBarService) {}

  configureRoutes() {
    return () => this.navBarService.init();
  }
}
