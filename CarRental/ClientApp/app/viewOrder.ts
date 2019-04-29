export class ViewOrder {
    constructor(
        public id?: number,
        public userId?: number,
        public userLastName?: number,
        public userFirstName?: string,
        public carId?: number,
        public carMake?: string,
        public carModel?: string,
        public carRegistrationNumber?: string,
        public startDate?: Date,
        public finalDate?: Date) { }
}