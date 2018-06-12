# Create a custom 404 error page
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* 404
## IsPublished
* True
## ModifiedDate
* 2013-06-13 09:49:12
## Description

<p class="MsoNormal">The sample code demonstrates how to create the intelligent error page in Asp.net application. In this sample, we add a custom 404 error
<span class="GramE">page</span> and find the similar local resources, then display them in error page. In this way, we will improve the user-experience, since users
<a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style="">don't need </span>
</a>to face a boring and helpless error page any more.</p>
<p class="MsoNormal">Here is the reason why we need this sample code:</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The normal website will throw you to a boring, inflexible 404 error page when you try to visit a non-exists page.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>You cannot get more useful information from normal 404 error page and cannot find right
<span class="SpellE"><span class="GramE">url</span></span> path, either.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The customize error page can provide a more friendly ways to tell customers that the current request page is not exist and we can provide some similar web pages for choosing.</p>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the <span style="">CSASPNETIntelligentErrorPage</span>.sln. Expand the
<span class="SpellE"><span style="">CSASPNETIntelligentErrorPage</span></span> web application and press Ctrl &#43; F5 to show the Default.aspx.
</p>
<p class="MsoNormal">Step 2: The Default.aspx page includes two kinds of link resources, the useful links can be redirected to correct pages and the useless links will be redirected to 404 error pages since the application does not contain these pages.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84179/1/image.png" alt="" width="556" height="505" align="middle">
</span><span style="">&nbsp;</span></p>
<p class="MsoNormal">Step 3: The useful links can be found by web application. </p>
<p class="MsoNormal"><span style="">&lt;u1:shape id=&quot;Picture_x0020_3&quot; u2:spid=&quot;_x0000_i1025&quot; type=&quot;#_x0000_t75&quot; alt=&quot;Description: Description: Description: Description: http://www.codeproject.com/KB/vista-security/UACSelfElevation/UACSelfElevation3.png&quot; style=&quot;width:3in;height:167.25pt;visibility:visible;mso-wrap-style:square&quot;&gt;&lt;u1:imagedata
 src=&quot;http://localhost:10242/Documentation/ReadMe_files/image003.png&quot; u2:title=&quot;UACSelfElevation3&quot;/&gt;&lt;/u1:shape&gt;
<img src="/site/view/file/84180/1/image.png" alt="" width="556" height="505" align="middle">
</span></p>
<p class="MsoNormal"><span class="GramE">Step 4.</span> When you try to visit useless links, the application will check the request name and category properties of your request
<span class="SpellE"><span class="GramE">url</span></span> with XML file. The customers can visit our customized 404 error page.
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84181/1/image.png" alt="" width="556" height="505" align="middle">
</span></p>
<p class="MsoNormal"><span class="GramE">Step 5.</span> If the sample application could not find any relative resources, it will remind user with the message &quot;No similar links&quot;.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84182/1/image.png" alt="" width="556" height="505" align="middle">
</span></p>
<p class="MsoNormal"><span class="GramE">Step 6.</span> Validation finished.</p>
<p class="MsoNormal">Code Logical:</p>
<p class="MsoNormal"><span class="GramE">Step 1.</span> Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;<span class="SpellE"><span style="">CSASPNETIntelligentErrorPage</span></span>&quot;.
 Add one folder, &quot;Relative Pages&quot;, in order to provide some similar web pages in this sample, we need to add more web pages for testing, for example, we can involve these web form pages in Relative Page folder, &quot;Aspnet.aspx&quot;, &quot;<span class="SpellE">Aspnet_DataControl</span>&quot;,
 &quot;<span class="SpellE">Aspnet_MVC</span>&quot;, &quot;Silverlight&quot;, &quot;<span class="SpellE">Silverlight_Toolkit</span>&quot;, &quot;WCF.aspx&quot;. And we also need an xml file for recording these pages' basic information, so please add an
 xml file named &quot;XmlData.xml&quot; in <span class="SpellE">App_Data</span> folder.</p>
