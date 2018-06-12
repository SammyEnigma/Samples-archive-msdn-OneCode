# Limit download speed in ASP.NET (VBASPNETLimitDownloadSpeed)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Download speed
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:32:35
## Description

<p style="font-family:Courier New"></p>
<h2>VBASPNETLimitDownloadSpeed Project Overview</h2>
<p style="font-family:Courier New"><br>
Use:<br>
<br>
This project illustrates how to limit the download speed via coding. <br>
</p>
<h3>Note:</h3>
<p style="font-family:Courier New"><br>
Please kindly note that IIS7 has an extension called Bit Rate Throttling can<br>
do this feature for us with very simple option settings. For more info about <br>
Bit Rate Throttling, please refer to: <a target="_blank" href="http://www.iis.net/download/BitRateThrottling">
http://www.iis.net/download/BitRateThrottling</a><br>
<br>
If you are not using IIS7 with Windows Server 2008, we strongly recommend you <br>
to upgrade your server as soon as possible. If you are already using IIS7, <br>
please use the Bit Rate Throttling feature instead of what this code sample <br>
demos to limit the download speed. Thanks.<br>
<br>
Demo the Sample.<br>
<br>
Step1: Browse the Default.aspx from the sample and select a limited speed<br>
from the DropDownList.<br>
<br>
Step2: Click the Download button to download the file.<br>
<br>
Step3: You can find the download speed is limited to the selected speed.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1: Create a VB.NET ASP.NET Web Application in Visual Studio 2008.<br>
<br>
Step2: Add a Default ASP.NET page into the application.<br>
<br>
Step3: Add these two namespaces to the code behind of Default.aspx.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Imports System.IO<br>
&nbsp; &nbsp;Imports System.Threading<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
NOTE: System.IO is used for FileStream and BinaryReader class as well as<br>
some enum type. System.Threading is used for Thread.Sleep() method. <br>
<br>
Step4: Navigate to the Page_Load event handler and write code to create <br>
a temporary big file for the download test.<br>
<br>
&nbsp; &nbsp;Protected Sub Page_Load(ByVal sender As Object, <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ByVal e As System.EventArgs)
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Handles Me.Load<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim length As Integer = 1024 * 1024 * 1<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim buffer As Byte() = New Byte(length - 1) {}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim filepath As String = Server.MapPath(&quot;~/bigFileSample.dat&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Using fs As New FileStream(filepath, <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; FileMode.Create,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; FileAccess.Write)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;fs.Write(buffer, 0, length)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Using<br>
&nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp;<br>
Step5: Add a DropDownList control and a Button control to the page. <br>
<br>
&nbsp; &nbsp;&lt;asp:DropDownList ID=&quot;ddlDownloadSpeed&quot; runat=&quot;server&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:ListItem Value=&quot;20&quot;&gt;20 Kb/s&lt;/asp:ListItem&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:ListItem Value=&quot;50&quot;&gt;50 Kb/s&lt;/asp:ListItem&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:ListItem Value=&quot;80&quot;&gt;80 Kb/s&lt;/asp:ListItem&gt;<br>
&nbsp; &nbsp;&lt;/asp:DropDownList&gt;<br>
&nbsp; &nbsp;&lt;asp:Button ID=&quot;btnDownload&quot; runat=&quot;server&quot; Text=&quot;Download&quot; /&gt;<br>
<br>
Step6: Write the DownloadFileWithLimitedSpeed() method. Please refer to the<br>
NOTE for understanding of this method.<br>
<br>
&nbsp; &nbsp;Public Sub DownloadFileWithLimitedSpeed(ByVal fileName As String, <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ByVal filePath As String,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ByVal downloadSpeed As Long)<br>
&nbsp; &nbsp; &nbsp; &nbsp;'...<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Sub<br>
&nbsp; &nbsp;<br>
NOTE: This method is the key of this sample. The basic logic to achieve the <br>
download speed limit feature in this method is to force the response thread <br>
sleep for an appropriate time each time it sends a file packs. <br>
<br>
For a simplest instance, if the size of the file pack is 1 Kb, we can make <br>
the response thread sleep for 1 second after it sends each file pack, so that<br>
we will get a controlled download speed as 1 Kb/s. To have different download<br>
speed, we just need to make the thread sleep shorter or longer.<br>
<br>
So obviously, to decide the sleep time is the most important thing here. <br>
<br>
Well, let's say if the file pack is 1 Kb, and we need a download speed limit <br>
of 50 Kb/s, how long shoud the sleep time be? The answer is 20 millisecond.<br>
50 Kb/s means that we need to send 50 file packs in a single second. As there <br>
are 1000 millisecond in a second, we can cut them to 50 parts and each part <br>
is 20 millisecond. 20 ms * 50 = &nbsp;1000 ms = 1 second.<br>
<br>
So, the formula of the sleep time should be: <br>
sleep = 1000 / (downloadspeed / pack)<br>
<br>
Follow the sample above, downloadspeed = 1024 * 50 and pack = 1024 and we get:<br>
sleep = 1000 / (50 * 1024 / 1024) = 1000 / 50 = 20.<br>
<br>
For a better understanding, we may think that the result of (1000 / sleep) is<br>
how many times that the thread should send the file packs in a single second. <br>
Like if sleep = 20, that means the thread sends 1000 / 20 = 50 file packs each <br>
second. So, the download speed equals to 50 file packs per second.<br>
<br>
<br>
MORE: You may find that sometimes the download speed doesn't meet the selected<br>
value accurately, especially when it comes to a higher speed. This is caused <br>
by the IO consumption. Higher speed stands for shorter sleep time, which also <br>
means the code below is fired more times than a lower speed in a second.<br>
<br>
&nbsp; &nbsp;If Response.IsClientConnected Then<br>
&nbsp; &nbsp; &nbsp; &nbsp;Response.BinaryWrite(br.ReadBytes(pack))<br>
&nbsp; &nbsp; &nbsp; &nbsp;Thread.Sleep(sleep)<br>
&nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
However, the code itself will spend some time to run, maybe 1 or 2 milliseconds.<br>
It will be not apparent if the sleep time is 100 ms or more. You see, 100 ms is<br>
not far different between 101 ms. But, if the sleep time is 10 ms or less, this<br>
percentage error will take much effect to the download speed.<br>
<br>
Step7: Add Button.Click event handler to call the method.<br>
<br>
&nbsp; &nbsp;Protected Sub btnDownload_Click(ByVal sender As Object, <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ByVal e As EventArgs)
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Handles btnDownload.Click<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim outputFileName As String = &quot;bigFileSample.dat&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim filePath As String = Server.MapPath(&quot;~/bigFileSample.dat&quot;)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim value As String = ddlDownloadSpeed.SelectedValue<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim downloadSpeed As Integer = 1024 * Integer.Parse(value)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Response.Clear()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DownloadFileWithLimitedSpeed(outputFileName,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; filePath,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; downloadSpeed)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Catch ex As Exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(ex.Message)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; &nbsp; &nbsp; &nbsp;Response.End()<br>
&nbsp; &nbsp;End Sub<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN:<br>
# HttpResponse.AddHeader Method<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.httpresponse.addheader.aspx">http://msdn.microsoft.com/en-us/library/system.web.httpresponse.addheader.aspx</a><br>
<br>
# HttpResponse.BinaryWrite Method<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.httpresponse.binarywrite.aspx">http://msdn.microsoft.com/en-us/library/system.web.httpresponse.binarywrite.aspx</a><br>
<br>
# Thread.Sleep Method <br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/d00bd51t.aspx">http://msdn.microsoft.com/en-us/library/d00bd51t.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>