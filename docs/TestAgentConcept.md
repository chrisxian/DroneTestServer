
## Test Agent Concept

#### Agent Use Case overview

``` plantuml
@startuml AgentUseCase
 left to right direction

 actor TestAgent

 package AgentUseCase as "Agent UseCase" {
     usecase Interaction as "Interaction with agent admin" #Cyan
     usecase ReportStatus as "Report Status"
     usecase AutoBranchUpdate as "Perform Auto branchupdate" #Cyan    
     usecase GetTask as "Get test Task to run"
     usecase ReportTestResult as "ReportTestResult"
 }

 TestAgent --> Interaction
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

#### UI of agent

should be as simple as possible. ideally a dos console UI would be enough to provide basic information and interaction with agent PC administrator.
by pressing:
* **status** to print current agent status and connected server address

* **connect** to reconnect to configued server in case currently disconnected(e.g.: inital connection was not succesful after 10 times of retry due to server is not online or network problem). connect will also use max retry count of 10.

* **exit** to end all current agent activities（send to server exit operation before really exit).

#### Connection behavior

on startup, the agent will try to connect to configued server automatically.
in case of network or server unavailaibilty, max 10 times of retry will be performed.

later on, connection has to be triggered manually by command 'connect'.

**Hint:**
configuration of server endpoint address and retry count is a focus in the first version.


#### Agent logging
first version will use console for logging.
(unlike server asp.net core app has built in logging)