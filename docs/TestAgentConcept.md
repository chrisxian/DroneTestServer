
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

#### User Interaction of Agent Service

As the agent is supposed to be working during nigh shift, when there's no one working with his/her PC anymore, so the UI interface should be as simple as possible. ideally a command window would be enough to provide basic information and interaction with agent PC administrator.
by pressing:
* **status** to print current agent status and connected server address

* **connect**(obsolete, trigger by timer automatically) to reconnect to configued server in case currently disconnected(e.g.: inital connection was not succesful after 10 times of retry due to server is not online or network problem). connect will also use max retry count of 10.

* **exit**(needed?) to end all current agent activities（send to server exit operation before really exit).

#### Auto Connection behavior
in State 'BranchUpdated', connection will be checked and triggered automatically.

in case of network or server unavailaibilty, max 10 times of retry will be performed.

in other states(e.g: Started, BranchUpdating, Executing), there's no need to connect to a Master Server, therefore connection will not be triggered.
-> this helps to reduce dependency on ConnectionManager and keep single responsibility princible of each state implementation.

**Hint:**
no manual trigged connection needed.

**Hint(open):**
in case connection to master server is failed for the first 10 retry, the network could be functioning at a later point of time(e.g.: server started very late)
how to avoid the Agent stays in BranchUpdated state forever ?
the TimedHostedService act as an enigine will trigger again the State.Handle. 



**Hint:**
configuration of server endpoint address and retry count is a focus in the first version.


### Agent State Handling

``` plantuml
@startuml AgentStateHandling
Started :
BranchUpdated  : but not connected
Standby: brachupdated & connected
Executing : 

[*] --> Started
Started --> BranchUpdated
BranchUpdated --> Standby
Standby --> Executing
Executing --> Standby : on finished
Standby --> BranchUpdated: disconnected

Executing --> [*]

@enduml
```

* **StartedState** 
the only responsilibty is to check if branchupdat needed, 
started state does not directly jump to Standby state,
If connected, then either enter branchupdating(?) or branchupdated state, then enter Standby state.

* **BranchUpdatingState** 
also does not check connection,
(actually the connection will not be performed untill entered branchUpdated state)

* **ExecutingState** 
there's no transition from ExecutingState to BranchUdpatedState, on test case execution finished, it does not check connection, but returns to StandbyState directly, in StandbyState, the connection will be checked,and enter BranchUpdatedState if connection is down.


#### Agent logging
~~first version will use console for logging.~~
(unlike server asp.net core app has built in logging)
-> switched to Worker Service, to embrance built-in logging provided by .NET core framework.