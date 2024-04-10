import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShowEntryComponent } from './components/show-entry/show-entry.component';
import { ManageEntriesComponent } from './components/manage-entries/manage-entries.component';

const routes: Routes = [
  {
    path: 'pages/:id',
    pathMatch: 'full',
    component: ShowEntryComponent,
  },
  {
    path: 'manage',
    pathMatch: 'full',
    component: ManageEntriesComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SimpleCMSRoutingModule {}
