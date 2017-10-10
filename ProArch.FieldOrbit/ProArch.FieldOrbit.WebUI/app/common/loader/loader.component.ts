import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { LoaderService } from '../../Services/loader.service';
import { LoaderState } from '../../Models/loader';


@Component({
    selector: 'angular-loader',
    templateUrl: 'loader.component.html',
    styleUrls: ['loader.component.scss']
})
export class LoaderComponent implements OnInit {

    show = false;
    color = 'primary';

    private subscription: Subscription;

    constructor(
        private loaderService: LoaderService
    ) { }

    ngOnInit() {
        this.subscription = this.loaderService.loaderState
            .subscribe((state: LoaderState) => {
                this.show = state.show;
            });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}
