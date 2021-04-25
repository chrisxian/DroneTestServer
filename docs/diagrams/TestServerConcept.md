 ```plantuml
@startuml AgentUseCase
 left to right direction

 actor TestServer

 package ServerUseCase as "TestServer UseCase" {
     usecase CaseDashboard as "TestCase Dashboard"        
     usecase AgentDashboard as "TestAgent Dashboard"
     usecase DistributeTask as "Distribute Test Task"
     note top : assign an unperformed test task \n in request from an agent, \nserver does not push a task to agent.
 }

 
 TestServer --> CaseDashboard
 TestServer --> AgentDashboard
 TestServer --> DistributeTask
@enduml
 ```