# Set the recovery property of Windows service (VBWindowsServiceRecoveryProperty)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Service
## Topics
* Recovery Property
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:33:50
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBWindowsServiceRecoveryProperty Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
VBWindowsServiceRecoveryProperty example demonstrates how to use <br>
ChangeServiceConfig2 to configure the service &quot;Recovery&quot; properties in VB.NET.
<br>
This example operates all the options you can see on the service &quot;Recovery&quot;
<br>
tab, including setting the &quot;Enable actions for stops with errors&quot; option in
<br>
Windows Vista and later operating systems. This example also include how to <br>
grant the shut down privilege to the process, so that we can configure a <br>
special option in the &quot;Recovery&quot; tab - &quot;Restart Computer Options...&quot;.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
1. The code sample must run on Windows Vista and later operating systems. <br>
2. The code sample need to run as administrator.<br>
3. You need to install the VBWindowsService sample service before you run <br>
&nbsp; this code sample.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
1.&nbsp;&nbsp;&nbsp;&nbsp;Install VBWindowsService service on your system.<br>
2.&nbsp;&nbsp;&nbsp;&nbsp;Build this project and run it as administrator.<br>
3.&nbsp;&nbsp;&nbsp;&nbsp;Use services.msc command to view the services on your system and find the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;VBWindowsService service, and then you can double click on that service
<br>
&nbsp;&nbsp;&nbsp;&nbsp;to open the property window.<br>
4.&nbsp;&nbsp;&nbsp;&nbsp;In the Recovery tab, you can find the recovery properties had been
<br>
&nbsp; &nbsp;configured by the sample application.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1.&nbsp;&nbsp;&nbsp;&nbsp;Open the service control manager with a high permission.<br>
2.&nbsp;&nbsp;&nbsp;&nbsp;Open the service with the service name and a high permission.<br>
3.&nbsp;&nbsp;&nbsp;&nbsp;Create three actions for the service control manager perform at these
<br>
&nbsp;&nbsp;&nbsp;&nbsp;three situations &quot;First failure&quot;, &quot;Second failure&quot; and &quot;Subsequent
<br>
&nbsp;&nbsp;&nbsp;&nbsp;failures&quot;.<br>
4.&nbsp;&nbsp;&nbsp;&nbsp;Grant shut down privilege to the process, so that we can configure the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&quot;Restart Computer Options...&quot;.<br>
&nbsp;&nbsp;&nbsp;&nbsp;a.&nbsp;&nbsp;&nbsp;&nbsp;Retrieve a pseudo handle for the current process.<br>
&nbsp;&nbsp;&nbsp;&nbsp;b.&nbsp;&nbsp;&nbsp;&nbsp;Open the access token associated with the process.<br>
&nbsp;&nbsp;&nbsp;&nbsp;c.&nbsp;&nbsp;&nbsp;&nbsp;Retrieve the locally unique identifier (LUID) used on a specified
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;system to locally represent the specified privilege name.<br>
&nbsp;&nbsp;&nbsp;&nbsp;d.&nbsp;&nbsp;&nbsp;&nbsp;Enable privileges in the specified access token.<br>
5.&nbsp;&nbsp;&nbsp;&nbsp;Construct a service failure actions struct with the above actions, the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;time after which to reset the failure count to zero if there are no
<br>
&nbsp;&nbsp;&nbsp;&nbsp;failures, in seconds, reboot message, the program with or without the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;command line parameters will execute with we set the failure action to
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Run_Command after the service failed and the fail count.<br>
6.&nbsp;&nbsp;&nbsp;&nbsp;Enable actions for stops with errors.<br>
7.&nbsp;&nbsp;&nbsp;&nbsp;Call the ChangeServiceConfig2 method to set the service recovery
<br>
&nbsp; &nbsp;properties.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
VBWindowsService<br>
<a target="_blank" href="http://1code.codeplex.com/SourceControl/changeset/view/55574#628200">http://1code.codeplex.com/SourceControl/changeset/view/55574#628200</a><br>
<br>
Service Security and Access Rights<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms685981(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms685981(VS.85).aspx</a><br>
<br>
Privilege Constants<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb530716(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/bb530716(v=VS.85).aspx</a><br>
<br>
System Error Codes (0-499)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms681382(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms681382(VS.85).aspx</a><br>
<br>
SC_ACTION_TYPE<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb401750.aspx">http://msdn.microsoft.com/en-us/library/bb401750.aspx</a><br>
<br>
SC_ACTION Structure<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms685126(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms685126(VS.85).aspx</a><br>
<br>
SERVICE_FAILURE_ACTIONS Structure<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms685939(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms685939(VS.85).aspx</a><br>
<br>
OpenSCManager Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms684323(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms684323(VS.85).aspx</a><br>
<br>
OpenService Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms684330(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms684330(VS.85).aspx</a><br>
<br>
ChangeServiceConfig2 Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms681988(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms681988(VS.85).aspx</a><br>
<br>
DllImportAttribute Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.runtime.interopservices.dllimportattribute.aspx">http://msdn.microsoft.com/en-us/library/system.runtime.interopservices.dllimportattribute.aspx</a><br>
<br>
TOKEN_PRIVILEGES Structure<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa379630(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa379630(VS.85).aspx</a><br>
<br>
GetCurrentProcess Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms683179(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms683179(VS.85).aspx</a><br>
<br>
OpenProcessToken Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa379295(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa379295(VS.85).aspx</a><br>
<br>
LookupPrivilegeValue Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa379180(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa379180(VS.85).aspx</a><br>
<br>
AdjustTokenPrivileges Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa375202(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa375202(VS.85).aspx</a><br>
<br>
Set up Recovery Actions to Take Place When a Service Fails<br>
<a target="_blank" href="http://technet.microsoft.com/en-us/library/cc753662.aspx">http://technet.microsoft.com/en-us/library/cc753662.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
