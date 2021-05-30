``` plantuml
@startuml deployment

node TestMaster
note right: C# console app hosts \r\n ASP.NET Core SignalR Hubs
node Agent1
note bottom : C# console app running on working PC
node Agent2
node Agent3
node Agent4
agent WebBrowser
note right : Razer pages in browser

WebBrowser --> TestMaster
TestMaster <-- Agent1 
TestMaster <-- Agent2 : signalR/gRPC
TestMaster <-- Agent3
TestMaster <-- Agent4 

@enduml
```