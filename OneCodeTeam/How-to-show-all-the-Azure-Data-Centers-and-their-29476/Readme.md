# How to show all the Microsoft Azure Data Centers and their available services
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Azure
* Cloud
## Topics
* Azure
* code snippets
## IsPublished
* True
## ModifiedDate
* 2014-06-24 07:31:52
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to scroll to the bottom of a multi-line TextBox in Windows Store apps</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This code snippet will show you how to automatically scroll to the bottom when adding text by code to the TextBox.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Suppose that we click a button and add content to the TextBox now.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span><span class="hidden">vb</span>
<pre class="hidden">private void addBtn_Click(object sender, RoutedEventArgs e)
        {
           
            textBox.Text &#43;= &quot;AddContent &quot; &#43; m_index &#43; &quot; &quot;;
            m_index&#43;&#43;;
        }
</pre>
<pre class="hidden">void TestApp::MainPage::addBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 textBox-&gt;Text &#43;= &quot;AddContent &quot; &#43; m_index &#43; &quot; &quot;;
 m_index&#43;&#43;;
}
</pre>
<pre class="hidden">Private Sub addBtn_Click(sender As Object, e As RoutedEventArgs) Handles addBtn.Click
        textBox.Text &#43;= &quot;AddContent &quot; &#43; m_index.ToString() &#43; &quot; &quot;
        m_index &#43;= 1
    End Sub
</pre>
<pre id="codePreview" class="csharp">private void addBtn_Click(object sender, RoutedEventArgs e)
        {
           
            textBox.Text &#43;= &quot;AddContent &quot; &#43; m_index &#43; &quot; &quot;;
            m_index&#43;&#43;;
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">When the content inside the text box is too long, the TextBox will just display the top of the content
</span><span style="font-size:11pt">by</span><span style="font-size:11pt"> default. Like:
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/117555/1/image.png" alt="" width="183" height="173" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">But we usually want to auto-scroll the content when adding text to the TextBox. Like:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/117556/1/image.png" alt="" width="183" height="178" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">So we&rsquo;ll implement this effect now.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Add TextChanged event handler first. When the text in the TextBox chang</span><span style="font-size:11pt">es</span><span style="font-size:11pt">, this function will be r</span><span style="font-size:11pt">u</span><a name="_GoBack"></a><span style="font-size:11pt">n.
 We get Grid from the TextBox using </span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.visualtreehelper.getchild(v=win.10).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">VisualTreeHelper.GetChild</span></a><span style="font-size:11pt">.
 Then look for the ScrollViewer control in the Grid we&rsquo;ve got. Once we find the ScrollViewer, we can use
</span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.scrollviewer.changeview(v=win.10).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">ChangeView</span></a><span style="font-size:11pt">
 to scroll the text inside the TextBox.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span><span class="hidden">vb</span>
<pre class="hidden">private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var grid = (Grid)VisualTreeHelper.GetChild(textBox, 0);
            for (var i = 0; i &lt;= VisualTreeHelper.GetChildrenCount(grid) - 1; i&#43;&#43;)
            {
                object obj = VisualTreeHelper.GetChild(grid, i);
                if (!(obj is ScrollViewer)) continue;
                ((ScrollViewer)obj).ChangeView(0.0f, ((ScrollViewer)obj).ExtentHeight, 1.0f);
                break;
            }
        }
</pre>
<pre class="hidden">void TestApp::MainPage::TextBox_TextChanged(Platform::Object^ sender, Windows::UI::Xaml::Controls::TextChangedEventArgs^ e)
{
 auto grid = (Grid^)VisualTreeHelper::GetChild(textBox, 0);
 for (int i = 0; i &lt;= VisualTreeHelper::GetChildrenCount(grid) - 1; i&#43;&#43;)
 {
  auto obj = VisualTreeHelper::GetChild(grid, i);
  
  if (obj-&gt;GetType()-&gt;FullName != ScrollViewer::typeid-&gt;FullName) continue;
  ((ScrollViewer^)obj)-&gt;ChangeView(0.0, ((ScrollViewer^)obj)-&gt;ExtentHeight, 1.0f);
  break;
 }
}
</pre>
<pre class="hidden">Private Sub TextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim grid = CType(VisualTreeHelper.GetChild(textBox, 0), Grid)
        Dim i
        For i = 0 To VisualTreeHelper.GetChildrenCount(grid) - 1 Step i &#43; 1
            Dim obj As Object = VisualTreeHelper.GetChild(grid, i)
            If Not TypeOf obj Is Windows.UI.Xaml.Controls.ScrollViewer Then
                Continue For
            End If
            CType(obj, ScrollViewer).ChangeView(0.0F, CType(obj, ScrollViewer).ExtentHeight, 1.0F)
            Exit For
        Next
    End Sub
</pre>
<pre id="codePreview" class="csharp">private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var grid = (Grid)VisualTreeHelper.GetChild(textBox, 0);
            for (var i = 0; i &lt;= VisualTreeHelper.GetChildrenCount(grid) - 1; i&#43;&#43;)
            {
                object obj = VisualTreeHelper.GetChild(grid, i);
                if (!(obj is ScrollViewer)) continue;
                ((ScrollViewer)obj).ChangeView(0.0f, ((ScrollViewer)obj).ExtentHeight, 1.0f);
                break;
            }
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">ScrollViewer.ChangeView methods</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.scrollviewer.changeview(v=win.10).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.scrollviewer.changeview(v=win.10).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">VisualTreeHelper.GetChild method</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.visualtreehelper.getchild(v=win.10).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.visualtreehelper.getchild(v=win.10).aspx</span></a></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
