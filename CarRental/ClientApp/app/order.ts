export class Order {
    constructor(
        public id?: number,
        public userId?: number,
        public carId?: number,
        public startDate?: Date,
        public finalDate?: Date,
        public comment?: string) { }
}