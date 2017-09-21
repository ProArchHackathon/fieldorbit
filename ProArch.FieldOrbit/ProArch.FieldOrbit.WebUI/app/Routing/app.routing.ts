import { AuthGuard } from './../Guards/auth.guard';
import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { LoginComponent } from "../common/login/login.component";

const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent, data: { Title: 'Login' } }
    // this route should be the last one
    // { path: '**', pathMatch: 'full', component: PathNotFoundComponent, data: { Title: '404' } }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(routes,{ useHash: true });
