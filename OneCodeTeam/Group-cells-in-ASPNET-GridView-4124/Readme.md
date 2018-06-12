# Group cells in ASP.NET GridView (VBASPNETGroupedGridView)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* jQuery
* GridView
* Control
## IsPublished
* True
## ModifiedDate
* 2011-08-08 07:29:26
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : VBASPNETGroupedGridView Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The code sample shows how to group cells in GridView with the same value.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Open the sample project and run tha web application. &nbsp;In Default.aspx, you <br>
will see two GridViews binding the same data (Product Name, Category, Weight). &nbsp;<br>
The first GridView shows each row of data as usual. &nbsp;The second GridView <br>
groups Product Name and Category, and shows the merged cells. <br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step1. Open your Visual Studio 2000 to create a Visual Basic Web application by <br>
choosing &quot;File&quot; -&gt; &quot;New&quot; -&gt; &quot;Project...&quot;, expand the &quot;Visual Basic&quot; tag and
<br>
select &quot;Web&quot;, then choose &quot;ASP.NET Web Application&quot;. &nbsp;You can name it as
<br>
&quot;VBASPNETGroupedGridView&quot;.<br>
<br>
Step2. In Default.aspx, add two GridViews. <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;table&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;tr&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;td style=&quot;padding:20px&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;h3&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;General GridView&lt;/h3&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:GridView ID=&quot;generalGridView&quot; runat=&quot;server&quot; AllowPaging=&quot;True&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;OnPageIndexChanged=&quot;generalGridView_PageIndexChanged&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;OnPageIndexChanging=&quot;generalGridView_PageIndexChanging&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;HeaderStyle HorizontalAlign=&quot;Center&quot; VerticalAlign=&quot;Middle&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;RowStyle HorizontalAlign=&quot;Center&quot; VerticalAlign=&quot;Middle&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:GridView&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/td&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;td style=&quot;padding:20px&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;h3&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Grouped GridView&lt;/h3&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:GridView ID=&quot;groupedGridView&quot; runat=&quot;server&quot; AllowPaging=&quot;True&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;OnPageIndexChanged=&quot;groupedGridView_PageIndexChanged&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;OnPageIndexChanging=&quot;groupedGridView_PageIndexChanging&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;HeaderStyle HorizontalAlign=&quot;Center&quot; VerticalAlign=&quot;Middle&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;RowStyle HorizontalAlign=&quot;Center&quot; VerticalAlign=&quot;Middle&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:GridView&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/td&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/tr&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/table&gt;<br>
<br>
Step3. Reference the jQuery library and add the following reusable Javascript <br>
function for grouping GridView cells. <br>
<br>
&nbsp; &nbsp;&lt;script type=&quot;text/javascript&quot; src=&quot;<a target="_blank" href="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.4.min.js&quot;&gt;&lt;/script&gt;">http://ajax.microsoft.com/ajax/jquery/jquery-1.4.4.min.js&quot;&gt;&lt;/script&gt;</a><br>
&nbsp; &nbsp;&lt;script type=&quot;text/javascript&quot;&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// This js function will automatially combine the GridView cells<br>
&nbsp; &nbsp; &nbsp; &nbsp;// gridviewId: The id of the gridview.<br>
&nbsp; &nbsp; &nbsp; &nbsp;function GroupGridViewCells(gridviewId) {<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the number of the rows<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var rowNum = $(gridviewId &#43; &quot; tr&quot;).length;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the number of the columns;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var colNum = $(gridviewId &#43; &quot; tr:eq(0)&gt;th&quot;).length;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the current cell<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var cell = null;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the previous cell<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var previouscell = null;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Begin to loop from the second row to the end<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;for (var col = 0; col &lt; colNum; &#43;&#43;col) {<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;for (var row = 1; row &lt; rowNum; &#43;&#43;row) {<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;cell = $(gridviewId &#43; &quot; tr:eq(&quot; &#43; row &#43; &quot;)&gt;td:eq(&quot; &#43; col &#43; &quot;)&quot;).first();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// We haven't the previous row to compare with, so keep this first<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (row == 1) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;previouscell = $(gridviewId &#43; &quot; tr:eq(&quot; &#43; row &#43; &quot;)&gt;td:eq(&quot; &#43; col &#43; &quot;)&quot;).first();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;previouscell.attr(&quot;rowspan&quot;, &quot;1&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else {<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// If the current value has the same value as the previous one,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// the previous one's rowspan should be increased by 1, and you should<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// hide the current cell.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (cell.html() == previouscell.html()) {<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;previouscell.attr(&quot;rowspan&quot;, parseInt(previouscell.attr(&quot;rowspan&quot;) &#43; 1));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;cell.css(&quot;display&quot;, &quot;none&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// If the current cell's value doesn't equal to the previous one<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// we should restart keep the cell for future comparation.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;previouscell = $(gridviewId &#43; &quot; tr:eq(&quot; &#43; row &#43; &quot;)&gt;td:eq(&quot; &#43; col &#43; &quot;)&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;previouscell.attr(&quot;rowspan&quot;, &quot;1&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;previouscontent = previouscell.html();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
Step4. Call the GroupGridViewCells function to group cells in the second <br>
GridView control.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Call the js function like this:<br>
&nbsp; &nbsp; &nbsp; &nbsp;$(function () {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GroupGridViewCells(&quot;#groupedGridView&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;})<br>
<br>
Step5. Switch to the code-behind and the following code to bind the same <br>
sorted test data to the GridViews.<br>
<br>
&nbsp; &nbsp;Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Not IsPostBack Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;BindSortedTestData(generalGridView)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;BindSortedTestData(groupedGridView)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Bind sorted test data to the given GridView control.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;gridView&quot;&gt;the GridView control&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp;Private Sub BindSortedTestData(ByVal gridView As GridView)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Const TestDataViewStateId As String = &quot;TestData&quot;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim dt As DataTable = TryCast(ViewState(TestDataViewStateId), DataTable)<br>
&nbsp; &nbsp; &nbsp; &nbsp;If dt Is Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dt = New DataTable()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dt.Columns.Add(&quot;Product Name&quot;, GetType(String))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dt.Columns.Add(&quot;Category&quot;, GetType(Integer))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dt.Columns.Add(&quot;Weight&quot;, GetType(Double))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim r As New Random(DateTime.Now.Millisecond)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;For i As Integer = 1 To 50<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Adding ProductId, Category, and random price.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dt.Rows.Add( _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;Product&quot; & r.Next(1, 5), _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;r.Next(1, 5), _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Math.Round(r.NextDouble() * 100 &#43; 50, 2))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Next<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ViewState(TestDataViewStateId) = dt<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Sort by Product Name and Category<br>
&nbsp; &nbsp; &nbsp; &nbsp;dt.DefaultView.Sort = &quot;Product Name,Category&quot;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;gridView.DataSource = dt<br>
&nbsp; &nbsp; &nbsp; &nbsp;gridView.DataBind()<br>
&nbsp; &nbsp;End Sub<br>
<br>
<br>
Reference：<br>
<br>
<a target="_blank" href="http://www.codeproject.com/KB/webforms/MergeGridViewCells.aspx">http://www.codeproject.com/KB/webforms/MergeGridViewCells.aspx</a>
<br>
(Containing a server-side solution for grouping cells in GridView)<br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
