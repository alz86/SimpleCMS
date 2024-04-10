import { APP_INITIALIZER, ModuleWithProviders, NgModule } from '@angular/core';
import { RouteConfigurator } from './providers/route.provider';

@NgModule()
export class SimpleCMSConfigModule {
  static forRoot(): ModuleWithProviders<SimpleCMSConfigModule> {
    return {
      ngModule: SimpleCMSConfigModule,
      providers: [
        RouteConfigurator,
        {
          provide: APP_INITIALIZER,
          useFactory: (configurator: RouteConfigurator) => configurator.configureRoutes(),
          deps: [RouteConfigurator],
          multi: true,
        },
      ],
    };
  }
}
