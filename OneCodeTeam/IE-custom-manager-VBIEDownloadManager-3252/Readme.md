# IE custom download manager (VBIEDownloadManager)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Internet Explorer
## Topics
* Download Manager
## IsPublished
* True
## ModifiedDate
* 2011-05-26 02:14:36
## Description

<p style="font-family:Courier New"></p>
<h2>IE Extension: VBIEDownloadManager</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New">The sample demonstrates how to implement a custom download manager for IE.
<br>
When IE starts to download a file, the VBWebDownloader.exe will be launched to<br>
download the file.<br>
<br>
NOTE: Some third party download extensions for IE may conflict with this code sample,<br>
&nbsp; &nbsp; &nbsp;so it is better to disable them temporarily before you try out the sample. &nbsp;<br>
</p>
<h3>Setup and Removal:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
For 32bit IE on x86 or x64 OS, install VBIEDownloadManagerSetup(x86).msi, the output<br>
of the VBIEDownloadManagerSetup(x86) setup project.<br>
<br>
For 64bit IE on x64 OS, install VBIEDownloadManagerSetup(x64).msi outputted by the
<br>
VBIEDownloadManagerSetup(x64) setup project.<br>
<br>
B. Removal<br>
<br>
For 32bit IE on x86 or x64 OS, uninstall VBIEDownloadManagerSetup(x86).msi, the <br>
output of the VBIEDownloadManagerSetup(x86) setup project. <br>
<br>
For 64bit IE on x64 OS, uninstall VBIEDownloadManagerSetup(x64).msi, the output of<br>
the VBIEDownloadManagerSetup(x64) setup project.<br>
&nbsp; </p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open this project in VS2010 and set the platform of the solution to x86. Make<br>
&nbsp; &nbsp; &nbsp; sure that the projects VBIEDownloadManagerSetup, VBWebDownloader and
<br>
&nbsp; &nbsp; &nbsp; VBIEDownloadManagerSetup(x86) are selected to build in Configuration Manager.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; NOTE: If you want to run this sample in 64bit IE, set the platform to x64 and
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; select VBIEDownloadManagerSetup, VBWebDownloader and
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; VBIEDownloadManagerSetup(x64) to build.<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
Step2. Build the solution.<br>
<br>
Step3. Right click the project VBIEDownloadManagerSetup(x86) in Solution Explorer,
<br>
&nbsp; &nbsp; &nbsp; and choose &quot;Install&quot;.<br>
<br>
<br>
Step4. Open 32bit IE and visit the the download link of Microsoft .NET Framework 4
<br>
&nbsp; &nbsp; &nbsp; <a target="_blank" href="http://www.microsoft.com/downloads/en/details.aspx?displaylang=en&FamilyID=0a391abd-25c1-4fc0-919f-b21f31ab88b7.">
http://www.microsoft.com/downloads/en/details.aspx?displaylang=en&FamilyID=0a391abd-25c1-4fc0-919f-b21f31ab88b7.</a><br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; Click the &quot;Download&quot; button on this page, and then VBWebDownloader.exe will
<br>
&nbsp; &nbsp; &nbsp; be launched. In VBWebDownloader.exe, you will find that the url is
<br>
&nbsp; &nbsp; &nbsp; <a target="_blank" href="http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe">
http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe</a><br>
&nbsp; &nbsp; &nbsp; and the local path is D:\dotNetFx40_Full_x86_x64.exe<br>
<br>
Step5. Click the button &quot;Download&quot; in VBWebDownloader.exe, it will start to download
<br>
&nbsp; &nbsp; &nbsp; the file, and after a few minutes, you will find a file D:\dotNetFx40_Full_x86_x64.exe<br>
&nbsp; &nbsp; &nbsp; in Windows Explorer.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A. Create the VBWebDownloader project with following features:<br>
&nbsp; 1. Set the buffer and cache size.<br>
&nbsp; 2. Download a specified block data of the whole file. <br>
&nbsp; 3. Start, Pause, Resume and Cancel a download. &nbsp;<br>
&nbsp; 4. Supply the file size, download speed and used time.<br>
&nbsp; 5. Expose the events StatusChanged, DownloadProgressChanged and DownloadCompleted.<br>
&nbsp; 6. Can be launched with an argument (the file to download).<br>
<br>
&nbsp; For more detailed information about the VBWebDownloader.exe, see <br>
&nbsp; <a target="_blank" href="http://code.msdn.microsoft.com/VBWebDownloader-5fdcfb74">
http://code.msdn.microsoft.com/VBWebDownloader-5fdcfb74</a> <br>
<br>
B. Create the VBIEDownloadManager project.<br>
<br>
&nbsp; In Visual Studio 2010, create a Visual Basic / Windows / Class Library project
<br>
&nbsp; named &quot;VBIEDownloadManager&quot;. <br>
&nbsp; <br>
&nbsp; The ability to implement a custom download manager was introduced in Microsoft
<br>
&nbsp; Internet Explorer 5.5. This feature enables you to extend the functionality of
<br>
&nbsp; Windows Internet Explorer and WebBrowser applications by implementing a Component<br>
&nbsp; Object Model (COM) object to handle the file download process.<br>
&nbsp; <br>
&nbsp; A download manager is implemented as a COM object that exposes the IUnknown and<br>
&nbsp; IDownloadManager interface. IDownloadManager has only one method, <br>
&nbsp; IDownloadManager::Download, which is called by Internet Explorer or a WebBrowser<br>
&nbsp; application to download a file. <br>
&nbsp; <br>
&nbsp; For Internet Explorer 6 and later, if the WebBrowser application does not implement<br>
&nbsp; the IServiceProvider::QueryService method, or when using Internet Explorer itself
<br>
&nbsp; for which IServiceProvider::QueryService cannot be implemented, the application
<br>
&nbsp; checks for the presence of a registry key containing the class identifier (CLSID)
<br>
&nbsp; of the download manager COM object. The CLSID can be provided in either of the
<br>
&nbsp; following registry values.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; HKEY_LOCAL_MACHINE<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Software<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Microsoft<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Internet Explorer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; DownloadUI<br>
&nbsp; &nbsp; &nbsp; HKEY_CURRENT_USER<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Software<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Microsoft<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Internet Explorer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; DownloadUI<br>
&nbsp; <br>
&nbsp; DownloadUI is not a key, it is a REG_SZ value under Software\Microsoft\Internet Explorer.<br>
&nbsp; <br>
&nbsp; If the application cannot locate a custom download manager the default download user
<br>
&nbsp; interface is used.<br>
&nbsp; <br>
&nbsp; The IEDownloadManager class implements the IDownloadManager interface. When IE starts to
<br>
&nbsp; download a file, the Download method of this class will be called, and then the
<br>
&nbsp; VBWebDownloader.exe will be launched to download the file.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Function Download(ByVal pmk As IMoniker, ByVal pbc As IBindCtx,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal dwBindVerb As UInteger, ByVal grfBINDF As Integer,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal pBindInfo As IntPtr, ByVal pszHeaders As String,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal pszRedir As String, ByVal uiCP As UInteger) As Integer Implements NativeMethods.IDownloadManager.Download<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Get the display name of the pointer to an IMoniker interface that specifies<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' the object to be downloaded.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim name As String = String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;pmk.GetDisplayName(pbc, Nothing, name)<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not String.IsNullOrEmpty(name) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim url As Uri = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim result As Boolean = Uri.TryCreate(name, UriKind.Absolute, url)<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If result Then<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Launch VBWebDownloader.exe to download the file.
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim assemblyFile As New FileInfo(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Reflection.Assembly.GetExecutingAssembly().Location)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim start As ProcessStartInfo = New ProcessStartInfo With _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{.Arguments = name,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; .FileName = String.Format(&quot;{0}\VBWebDownloader.exe&quot;, assemblyFile.DirectoryName)}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Process.Start(start)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return 1<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
&nbsp; <br>
&nbsp; This class will also set the registry values when this assembly is registered to COM.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Called when derived class is registered as a COM server.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;ComRegisterFunction()&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Shared Sub Register(ByVal t As Type)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim ieKeyPath As String = &quot;SOFTWARE\Microsoft\Internet Explorer\&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Using ieKey As RegistryKey = Registry.LocalMachine.CreateSubKey(ieKeyPath)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ieKey.SetValue(&quot;DownloadUI&quot;, t.GUID.ToString(&quot;B&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Using<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Called when derived class is unregistered as a COM server.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;ComUnregisterFunction()&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Shared Sub Unregister(ByVal t As Type)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim ieKeyPath As String = &quot;SOFTWARE\Microsoft\Internet Explorer\&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Using ieKey As RegistryKey = Registry.LocalMachine.OpenSubKey(ieKeyPath, True)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ieKey.DeleteValue(&quot;DownloadUI&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Using<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
C. Deploying the IE Download Manager with a setup project.<br>
&nbsp; <br>
&nbsp; 1. In VBIEDownloadManager, add an Installer class (named IEDownloadManagerInstaller
<br>
&nbsp; &nbsp; &nbsp;in this sample) to define the custom actions in the setup. The class derives from<br>
&nbsp; &nbsp; &nbsp;System.Configuration.Install.Installer. We use the custom actions to
<br>
&nbsp; &nbsp; &nbsp;register/unregister the COM-visible classes in the current managed assembly when<br>
&nbsp; &nbsp; &nbsp;user installs/uninstalls the component. <br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;RunInstaller(True)&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Partial Public Class IEDownloadManagerInstaller<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Inherits Installer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Public Sub New()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; InitializeComponent()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' This is called when installer's custom action executes and<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' registers the explorer bar as COM server.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;param name=&quot;stateSaver&quot;&gt;&lt;/param&gt; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MyBase.Install(stateSaver)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim regsrv As New RegistrationServices()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If Not regsrv.RegisterAssembly(Me.GetType().Assembly,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AssemblyRegistrationFlags.SetCodeBase) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Throw New InstallException(&quot;Failed To Register for COM&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' This is called when installer's custom action executes and<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' unregisters the explorer bar.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;param name=&quot;stateSaver&quot;&gt;&lt;/param&gt; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Public Overrides Sub Uninstall(ByVal savedState As System.Collections.IDictionary)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MyBase.Uninstall(savedState)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim regsrv As New RegistrationServices()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If Not regsrv.UnregisterAssembly(Me.GetType().Assembly) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Throw New InstallException(&quot;Failed To Unregister for COM&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Class<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; <br>
&nbsp; 2. To add a deployment project, on the File menu, point to Add, and then click
<br>
&nbsp; &nbsp; &nbsp;New Project. In the Add New Project dialog box, expand the Other Project Types node,<br>
&nbsp; &nbsp; &nbsp;expand the Setup and Deployment Projects, click Visual Studio Installer, and then
<br>
&nbsp; &nbsp; &nbsp;click Setup Project. In the Name box, type VBIEDownloadManagerSetup(x86). Click OK<br>
&nbsp; &nbsp; &nbsp;to create the project. <br>
<br>
&nbsp; &nbsp; &nbsp;In the Properties dialog of the setup project, make sure that the TargetPlatform
<br>
&nbsp; &nbsp; &nbsp;property is set to x86. This setup project is to be deployed for 32bit IE on x86
<br>
&nbsp; &nbsp; &nbsp;or x64 Windows operating systems. <br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp;Right-click the setup project, and choose Add / Project Output .... In the
<br>
&nbsp; &nbsp; &nbsp;Add Project Output Group dialog box, VBIEDownloadManager and &nbsp;VBWebDownloader will &nbsp;<br>
&nbsp; &nbsp; &nbsp;be displayed in the Project list. Select the Primary Output (with the Debug | Any CPU<br>
&nbsp; &nbsp; &nbsp;configuration) of them and click OK. VS will detect the dependencies of the
<br>
&nbsp; &nbsp; &nbsp;VBIEDownloadManager and &nbsp;VBWebDownloader, including .NET Framework 4.0 (Client Profile).<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp;Right-click the setup project, and choose View / Custom Actions. In the
<br>
&nbsp; &nbsp; &nbsp;Custom Actions Editor, right-click the root Custom Actions node. On the Action menu,
<br>
&nbsp; &nbsp; &nbsp;click Add Custom Action. In the Select Item in Project dialog box, double-click the
<br>
&nbsp; &nbsp; &nbsp;Application Folder. Select Primary output from VBIEDownloadManager. This adds the
<br>
&nbsp; &nbsp; &nbsp;custom actions that we defined in IEDownloadManagerInstaller of VBIEDownloadManager.
<br>
&nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp;Build the setup project. If the build succeeds, you will get a .msi file
<br>
&nbsp; &nbsp; &nbsp;and a Setup.exe file. You can distribute them to your users to install or
<br>
&nbsp; &nbsp; &nbsp;uninstall this IE Download Manager. <br>
&nbsp; <br>
&nbsp; 3. To deploy the Explorer Bar for 64bit IE on a x64 operating system, you must create
<br>
&nbsp; &nbsp; &nbsp;a new setup project (e.g. VBIEDownloadManagerSetup(x64) in this sample), and set its<br>
&nbsp; &nbsp; &nbsp;TargetPlatform property to x64. <br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp;Although the TargetPlatform property is set to x64, the native shim packaged with
<br>
&nbsp; &nbsp; &nbsp;the .msi file is still a 32-bit executable. The Visual Studio embeds the 32-bit
<br>
&nbsp; &nbsp; &nbsp;version of InstallUtilLib.dll into the Binary table as InstallUtil. So the custom<br>
&nbsp; &nbsp; &nbsp;actions will be run in the 32-bit, which is unexpected in this code sample. To
<br>
&nbsp; &nbsp; &nbsp;workaround this issue and ensure that the custom actions run in the 64-bit mode, you<br>
&nbsp; &nbsp; &nbsp;either need to import the appropriate bitness of InstallUtilLib.dll into the Binary<br>
&nbsp; &nbsp; &nbsp;table for the InstallUtil record or - if you do have or will have 32-bit managed custom
<br>
&nbsp; &nbsp; &nbsp;actions add it as a new record in the Binary table and adjust the CustomAction table
<br>
&nbsp; &nbsp; &nbsp;to use the 64-bit Binary table record for 64-bit managed custom actions. This blog
<br>
&nbsp; &nbsp; &nbsp;article introduces how to do it manually with Orca<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://blogs.msdn.com/b/heaths/archive/2006/02/01/64-bit-managed-custom-actions-with-visual-studio.aspx">http://blogs.msdn.com/b/heaths/archive/2006/02/01/64-bit-managed-custom-actions-with-visual-studio.aspx</a><br>
&nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp;In this code sample, we automate the modification of InstallUtil by using a post-build<br>
&nbsp; &nbsp; &nbsp;javascript: Fix64bitInstallUtilLib.js. You can find the script file in the
<br>
&nbsp; &nbsp; &nbsp;VBIEDownloadManagerSetup(x64) project folder. To configure the script to run in the
<br>
&nbsp; &nbsp; &nbsp;post-build event, you select the VBIEDownloadManagerSetup(x64) project in Solution Explorer,<br>
&nbsp; &nbsp; &nbsp;and find the PostBuildEvent property in the Properties window. Specify its value to be
<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;$(ProjectDir)Fix64bitInstallUtilLib.js&quot; &quot;$(BuiltOuputPath)&quot; &quot;$(ProjectDir)&quot;<br>
&nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp;Repeat the rest steps in 2 to add the project output, set the custom actions, configure<br>
&nbsp; &nbsp; &nbsp;the prerequisites, and build the setup project.<br>
&nbsp; <br>
</p>
<h3>Diagnostic:</h3>
<p style="font-family:Courier New"><br>
To debug the ID Download Manager, you can attach to iexplorer.exe. <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Implementing a Custom Download Manager<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa753618(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa753618(VS.85).aspx</a><br>
<br>
How to implement a custom download manager<br>
<a target="_blank" href="http://support.microsoft.com/kb/327865">http://support.microsoft.com/kb/327865</a><br>
<br>
IDownloadManager Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa753613(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa753613(VS.85).aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
