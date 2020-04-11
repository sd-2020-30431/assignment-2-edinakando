export class Donation{
    Id: Number;
    ItemId: Number;
    CharityId: Number;
    
    constructor(itemId, charityId){
        this.ItemId = itemId;
        this.CharityId = charityId;
    }
}