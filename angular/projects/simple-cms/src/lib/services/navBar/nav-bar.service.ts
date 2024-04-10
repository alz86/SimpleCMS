import { Injectable } from '@angular/core';
import { EntriesService } from '../entries/entries.service';
import { ABP, RoutesService, eLayoutType, LocalizationService } from '@abp/ng.core';
import { Subscription } from 'rxjs';
import { ContentEntryDto } from '@proxy/dto';

/**
 * Services to handle tasks related to
 * the creation and update of the navigation
 * bar menu.
 */
@Injectable({
  providedIn: 'root',
})
export class NavBarService {
  constructor(
    private readonly routesService: RoutesService,
    private readonly entriesService: EntriesService,
    private readonly localizationService: LocalizationService
  ) {}

  private entriesSubscription?: Subscription = null;

  private isInit = false;
  /**
   * Initializes the service, adding to the
   * menu the existing items, and listening for
   * changes in the entries list to update it..
   */
  public init() {
    if (this.isInit) return;

    //before anything else, we have to ensure that localization resources are
    //loaded. this is because the "Manage" menu item uses localized texts, and
    //thus we need to wait for them to be loaded before adding to the menu bar.
    this.localizationService.getResource$('SimpleCMS').subscribe(() => {
      //subscription to changes in the entity list, which means that the list of
      //items in the menu may change.
      this.entriesSubscription = this.entriesService.entries$.subscribe(entries => {
        this.buildMenu(entries);
      });

      //ensures that the list of entries is loaded
      this.entriesService.ensureInit();
    });
    this.isInit = true;
  }

  private buildMenu(entries: ContentEntryDto[]) {
    const baseOrder = 101;
    const basePath = 'simple-cms';

    //page items
    entries.forEach((item, idx) => {
      this.addOrUpdateMenuItem({
        path: `${basePath}/pages/${item.id}`,
        name: item.title,
        iconClass: 'fas fa-file',
        layout: eLayoutType.application,
        order: baseOrder + idx,
      });
    });

    //for Manage menu item, we need a fix to ensure that resources are already loaded
    //(they are not when you first load the app) and only then, add the menu item, with
    //the right localized value.
    //NOTE: this menu has also to be patched because its order
    //(baseOrder + entries.length + 1) is calculated based on the number of entries,
    //which may be changed. Thus, we have to operate with them as with any other, dynamic,
    //menu item.
    this.addOrUpdateMenuItem({
      path: `${basePath}/manage/`,
      name: this.localizationService.instant('SimpleCMS::Menus:Manage'),
      iconClass: 'fas fa-cog',
      layout: eLayoutType.application,
      order: baseOrder + entries.length + 1,
      requiredPolicy: 'SimpleCMS:Permissions:Create',
    });
  }

  private addOrUpdateMenuItem(item: ABP.Route) {
    //items are find by its path, which remains constant, while its name
    //may change.
    var existing = this.routesService.find(t => t.path == item.path);
    if (existing) this.routesService.patch(existing.name, item);
    this.routesService.add([item]);
  }
}
