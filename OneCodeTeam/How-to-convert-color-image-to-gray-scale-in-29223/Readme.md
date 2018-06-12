# How to convert color image to gray scale in Windows Forms
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* GDI+
* Windows Desktop App Development
* Graphics and Gaming
## Topics
* code snippets
* convert image to gray
## IsPublished
* True
## ModifiedDate
* 2014-06-11 08:45:54
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to convert color image to gray scale
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Th</span><span style="font-size:11pt">e</span><span style="font-size:11pt">
</span><span style="font-size:11pt">following </span><span style="font-size:11pt">code snippet</span><span style="font-size:11pt">s will
</span><span style="font-size:11pt">demonstrate how to convert color image to gray scale.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Code Snippet</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span><span style="">The basic steps to convert color image to gray scale as shown below:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Create </span>
<span style="font-size:11pt">ConvertToGrayscale</span><span style="font-size:11pt"> method.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">iteratively</span><span style="font-size:11pt"> get each pixel value of the image.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Reset the pixel value by using
</span><span style="font-size:11pt">SetPixel</span><span style="font-size:11pt"> method.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">
&nbsp;
using System;
using System.Drawing; 
&nbsp;
class Program
    {
        static void Main(string[] args)
        {
            string bmstr = @&quot;D:\logo.png&quot;;
            string graystr = @&quot;D:\gray.png&quot;;
            Bitmap sourcebm = null;
            Bitmap graybm=null;
            try
            {
                sourcebm = new Bitmap(bmstr);
                graybm = ConvertToGrayscale(sourcebm);
                graybm.Save(graystr);
                Console.WriteLine(&quot;Convert scuccessfully&quot;);
            }
            catch (Exception ex)
            {
                Console.WriteLine(&quot;Err message:&quot; &#43; ex.Message);
            }
            finally
            {
                if (sourcebm != null)
                {
                    sourcebm.Dispose();
                }
                if (graybm != null)
                {
                    graybm.Dispose();
                }
            }
            Console.Read();
        }
        public static Bitmap ConvertToGrayscale(Bitmap source)
        {
            Bitmap bm = new Bitmap(source.Width, source.Height);
            for (int y = 0; y &lt; bm.Height; y&#43;&#43;)
            {
                for (int x = 0; x &lt; bm.Width; x&#43;&#43;)
                {
                    Color c = source.GetPixel(x, y);
                    int average = (Convert.ToInt32(c.R) &#43; Convert.ToInt32(c.G) &#43; Convert.ToInt32(c.B)) / 3;
                    //int average = (int)(c.R * 0.3 &#43; c.G * 0.59 &#43; c.B * 0.11);
                    bm.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }
            return bm;
        }
    }
</pre>
<pre class="hidden">
Imports System.Drawing
    Sub Main()
        Dim bmstr As String = &quot;D:\\logo.png&quot;
        Dim graystr As String = &quot;D:\\gray.png&quot;
        Dim sourcebm As Bitmap = Nothing
        Dim graybm As Bitmap = Nothing
        Try
            sourcebm = New Bitmap(bmstr)
            graybm = ConvertToGrayscale(sourcebm)
            graybm.Save(graystr)
            Console.WriteLine(&quot;Convert scuccessfully&quot;)
        Catch ex As Exception
            Console.WriteLine(&quot;Err message:&quot; &#43; ex.Message)
        Finally
            If sourcebm IsNot Nothing Then
                sourcebm.Dispose()
            End If
            If graybm IsNot Nothing Then
                graybm.Dispose()
            End If
        End Try
        Console.Read()
    End Sub
    Public Function ConvertToGrayscale(source As Bitmap) As Bitmap
        Dim bm As New Bitmap(source.Width, source.Height)
        For y As Integer = 0 To bm.Height - 1
            For x As Integer = 0 To bm.Width - 1
                Dim c As Color = source.GetPixel(x, y)
                Dim average As Integer = (Convert.ToInt32(c.R) &#43; Convert.ToInt32(c.G) &#43; Convert.ToInt32(c.B)) / 3
                'int average = (int)(c.R * 0.3 &#43; c.G * 0.59 &#43; c.B * 0.11);
                bm.SetPixel(x, y, Color.FromArgb(average, average, average))
            Next
        Next
        Return bm
    End Function
</pre>
<pre class="hidden">
#include &lt;comdef.h&gt;
#include &lt;iostream&gt;
#include &lt;gdiplus.h&gt; 
#include &lt;Gdipluscolor.h&gt;
using namespace Gdiplus;
#pragma comment(lib, &quot;gdiplus.lib&quot;)
void ConvertToGrayscale(Bitmap *source,Bitmap *bm)
{
 int Height = source-&gt;GetHeight();
 int Width = source-&gt;GetWidth();
 for (int y = 0; y &lt; Height; y&#43;&#43;)
 {
  for (int x = 0; x &lt; Width; x&#43;&#43;)
  {
   Color c;
   source-&gt;GetPixel(x, y, &c);
   BYTE average = (BYTE)((c.GetRed()&#43;c.GetGreen()&#43;c.GetBlue())/3);
   bm-&gt;SetPixel(x, y, Color(average, average, average));
  }
 }
}
// Get Encoder ClsId
int GetEncoderClsid(const WCHAR* format, CLSID* pClsid)
{
 UINT  num = 0;          // number of image encoders
 UINT  size = 0;         // size of the image encoder array in bytes
 ImageCodecInfo* pImageCodecInfo = NULL;
 GetImageEncodersSize(&num, &size);
 if (size == 0)
  return -1;  // Failure
 pImageCodecInfo = (ImageCodecInfo*)(malloc(size));
 if (pImageCodecInfo == NULL)
  return -1;  // Failure
 GetImageEncoders(num, size, pImageCodecInfo);
 for (UINT j = 0; j &lt; num; &#43;&#43;j)
 {
  if (wcscmp(pImageCodecInfo[j].MimeType, format) == 0)
  {
   *pClsid = pImageCodecInfo[j].Clsid;
   free(pImageCodecInfo);
   return j;  // Success
  }
 }
 free(pImageCodecInfo);
 return -1;  // Failure
}
void main()
{
 GdiplusStartupInput gdiplusStartupInput;
 ULONG_PTR gdiplusToken;
 GdiplusStartup(&gdiplusToken, &gdiplusStartupInput, NULL);
 Bitmap *sourcebm = Bitmap::FromFile(L&quot;D:\\logo.png&quot;);
 Bitmap *graybm =new Bitmap(sourcebm-&gt;GetWidth(), sourcebm-&gt;GetHeight());
 int height = sourcebm-&gt;GetHeight();
 ConvertToGrayscale(sourcebm, graybm);
 CLSID pngClsid;
 if (GetEncoderClsid(L&quot;image/png&quot;, &pngClsid) != -1)
 {
  graybm-&gt;Save(L&quot;D:\\gray.png&quot;, &pngClsid, NULL);
  std::cout &lt;&lt; &quot;Convert successfully&quot; &lt;&lt; std::endl;
 }
 else
 {
  std::cout &lt;&lt; &quot;Error&quot; &lt;&lt; std::endl;
 }
 delete sourcebm;
 sourcebm = NULL;
 delete graybm;
 graybm = NULL;
 GdiplusShutdown(gdiplusToken);
}
</pre>
<pre id="codePreview" class="csharp">
&nbsp;
using System;
using System.Drawing; 
&nbsp;
class Program
    {
        static void Main(string[] args)
        {
            string bmstr = @&quot;D:\logo.png&quot;;
            string graystr = @&quot;D:\gray.png&quot;;
            Bitmap sourcebm = null;
            Bitmap graybm=null;
            try
            {
                sourcebm = new Bitmap(bmstr);
                graybm = ConvertToGrayscale(sourcebm);
                graybm.Save(graystr);
                Console.WriteLine(&quot;Convert scuccessfully&quot;);
            }
            catch (Exception ex)
            {
                Console.WriteLine(&quot;Err message:&quot; &#43; ex.Message);
            }
            finally
            {
                if (sourcebm != null)
                {
                    sourcebm.Dispose();
                }
                if (graybm != null)
                {
                    graybm.Dispose();
                }
            }
            Console.Read();
        }
        public static Bitmap ConvertToGrayscale(Bitmap source)
        {
            Bitmap bm = new Bitmap(source.Width, source.Height);
            for (int y = 0; y &lt; bm.Height; y&#43;&#43;)
            {
                for (int x = 0; x &lt; bm.Width; x&#43;&#43;)
                {
                    Color c = source.GetPixel(x, y);
                    int average = (Convert.ToInt32(c.R) &#43; Convert.ToInt32(c.G) &#43; Convert.ToInt32(c.B)) / 3;
                    //int average = (int)(c.R * 0.3 &#43; c.G * 0.59 &#43; c.B * 0.11);
                    bm.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }
            return bm;
        }
    }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Use the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, </span><span style="font-size:11pt">c</span><span style="font-size:11pt">reate Console Application and then add &quot;System.Drawing.dll&quot; reference</span><span style="font-size:11pt"> when using C#/VB.NET.
 W</span><span style="font-size:11pt">e should include </span><span style="font-size:11pt">the related
</span><span style="font-size:11pt">header file</span><span style="font-size:11pt">s/libraries when</span><span style="font-size:11pt"> using
</span><span style="font-size:11pt">native </span><span style="font-size:11pt">C&#43;&#43;.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Second, </span><span style="font-size:11pt">c</span><span style="font-size:11pt">reate
</span><span style="font-size:11pt">a </span><span style="font-size:11pt">method named &quot;</span><span style="font-size:11pt">ConvertToGrayscale</span><span style="font-size:11pt">&quot;.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">
public static Bitmap ConvertToGrayscale(Bitmap source)
        {
            Bitmap bm = new Bitmap(source.Width, source.Height);
            for (int y = 0; y &lt; bm.Height; y&#43;&#43;)
            {
                for (int x = 0; x &lt; bm.Width; x&#43;&#43;)
                {
                    Color c = source.GetPixel(x, y);
                    int average = (Convert.ToInt32(c.R) &#43; Convert.ToInt32(c.G) &#43; Convert.ToInt32(c.B)) / 3;
                    //int average = (int)(c.R * 0.3 &#43; c.G * 0.59 &#43; c.B * 0.11);
                    bm.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }
            return bm;
        }
</pre>
<pre class="hidden">
Public Function ConvertToGrayscale(source As Bitmap) As Bitmap
        Dim bm As New Bitmap(source.Width, source.Height)
        For y As Integer = 0 To bm.Height - 1
            For x As Integer = 0 To bm.Width - 1
                Dim c As Color = source.GetPixel(x, y)
                Dim average As Integer = (Convert.ToInt32(c.R) &#43; Convert.ToInt32(c.G) &#43; Convert.ToInt32(c.B)) / 3
                'int average = (int)(c.R * 0.3 &#43; c.G * 0.59 &#43; c.B * 0.11);
                bm.SetPixel(x, y, Color.FromArgb(average, average, average))
            Next
        Next
        Return bm
    End Function
</pre>
<pre class="hidden">
void ConvertToGrayscale(Bitmap *source,Bitmap *bm)
{
 int Height = source-&gt;GetHeight();
 int Width = source-&gt;GetWidth();
 for (int y = 0; y &lt; Height; y&#43;&#43;)
 {
  for (int x = 0; x &lt; Width; x&#43;&#43;)
  {
   Color c;
   source-&gt;GetPixel(x, y, &c);
   BYTE average = (BYTE)((c.GetRed()&#43;c.GetGreen()&#43;c.GetBlue())/3);
   bm-&gt;SetPixel(x, y, Color(average, average, average));
  }
 }
}
</pre>
<pre id="codePreview" class="csharp">
public static Bitmap ConvertToGrayscale(Bitmap source)
        {
            Bitmap bm = new Bitmap(source.Width, source.Height);
            for (int y = 0; y &lt; bm.Height; y&#43;&#43;)
            {
                for (int x = 0; x &lt; bm.Width; x&#43;&#43;)
                {
                    Color c = source.GetPixel(x, y);
                    int average = (Convert.ToInt32(c.R) &#43; Convert.ToInt32(c.G) &#43; Convert.ToInt32(c.B)) / 3;
                    //int average = (int)(c.R * 0.3 &#43; c.G * 0.59 &#43; c.B * 0.11);
                    bm.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }
            return bm;
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">At last, call the method in main method.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span><span style="">(</span><span style="font-style:italic">Note: for simplicity, the following code snippet hardcodes the
</span><span style="font-weight:bold; font-style:italic">bmstr</span><span style="font-weight:bold; font-style:italic">
</span><span style="font-style:italic">and </span><span style="font-weight:bold; font-style:italic">graystr</span><span style="font-weight:bold; font-style:italic">
</span><span style="font-style:italic">variables. You can change them optionally.)</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">
static void Main(string[] args)
        {
            string bmstr = @&quot;D:\logo.png&quot;;
            string graystr = @&quot;D:\gray.png&quot;;
            Bitmap sourcebm = null;
            Bitmap graybm=null;
            try
            {
                sourcebm = new Bitmap(bmstr);
                graybm = ConvertToGrayscale(sourcebm);
                graybm.Save(graystr);
                Console.WriteLine(&quot;Convert scuccessfully&quot;);
            }
            catch (Exception ex)
            {
                Console.WriteLine(&quot;Err message:&quot; &#43; ex.Message);
            }
            finally
            {
                if (sourcebm != null)
                {
                    sourcebm.Dispose();
                }
                if (graybm != null)
                {
                    graybm.Dispose();
                }
            }
            Console.Read();
        }
</pre>
<pre class="hidden">
Sub Main()
        Dim bmstr As String = &quot;D:\\logo.png&quot;
        Dim graystr As String = &quot;D:\\gray.png&quot;
        Dim sourcebm As Bitmap = Nothing
        Dim graybm As Bitmap = Nothing
        Try
            sourcebm = New Bitmap(bmstr)
            graybm = ConvertToGrayscale(sourcebm)
            graybm.Save(graystr)
            Console.WriteLine(&quot;Convert scuccessfully&quot;)
        Catch ex As Exception
            Console.WriteLine(&quot;Err message:&quot; &#43; ex.Message)
        Finally
            If sourcebm IsNot Nothing Then
                sourcebm.Dispose()
            End If
            If graybm IsNot Nothing Then
                graybm.Dispose()
            End If
        End Try
        Console.Read()
    End Sub
</pre>
<pre class="hidden">
void main()
{
 GdiplusStartupInput gdiplusStartupInput;
 ULONG_PTR gdiplusToken;
 GdiplusStartup(&gdiplusToken, &gdiplusStartupInput, NULL);
 Bitmap *sourcebm = Bitmap::FromFile(L&quot;D:\\logo.png&quot;);
 Bitmap *graybm =new Bitmap(sourcebm-&gt;GetWidth(), sourcebm-&gt;GetHeight());
 int height = sourcebm-&gt;GetHeight();
 ConvertToGrayscale(sourcebm, graybm);
 CLSID pngClsid;
 if (GetEncoderClsid(L&quot;image/png&quot;, &pngClsid) != -1)
 {
  graybm-&gt;Save(L&quot;D:\\gray.png&quot;, &pngClsid, NULL);
  std::cout &lt;&lt; &quot;Convert successfully&quot; &lt;&lt; std::endl;
 }
 else
 {
  std::cout &lt;&lt; &quot;Error&quot; &lt;&lt; std::endl;
 }
 delete sourcebm;
 sourcebm = NULL;
 delete graybm;
 graybm = NULL;
 GdiplusShutdown(gdiplusToken);
}
</pre>
<pre id="codePreview" class="csharp">
static void Main(string[] args)
        {
            string bmstr = @&quot;D:\logo.png&quot;;
            string graystr = @&quot;D:\gray.png&quot;;
            Bitmap sourcebm = null;
            Bitmap graybm=null;
            try
            {
                sourcebm = new Bitmap(bmstr);
                graybm = ConvertToGrayscale(sourcebm);
                graybm.Save(graystr);
                Console.WriteLine(&quot;Convert scuccessfully&quot;);
            }
            catch (Exception ex)
            {
                Console.WriteLine(&quot;Err message:&quot; &#43; ex.Message);
            }
            finally
            {
                if (sourcebm != null)
                {
                    sourcebm.Dispose();
                }
                if (graybm != null)
                {
                    graybm.Dispose();
                }
            }
            Console.Read();
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You can get the result as</span><span style="font-size:11pt"> follows:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The</span><span style="font-size:11pt">
</span><span style="font-size:11pt">s</span><span style="font-size:11pt">ource Image is:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/116699/1/image.png" alt="" width="149" height="149" align="middle">
</span><a name="_GoBack"></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">After conversion, the image becomes gray:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/116700/1/image.png" alt="" width="149" height="149" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Bitmap Class</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Bitmap.GetPixel</span><span style=""> Method</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.getpixel(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.getpixel(v=vs.110).aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Bitmap.SetPixel</span><span style=""> Method</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.setpixel(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.setpixel(v=vs.110).aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">GDI&#43; Reference</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms533799(v=vs.85).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/desktop/ms533799(v=vs.85).aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Image.Save</span><span style="">(</span><span style="">const</span><span style=""> WCHAR*,
</span><span style="">const</span><span style=""> CLSID*, </span><span style="">const</span><span style="">
</span><span style="">EncoderParameters</span><span style="">*) method</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms535407(v=vs.85).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/desktop/ms535407(v=vs.85).aspx</span></a></span>
</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
