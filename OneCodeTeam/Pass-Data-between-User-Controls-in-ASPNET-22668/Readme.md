# Pass Data between User Controls in ASP.NET
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* User Control
## IsPublished
* False
## ModifiedDate
* 2013-06-13 10:46:46
## Description

<h1>How to pass data from one user control to another (VBASPNETUserControlPassData)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This project illustrates how to pass data from one user control to another. A user control can contain other controls like TextBoxes or Labels, These control are declared as protected members, we cannot get the use control from another
 one directly.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step 1: Open the VBASPNETUserControlPassData.sln.<br>
Step 2: Expand the VBASPNETUserControlPassData web application and press Ctrl &#43; F5 to show the Default.aspx.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84689/1/image.png" alt="" width="532" height="135" align="middle">
</span><br>
Step 3: You can find two messages on Default page. The messages be outputted by<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>UserControl2 user control, UserControl2 can retrieve the data that come from UserControl1 user control.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84690/1/image.png" alt="" width="521" height="120" align="middle">
</span><br>
Step 4: Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step 1. Create a Visual Basic &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2012. Name it as &quot;VBASPNETUserControlPassData&quot;.</p>
<p class="MsoNormal">Step 2. Add one web form in the root directory, name it as &quot;Default.aspx&quot;. This page is use to show user controls.</p>
<p class="MsoNormal">Step 3. Add a folder named &quot;UserControl&quot; with two user controls, &quot;UserControl1.ascx&quot;,<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&quot;UserControl2.ascx&quot;.</p>
<p class="MsoNormal">Step 4. The UserControl1 user control provide public property as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not IsPostBack Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; StrCallee = &quot;I come from UserControl1.&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbPublicVariable.Text = StrCallee
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
 &nbsp;&nbsp;End Sub
&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' UserControl2 message.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; Public Property StrCallee As String = &quot;I come from UserControl1.&quot;

</pre>
<pre id="codePreview" class="vb">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not IsPostBack Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; StrCallee = &quot;I come from UserControl1.&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbPublicVariable.Text = StrCallee
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
 &nbsp;&nbsp;End Sub
&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' UserControl2 message.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; Public Property StrCallee As String = &quot;I come from UserControl1.&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 5.<span style="">&nbsp; </span>The UserControl2 user control is use to output private messages and the data of<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>UserControl1 user control.<span style=""> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class UserControl2
&nbsp;&nbsp;&nbsp; Inherits System.Web.UI.UserControl
&nbsp;&nbsp;&nbsp; Private userControl1 As UserControl1


&nbsp;&nbsp;&nbsp; Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not Page.IsPostBack Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Output UserControl2 user control message.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbPublicVariable2.Text = StrCaller


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Find UserControl1 user control.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim control As Control = Page.FindControl(&quot;UserControl1ID&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userControl1 = DirectCast(control, UserControl1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If userControl1 IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Output UserControl1 user control message.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim lbUserControl1 As Label = TryCast(userControl1.FindControl(&quot;lbPublicVariable&quot;), Label)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If lbUserControl1 IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbUserControl1.Text = userControl1.StrCallee
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tbModifyUserControl1.Text = userControl1.StrCallee
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; End Sub
&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' UserControl2 message.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; Public Property StrCaller As String = &quot;I come from UserControl2.&quot;


&nbsp;&nbsp;&nbsp; Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not tbModifyUserControl1.Text.Trim().Equals(String.Empty) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim control As Control = TryCast(Session(&quot;UserControl1&quot;), Control)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userControl1 = TryCast(control, UserControl1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If userControl1 IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;' Set UserControl1 user control message.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbFormatMessage.Text = String.Format(&quot;forward message: {0} &quot;, userControl1.StrCallee)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userControl1.StrCallee = tbModifyUserControl1.Text
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Session(&quot;UserControl1&quot;) = userControl1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pageUserControl1 As UserControl1 = TryCast(Page.FindControl(&quot;UserControl1ID&quot;), UserControl1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim lbUserControl1 As Label = TryCast(pageUserControl1.FindControl(&quot;lbPublicVariable&quot;), Label)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbUserControl1.Text = tbModifyUserControl1.Text
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; control = Page.FindControl(&quot;UserControl1ID&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userControl1 = DirectCast(control, UserControl1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userControl1.StrCallee = tbModifyUserControl1.Text.Trim()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim lbUserControl1 As Label = TryCast(userControl1.FindControl(&quot;lbPublicVariable&quot;), Label)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbUserControl1.Text = userControl1.StrCallee
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Session(&quot;UserControl1&quot;) = userControl1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbMessage.Text = &quot;The message can not be null.&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End Sub
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class UserControl2
&nbsp;&nbsp;&nbsp; Inherits System.Web.UI.UserControl
&nbsp;&nbsp;&nbsp; Private userControl1 As UserControl1


&nbsp;&nbsp;&nbsp; Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not Page.IsPostBack Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Output UserControl2 user control message.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbPublicVariable2.Text = StrCaller


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Find UserControl1 user control.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim control As Control = Page.FindControl(&quot;UserControl1ID&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userControl1 = DirectCast(control, UserControl1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If userControl1 IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Output UserControl1 user control message.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim lbUserControl1 As Label = TryCast(userControl1.FindControl(&quot;lbPublicVariable&quot;), Label)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If lbUserControl1 IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbUserControl1.Text = userControl1.StrCallee
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tbModifyUserControl1.Text = userControl1.StrCallee
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; End Sub
&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' UserControl2 message.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; Public Property StrCaller As String = &quot;I come from UserControl2.&quot;


&nbsp;&nbsp;&nbsp; Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not tbModifyUserControl1.Text.Trim().Equals(String.Empty) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim control As Control = TryCast(Session(&quot;UserControl1&quot;), Control)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userControl1 = TryCast(control, UserControl1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If userControl1 IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;' Set UserControl1 user control message.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbFormatMessage.Text = String.Format(&quot;forward message: {0} &quot;, userControl1.StrCallee)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userControl1.StrCallee = tbModifyUserControl1.Text
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Session(&quot;UserControl1&quot;) = userControl1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pageUserControl1 As UserControl1 = TryCast(Page.FindControl(&quot;UserControl1ID&quot;), UserControl1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim lbUserControl1 As Label = TryCast(pageUserControl1.FindControl(&quot;lbPublicVariable&quot;), Label)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbUserControl1.Text = tbModifyUserControl1.Text
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; control = Page.FindControl(&quot;UserControl1ID&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userControl1 = DirectCast(control, UserControl1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userControl1.StrCallee = tbModifyUserControl1.Text.Trim()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim lbUserControl1 As Label = TryCast(userControl1.FindControl(&quot;lbPublicVariable&quot;), Label)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbUserControl1.Text = userControl1.StrCallee
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Session(&quot;UserControl1&quot;) = userControl1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbMessage.Text = &quot;The message can not be null.&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End Sub
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 6. You need drag and drop the user controls in default page.<br>
Step 7. Build the application and you can debug it.</p>
<h2>More Information</h2>
<p class="MsoNormal">MSDN: ASP.NET User Controls Overview<br>
<a href="http://msdn.microsoft.com/en-us/library/fb3w5b53.aspx">http://msdn.microsoft.com/en-us/library/fb3w5b53.aspx</a><br>
MSDN: Page.FindControl Method (String)<br>
<a href="http://msdn.microsoft.com/en-us/library/31hxzsdw.aspx">http://msdn.microsoft.com/en-us/library/31hxzsdw.aspx</a><br>
MSDN: Page.LoadControl Method <br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.page.loadcontrol.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.page.loadcontrol.aspx</a><br style="">
<br style="">
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
