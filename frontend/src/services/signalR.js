import * as signalR from "@microsoft/signalr";

const connection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5000/taskHub")
  .withAutomaticReconnect()
  .build();

connection.start().catch((err) => console.error(err.toString()));

export default connection;
