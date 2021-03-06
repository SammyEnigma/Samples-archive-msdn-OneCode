# Win7 Direct2D sample (CppWin7Direct2D)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows 7
* Windows SDK
## Topics
* Graphics
* Direct2D
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:58:18
## Description

<h1>Win7 Direct2D sample (C<span style="">pp</span>Win7Direct2D)<span style=""> </span>
</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Windows 7 and Windows 2008 R2 come with a lot of cool new features. One of the most exciting new features is a new graphic API powered by DirectX. It allows you to take advantage of graphic cards to render complex scenarios. It includes
 3 components:</p>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Direct2D: API for drawing vector graphics.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">DirectWrite</span>: API for text rendering.</p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>WIC (Windows Imaging Component): API for bitmaps encoding and decoding. This API has been around since Windows Vista.</p>
<p class="MsoNormal">Direct2D and <span class="SpellE">DirectWrite</span> will be ported to Vista in the future. But in the meanwhile, you need Windows 7 in order to experience the power brought by the new graphic engine.</p>
<p class="MsoNormal">Among all the three components, Direct2D is the most important. You need to use Direct2D to render text and bitmap.
<span class="SpellE">DirectWrite</span> and WIC do not touch rendering on themselves. Also, only WIC relies on COM runtime. Direct2D and
<span class="SpellE">DirectWrite</span> can work without COM runtime. This sample focuses on Direct2D. We will demonstrate other components in the future.</p>
<p class="MsoNormal">The main target audiences of the new graphic API are native application developers. This sample (written in managed code) is just for demonstrating purpose. Most managed applications should still use WPF, because WPF provides you with
 a nice application framework and a nice UI framework. WPF uses Dirct3D 9 as its underlying rendering engine, while Direct2D uses Direct3D 10. In most cases, you will not notice too much performance difference between WPF and managed Direct2D. You will gain
 performance when hardware rendering is not an option (such as server side batch operation), because Direct2D has optimized software rendering engine, as well as a hardware rendering engine. You may also need Direct2D when working with Direct3D
<span class="SpellE">interop</span> scenarios, to take advantages of advanced GPU pipelines such as geometry
<span class="SpellE">shader</span>.</p>
<p class="MsoNormal">This sample provides an overview of the new vector graphic API. It renders a simple scene with a star (or sun) and a planet (or earth). When you click the planet, it will move around the star.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53377/1/image.png" alt="" width="989" height="566" align="middle">
</span></p>
<p class="MsoNormal">The sample <span class="SpellE">demostrates</span> the following features:</p>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Draw simple vector graphics (such as ellipse).</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Draw complex paths.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a PowerShell script to translate XAML path data to C# Direct2D code.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create solid color and radial gradient brushes.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Simple render transform.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Perform hit test.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Control z-index.</p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Clip path.</p>
<p class="MsoNormal">For more information, please refer to the <a href="http://msdn.microsoft.com/en-us/library/dd370990(VS.85).aspx">
MSDN documents</a> and the Windows SDK samples.<span style=""> </span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">You have to run this sample on Windows7 or Windows Server2008 R2. Press F5 and you will see following image.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53378/1/image.png" alt="" width="989" height="566" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Prepare the project</b><b style=""><span style="">
</span></b></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">To work with Direct2D, you must first import thed2d1.lib library into your Win32 project (specified in Visual C&#43;&#43;'s &quot;Project Property Pages&quot; =&gt; &quot;Linker&quot; =&gt; &quot;Input&quot; =&gt;
 &quot;Additional Dependencies&quot;)</span><span style="">. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">Assume you're working with a standard Win32 project; please also add the d2d1.h header files to your