<p class="MsoNormal"><span class="GramE">Step 2.</span> Add two web form pages, &quot;Default.aspx&quot; and &quot;ErrorPage.aspx&quot;, the Default page is used to list some useful and useless link resources, and the
<span class="SpellE">ErrorPage</span> is used to replace default 404 error page. Before we begin to code, add some important sections in
<span class="SpellE">Web.Config</span> to enable custom errors. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;system.web&gt;
    &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.0&quot; /&gt;


  &lt;customErrors mode=&quot;On&quot; defaultRedirect=&quot;ErrorPage.aspx&quot;&gt; 
    &lt;error statusCode=&quot;404&quot; redirect=&quot;ErrorPage.aspx&quot; /&gt;
    &lt;!--&lt;error statusCode=&quot;403&quot; redirect=&quot;&quot;/&gt;--&gt;
  &lt;/customErrors&gt;
&lt;/system.web&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;system.web&gt;
    &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.0&quot; /&gt;


  &lt;customErrors mode=&quot;On&quot; defaultRedirect=&quot;ErrorPage.aspx&quot;&gt; 
    &lt;error statusCode=&quot;404&quot; redirect=&quot;ErrorPage.aspx&quot; /&gt;
    &lt;!--&lt;error statusCode=&quot;403&quot; redirect=&quot;&quot;/&gt;--&gt;
  &lt;/customErrors&gt;
&lt;/system.web&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class XmlHandler
{
    DataTable tabItems = new DataTable();
    string xmlPath = string.Empty;
    public XmlHandler(string url)
    {
        this.xmlPath = url;
        DataColumn dcName = new DataColumn(&quot;Name&quot;, Type.GetType(&quot;System.String&quot;));
        DataColumn dcCategory = new DataColumn(&quot;Category&quot;, Type.GetType(&quot;System.String&quot;));
        DataColumn dcUrl = new DataColumn(&quot;Path&quot;, Type.GetType(&quot;System.String&quot;));
        tabItems.Columns.Add(dcName);
        tabItems.Columns.Add(dcCategory);
        tabItems.Columns.Add(dcUrl);
    }


    public DataTable GetOpenData()
    {
        tabItems.Clear();
        XDocument document = XDocument.Load(xmlPath);
        var items = from item in document.Descendants(&quot;Item&quot;)
                    where item.Attribute(&quot;open&quot;).Value == &quot;1&quot;
                    select
                    item;
        foreach (var item in items)
        {
            DataRow dr = tabItems.NewRow();
            dr[&quot;Name&quot;] = item.Element(&quot;Name&quot;).Value;
            dr[&quot;Category&quot;] = item.Element(&quot;Category&quot;).Value;
            dr[&quot;Path&quot;] = item.Element(&quot;Path&quot;).Value;
            tabItems.Rows.Add(dr);
        }
        return tabItems;
    }


    public DataTable GetDataItemByName(string name)
    {
        tabItems.Clear();
        XDocument document = XDocument.Load(xmlPath);
        var items = from item in document.Descendants(&quot;Item&quot;)
                    where item.Element(&quot;Category&quot;).Value.ToLower().Contains(name.ToLower())
                    || item.Element(&quot;Name&quot;).Value.ToLower().Contains(name.ToLower())
                    select new ItemModel
                    {
                        Name = item.Element(&quot;Name&quot;).Value,
                        Category = item.Element(&quot;Category&quot;).Value,
                        Url = item.Element(&quot;Path&quot;).Value
                    };
        foreach (var item in items)
        {
            DataRow dr = tabItems.NewRow();
            dr[&quot;Name&quot;] = item.Name;
            dr[&quot;Category&quot;] = item.Category;
            dr[&quot;Path&quot;] = item.Url;
            tabItems.Rows.Add(dr);
        }
        return tabItems;
    }
}

</pre>
<pre id="codePreview" class="csharp">
public class XmlHandler
{
    DataTable tabItems = new DataTable();
    string xmlPath = string.Empty;
    public XmlHandler(string url)
    {
        this.xmlPath = url;
        DataColumn dcName = new DataColumn(&quot;Name&quot;, Type.GetType(&quot;System.String&quot;));
        DataColumn dcCategory = new DataColumn(&quot;Category&quot;, Type.GetType(&quot;System.String&quot;));
        DataColumn dcUrl = new DataColumn(&quot;Path&quot;, Type.GetType(&quot;System.String&quot;));
        tabItems.Columns.Add(dcName);
        tabItems.Columns.Add(dcCategory);
        tabItems.Columns.Add(dcUrl);
    }


