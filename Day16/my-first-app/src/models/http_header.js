import { Server } from "./server";

export class HttpHeader {
  static get() {
    return {
      Authorization: "Bearer " + Server.token,
      "Content-Type": "application/json",
    };
  }
}
