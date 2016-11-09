# Ignite NZ 2016 Demo

Callum Lowe and @DanielLarsenNZ 's demo for the Ignite NZ presentation: [Enabling DevOps from an IT Pro perspective].

## Contents

1. [OMS](./1. OMS.md)
1. [DSC](./2. DSC.md)
1. [Windows Server 2016, Containers, VMA, MMA, VSTSA, DSC.  PaaS SQL](./Windows Server 2016, Containers, VMA, MMA, VSTSA, DSC.  PaaS SQL.md)
1. [Azure Monitor](./Azure Monitor.md)

## Build Configuration

Once @DarqueWarrior open-sources his ['yo vsts'] Yoeman.io generator, we will fork
and PR to add a profile that will add the basic Build and Release configuration
for this project. In the meantime here are a few notes.

### Build API and Publish files

1. Create an _MSBuild_ task.
1. _Project_ = your API .csproj
1. MSBuild Arguments = `/p:PublishDestination="$(build.artifactstagingdirectory)\Docker\api\wwwroot" /t:PublishToFileSystem`

#### Copy files to the artefacts folder

1. Create a _Copy files_ task.
1. _Source Folder_ = `Demo/Docker`
1. _Target Folder_ = `$(build.artifactstagingdirectory)\Docker`

## Release Configuration

### Override Template Parameters

The *Deploy Resource Group* task will need the following parameters overrided with corresponding variables:

```powershell
-DBAdminUsernamePassword '$(DBAdminUsernamePassword)'
-VMAdminPassword (ConvertTo-SecureString -String '$(VMAdminPassword)' -AsPlainText -Force)
-VSOUser '$(VSOUser)'
-VSOPass (ConvertTo-SecureString -String '$(VSOPass)' -AsPlainText -Force)
-DSCRegistrationKey (ConvertTo-SecureString -String '$(DSCRegistrationKey)' -AsPlainText -Force)
-OMSMonitoringAgentWorkspaceKey (ConvertTo-SecureString -String '$(OMSMonitoringAgentWorkspaceKey)' -AsPlainText -Force)
-DSCTimeStamp '10/28/2016 9:09:00 pm'
```

[Enabling DevOps from an IT Pro perspective]:https://channel9.msdn.com/events/Ignite/New-Zealand-2016/M371
['yo vsts']:https://channel9.msdn.com/events/Ignite/New-Zealand-2016/M328
