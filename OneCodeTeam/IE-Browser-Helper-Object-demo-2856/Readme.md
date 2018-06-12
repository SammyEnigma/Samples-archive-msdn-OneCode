# IE Browser Helper Object demo (VBBrowserHelperObject)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Internet Explorer
## Topics
* BHO
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:49:54
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: VBBrowserHelperObject Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New">The sample demonstrates how to create and deploy a Browser Helper Object. A Browser<br>
Helper Object runs within Internet Explorer and offers additional services, &nbsp;and
<br>
the BHO in this sample is used to disable the context menu in IE.<br>
<br>
To add a BHO to IE, this class should be registered to COM with a class ID (CLSID,<br>
{C42D40F0-BEBF-418D-8EA1-18D99AC2AB17} in this sample), and add a key under <br>
&quot;HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\Browser Helper Objects&quot;.<br>
<br>
NOTE: <br>
1. On 64bit machine, 32bit IE will use <br>
&nbsp; &quot;HKLM\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\Browser Helper Objects&quot;<br>
<br>
2. On Windows Server 2008 or Windows Server 2008 R2, the Internet Explorer Enhanced
<br>
&nbsp; Security Configuration (IE ESC) is set to On by default, which means that this BHO<br>
&nbsp; can not be loaded by IE. You have to turn off IE ESC for you. <br>
<br>
</p>
<h3>Setup and Removal:</h3>
<p style="font-family:Courier New"><br>
--------------------------------------<br>
In the Development Environment<br>
<br>
A. Setup<br>
<br>
For 32bit IE on x86 or x64 OS, run 'Visual Studio Command Prompt (2010)' in the <br>
Microsoft Visual Studio 2010 \ Visual Studio Tools menu as administrator. For 64bit<br>
IE on x64 OS, run Visual Studio x64 Win64 Command Prompt (2010).<br>
<br>
Navigate to the folder that contains the build result VBBrowserHelperObject.dll and
<br>
enter the command:<br>
<br>
&nbsp; &nbsp;Regasm.exe VBBrowserHelperObject.dll /codebase<br>
<br>
The BHO is registered successfully if the command prints:<br>
&nbsp; &nbsp;&quot;Types registered successfully&quot;<br>
<br>
B. Removal<br>
<br>
For 32bit IE on x86 or x64 OS, run 'Visual Studio Command Prompt (2010)' in the <br>
Microsoft Visual Studio 2010 \ Visual Studio Tools menu as administrator. For 64bit<br>
IE on x64 OS, run Visual Studio x64 Win64 Command Prompt (2010).<br>
<br>
Navigate to the folder that contains the build result VBBrowserHelperObject.dll and
<br>
enter the command:<br>
<br>
&nbsp; &nbsp;Regasm.exe VBBrowserHelperObject.dll /unregister<br>
<br>
The BHO is unregistered successfully if the command prints:<br>
<br>
&nbsp; &nbsp;&quot;Types un-registered successfully&quot;<br>
<br>
--------------------------------------<br>
In the Deployment Environment<br>
<br>
A. Setup<br>
<br>
For 32bit IE on x86 or x64 OS, install VBBrowserHelperObjectSetup(x86).msi, the output<br>
of the VBBrowserHelperObjectSetup(x86) setup project.<br>
<br>
For 64bit IE on x64 OS, install VBBrowserHelperObjectSetup(x64).msi outputted by the
<br>
VBBrowserHelperObjectSetup(x64) setup project.<br>
<br>
B. Removal<br>
<br>
For 32bit IE on x86 or x64 OS, uninstall VBBrowserHelperObjectSetup(x86).msi, the
<br>
output of the VBBrowserHelperObjectSetup(x86) setup project. <br>
<br>
For 64bit IE on x64 OS, uninstall VBBrowserHelperObjectSetup(x64).msi, the output of<br>
the VBBrowserHelperObjectSetup(x64) setup project.<br>
<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open this project in VS2010 and set the platform of the solution to x86. Make<br>
&nbsp; &nbsp; &nbsp; sure that the projects VBBrowserHelperObject and VBBrowserHelperObjectSetup(x86)<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; are selected to build in Configuration Manager.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; NOTE: If you want to use this BHO in 64bit IE, set the platform to x64 and
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; select VBBrowserHelperObject and VBBrowserHelperObjectSetup(x64) to build.<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
Step2. Build the solution.<br>
<br>
Step3. Right click the project VBBrowserHelperObjectSetup(x86) in Solution Explorer,
<br>
&nbsp; &nbsp; &nbsp; and choose &quot;Install&quot;.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; After the installation, open 32bit IE and click Tools=&gt;Manage Add-ons, in the
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Manage Add-ons dialog, you can find the item <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &quot;VBBrowserHelperObject.BHOIEContextMenu&quot; and make sure it is enabled. You may
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; have to restart IE to make it take effect. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; NOTE: You can also use the Regasm command in the &quot;Setup and Removal&quot; section.<br>
<br>
Step4. Open IE and visit <a target="_blank" href="http://www.microsoft.com/.">http://www.microsoft.com/.</a> After the page was loaded
<br>
&nbsp; &nbsp; &nbsp; completely, right click this page and you will find that the context menu is
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; disabled.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
A. Create the project and add references<br>
<br>
In Visual Studio 2010, create a Visual Basic / Windows / Class Library project <br>
named &quot;VBBrowserHelperObject&quot;. <br>
<br>
Right click the project in Solution Explorer and choose &quot;Add Reference&quot;. Add<br>
&quot;Microsoft HTML Object Library&quot; and &quot;Microsoft Internet Controls&quot; in COM tab.<br>
-----------------------------------------------------------------------------<br>
<br>
B. Implement a basic Component Object Model (COM) DLL<br>
<br>
A Browser Helper Object is a COM object implemented as a DLL. Making a basic <br>
.NET COM component is very straightforward. You just need to define a <br>
'public' class with ComVisible(true), use the Guid attribute to specify its <br>
CLSID, and explicitly implements certain COM interfaces. For example, <br>
<br>
&lt;ComVisible(True), ClassInterface(ClassInterfaceType.None),<br>
Guid(&quot;C42D40F0-BEBF-418D-8EA1-18D99AC2AB17&quot;)&gt;<br>
Public Class SimpleObject<br>
&nbsp; &nbsp;Implements ISimpleObject<br>
&nbsp;&nbsp;&nbsp;&nbsp;...<br>
EndClass<br>
<br>
<br>
You even do not need to implement IUnknown and class factory by yourself <br>
because .NET Framework handles them for you.<br>
<br>
-----------------------------------------------------------------------------<br>
<br>
C. Implement the IObjectWithSite interface. <br>
<br>
<br>
The BHOIEContextMenu.cs file defines the BHO. <br>
<br>
The class also implements the IObjectWithSite interface. In the SetSite method, you
<br>
can get an instance implemented the InternetExplorer interface.<br>
<br>
&nbsp; &nbsp; Public Sub SetSite(ByVal site As Object) Implements IObjectWithSite.SetSite<br>
&nbsp; &nbsp; &nbsp; &nbsp;If site IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ieInstance = CType(site, InternetExplorer)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Register the DocumentComplete event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddHandler ieInstance.DocumentComplete, AddressOf ieInstance_DocumentComplete<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Public Sub GetSite(ByRef guid_Renamed As Guid,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;System.Runtime.InteropServices.Out()&gt; ByRef ppvSite As Object) _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Implements IObjectWithSite.GetSite<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim punk As IntPtr = Marshal.GetIUnknownForObject(ieInstance)<br>
&nbsp; &nbsp; &nbsp; &nbsp;ppvSite = New Object()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim ppvSiteIntPtr As IntPtr = Marshal.GetIUnknownForObject(ppvSite)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim hr As Integer = Marshal.QueryInterface(punk, guid_Renamed, ppvSiteIntPtr)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Marshal.ThrowExceptionForHR(hr)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Marshal.Release(ppvSiteIntPtr)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Marshal.Release(punk)<br>
&nbsp; &nbsp;End Sub<br>
<br>
<br>
-----------<br>
Register the BHO:<br>
<br>
The registration and unregistration logic of the BHO are also implemented in <br>
this class. To register a BHO, a new key should be created under the key:<br>
<br>
HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\Browser Helper Objects<br>
<br>
<br>
-----------------------------------------------------------------------------<br>
<br>
D. Deploying the BHO with a setup project.<br>
<br>
&nbsp;(1) In BHOIEContextMenu, add an Installer class (named BHOInstaller in this
<br>
&nbsp; code sample) to define the custom actions in the setup. The class derives from<br>
&nbsp; System.Configuration.Install.Installer. We use the custom actions to <br>
&nbsp; register/unregister the COM-visible classes in the current managed assembly<br>
&nbsp; when user installs/uninstalls the component. <br>
<br>
&nbsp; &nbsp;&lt;RunInstaller(True), ComVisible(False)&gt;<br>
Partial Public Class BHOInstaller<br>
&nbsp; &nbsp;Inherits Installer<br>
&nbsp; &nbsp;Public Sub New()<br>
&nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)<br>
&nbsp; &nbsp; &nbsp; &nbsp;MyBase.Install(stateSaver)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim regsrv As New RegistrationServices()<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Not regsrv.RegisterAssembly(Me.GetType().Assembly,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AssemblyRegistrationFlags.SetCodeBase) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw New InstallException(&quot;Failed To Register for COM&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
&nbsp; <br>
&nbsp; &nbsp;Public Overrides Sub Uninstall(ByVal savedState As System.Collections.IDictionary)<br>
&nbsp; &nbsp; &nbsp; &nbsp;MyBase.Uninstall(savedState)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim regsrv As New RegistrationServices()<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Not regsrv.UnregisterAssembly(Me.GetType().Assembly) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw New InstallException(&quot;Failed To Unregister for COM&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
<br>
End Class<br>
<br>
&nbsp;In the overriden Install method, we use RegistrationServices.RegisterAssembly
<br>
&nbsp;to register the classes in the current managed assembly to enable creation <br>
&nbsp;from COM. The method also invokes the static method marked with <br>
&nbsp;ComRegisterFunctionAttribute to perform the custom COM registration steps. <br>
&nbsp;The call is equivalent to running the command: <br>
&nbsp;<br>
&nbsp; &nbsp;&quot;Regasm.exe VBBrowserHelperObject.dll /codebase&quot;<br>
<br>
&nbsp;in the development environment. <br>
<br>
&nbsp;(2) To add a deployment project, on the File menu, point to Add, and then <br>
&nbsp;click New Project. In the Add New Project dialog box, expand the Other <br>
&nbsp;Project Types node, expand the Setup and Deployment Projects, click Visual <br>
&nbsp;Studio Installer, and then click Setup Project. In the Name box, type <br>
&nbsp;VBBrowserHelperObjectSetup(x86). Click OK to create the project. <br>
&nbsp;In the Properties dialog of the setup project, make sure that the <br>
&nbsp;TargetPlatform property is set to x86. This setup project is to be deployed
<br>
&nbsp;for 32bit IE on x86 or x64 Windows operating systems. <br>
<br>
&nbsp;Right-click the setup project, and choose Add / Project Output ... <br>
&nbsp;In the Add Project Output Group dialog box, VBBrowserHelperObject will &nbsp;<br>
&nbsp;be displayed in the Project list. Select Primary Output and click OK. VS<br>
&nbsp;will detect the dependencies of the VBBrowserHelperObject, including .NET<br>
&nbsp;Framework 4.0 (Client Profile).&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
&nbsp;Right-click the setup project again, and choose View / Custom Actions. <br>
&nbsp;In the Custom Actions Editor, right-click the root Custom Actions node. On <br>
&nbsp;the Action menu, click Add Custom Action. In the Select Item in Project <br>
&nbsp;dialog box, double-click the Application Folder. Select Primary output from
<br>
&nbsp;VBBrowserHelperObject. This adds the custom actions that we defined <br>
&nbsp;in BHOInstaller of VBBrowserHelperObject. <br>
<br>
&nbsp;Build the setup project. If the build succeeds, you will get a .msi file <br>
&nbsp;and a Setup.exe file. You can distribute them to your users to install or <br>
&nbsp;uninstall this BHO. <br>
<br>
&nbsp;(3) To deploy the BHO for 64bit IE on a x64 operating system, you <br>
&nbsp;must create a new setup project (e.g. VBBrowserHelperObjectSetup(x64) <br>
&nbsp;in this code sample), and set its TargetPlatform property to x64. <br>
<br>
&nbsp;Although the TargetPlatform property is set to x64, the native shim <br>
&nbsp;packaged with the .msi file is still a 32-bit executable. The Visual Studio
<br>
&nbsp;embeds the 32-bit version of InstallUtilLib.dll into the Binary table as <br>
&nbsp;InstallUtil. So the custom actions will be run in the 32-bit, which is <br>
&nbsp;unexpected in this code sample. To workaround this issue and ensure that <br>
&nbsp;the custom actions run in the 64-bit mode, you either need to import the <br>
&nbsp;appropriate bitness of InstallUtilLib.dll into the Binary table for the <br>
&nbsp;InstallUtil record or - if you do have or will have 32-bit managed custom <br>
&nbsp;actions add it as a new record in the Binary table and adjust the <br>
&nbsp;CustomAction table to use the 64-bit Binary table record for 64-bit managed
<br>
&nbsp;custom actions. This blog article introduces how to do it manually with <br>
&nbsp;Orca <a target="_blank" href="http://blogs.msdn.com/b/heaths/archive/2006/02/01/64-bit-managed-custom-actions-with-visual-studio.aspx">
http://blogs.msdn.com/b/heaths/archive/2006/02/01/64-bit-managed-custom-actions-with-visual-studio.aspx</a><br>
<br>
&nbsp;In this code sample, we automate the modification of InstallUtil by using a
<br>
&nbsp;post-build javascript: Fix64bitInstallUtilLib.js. You can find the script <br>
&nbsp;file in the VBBrowserHelperObjectSetup(x64) project folder. To <br>
&nbsp;configure the script to run in the post-build event, you select the <br>
&nbsp;VBBrowserHelperObjectSetup(x64) project in Solution Explorer, and <br>
&nbsp;find the PostBuildEvent property in the Properties window. Specify its <br>
&nbsp;value to be <br>
&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&quot;$(ProjectDir)Fix64bitInstallUtilLib.js&quot; &quot;$(BuiltOuputPath)&quot; &quot;$(ProjectDir)&quot;<br>
<br>
&nbsp;Repeat the rest steps in (2) to add the project output, set the custom <br>
&nbsp;actions, configure the prerequisites, and build the setup project.<br>
<br>
</p>
<h3>Diagnostic:</h3>
<p style="font-family:Courier New"><br>
To debug BHO, you can attach to iexplorer.exe. <br>
<br>
<br>
<br>
<br>
References:<br>
<br>
Browser Helper Objects: The Browser the Way You Want It<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms976373.aspx">http://msdn.microsoft.com/en-us/library/ms976373.aspx</a><br>
<br>
Hosting and Reuse<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa752038(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa752038(VS.85).aspx</a><br>
<br>
IHTMLDocument2 Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa752574(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa752574(VS.85).aspx</a><br>
<br>
Mouse event handling problem in BHO<br>
<a target="_blank" href="http://social.msdn.microsoft.com/Forums/en/ieextensiondevelopment/thread/1ea154a5-5802-460c-9941-30f14b36d0a4">http://social.msdn.microsoft.com/Forums/en/ieextensiondevelopment/thread/1ea154a5-5802-460c-9941-30f14b36d0a4</a><br>
</p>
<h3></h3>
<p style="font-family:Courier New"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>