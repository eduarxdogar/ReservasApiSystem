import { ContactType } from "./ContactType";

export interface Contact {
    id?: number,
    name: string,
    nameSortable?: string,
    phone?: string,
    birthDate: string,
    contactTypeId: number,
    contactType?: ContactType,
    contactTypeNameSortable?: string
}