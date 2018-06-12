# ASP.NET cascading drop-down-list (VBASPNETCascadingDropDownList)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Controls
* DropDownList
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:00:21
## Description

<h1>ASP.NET cascading drop-down-list (<a name="OLE_LINK1"></a><a name="OLE_LINK2"><span style="">VBASPNETCascadingDropDownList</span></a>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The example shows how to create Cascading DropDownList in two ways. You can view the Default.aspx page, and then you can find there&#39;re two links in this page:</p>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use ASP.NET DropDownList control with postback.</p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use ASP.NET DropDownList control with callback. </p>
<p class="MsoNormal">The CascadingDropDownListWithPostBack.aspx will save the selected option value in hidden text, and restore them when page is postback, the CascadingDropDownListWithCallBack.aspx page will create a XmlHttpRequest object and send callback
 to .aspx page when dropdownlist control options is changed.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the VBASPNETCascadingDropDownList.sln. Expand the VBASPNETCascadingDropDownList web application and press Ctrl &#43; F5 to show the default.aspx.
</p>
<p class="MsoNormal">Step 2: We will see two links on default.aspx page, the two links point to CascadingDropDownListWithPostBack.aspx page and CascadingDropDownListWithCallBack.aspx page respectively. You can click one of them, and you may find these two
 web form pages appear to be similar to each other, but actually they achieve the same goal with different methods.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53637/1/image.png" alt="" width="529" height="527" align="middle">
</span></p>
<p class="MsoNormal">Step 3: There are three cascading dropdownlist controls and one button on the target page, please try to select the options which you like, and click submit button.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53638/1/image.png" alt="" width="529" height="527" align="middle">
</span></p>
<p class="MsoNormal">Step 4:<span style="">&nbsp; </span>The page will give the summary information for your selected options, just like the following screenshot.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53639/1/image.png" alt="" width="529" height="527" align="middle">
</span></p>
<p class="MsoNormal">Step 5: Now please click the ��Go Back to Default page�� link, you can test the CascadingDropDownListWithCallBack.aspx page now.</p>
<p class="MsoNormal">Step 6: Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Code Logical: </p>
<p class="MsoNormal">Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2008. Name it as ��VBASPNETCascadingDropDownList&quot;. Add four web form pages in the root directory of the application, Default.aspx page is used to show
 different cascading dropdownlist pages, the CascadingDropDownListWithCallBack.aspx page is used to show the cascading dropdownlist with callback method, the CascadingDropDownListWithPostBack.aspx page is used to show the cascading dropdownlist with callback
 method, the GetDataForCallBack.aspx page is used to retrieve data in callback and write data to client-side application.</p>
<p class="MsoNormal">Step 2. The CascadingDropDownListWithCallBack.aspx page will use JavaScript functions to create XmlHttpRequest object for saving and restoring data, and we should add onChange event in Dropdownlist control for call ddlCountryOnChange()
 function.</p>
<h3>The following code snippet is from Jscript.js file:</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
var xmlHttp = null; // XMLHttpRequest object
var ddlCountry = null; // DropDownList for country
var ddlRegion = null; // DropDownList for region
var ddlCity = null;  // DropDownList for city
var hdfRegion = null; // Use to save region DropDownList options and restore it when page is rendering
var hdfCity = null;  // Use to save city DropDownList options and restore it when page is loadrenderinged
var hdfRegionSelectValue = null; // Use to save region DropDownList selected options and restore it when page is rendering
var hdfCitySelectValue = null; // Use to save city DropDownList selected options and restore it when page is rendering
var hdfCountrySelectValue = null;   // Use to save country DropDownList selected options and restore it when page is rendering


// Instance XMLHttpRequest
window.onload = function loadXMLHttp() {
    if (window.XMLHttpRequest) {
        xmlHttp = new XMLHttpRequest();
    } else if (window.ActiveXObject) {
        try {
            xmlHttp = new ActiveXObject(&quot;Microsoft.XMLHTTP&quot;);
        }
        catch (e) { }
    }


    ddlCountry = document.getElementById('ddlCountry');
    ddlRegion = document.getElementById('ddlRegion');
    ddlCity = document.getElementById('ddlCity');
    hdfRegion = document.getElementById('hdfRegion');
    hdfCity = document.getElementById('hdfCity');
    hdfRegionSelectValue = document.getElementById('hdfRegionSelectValue');
    hdfCitySelectValue = document.getElementById('hdfCitySelectValue');
    hdfCountrySelectValue = document.getElementById('hdfCountrySelectValue');
    ShowFirstOption(ddlCountry); // Add &quot;Please Select a xxxx&quot; option in the top of country DropDownList 
    RestoreDropdownlist(); // Restore dropdownlist when page is rendering


}


// Restore dropdownlist when page is rendering
function RestoreDropdownlist() {
    // Restore region dropdownlist
    if (hdfRegion.value != &quot;&quot;) {
        addOption(ddlRegion, hdfRegion.value);
        ddlRegion.selectedIndex = hdfRegionSelectValue.value;
    } // Restore city dropdownlist
    if (hdfCity.value != &quot;&quot;) {
        addOption(ddlCity, hdfCity.value);
        ddlCity.selectedIndex = hdfCitySelectValue.value;
    }
    ddlCountry.selectedIndex = hdfCountrySelectValue.value;
}


// Save selected options in hide field so that we can access it from codebehind class
function SaveSelectedData() {


    hdfCitySelectValue.value = ddlCity.selectedIndex;
    hdfCountrySelectValue.value = ddlCountry.selectedIndex;
    hdfRegionSelectValue.value = ddlRegion.selectedIndex;


    if (ddlCity != null && ddlCountry != null && ddlRegion != null
     && ddlCity.length &gt; 0 && ddlCountry.length &gt; 0 && ddlRegion.length &gt; 0
     && ddlCity.selectedIndex != '0' && ddlCountry.selectedIndex != '0' && ddlRegion.selectedIndex != '0') {


        var strResult = ddlCountry.options[ddlCountry.selectedIndex].value &#43; '; '
        &#43; ddlRegion.options[ddlRegion.selectedIndex].value &#43; '; '
        &#43; ddlCity.options[ddlCity.selectedIndex].value;


        document.getElementById('hdfResult').value = strResult;




    }
    else {
        document.getElementById('hdfResult').value = 'Please select option from DropDownList.';
    }
}

</pre>
<pre id="codePreview" class="js">
var xmlHttp = null; // XMLHttpRequest object
var ddlCountry = null; // DropDownList for country
var ddlRegion = null; // DropDownList for region
var ddlCity = null;  // DropDownList for city
var hdfRegion = null; // Use to save region DropDownList options and restore it when page is rendering
var hdfCity = null;  // Use to save city DropDownList options and restore it when page is loadrenderinged
var hdfRegionSelectValue = null; // Use to save region DropDownList selected options and restore it when page is rendering
var hdfCitySelectValue = null; // Use to save city DropDownList selected options and restore it when page is rendering
var hdfCountrySelectValue = null;   // Use to save country DropDownList selected options and restore it when page is rendering


// Instance XMLHttpRequest
window.onload = function loadXMLHttp() {
    if (window.XMLHttpRequest) {
        xmlHttp = new XMLHttpRequest();
    } else if (window.ActiveXObject) {
        try {
            xmlHttp = new ActiveXObject(&quot;Microsoft.XMLHTTP&quot;);
        }
        catch (e) { }
    }


    ddlCountry = document.getElementById('ddlCountry');
    ddlRegion = document.getElementById('ddlRegion');
    ddlCity = document.getElementById('ddlCity');
    hdfRegion = document.getElementById('hdfRegion');
    hdfCity = document.getElementById('hdfCity');
    hdfRegionSelectValue = document.getElementById('hdfRegionSelectValue');
    hdfCitySelectValue = document.getElementById('hdfCitySelectValue');
    hdfCountrySelectValue = document.getElementById('hdfCountrySelectValue');
    ShowFirstOption(ddlCountry); // Add &quot;Please Select a xxxx&quot; option in the top of country DropDownList 
    RestoreDropdownlist(); // Restore dropdownlist when page is rendering


}


// Restore dropdownlist when page is rendering
function RestoreDropdownlist() {
    // Restore region dropdownlist
    if (hdfRegion.value != &quot;&quot;) {
        addOption(ddlRegion, hdfRegion.value);
        ddlRegion.selectedIndex = hdfRegionSelectValue.value;
    } // Restore city dropdownlist
    if (hdfCity.value != &quot;&quot;) {
        addOption(ddlCity, hdfCity.value);
        ddlCity.selectedIndex = hdfCitySelectValue.value;
    }
    ddlCountry.selectedIndex = hdfCountrySelectValue.value;
}


// Save selected options in hide field so that we can access it from codebehind class
function SaveSelectedData() {


    hdfCitySelectValue.value = ddlCity.selectedIndex;
    hdfCountrySelectValue.value = ddlCountry.selectedIndex;
    hdfRegionSelectValue.value = ddlRegion.selectedIndex;


    if (ddlCity != null && ddlCountry != null && ddlRegion != null
     && ddlCity.length &gt; 0 && ddlCountry.length &gt; 0 && ddlRegion.length &gt; 0
     && ddlCity.selectedIndex != '0' && ddlCountry.selectedIndex != '0' && ddlRegion.selectedIndex != '0') {


        var strResult = ddlCountry.options[ddlCountry.selectedIndex].value &#43; '; '
        &#43; ddlRegion.options[ddlRegion.selectedIndex].value &#43; '; '
        &#43; ddlCity.options[ddlCity.selectedIndex].value;


        document.getElementById('hdfResult').value = strResult;




    }
    else {
        document.getElementById('hdfResult').value = 'Please select option from DropDownList.';
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Then you can handle data binding event in code-behind file.</p>
<h3>The following code is used to bind data with dropdownlist controls and handle on submit button.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Page Load event
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ' Register client onclick event for submit button
    btnSubmit.Attributes.Add(&quot;onclick&quot;, &quot;SaveSelectedData();&quot;)
    If Not IsPostBack Then
        ' Bind country dropdownlist
        BindddlCountry()
        ' Initialize hide field value
        hdfResult.Value = &quot;&quot;
        hdfCity.Value = &quot;&quot;
        hdfCitySelectValue.Value = &quot;0&quot;
        hdfRegion.Value = &quot;&quot;
        hdfRegionSelectValue.Value = &quot;&quot;
    End If
End Sub


''' &lt;summary&gt;
''' Bind country dropdownlist
''' &lt;/summary&gt;
Public Sub BindddlCountry()
    Dim list As List(Of String) = RetrieveDataFromXml.GetAllCountry()
    ddlCountry.DataSource = list
    ddlCountry.DataBind()
End Sub


''' &lt;summary&gt;
''' Submit button click event and show select result
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
    ' Get result from hide field saved in client
    Dim strResult As String = hdfResult.Value
    lblResult.Text = strResult
End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Page Load event
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ' Register client onclick event for submit button
    btnSubmit.Attributes.Add(&quot;onclick&quot;, &quot;SaveSelectedData();&quot;)
    If Not IsPostBack Then
        ' Bind country dropdownlist
        BindddlCountry()
        ' Initialize hide field value
        hdfResult.Value = &quot;&quot;
        hdfCity.Value = &quot;&quot;
        hdfCitySelectValue.Value = &quot;0&quot;
        hdfRegion.Value = &quot;&quot;
        hdfRegionSelectValue.Value = &quot;&quot;
    End If
End Sub


''' &lt;summary&gt;
''' Bind country dropdownlist
''' &lt;/summary&gt;
Public Sub BindddlCountry()
    Dim list As List(Of String) = RetrieveDataFromXml.GetAllCountry()
    ddlCountry.DataSource = list
    ddlCountry.DataBind()
End Sub


''' &lt;summary&gt;
''' Submit button click event and show select result
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
    ' Get result from hide field saved in client
    Dim strResult As String = hdfResult.Value
    lblResult.Text = strResult
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 3. Then you need to use GetDataForCallback.aspx page to retrieve data and write data to the client.
</p>
<h3>The following code is used to retrieve and write data by callback method.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Get region based on country value
''' &lt;/summary&gt;
''' &lt;param name=&quot;strValue&quot;&gt;The country value&lt;/param&gt;
Public Sub RetrieveRegionByCountry(ByVal strValue As String)
    Dim list As List(Of String) = RetrieveDataFromXml.GetRegionByCountry(strValue)
    WriteData(list)
End Sub


''' &lt;summary&gt;
''' Get city based on region value
''' &lt;/summary&gt;
''' &lt;param name=&quot;strValue&quot;&gt;The region value&lt;/param&gt;
Public Sub RetrieveCityByRegion(ByVal strValue As String)
    Dim list As List(Of String) = RetrieveDataFromXml.GetCityByRegion(strValue)
    WriteData(list)
End Sub


''' &lt;summary&gt;
''' Write data to client
''' &lt;/summary&gt;
''' &lt;param name=&quot;list&quot;&gt;The list contains value &lt;/param&gt;
Public Sub WriteData(ByVal list As List(Of String))
    Dim iCount As Integer = list.Count
    Dim builder As New StringBuilder()
    If iCount &gt; 0 Then
        For i As Integer = 0 To iCount - 2
            builder.Append(list(i) &#43; &quot;,&quot;)
        Next
        builder.Append(list(iCount - 1))
    End If


    Response.ContentType = &quot;text/xml&quot;
    ' Write data in string format &quot;###,###,###&quot; to client
    Response.Write(builder.ToString())
    Response.[End]()
End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Get region based on country value
''' &lt;/summary&gt;
''' &lt;param name=&quot;strValue&quot;&gt;The country value&lt;/param&gt;
Public Sub RetrieveRegionByCountry(ByVal strValue As String)
    Dim list As List(Of String) = RetrieveDataFromXml.GetRegionByCountry(strValue)
    WriteData(list)
End Sub


''' &lt;summary&gt;
''' Get city based on region value
''' &lt;/summary&gt;
''' &lt;param name=&quot;strValue&quot;&gt;The region value&lt;/param&gt;
Public Sub RetrieveCityByRegion(ByVal strValue As String)
    Dim list As List(Of String) = RetrieveDataFromXml.GetCityByRegion(strValue)
    WriteData(list)
End Sub


''' &lt;summary&gt;
''' Write data to client
''' &lt;/summary&gt;
''' &lt;param name=&quot;list&quot;&gt;The list contains value &lt;/param&gt;
Public Sub WriteData(ByVal list As List(Of String))
    Dim iCount As Integer = list.Count
    Dim builder As New StringBuilder()
    If iCount &gt; 0 Then
        For i As Integer = 0 To iCount - 2
            builder.Append(list(i) &#43; &quot;,&quot;)
        Next
        builder.Append(list(iCount - 1))
    End If


    Response.ContentType = &quot;text/xml&quot;
    ' Write data in string format &quot;###,###,###&quot; to client
    Response.Write(builder.ToString())
    Response.[End]()
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 4. The next step, we need to implement cascading dropdownlist control, we must implement Dropdownlist��s SelectedIndexChanged event. Here we also need to add JavaScript functions to bind data with those controls.</p>
<h3>The following code is showing how to implement with DropDownList SelectedIndexChanged event.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Country dropdownlist SelectedIndexChanged event
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCountry.SelectedIndexChanged
    ' Remove region dropdownlist items
    ddlRegion.Items.Clear()
    Dim strCountry As String = String.Empty
    strCountry = ddlCountry.SelectedValue
    Dim list As List(Of String) = Nothing


    ' Bind Region dropdownlist based on country value
    If ddlCountry.SelectedIndex &lt;&gt; 0 Then
        list = RetrieveDataFromXml.GetRegionByCountry(strCountry)
        If list IsNot Nothing AndAlso list.Count &lt;&gt; 0 Then
            ddlRegion.Enabled = True
        End If


        ddlRegion.DataSource = list
        ddlRegion.DataBind()
    Else
        ddlRegion.Enabled = False
    End If


    ddlRegion.Items.Insert(0, New ListItem(&quot;Select Region&quot;, &quot;-1&quot;))


    ' Clear city dropdownlist
    ddlCity.Enabled = False
    ddlCity.Items.Clear()
    ddlCity.Items.Insert(0, New ListItem(&quot;Select City&quot;, &quot;-1&quot;))


    ' Initialize city dropdownlist selected index
    hdfDdlCitySelectIndex.Value = &quot;0&quot;
End Sub
''' &lt;summary&gt;
''' Region dropdownlist SelectedIndexChanged event
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub ddlRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlRegion.SelectedIndexChanged
    ' Bind city dropdownlist based on region value
    Dim strRegion As String = String.Empty
    strRegion = ddlRegion.SelectedValue
    Dim list As List(Of String) = Nothing
    list = RetrieveDataFromXml.GetCityByRegion(strRegion)
    ddlCity.Items.Clear()
    ddlCity.DataSource = list
    ddlCity.DataBind()
    ddlCity.Items.Insert(0, New ListItem(&quot;Select City&quot;, &quot;-1&quot;))


    ' Initialize city dropdownlist selected index
    hdfDdlCitySelectIndex.Value = &quot;0&quot;


    ' Enable city dropdownlist when it has items
    If list.Count &gt; 0 Then
        ddlCity.Enabled = True
    Else
        ddlCity.Enabled = False
    End If
End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Country dropdownlist SelectedIndexChanged event
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCountry.SelectedIndexChanged
    ' Remove region dropdownlist items
    ddlRegion.Items.Clear()
    Dim strCountry As String = String.Empty
    strCountry = ddlCountry.SelectedValue
    Dim list As List(Of String) = Nothing


    ' Bind Region dropdownlist based on country value
    If ddlCountry.SelectedIndex &lt;&gt; 0 Then
        list = RetrieveDataFromXml.GetRegionByCountry(strCountry)
        If list IsNot Nothing AndAlso list.Count &lt;&gt; 0 Then
            ddlRegion.Enabled = True
        End If


        ddlRegion.DataSource = list
        ddlRegion.DataBind()
    Else
        ddlRegion.Enabled = False
    End If


    ddlRegion.Items.Insert(0, New ListItem(&quot;Select Region&quot;, &quot;-1&quot;))


    ' Clear city dropdownlist
    ddlCity.Enabled = False
    ddlCity.Items.Clear()
    ddlCity.Items.Insert(0, New ListItem(&quot;Select City&quot;, &quot;-1&quot;))


    ' Initialize city dropdownlist selected index
    hdfDdlCitySelectIndex.Value = &quot;0&quot;
End Sub
''' &lt;summary&gt;
''' Region dropdownlist SelectedIndexChanged event
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub ddlRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlRegion.SelectedIndexChanged
    ' Bind city dropdownlist based on region value
    Dim strRegion As String = String.Empty
    strRegion = ddlRegion.SelectedValue
    Dim list As List(Of String) = Nothing
    list = RetrieveDataFromXml.GetCityByRegion(strRegion)
    ddlCity.Items.Clear()
    ddlCity.DataSource = list
    ddlCity.DataBind()
    ddlCity.Items.Insert(0, New ListItem(&quot;Select City&quot;, &quot;-1&quot;))


    ' Initialize city dropdownlist selected index
    hdfDdlCitySelectIndex.Value = &quot;0&quot;


    ' Enable city dropdownlist when it has items
    If list.Count &gt; 0 Then
        ddlCity.Enabled = True
    Else
        ddlCity.Enabled = False
    End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 5. Build the application and you can debug it.</p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.dropdownlist.aspx">ASP.NET DropDownList Control</a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/ms535874(VS.85).aspx">XMLHttpRequest Object</a></p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.xml.xmldocument.aspx">XmlDocument Class</a>
</span></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
