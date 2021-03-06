import { Injectable } from '@angular/core';
import { ChartModel } from '../interfaces/ChartModel';
import * as signalR from "@aspnet/signalr";


@Injectable({
  providedIn: 'root'
})
export class SignalRService {

public data:ChartModel[];

private hubConnection:signalR.HubConnection


public startConnection()
{

  this.hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://192.168.1.2:5000/charts")
  .build();


  this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))


}


public addTransferChartDataListener()
{
      this.hubConnection.on("transferchartdata",
      (data)=>{

        this.data = data;
        console.log(data);

      });



}




  constructor() { }
}