    public DataTable GetOpenData()
    {
        tabItems.Clear();
        XDocument document = XDocument.Load(xmlPath);
        var items = from item in document.Descendants(&quot;Item&quot;)
                    where item.Attribute(&quot;open&quot;).Value == &quot;1&quot;
                    select
                    item;
        foreach (var item in items)
        {
            DataRow dr = tabItems.NewRow();
            dr[&quot;Name&quot;] = item.Element(&quot;Name&quot;).Value;
            dr[&quot;Category&quot;] = item.Element(&quot;Category&quot;).Value;
            dr[&quot;Path&quot;] = item.Element(&quot;Path&quot;).Value;
            tabItems.Rows.Add(dr);
        }
        return tabItems;
    }


    public DataTable GetDataItemByName(string name)
    {
        tabItems.Clear();
        XDocument document = XDocument.Load(xmlPath);
        var items = from item in document.Descendants(&quot;Item&quot;)
                    where item.Element(&quot;Category&quot;).Value.ToLower().Contains(name.ToLower())
                    || item.Element(&quot;Name&quot;).Value.ToLower().Contains(name.ToLower())
                    select new ItemModel
                    {
                        Name = item.Element(&quot;Name&quot;).Value,
                        Category = item.Element(&quot;Category&quot;).Value,
                        Url = item.Element(&quot;Path&quot;).Value
                    };
        foreach (var item in items)
        {
            DataRow dr = tabItems.NewRow();
            dr[&quot;Name&quot;] = item.Name;
            dr[&quot;Category&quot;] = item.Category;
            dr[&quot;Path&quot;] = item.Url;
            tabItems.Rows.Add(dr);
        }
        return tabItems;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span class="GramE">Step 4.</span> The Default page uses
<span class="SpellE">XmlHandler.GetOpenData</span>() method to get all available resources from xml file and binds them to
<span class="SpellE">ListView</span> control, the Error Page can get file name from request
<span class="SpellE">url</span> string variable and call <span class="SpellE">
XmlHandler.GetItemByName</span>(string name) method to get relative web resources.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public partial class ErrorPage : System.Web.UI.Page
{
    const string xmlPath = &quot;~/App_Data/XmlData.xml&quot;;
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Request.QueryString[&quot;aspxerrorpath&quot;].ToString();
        string fileFullName = path.Substring(path.LastIndexOf('/') &#43; 1);
        string fileName = fileFullName.Substring(0,fileFullName.LastIndexOf('.'));
        XmlHandler handler = new XmlHandler(Server.MapPath(xmlPath));
        DataTable tab = new DataTable();
        tab = handler.GetDataItemByName(fileName);
        lvwPageList.DataSource = tab;
        lvwPageList.DataBind();
    }
}

</pre>
<pre id="codePreview" class="csharp">
public partial class ErrorPage : System.Web.UI.Page
{
    const string xmlPath = &quot;~/App_Data/XmlData.xml&quot;;
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Request.QueryString[&quot;aspxerrorpath&quot;].ToString();
        string fileFullName = path.Substring(path.LastIndexOf('/') &#43; 1);
        string fileName = fileFullName.Substring(0,fileFullName.LastIndexOf('.'));
        XmlHandler handler = new XmlHandler(Server.MapPath(xmlPath));
        DataTable tab = new DataTable();
        tab = handler.GetDataItemByName(fileName);
        lvwPageList.DataSource = tab;
        lvwPageList.DataBind();
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span class="GramE">Step 5.</span> Build the application and you can debug it.</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/system.xml.linq.xdocument.aspx">MSDN:
<span class="SpellE">XDocument</span> Class</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/h0hfz6fc(v=VS.71).aspx">MSDN: &lt;<span class="SpellE">customErrors</span>&gt; Element</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>