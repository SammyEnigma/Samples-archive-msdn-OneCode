# Create a VSX Project SubType (VBVSXProjectSubType)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Project SubType
* ProjectFlavor
## IsPublished
* True
## ModifiedDate
* 2011-08-08 07:32:38
## Description

<p style="font-family:Courier New"></p>
<h2>Visual Studio Package Project: VBVSXProjectSubType </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
A Project SubType, or called ProjectFlavor, let you customize or flavor the <br>
behavior of the project systems of Visual Studio. Customizations include <br>
1. Saving additional data in the project file.<br>
2. Adding or filtering items in the Add New Item dialog box.<br>
3. Controlling how assemblies are debugged and deployed.<br>
4. Extending the project Property Pages dialog box.<br>
<br>
In this sample, we demonstrate how to create a Project SubType with following <br>
features:<br>
1. Removing the Services Property Page.<br>
2. Adding a custom Property Page.<br>
3. Saving the data on the custom Property Page to project file.<br>
<br>
For more detailed information about Project SubTypes, please check <br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/bb166488.aspx">http://msdn.microsoft.com/en-us/library/bb166488.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166488.aspx">http://msdn.microsoft.com/en-us/library/bb166488.aspx</a><br>
</p>
<h3>How the Project SubTypes Work:</h3>
<p style="font-family:Courier New"><br>
First, we have to register our CustomPropertyPageProjectFactory to Visual Studio.<br>
<br>
Second, we need a Project Template, which is created by the VBVSXProjectSubTypeTemplate<br>
project.<br>
<br>
The ProjectTemplate.vbproj in VBVSXProjectSubTypeTemplate contains following script
<br>
&nbsp; &nbsp;&lt;ProjectTypeGuids&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;{9E1605FB-8DEB-462D-986B-B8866D9CDE60};<br>
&nbsp; &nbsp; &nbsp; &nbsp;{F184B08F-C81C-45F6-A57F-5ABD9991F28F}<br>
&nbsp; &nbsp;&lt;/ProjectTypeGuids&gt;<br>
<br>
&nbsp; &nbsp;{9E1605FB-8DEB-462D-986B-B8866D9CDE60} is the Guid of the CustomPropertyPageProjectFactory.<br>
&nbsp; &nbsp;{F184B08F-C81C-45F6-A57F-5ABD9991F28F} means Visual Basic project. <br>
<br>
At last, When Visual Studio is creating or opening a Visual Basic project with above ProjectTypeGuids,<br>
1. The environment calls the base project (Visual Basic Project)'s CreateProject, and while the
<br>
&nbsp; project parses its project file it discovers that the aggregate project type GUIDs list<br>
&nbsp; is not null. The project discontinues directly creating its project.<br>
<br>
2. If there are multiple project type GUIDs, the environment makes recursive function calls to
<br>
&nbsp; your implementations of PreCreateForOuter, <br>
&nbsp; Microsoft.VisualStudio.Shell.Interop.IVsAggregatableProject.SetInnerProject(System.Object)
<br>
&nbsp; and InitializeForOuter methods while it is walking the list of project type GUIDs,
<br>
&nbsp; starting with the outermost project subtype.<br>
<br>
3. In the PreCreateForOuter method of the ProjectFactory, we can return our ProjectFlavor object,<br>
&nbsp; which can customize the Property Page. <br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
Visual Studio 2010 Professional or Visual Studio 2010 Ultimate. Visual Studio 2010 SDK.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open this solution in Visual Studio 2010 Professional or better. <br>
<br>
Step2. Set the VBVSXProjectSubTypeVSIX as the StartUp Project, and open its property pages.
<br>
<br>
&nbsp; &nbsp; &nbsp; 1. Select the Debug tab. Set the Start Option to Start external program and browse
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;the devenv.exe (The default location is C:\Program Files\Microsoft Visual Studio<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;10.0\Common7\IDE\devenv.exe), and add &quot;/rootsuffix Exp&quot; (no quote) to the Command<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;line arguments.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; 2. Select the VSIX tab, make sure &quot;Create VSIX Container during build&quot; and
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;Deploy VSIX content to Experimental Instance for debugging&quot; are checked.<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
Step3. Build the solution. &nbsp;<br>
<br>
Step4. Press F5, and the Experimental Instance of Microsoft Visual Studio 2010 will
<br>
&nbsp; &nbsp; &nbsp; be launched.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; In the VS Experimental Instance, click Tool=&gt;Extension Manager, you will find
<br>
&nbsp; &nbsp; &nbsp; VBVSXProjectSubTypeVSIX is loaded.<br>
<br>
Step5. In the VS Experimental Instance, click File=&gt;New=&gt;Project. In the &quot;New Project&quot;<br>
&nbsp; &nbsp; &nbsp; dialog, you will find &quot;VBVSXProjectSubTypeTemplate&quot; in the Visual Basic templates.<br>
<br>
&nbsp; &nbsp; &nbsp; Use the VBVSXProjectSubTypeTemplate to create a new project, for example,
<br>
&nbsp; &nbsp; &nbsp; VBVSXProjectSubTypeTemplate1.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; <br>
Step6. Open the property page of VBVSXProjectSubTypeTemplate1, you will find that
<br>
&nbsp; &nbsp; &nbsp; 1. The &quot;Service&quot; Property Page is removed.<br>
&nbsp; &nbsp; &nbsp; 2. A new &quot;Custom&quot; Property Page is added.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
Step7. Select the &quot;Custom&quot; Property Page of VBVSXProjectSubTypeTemplate1, you will
<br>
&nbsp; &nbsp; &nbsp; see 3 controls: a Label, a TextBox and a CheckBox. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; Type some text in the TextBox and check the CheckBox, save it. And then open
<br>
&nbsp; &nbsp; &nbsp; VBVSXProjectSubTypeTemplate1.vbproj with NotePad, you will find the text that<br>
&nbsp; &nbsp; &nbsp; you typed.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A. Create a Visual Basic Project Template.<br>
<br>
&nbsp; VS SDK supplies a Project Template called &quot;Visual Basic Project Template&quot;, with it you can create a
<br>
&nbsp; Visual Basic Project Template. For more detailed steps, see <br>
&nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd885241.aspx">
http://msdn.microsoft.com/en-us/library/dd885241.aspx</a><br>
<br>
&nbsp; Then open the ProjectTemplate.vbproj in the VBVSXProjectSubTypeTemplate project, add
<br>
&nbsp; ProjectTypeGuids property to &lt;Project&gt;&lt;PropertyGroup&gt; element.<br>
<br>
&nbsp; &nbsp; &nbsp; &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;<br>
&nbsp; &nbsp; &nbsp; &lt;Project ToolsVersion=&quot;4.0&quot; DefaultTargets=&quot;Build&quot; xmlns=&quot;<a target="_blank" href="http://schemas.microsoft.com/developer/msbuild/2003&quot;&gt;">http://schemas.microsoft.com/developer/msbuild/2003&quot;&gt;</a><br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&lt;PropertyGroup&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;ProjectTypeGuids&gt;{9E1605FB-8DEB-462D-986B-B8866D9CDE60};{F184B08F-C81C-45F6-A57F-5ABD9991F28F}&lt;/ProjectTypeGuids&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ...<br>
&nbsp; <br>
&nbsp; {9E1605FB-8DEB-462D-986B-B8866D9CDE60} is the Guid of our Project Factory.<br>
&nbsp; {F184B08F-C81C-45F6-A57F-5ABD9991F28F} means Visual Basic project. <br>
<br>
<br>
B. Create a VSPackage project to Create and Register our Project Factory.<br>
<br>
&nbsp; Follow the steps in <a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb164725.aspx">
http://msdn.microsoft.com/en-us/library/bb164725.aspx</a> to create<br>
&nbsp; an Empty VS Package, NOT to check the &quot;Menu Command&quot; option in step5, and skip the<br>
&nbsp; step6.<br>
<br>
&nbsp; 1. The code files under the PropertyPageBase folder are from VS2005 SDK of April 2006.<br>
<br>
&nbsp; &nbsp; &nbsp;A PropertyPage object contains a PropertyStore object which stores the Properties,<br>
&nbsp; &nbsp; &nbsp;and a PageView object which is a UserControl used to display the Properties.<br>
<br>
&nbsp; &nbsp; &nbsp;The PropertyControlTable class stores the Control / Property Name KeyValuePairs,
<br>
&nbsp; &nbsp; &nbsp;and The PropertyControlMap class is used to initialize the Controls on a PageView<br>
&nbsp; &nbsp; &nbsp;Object by the PropertyPage object. <br>
<br>
&nbsp; 2. The CustomPropertyPage, CustomPropertyPagePropertyStore and CustomPropertyPageView<br>
&nbsp; &nbsp; &nbsp;classed under the ProjectFlavor folder inherit the classes or implement the
<br>
&nbsp; &nbsp; &nbsp;interfaces of the PropertyPageBase.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 3. The CustomPropertyPageProjectFlavor class is our ProjectFlavor, and the
<br>
&nbsp; &nbsp; &nbsp;CustomPropertyPageProjectFlavorCfg class give the project subtype access to various
<br>
&nbsp; &nbsp; &nbsp;configuration interfaces.<br>
<br>
&nbsp; &nbsp; &nbsp;By overriding GetProperty method and using propId parameter containing one of
<br>
&nbsp; &nbsp; &nbsp;the values of the __VSHPROPID2 enumeration, we can filter, add or remove project<br>
&nbsp; &nbsp; &nbsp;properties. <br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp;For example, to add a page to the configuration-dependent property pages, we<br>
&nbsp; &nbsp; &nbsp;need to filter configuration-dependent property pages and then add a new page
<br>
&nbsp; &nbsp; &nbsp;to the existing list. <br>
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; Protected Overrides Function GetProperty(ByVal itemId As UInteger,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal propId As Integer,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Out()&gt; ByRef [property] As Object) _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; As Integer<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If propId = CInt(__VSHPROPID2.VSHPROPID_CfgPropertyPagesCLSIDList) Then<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Get a semicolon-delimited list of clsids of the configuration-dependent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' property pages.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ErrorHandler.ThrowOnFailure(MyBase.GetProperty(itemId, propId, [property]))<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Add the CustomPropertyPage property page.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;[property] &#43;= AscW(&quot;;&quot;c) &#43; GetType(CustomPropertyPage).GUID.ToString(&quot;B&quot;)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return VSConstants.S_OK<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If propId = CInt(__VSHPROPID2.VSHPROPID_PropertyPagesCLSIDList) Then<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Get the list of priority page guids from the base project system.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ErrorHandler.ThrowOnFailure(MyBase.GetProperty(itemId, propId, [property]))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim pageList As String = CStr([property])<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Remove the Services page from the project designer.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim servicesPageGuidString As String = &quot;{43E38D2E-43B8-4204-8225-9357316137A4}&quot;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RemoveFromCLSIDList(pageList, servicesPageGuidString)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;[property] = pageList<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return VSConstants.S_OK<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return MyBase.GetProperty(itemId, propId, [property])<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
&nbsp; <br>
&nbsp; 4. The CustomPropertyPageProjectFactory class &nbsp;is the project factory for our project flavor.<br>
&nbsp; &nbsp; &nbsp;You can read the &quot;How the Project SubTypes Work:&quot; section to learn the code logic of this<br>
&nbsp; &nbsp; &nbsp;Project Factory.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; #region IVsAggregatableProjectFactory<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' Create an instance of CustomPropertyPageProjectFlavor.
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' The initialization will be done later when Visual Studio calls<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' InitalizeForOuter on it.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;outerProjectIUnknown&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' This value points to the outer project. It is useful if there is a
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' Project SubType of this Project SubType.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' An CustomPropertyPageProjectFlavor instance that has not been initialized.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Protected Overrides Function PreCreateForOuter(ByVal outerProjectIUnknown As IntPtr) As Object<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim newProject As New CustomPropertyPageProjectFlavor()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;newProject.Package = Me.package<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return newProject<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
<br>
<br>
&nbsp; 5. The VSXProjectSubTypePackage class is a VSPackage that registers our Project Factory
<br>
&nbsp; &nbsp; &nbsp;and Property Page.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;PackageRegistration(UseManagedResourcesOnly:=True), _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ProvideObject(GetType(ProjectFlavor.CustomPropertyPage),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; RegisterUsing:=RegistrationMethod.CodeBase), _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ProvideProjectFactory(GetType(ProjectFlavor.CustomPropertyPageProjectFactory),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;Task Project&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Nothing,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Nothing,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Nothing,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;..\Templates\Projects&quot;), _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Guid(GuidList.guidVBVSXProjectSubTypePkgString)&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Public NotInheritable Class VSXProjectSubTypePackage<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Inherits Package<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ...<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Protected Overrides Sub Initialize()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Trace.WriteLine(String.Format(CultureInfo.CurrentCulture,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;Entering Initialize() of: {0}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.GetType().Name))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MyBase.Initialize()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.RegisterProjectFactory(New ProjectFlavor.CustomPropertyPageProjectFactory(Me))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Class<br>
<br>
C. Create a VSIX project to package up the VSPackage and Project Template. <br>
&nbsp; <br>
&nbsp; Follow the steps in <a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd393742.aspx">
http://msdn.microsoft.com/en-us/library/dd393742.aspx</a> to create an <br>
&nbsp; empty VSIX project.<br>
<br>
&nbsp; Double click source.extension.vsixmanifest of VBVSXProjectSubTypeVSIX to open it. Click<br>
&nbsp; &quot;Add Content&quot; button to add the VSPackage of the VBVSXProjectSubType project, and
<br>
&nbsp; Project Template of the VBVSXProjectSubTypeTemplate.<br>
<br>
<br>
<br>
&nbsp; <br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Project Subtypes<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/bb166488.aspx">http://msdn.microsoft.com/en-us/library/bb166488.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166488.aspx">http://msdn.microsoft.com/en-us/library/bb166488.aspx</a><br>
<br>
IPropertyPage Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms691246(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms691246(VS.85).aspx</a><br>
<br>
FlavoredProjectFactoryBase Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.flavor.flavoredprojectfactorybase.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.flavor.flavoredprojectfactorybase.aspx</a><br>
<br>
FlavoredProjectBase Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.flavor.flavoredprojectbase.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.flavor.flavoredprojectbase.aspx</a><br>
<br>
IVsProjectFlavorCfgProvider Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsprojectflavorcfgprovider.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsprojectflavorcfgprovider.aspx</a><br>
<br>
IVsProjectFlavorCfg Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsprojectflavorcfg.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsprojectflavorcfg.aspx</a><br>
<br>
IPersistXMLFragment Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ipersistxmlfragment.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ipersistxmlfragment.aspx</a><br>
<br>
VSIX Deployment<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ff363239.aspx">http://msdn.microsoft.com/en-us/library/ff363239.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>