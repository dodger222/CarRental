export class Order {
    constructor(
        public id?: number,
        public userId?: number,
        public carId?: number,
        public startDate?: string,
        public finalDate?: string,
        public comment?: string) { }
}