export class Server {
  static host = "https://localhost:44332/";
  static url = "https://localhost:44332/api/";
  static token = localStorage.getItem("token") ?? "";
}
