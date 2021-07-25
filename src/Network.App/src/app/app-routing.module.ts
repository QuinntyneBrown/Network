import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Route } from '@shared/shell';

const routes: Routes = [
  Route.withShell([
    { path: '', redirectTo: 'landing', pathMatch: 'full' },
    { path: 'landing', loadChildren: () => import('./landing/landing.module').then(m => m.LandingModule) },
    { path: 'profile', loadChildren: () => import('./profile/profile.module').then(m => m.ProfileModule) },
    { path: 'organization', loadChildren: () => import('./organization/organization.module').then(m => m.OrganizationModule) },
    { path: 'technology', loadChildren: () => import('./technology/technology.module').then(m => m.TechnologyModule) },
    { path: 'skill', loadChildren: () => import('./skill/skill.module').then(m => m.SkillModule) }
  ])
];

@NgModule({
  imports: [RouterModule.forRoot( routes, {
    scrollPositionRestoration: "top"
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
