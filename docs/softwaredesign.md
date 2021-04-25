
**Table of contents**

* [Supported test agent use cases](#supported-test-agent-use-cases)
* [Supported test server use cases](#supported-test-server-use-cases)
* [Choose the right framework for communication](#choose-the-right-framework-for-communication)
* [Open issues](open-issues)



### Supported test agent use cases:
[diagram source](docs\diagrams\TestAgentUsecase.puml)
``` plantuml
@startuml AgentUseCase
 left to right direction

 actor TestAgent

 package AgentUseCase as "Agent UseCase" {
     usecase ReportStatus as "Report Status"
     usecase AutoBranchUpdate as "Perform Auto branchupdate" #Cyan    
     usecase GetTask as "Get test Task to run"
     usecase ReportTestResult as "ReportTestResult"
 }

 
 TestAgent --> ReportStatus
 TestAgent --> AutoBranchUpdate
 TestAgent --> GetTask

legend right
|Color    | Type    |
|<#Wheat> | remotely|
|<#Cyan>  | local   |
endlegend

@enduml

 ```

 ### Supported test server use cases:
 [diagram source](docs\diagrams\TestServerUsecase.puml)
 ```plantuml
@startuml AgentUseCase
 left to right direction

 actor TestServer

 package ServerUseCase as "TestServer UseCase" {
     usecase CaseDashboard as "TestCase Dashboard"        
     usecase AgentDashboard as "TestAgent Dashboard"
     usecase DistributeTask as "Distribute Test Task"
 }

 
 TestServer --> CaseDashboard
 TestServer --> AgentDashboard
 TestServer --> DistributeTask
@enduml
```
### Choose the right framework for communication

* server has to know agents connected/disconnected for agent status dashboard

* Is bi-directional communication needed ?

* gRPC supports js client ?



### Open issues

