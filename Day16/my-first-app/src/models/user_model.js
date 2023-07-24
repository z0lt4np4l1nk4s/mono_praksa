export class User {
    constructor (firstName, lastName, email)
    {
        this.id = crypto.randomUUID();
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
    }
}