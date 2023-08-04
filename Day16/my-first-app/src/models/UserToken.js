export class UserToken {
  constructor(data) {
    this.token = data.token;
    this.fullName = data.fullName;
    this.email = data.email;
    this.expires = new Date(data.expires);
  }

  static fromResponse(json) {
    return new UserToken({
      token: json.access_token,
      fullName: json.fullName,
      email: json.email,
      expires: json[".expires"],
    });
  }
}
