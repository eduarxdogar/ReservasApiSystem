import { Pipe, PipeTransform } from '@angular/core';
import { translate } from '@ngneat/transloco';

enum Days {
    monday,
    tuesday,
    wednesday,
    thursday,
    friday,
    saturday,
    sunday
}

enum Months {
    january,
    february,
    mars,
    april,
    may,
    june,
    july,
    august,
    september,
    october,
    november,
    december
}

@Pipe({ 
    name: 'dateTranslated'
 })
export class FrenchDatePipe implements PipeTransform {
    constructor(){ }

    transform(dateString: string, lang: string) {
        const date=new Date(dateString);

        const dayOfMonth = date.getDate();
        const nameOfDay = Days[date.getDay()];
        const nameOfMonth = Months[date.getMonth()];
        const year = date.getFullYear();

        const result = 
        translate(nameOfDay) 
        + ' ' + 
        translate(nameOfMonth) 
        + ' ' + 
        dayOfMonth 
        + ' ' + 
        translate('at')
        + ' ' + year;

       return result;
    }
}