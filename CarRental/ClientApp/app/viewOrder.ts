export class ViewOrder {
    constructor(
        public id?: number,
        public userId?: number,
        public userFirstName?: string,
        public carId?: number,
        public carMake?: string,
        public startDate?: Date,
        public finalDate?: Date) { }
}