# Hide Ribbon from anonymous users (CSSharePointHideRibbonFromAnonymous)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* Ribbon
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:47:42
## Description

<h1><span style="">Hide SharePoint Ribbon for anonymous <a name="OLE_LINK5"></a><a name="OLE_LINK6"><span style="">users
</span></a></span><span style=""></span><span style=""></span>(<span class="SpellE"><span style="">CSSharePointHideRibbonFromAnonymous</span></span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">The project demonstrates how to hide ribbon for anonymous <span style="">
users</span>.<span style="color:#384B38"> </span>This sample will remove the ribbon from the master page if anonymous users logged in. Javascript code will check if the user is anonymous or not.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.<br>
Step 1: Open the &quot;CSSharePointHideRibbonFromAnonymous.sln&quot;. Set the &quot;Site URL&quot; property of the project to the URL of your own site.<br>
Step 2: Right-click the solution then click &quot;Deploy&quot;.<br>
Step 3: Under the &quot;Site Administration&quot; node of your site, you may find a new setting item named &quot;Ribbon Visibility settings&quot;.<br>
Step 4: Make sure the option &quot;Hide the ribbon for anonymous user&quot; is checked then click the save button.
<br>
Step 5: Try to access your site with an <a name="OLE_LINK7">anonymous </a>user.<br style="">
<br style="">
</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1. Create a C# &quot;Empty SharePoint Project&quot; in Visual Studio 2010. Name it as &quot;<span class="SpellE">CSSharePointHideRibbonFromAnonymous</span>&quot;.<span style="">&nbsp;
</span>In the SharePoint Customization Wizard, choose &quot;Deploy as a farm solution&quot;, and then click &quot;Finish&quot;.</p>
<p class="MsoNormal"><span class="GramE">Step 2.</span> In the Solution Explorer, you can right-click the project. Select &quot;Add SharePoint Mapped Folder&quot;
<span style="font-family:Wingdings"><span style="">è</span></span> &quot;TEMPLATE&quot;
<span style="font-family:Wingdings"><span style="">è</span></span> &quot;<span class="SpellE">ControlTemplates</span>&quot;.</p>
<p class="MsoNormal"><span class="GramE">Step 3.</span> Add &quot;SharePoint Layouts Mapped Folder&quot;. Select &quot;Add&quot;
<span style="font-family:Wingdings"><span style="">è</span></span> &quot;New Item&quot; to add two &quot;Empty Element&quot;. Name them &quot;actions&quot; and &quot;Controls&quot;.</p>
<p class="MsoNormal"><span class="GramE">Step 4.</span> Right-click the &quot;<span class="SpellE">ControlTemplates</span>&quot; folder and add a new folder named &quot;<span class="SpellE">SPRibbonVisibility</span>&quot;, and then add a
<span class="SpellE">UserControl</span> named &quot;RibbonVisibility.ascx&quot;.</p>
<p class="MsoNormal"><span class="GramE">Step 5.</span> Right-click the &quot;Layouts&quot; folder and add a new folder named &quot;<span class="SpellE">SPRibbonVisibility</span>&quot;, and then add a new
<span class="SpellE">ApplicationPage</span> named &quot;RibbonVisibility.ascx&quot;.</p>
<p class="MsoNormal"><span class="GramE">Step 6.</span> Modify the contents of the following two Elements.xml files.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Elements.xml of actions:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;
        &lt;CustomAction Id=&quot;RibbonVisibilitySiteAction&quot; GroupId=&quot;SiteAdministration&quot; Location=&quot;Microsoft.SharePoint.SiteSettings&quot;    Title=&quot;Ribbon Visibility settings&quot;&gt;
         &lt;UrlAction Url=&quot;~site/_layouts/SPRibbonVisibility/RibbonVisibility.aspx&quot;/&gt;
        &lt;/CustomAction&gt;
      &lt;/Elements&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;
        &lt;CustomAction Id=&quot;RibbonVisibilitySiteAction&quot; GroupId=&quot;SiteAdministration&quot; Location=&quot;Microsoft.SharePoint.SiteSettings&quot;    Title=&quot;Ribbon Visibility settings&quot;&gt;
         &lt;UrlAction Url=&quot;~site/_layouts/SPRibbonVisibility/RibbonVisibility.aspx&quot;/&gt;
        &lt;/CustomAction&gt;
      &lt;/Elements&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Elements.xml of Controls:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;
      &lt;Control Id=&quot;AdditionalPageHead&quot; ControlSrc=&quot;~/_controltemplates/SPRibbonVisibility/RibbonVisibility.ascx&quot; Sequence=&quot;10011&quot; /&gt;
    &lt;/Elements&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;
      &lt;Control Id=&quot;AdditionalPageHead&quot; ControlSrc=&quot;~/_controltemplates/SPRibbonVisibility/RibbonVisibility.ascx&quot; Sequence=&quot;10011&quot; /&gt;
    &lt;/Elements&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="">Step 7. The RibbonVisibility.aspx page is used to show the setting item and execute the setting. The method &quot;ApplyInitialValue&quot; is used to do the initialization. The method &quot;<span class="SpellE">ApplyValue</span>&quot;
 is used to update the setting for anonymous user.</p>
<p class="MsoNormal" style=""><span class="GramE">Step 8.</span> The RibbonVisibility.ascx page is a Delegate Control .The method &quot;<span class="SpellE">InjectScript</span>&quot; injects the &quot;RibbonVisibility.js&quot; to control master page.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
string scriptfile = &quot;/_controltemplates/SPRibbonVisibility/RibbonVisibility.js&quot;; 
        ScriptManager.RegisterClientScriptInclude(this, typeof(RibbonVisibilityControl), &quot;SPRibbonVisibility&quot;, scriptfile);

</pre>
<pre id="codePreview" class="csharp">
string scriptfile = &quot;/_controltemplates/SPRibbonVisibility/RibbonVisibility.js&quot;; 
        ScriptManager.RegisterClientScriptInclude(this, typeof(RibbonVisibilityControl), &quot;SPRibbonVisibility&quot;, scriptfile);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//check whether Anonymous or not
   if (SPContext.Current.Web.CurrentUser == null)
   {
       if (hideForAnonymous)
           InjectScript();
       else
           return;
   }

</pre>
<pre id="codePreview" class="csharp">
//check whether Anonymous or not
   if (SPContext.Current.Web.CurrentUser == null)
   {
       if (hideForAnonymous)
           InjectScript();
       else
           return;
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="">Step 9. Build the feature and you can test it.</p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/ms463169.aspx">Delegate Control (Control
<span class="SpellE">Templatization</span>)</a> </span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.web.httprequest.servervariables.aspx"><span class="SpellE">HttpRequest.ServerVariables</span> Property</a>
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/ms470880.aspx">How to: Customize a Delegate Control</a><br style="">
<br style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