<span class="SpellE">stdafx.h</span></span><span style="">. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">Still in <span class="SpellE">
stdafx.h</span>, let's write a standard <span class="SpellE">SafeRelease</span> function, which serves to release resources in a safe way. You can find this function in many SDK samples. Please refer to the
<span class="SpellE">SafeRelease</span> function in the sample's <span class="SpellE">
stdafx.h</span> file for the code.</span><span style=""> </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Essential steps to work with Direct2D</b><b style=""><span style="">
</span></b></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">To work with Direct2D, the following steps are required:
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create a factory. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create a render target. The render target represents the actual divide. It can be a simple
<span class="SpellE">hwnd</span> (as demonstrate in this sample), a Direct3D device (DXGI), or anything else.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create other resources, such as brushes. </span>
</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Handle the WM_PAINT message, and render the scene. In managed code, you perform this step by writing a method that implements the Render delegate of the Render/<span class="SpellE">DirectHost</span>.
</span></p>
<p class="MsoNormal" style="margin-left:35.45pt"><span style="">To render the scene, the following steps are required:
</span></p>
<p class="MsoListParagraphCxSpFirst" style="margin-left:71.45pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Call <span class="SpellE">BeginDraw</span> to initializing the scene.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:71.45pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Set the transform matrix for the next graph. </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:71.45pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Prepare the graph, if necessary. For example, create a bounding rectangle for text.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:71.45pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Call various drawing functions to draw vector/bitmap graphics and texts.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:71.45pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Call <span class="SpellE">EndDraw</span> to flush the drawing instructions.
</span></p>
<p class="MsoNormal" style="margin-left:35.45pt"><span class="GramE"><span style="">A note about gradient brushes.</span></span><span style=""> Unlike WPF, in Direct2D, gradient brushes always use global coordinate system. So you have to do additional work
 to calculate the position of each gradient stop. </span></p>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Draw complex paths </span></b></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">It is almost impossible to draw complex paths without first creating them in a graphic authoring tool. WPF allows you to draw paths in Expression Design (or Expression Blend directly if the path
 is not too complex), and then export to XAML. WPF can directly render XAML content as vector graphics. With Direct2D, you do not have
<span class="GramE">the luxuriate</span> to utilize XAML. Traditionally, programmers tend to use bitmaps extensively, and avoid vector graphics as much as possible. However, bitmaps have a lot of disadvantages, such as difficult to animate and losing quality
 during scaling. Nowadays with WPF, a lot of managed applications have begun to use more and more vector graphics. Our native applications must catch up with them. Also Direct2D is a vector graphic API. So it will be great if we can use Expression Studio, but
 output Direct2D code instead of XAML. </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">&nbsp;</span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">You can try to create a tool to perform the translation. This sample provides you with a general idea. XAML is xml, and there's a powerful tool in Windows 7 (and can be downloaded separately in
 Vista) named PowerShell. PowerShell is capable of a lot of tasks, including parsing xml files. You can use the WPF powered GUI PowerShell ISE to authorize PowerShell scripts. Assume your path contains
<span class="SpellE">bezier</span> segments only; you can use the following script to generate C# code from XAML snip.
</span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">&nbsp;</span>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">powershell</span>
<pre class="hidden">
$invocation = (Get-Variable MyInvocation -Scope 0).Value
$currentDir = Split-Path $invocation.InvocationName
cd $currentDir
$xmlData = [xml](Get-Content $args[0])
$segments = $xmlData.PathFigure.SelectNodes(&quot;BezierSegment&quot;)
$segments | ForEach-Object { &quot;sink.AddBezier(new BezierSegment(
new Point2F({0}f, {1}f),
new Point2F({2}f, {3}f),
new Point2F({4}f, {5}f)));
&quot; -f $_.GetAttribute(&quot;Point1&quot;).split(',')[0],
$_.GetAttribute(&quot;Point1&quot;).split(',')[1],
$_.GetAttribute(&quot;Point2&quot;).split(',')[0],
$_.GetAttribute(&quot;Point2&quot;).split(',')[1],
$_.GetAttribute(&quot;Point3&quot;).split(',')[0],
$_.GetAttribute(&quot;Point3&quot;).split(',')[1]
} &gt; $args[1]

