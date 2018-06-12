# Automate Office Ribbon through MSAA (VBOfficeRibbonAccessibility)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Office
## Topics
* VSTO
* Ribbon
* Accessibility
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:58:43
## Description

<p style="font-family:Courier New"></p>
<h2>VSTO APPLICATION : VBOfficeRibbonAccessibility Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This example illustrates how to pinvoke the Microsoft Active Accessibilty <br>
(MSAA) API to automate Office Ribbon controls. The code calls the following <br>
APIs,<br>
<br>
&nbsp; &nbsp;AccessibleObjectFromWindow, <br>
&nbsp; &nbsp;AccessibleChildren,<br>
&nbsp; &nbsp;GetRoleText,<br>
&nbsp; &nbsp;GetStateText,<br>
<br>
to display the whole structure of the Office ribbon, including tabs, groups,<br>
and controls. It also shows how to nagivate to a tab and execute button <br>
function programmatically.<br>
<br>
</p>
<h3>Prerequisties:</h3>
<p style="font-family:Courier New"><br>
* Visual Studio 2010 and Office 2010<br>
or <br>
* Visual Studio 2008 and Office 2007<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
1. Compile the VSTO project using Visual Studio 2008 or 2010.<br>
<br>
2. Open your Office Word 2007 or 2010. You should see a group named <br>
&quot;VBOfficeRibbonAccessibility&quot; in the Add-Ins ribbon tab. In the group, there
<br>
is a button &quot;Show Ribbon Information&quot;.<br>
<br>
3. Click the &quot;Show Ribbon Information&quot; button. You will see a windows form
<br>
with the title &quot;Ribbon Information&quot;.<br>
<br>
4. In the &quot;Tabs&quot; list box, you can see all visible tabs. Clicking any of them
<br>
make the office navigate to that tab.<br>
<br>
6. By click the button &quot;List child groups&quot;, the form will list all groups in
<br>
the currently selected tab in the &quot;Groups&quot; list box.<br>
<br>
7. Select a group and click the button &quot;List child controls&quot;. The form will
<br>
list all controls in the currently selected group in the &quot;Controls&quot; list box.
<br>
<br>
8. Select a control, and click the button &quot;Execute selected control&quot;. the form<br>
will invoke the selected control's function.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a VSTO Word 2010 AddIn using Visual Studio 2010. Right click the <br>
project, and click Add-&gt;New Item. In the popup dialog, choose Office tab, &nbsp;<br>
select the Ribbon (Visual Designer) at the right panel and click OK. In the <br>
Ribbon designer, drag a button to the Add-ins Tab. Double click the button to <br>
generate a ribbon control click event handler.<br>
<br>
Step2. Right click the project, and click Add-&gt;New Item. In the popup dialog, <br>
choose the Windows Form tab, and add a Form named RibbonInfoForm. In the <br>
Form designer, drag labels, listboxs, and buttons as the sample shows.<br>
<br>
Step3. In the event handler created in step 1, we add code to show the <br>
RibbonInfoForm form.<br>
<br>
&nbsp; &nbsp;Dim form As New RibbonInfoForm()<br>
&nbsp; &nbsp;form.Show()<br>
<br>
----------------<br>
<br>
B. Using the Microsoft Active Accessibility API<br>
<br>
Microsoft Active Accessibility (MSAA) is an API for user interface <br>
accessibility. The Accessibility interface offers a hierarchy of objects <br>
subordinate to the main window of the Office 2007/2010 applications. You can <br>
use the API to automate Office ribbon controls. <br>
<br>
NativeMethods.cs declares the P/Invoke signatures for MSAA APIs:<br>
&nbsp; &nbsp;AccessibleChildren<br>
&nbsp; &nbsp;AccessibleObjectFromWindow<br>
&nbsp; &nbsp;GetRoleText<br>
&nbsp; &nbsp;GetStateText<br>
<br>
MSAAHelper.cs provides helper functions that invoke the native MSAA APIs:<br>
&nbsp; &nbsp;GetAccessibleChildren<br>
&nbsp; &nbsp;GetAccessibleObjectListByRole<br>
&nbsp; &nbsp;GetAccessibleObjectFromHandle<br>
&nbsp; &nbsp;GetAccessibleObjectByNameAndRole<br>
&nbsp; &nbsp;GetRoleText<br>
&nbsp; &nbsp;GetStateText<br>
<br>
In RibbonInfoForm.cs, the form lists all accessible ribbon tab, group and <br>
control objects, and execute their default actions. The sample basically does <br>
the following logic:<br>
<br>
&nbsp;1. Find the top window of the Office application, and get its IAccessible <br>
&nbsp; &nbsp; interface. <br>
&nbsp;2. Get the IAccessibile interface for the ribbon object.<br>
&nbsp;3. Recurse through the IAccessibility tree and find the tabs, groups and <br>
&nbsp; &nbsp; controls. We use the accessible name and role to identify the tabs,
<br>
&nbsp; &nbsp; groups and controls. You can use the Inspect tool in the Windows SDK to
<br>
&nbsp; &nbsp; inspet the accessible name and role of the Office ribbon.<br>
&nbsp; &nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd318521.aspx">
http://msdn.microsoft.com/en-us/library/dd318521.aspx</a><br>
&nbsp;4. Execute the default action (in case of ribbon tabs the default action is
<br>
&nbsp; &nbsp; switch, for buttons it’s click and for the dropdowns it’s drop).<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
How to switch ribbon tab programmatically... looks simple?<br>
<a target="_blank" href="http://blogs.msdn.com/b/pranavwagh/archive/2008/01/21/how-to-switch-ribbon-tab-programmatically-looks-simple.aspx">http://blogs.msdn.com/b/pranavwagh/archive/2008/01/21/how-to-switch-ribbon-tab-programmatically-looks-simple.aspx</a><br>
<br>
Microsoft Active Accessibility<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms697707.aspx">http://msdn.microsoft.com/en-us/library/ms697707.aspx</a><br>
<br>
Accessing the Ribbon with VBA<br>
<a target="_blank" href="http://www.wordarticles.com/Shorts/RibbonVBA/RibbonVBADemo.htm">http://www.wordarticles.com/Shorts/RibbonVBA/RibbonVBADemo.htm</a><br>
<br>
UI Automation using Microsoft Active Accessibility(MSAA)<br>
<a target="_blank" href="http://www.codeproject.com/KB/winsdk/MSAA_UI_Automation.aspx">http://www.codeproject.com/KB/winsdk/MSAA_UI_Automation.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
