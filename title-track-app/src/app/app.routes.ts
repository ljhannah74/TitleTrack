import { Routes } from '@angular/router';
import { TitleAbstractListComponent } from './title-abstract-list/title-abstract-list.component';
import { TitleAbstractDetailsComponent } from './title-abstract-details/title-abstract-details.component';

export const routes: Routes = [
  { path: 'titleabstracts', component: TitleAbstractListComponent },
  { path: '', redirectTo: 'titleabstracts', pathMatch: 'full' },
  { path: 'create', component: TitleAbstractDetailsComponent },
];
