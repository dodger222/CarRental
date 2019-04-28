export class Order {
    constructor(
        public id?: number,
        public userId?: number,
        public autoId?: number,
        public startDate?: Date,
        public finalDate?: Date) { }
}