import { Contact } from "./Contact";

export interface Reservation {
    id?: number,
    ranking?: number,
    favorite?: boolean,
    date: string,
    description?: string,
    contactId?: number,
    contact?: Contact,
    contactNameSortable?: string
}