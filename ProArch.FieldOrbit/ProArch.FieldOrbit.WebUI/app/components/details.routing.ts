import { DetailsComponent } from './details/details.component';
import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { JobComponent } from '../components/job/job.component';
import { ServiceRequestComponent } from '../components/serviceRequest/serviceRequest.component';
import { WorkRequestComponent } from '../components/workrequest/workrequest.component';
import { AuthGuard } from '../Guards/auth.guard';

const routes: Routes = [
        { path: 'dashboard', component: DetailsComponent, canActivate: [AuthGuard],
         children: [
             {path: '', redirectTo: 'servicerequest', pathMatch: 'full'},
            { path: 'servicerequest', component: ServiceRequestComponent, data: { Title: 'Service Request' } },
            { path: 'job', component: JobComponent , data: { Title: 'Job Details' } },
            { path: 'workrequest', component: WorkRequestComponent, data: { Title: 'Work Request' } }
            ]
        }
    // // this route should be the last one
    // { path: '**', pathMatch: 'full', component: PathNotFoundComponent, data: { Title: '404' } }
];

export const DetailsRouting: ModuleWithProviders = RouterModule.forRoot(routes);
