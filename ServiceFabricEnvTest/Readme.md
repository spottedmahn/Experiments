Service Fabric App Expirement to debug:

>Register-ServiceFabricApplicationType : Value cannot be null.
>Parameter name: source

In `ApplicationManifest.xml` I've defined an `<EnvironmentOverrides>` w/ one entry but I didn't define it in `ServiceManifest.xml`.  This produces a not so easy error message to debug/troubleshoot.

[Stack Overflow post](https://stackoverflow.com/questions/47888749/register-servicefabricapplicationtype-value-cannot-be-null-parameter-name-so)


---

More complete log from debug window:

>-------- Package: Project: Application1 succeeded, Time elapsed: 00:00:09.4086651 --------
>Started executing script 'Deploy-FabricApplication.ps1'.
>. 'C:\Users\mdepouw\source\repos\GitHub\spottedmahn\Experiments\ServiceFabricEnvTest\Application1\Scripts\Deploy-FabricApplication.ps1' -ApplicationPackagePath 'C:\Users\mdepouw\source\repos\GitHub\spottedmahn\Experiments\ServiceFabricEnvTest\Application1\pkg\Debug' -PublishProfileFile 'C:\Users\mdepouw\source\repos\GitHub\spottedmahn\Experiments\ServiceFabricEnvTest\Application1\PublishProfiles\Local.1Node.xml' -DeployOnly:$true -ApplicationParameter:@{} -UnregisterUnusedApplicationVersionsAfterUpgrade $false -OverrideUpgradeBehavior 'None' -OverwriteBehavior 'Always' -SkipPackageValidation:$true -ErrorAction Stop
>Copying application to image store...
>Upload to Image Store succeeded
>Registering application type...
>Register-ServiceFabricApplicationType : Value cannot be null.
>Parameter name: source
>At C:\Program Files\Microsoft SDKs\Service 
>Fabric\Tools\PSModule\ServiceFabricSDK\Publish-NewServiceFabricApplication.ps1:251 char:9
>+         Register-ServiceFabricApplicationType -ApplicationPathInImage ...
>+         ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
>    + CategoryInfo          : InvalidOperation: (Microsoft.Servi...usterConnection:ClusterConnection) [Register-Servic 
>   eFabricApplicationType], FabricException
>    + FullyQualifiedErrorId : RegisterApplicationTypeErrorId,Microsoft.ServiceFabric.Powershell.RegisterApplicationTyp 
>   e
> 
>Finished executing script 'Deploy-FabricApplication.ps1'.
>Time elapsed: 00:00:24.1217153
>The PowerShell script failed to execute.