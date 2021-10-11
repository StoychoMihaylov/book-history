export class Book {
    public title: string
    public description: string
    public authorNames: Array<string> = new Array
}

export class BookDetailsModel {
    public title: string
    public description: string
    public authorNames: Array<string>
    public bookEditHistories : Array<BookEditHistory>
}

export interface BookEditHistory {
    dateOfEdit: Date;
    titleChanges: string;
    descriptionChanges: string;
    authorChanges: string;
}