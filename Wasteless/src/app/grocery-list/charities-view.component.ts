import { Component } from '@angular/core';
import { CharitiesService } from '../services/charities.service'
import { Charity } from 'src/app/models/charity';
import { Donation } from 'src/app/models/donation';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'charities-view',
    templateUrl: './charities-view.component.html',
    providers: [CharitiesService]
})

export class CharitiesComponent {
    charities: Charity[];
    itemId: number;

    constructor(private charitiesService: CharitiesService,
                private activatedRoute: ActivatedRoute) { }

    ngOnInit() {
        this.itemId = Number(this.activatedRoute.snapshot.paramMap.get("id"));
        console.log(this.itemId);
        this.charitiesService.getAll()
            .subscribe(res => {
                this.setCharitiesView(res);
            })
    }

    setCharitiesView(res){
        this.charities = res;
    }

    donate(charityId){
        this.charitiesService.donate(new Donation(this.itemId, charityId));
    }
}