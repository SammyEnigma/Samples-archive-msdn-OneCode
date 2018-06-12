# Url Routing in Windows Azure (CSAzureUrlRouting)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Microsoft Azure
## Topics
* URL Routing
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:32:53
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<p class="MsoNormal">To build this sample successfully, please make sure you have installed<span> Windows Azure SDK 1.6 and SQL Server 2008 R2.</span></p>
<p class="MsoNormal">1. <span>Open the</span><strong><span style="font-size:14.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></strong><span>CSAzureUrlRouting</span><span>.sln file with Visual Studio </span>
in elevated (administrator) mode<span>, and then you need to set </span><span class="SpellE"><span>CSAzureUrlRouting</span></span><span> Azure application as the startup application.</span><em><span>
</span></em></p>
<p class="MsoNormal">2.<span> </span>Set Default.aspx as the startup page, and press F5 to start the Azure emulator. You will see some links on the page. Please also open the Solution Explorer of Visual Studio and observe folders and web form pages, the URL
 routing format is {Root}<span class="GramE">/{</span>Directory Name}/{File Name}.</p>
<p class="MsoNormal"><img src="/site/view/file/61979/1/image.png" alt="" width="583" height="533" align="middle">
<span><br>
</span></p>
<p class="MsoNormal">3. <span>If the URL format is correct, Root/directory name follow the &quot;Routing.xml&quot; in the
<span class="SpellE">App_Data</span> folder and the page exists. You will see the page in Browser like below:
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/61980/1/image.png" alt="" width="583" height="533" align="middle">
</span></p>
<p class="MsoNormal">4. <span>If the file does not exist or the folder name and the root name don't map, for example, try to access Sample/PageResources2/Page3.aspx in browser, you will see NoHandler.aspx.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/61981/1/image.png" alt="" width="587" height="537" align="middle">
</span></p>
<p class="MsoNormal">5. <span>Validation finished </span></p>
<p class="MsoNormal"><span>1</span>. <span>Create a Windows Azure Application Project in Visual Studio 2010; name it as &quot;<span class="SpellE"><span>CSAzureUrlRouting</span></span>&quot;.
</span></p>
<p class="MsoNormal"><span>2. </span>Create a Web Role and name it as &quot;<span class="SpellE">CSAzureUrlRouting_WebRole</span>&quot;, this project is used to create a web application and implement URL Routing map in
<span class="SpellE">Global.asax</span> page. <strong></strong></p>
<p class="MsoNormal">3. Add a class file implement <span class="SpellE">IRouteHandler</span> interface, this handler class can retrieve parameters and values from URL string variable (follow
<span class="SpellE">url</span> routing format), also it will check if URL rule is correct and if the file exists, if not, provide NoHandler.aspx page as the response.</p>
<p class="MsoNormal"><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">The following code shows</span></strong><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;"> how to implement
<span class="SpellE">IRouteHandler</span> interface and <span class="SpellE">
GetHttpHandler</span> method: </span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Check URLs from requests.
/// &lt;/summary&gt;
/// &lt;param name=&quot;requestContext&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
public IHttpHandler GetHttpHandler(RequestContext requestContext)
{
    string root = requestContext.RouteData.Values[&quot;root&quot;].ToString().ToLower();
    string name = requestContext.RouteData.Values[&quot;name&quot;].ToString().ToLower();
    string directory = requestContext.RouteData.Values[&quot;directory&quot;].ToString().ToLower();
    string page = string.Format(&quot;~/{0}/{1}&quot;, directory, name);
    string xmlPath = requestContext.HttpContext.Server.MapPath(&quot;~/App_Data/Routing.xml&quot;);
    if(!IsInRoot(directory,root, xmlPath))
        return BuildManager.CreateInstanceFromVirtualPath(&quot;~/NoHandler.aspx&quot;, typeof(Page)) as IHttpHandler;
    if(File.Exists(requestContext.HttpContext.Server.MapPath(page)))
    {
        IHttpHandler handler = BuildManager.CreateInstanceFromVirtualPath(page, typeof(Page)) as IHttpHandler;
        return handler;
    }
    else
    {
        return BuildManager.CreateInstanceFromVirtualPath(&quot;~/NoHandler.aspx&quot;, typeof(Page)) as IHttpHandler;
    }
}


