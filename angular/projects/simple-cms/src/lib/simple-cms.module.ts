import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory, LocalizationModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { SimpleCMSRoutingModule } from './simple-cms-routing.module';
import { ShowEntryComponent } from './components/show-entry/show-entry.component';
import { ManageEntriesComponent } from './components/manage-entries/manage-entries.component';
import { CommonModule } from '@angular/common';
import localizations from './localization/simple-cms';
import { NgxEditorModule } from 'ngx-editor';

@NgModule({
  declarations: [],
  imports: [
    CoreModule.forChild({
      localizations,
    }),
    ThemeSharedModule,
    LocalizationModule,
    SimpleCMSRoutingModule,
    ShowEntryComponent,
    ManageEntriesComponent,
    NgxEditorModule,
  ],
  exports: [ManageEntriesComponent, ShowEntryComponent],
})
export class SimpleCMSModule {
  static forChild(): ModuleWithProviders<SimpleCMSModule> {
    return {
      ngModule: SimpleCMSModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<SimpleCMSModule> {
    return new LazyModuleFactory(SimpleCMSModule.forChild());
  }
}
