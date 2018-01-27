
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ProjectFormComponent } from './components/project-form/project-form.component'

// import 'hammerjs';
import { MatButtonModule, MatSlideToggleModule, MatInputModule, MatFormFieldModule, MatSelectModule } from '@angular/material';
import { ProjectService } from './services/project.service';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ProjectFormComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        MatButtonModule,
        MatSlideToggleModule,
        MatInputModule,
        MatFormFieldModule, MatSelectModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'projects/new', component: ProjectFormComponent },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        ProjectService
    ]
})
export class AppModuleShared {
}