/// &lt;summary&gt;
/// Check directory name is in root node (XML file).
/// &lt;/summary&gt;
/// &lt;param name=&quot;directory&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;root&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;xmlPath&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private bool IsInRoot(string directory, string root, string xmlPath)
{
    XDocument document = XDocument.Load(xmlPath);
    var list = from e in document.Descendants(root).Descendants(&quot;add&quot;)
               where directory.Equals(e.Value)
               select e;
    if (list.Count() &gt; 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

</pre>
<pre id="codePreview" class="csharp">/// &lt;summary&gt;
/// Check URLs from requests.
/// &lt;/summary&gt;
/// &lt;param name=&quot;requestContext&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
public IHttpHandler GetHttpHandler(RequestContext requestContext)
{
    string root = requestContext.RouteData.Values[&quot;root&quot;].ToString().ToLower();
    string name = requestContext.RouteData.Values[&quot;name&quot;].ToString().ToLower();
    string directory = requestContext.RouteData.Values[&quot;directory&quot;].ToString().ToLower();
    string page = string.Format(&quot;~/{0}/{1}&quot;, directory, name);
    string xmlPath = requestContext.HttpContext.Server.MapPath(&quot;~/App_Data/Routing.xml&quot;);
    if(!IsInRoot(directory,root, xmlPath))
        return BuildManager.CreateInstanceFromVirtualPath(&quot;~/NoHandler.aspx&quot;, typeof(Page)) as IHttpHandler;
    if(File.Exists(requestContext.HttpContext.Server.MapPath(page)))
    {
        IHttpHandler handler = BuildManager.CreateInstanceFromVirtualPath(page, typeof(Page)) as IHttpHandler;
        return handler;
    }
    else
    {
        return BuildManager.CreateInstanceFromVirtualPath(&quot;~/NoHandler.aspx&quot;, typeof(Page)) as IHttpHandler;
    }
}


/// &lt;summary&gt;
/// Check directory name is in root node (XML file).
/// &lt;/summary&gt;
/// &lt;param name=&quot;directory&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;root&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;xmlPath&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private bool IsInRoot(string directory, string root, string xmlPath)
{
    XDocument document = XDocument.Load(xmlPath);
    var list = from e in document.Descendants(root).Descendants(&quot;add&quot;)
               where directory.Equals(e.Value)
               select e;
    if (list.Count() &gt; 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>4. In order to make your application runs successfully in Azure environment, please create
<span class="SpellE">IISHandler</span> that inherits <span class="SpellE">UrlRoutingHandler</span> class, this custom routing handler is used to cancel verification of process request. Then you can add the related configuration section in
<span class="SpellE">Web.config</span> file as below</span>:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;system.webServer&gt;
  &lt;modules runAllManagedModulesForAllRequests=&quot;true&quot; /&gt;
  &lt;handlers&gt;
    &lt;add name=&quot;UrlRoutingHandler&quot; preCondition=&quot;integratedMode&quot; verb=&quot;*&quot; path=&quot;UrlRouting.axd&quot; type=&quot;WebCore.IISHandler, WebCore&quot;/&gt;
  &lt;/handlers&gt;
&lt;/system.webServer&gt;

</pre>
<pre id="codePreview" class="xml">&lt;system.webServer&gt;
  &lt;modules runAllManagedModulesForAllRequests=&quot;true&quot; /&gt;
  &lt;handlers&gt;
    &lt;add name=&quot;UrlRoutingHandler&quot; preCondition=&quot;integratedMode&quot; verb=&quot;*&quot; path=&quot;UrlRouting.axd&quot; type=&quot;WebCore.IISHandler, WebCore&quot;/&gt;
  &lt;/handlers&gt;
&lt;/system.webServer&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">5. The next step, add route in route table before application starts, and please also add some sample links in Default.aspx page.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">RouteTable.Routes.Add(&quot;PageResources&quot;, new Route(&quot;{root}/{directory}/{name}&quot;, new WebRoleRoute()));

</pre>
<pre id="codePreview" class="csharp">RouteTable.Routes.Add(&quot;PageResources&quot;, new Route(&quot;{root}/{directory}/{name}&quot;, new WebRoleRoute()));

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">6. Add an xml file to manage Root name and directory name, URL string should follow this xml file; you can also create your rule via this xml file.</p>
<p class="MsoNormal">7. Build the application and you can debug it now.</p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/cc668201.aspx">ASP.NET Routing</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>