</pre>
<pre id="codePreview" class="powershell">
$invocation = (Get-Variable MyInvocation -Scope 0).Value
$currentDir = Split-Path $invocation.InvocationName
cd $currentDir
$xmlData = [xml](Get-Content $args[0])
$segments = $xmlData.PathFigure.SelectNodes(&quot;BezierSegment&quot;)
$segments | ForEach-Object { &quot;sink.AddBezier(new BezierSegment(
new Point2F({0}f, {1}f),
new Point2F({2}f, {3}f),
new Point2F({4}f, {5}f)));
&quot; -f $_.GetAttribute(&quot;Point1&quot;).split(',')[0],
$_.GetAttribute(&quot;Point1&quot;).split(',')[1],
$_.GetAttribute(&quot;Point2&quot;).split(',')[0],
$_.GetAttribute(&quot;Point2&quot;).split(',')[1],
$_.GetAttribute(&quot;Point3&quot;).split(',')[0],
$_.GetAttribute(&quot;Point3&quot;).split(',')[1]
} &gt; $args[1]

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">For more information about PowerShell, please refer to
<a href="http://www.microsoft.com/technet/scriptcenter/topics/winpsh/manual/default.mspx">
http://www.microsoft.com/technet/scriptcenter/topics/winpsh/manual/default.mspx</a>.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Render transforms</b><b style=""><span style="">
</span></b></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">Unlike WPF, in Direct2D, there's no object tree. A transform is applied to the whole render target, which affects all pending drawing instructions, not to a particular object. So after you want
 to transform the planet using matrix a, and then want to transform the star with matrix b, you need to follow these steps:
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Call <span class="SpellE">SetTransform</span>, passing matrix a as the parameter.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Draw all elements containing in the planet. They will all use matrix a.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Call <span class="SpellE">SetTransform</span>, passing matrix b as the parameter.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Draw all elements containing in the star. They will all use matrix b.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">&nbsp;</span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">If you want to draw an untransformed element, please set the transform back to an identity matrix before drawing it.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">&nbsp;</span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">Note currently the managed code pack does not support Direct2D matrix multiplication. As a workaround, you can either implement your own, or simply create WPF matrixes to perform the multiplications.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Hit test<span style=""> </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">To handle mouse input, you handle the standard Win32 message loop. Input system is independent from rendering engines such as Direct2D. However, there is a limitation in WPF and Direct2D
<span class="SpellE">interop</span> scenario. You can't handle the mouse/keyboard events by specifying the event handlers in XAML, because a separate
<span class="SpellE">hwnd</span> is created to render the Direct2D content. You have to handle
<span class="SpellE">ComponentDispatcher.ThreadPreprocessMessage</span> to get the Win32 message loop, as you do in a normal WPF/Win32
<span class="SpellE">interop</span> scenario. </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">&nbsp;</span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">To perform hit test, you call the
<span class="SpellE">FillContainsPoint</span> function on the geometry (or <span class="SpellE">
StrokeContainsPoint</span> if you only want to hit test the stroke). Note when drawing known geometries (such as ellipse), normally you do not need to create a geometry. However, if you want to perform hit test on the known geometry, you have to explicitly
 create it. </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">&nbsp;</span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">Unlike WPF, with Direct2D's immediate rendering model, it does not retain a tree about
<span class="GramE">each geometry</span>'s transform, so you must explicitly pass the transform matrix as a parameter in
<span class="SpellE">FillContainsPoint</span>. </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Z-index </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">Once again, in an immediate rendering environment, you lose the track of previous rendered elements. It will be impossible to say, hey, the planet is rendered later than the star, but I hope the
 star will cover the planet. There's no concept of z-index in Direct2D. To simulate z-index, you will have to plan carefully on the order of the elements being rendered. For example, if you hope the star to cover the planet, draw the planet first and then the
 star. On the <span class="SpellE">othe</span> hand, if you hope the planet to cover the star, draw the star first and then the planet.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Clip path </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="">Direct2D doesn't support clipping path directly. However, a similar effect can be achieved by intersecting the geometry with the clipping path. To perform common geometry operations (such as intersect
 and union), you need to prepare the two source geometries first, and then call <span class="SpellE">
CombineWithGeometry</span> on the first geometry, passing the second geometry as the parameter, and finally save the result to a third geometry. Please remember to delete the source geometries if you no longer need them.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Conclusion<span style=""> </span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style="">Windows 7 ships with a new vector graphic API: Direct2D. It primarily targets native developers, but you can also use it in managed applications, if you want. However, for most managed applications,
 you should still use WPF. You can embed Direct2D scenes inside a WPF application.
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/dd370990(VS.85).aspx">Direct2D</a>
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://archive.msdn.microsoft.com/WindowsAPICodePack/Release/ProjectReleases.aspx?ReleaseId=4906">Windows API Code Pack</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
