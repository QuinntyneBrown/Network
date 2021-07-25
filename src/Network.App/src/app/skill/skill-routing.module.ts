import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SkillComponent } from './skill.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'create' },
  { path: 'create', component: SkillComponent },
  { path: 'edit/:editId', component: SkillComponent },
  { path: ':id', component: SkillComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SkillRoutingModule { }
