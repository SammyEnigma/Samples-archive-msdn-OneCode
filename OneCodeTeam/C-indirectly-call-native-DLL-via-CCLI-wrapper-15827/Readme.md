# C# indirectly call native DLL via C++/CLI wrapper (CSCallNativeDllWrapper)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* Interop
## IsPublished
* True
## ModifiedDate
* 2012-08-22 03:48:24
## Description

<h1><span style="font-family:新宋体">Console Application </span>(<span class="SpellE"><span style="font-family:新宋体">CSCallNativeDllWrapper</span></span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
The code sample demonstrates calling the functions and classes exported by a native C&#43;&#43; DLL module from Visual C# code through C&#43;&#43;/CLI wrapper classes.
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&nbsp; </span><span class="SpellE">CSCallNativeDllWrapper</span> (this .NET application)<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>--&gt;<span style="">&nbsp;&nbsp; </span><span class="SpellE">CppCLINativeDllWrapper</span> (the C&#43;&#43;/CLI wrapper)<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>--&gt;<span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span><span class="SpellE">CppDynamicLinkLibrary</span> (a native C&#43;&#43; DLL module)</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
In this code sample, the <span class="SpellE">CSimpleObjectWrapper</span> class wraps the native C&#43;&#43; class
<span class="SpellE">CSimpleObject</span>, and the <span class="SpellE">NativeMethods</span> class wraps the global functions exported by CppDynamicLinkLibrary.dll.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
The interoperability features supported by Visual C&#43;&#43;/CLI offer a particular advantage over other .NET languages when it comes to interoperating with native modules. Apart from the traditional explicit P/Invoke, C&#43;&#43;/CLI allows implicit P/Invoke, also known
 as C&#43;&#43; <span class="SpellE">Interop</span>, or It Just Work (IJW), which mixes managed code and native code almost invisibly. The feature provides better type safety, easier coding, greater performance, and is more forgiving if the native API is modified.
 You can use the technology to build .NET wrappers for native C&#43;&#43; classes and functions if their source code is available, and allow any .NET clients to access the native C&#43;&#43; classes and functions through the wrappers.<span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;"></span></b></p>
<h3>Demo</h3>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The following steps walk through a demonstration of the .NET-native
<span class="SpellE">interop</span> sample. </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. After you successfully build the <span class="SpellE">CppDynamicLinkLibrary</span>,
<span class="SpellE">CppCLINativeDllWrapper</span>, and <span class="SpellE">
CSCallNativeDllWrapper</span> sample projects in Visual Studio 2008, targeting either the Win32 platform or the x64 platform, you will get the applications: CSCallNativeDllWrapper.exe and two DLL files:
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="GramE"><span style="">CppCLINativeDllWrapper.dll and CppDynamicLinkLibrary.dll.</span></span><span style=""> Their relationship is that CSCallNativeDllWrapper.exe invokes CppCLINativeDllWrapper.dll, which further invokes the functions and classes
 exported by CppDynamicLinkLibrary.dll. </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Run <span class="SpellE">CSCallNativeDllWrapper</span> in a command prompt. The application should print the following messages in the console.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/65151/1/image.png" alt="" width="549" height="235" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The messages indicate that <span class="SpellE">CSCallNativeDllWrapper</span>
<span class="SpellE">successfuly</span> loaded CppDynamicLinkLibrary.dll and invoked the functions (GetStringLength1, GetStringLength2, Max) and the class (<span class="SpellE">CSimpleObject</span>) exported by the native module.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">NOTE: You may receive the following error if you run the debug build of the sample project on a system without the Visual Studio 2008 installed.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Unhandled Exception: <span class="SpellE">System.IO.FileLoadException</span>: Could not load file
<span class="GramE">or<span style="">&nbsp; </span>assembly</span> '<span class="SpellE">CppCLINativeDllWrapper</span>, Version=1.0.0.0, Culture=neutral,<span style="">&nbsp;
</span><span class="SpellE">PublicKeyToken</span>=null' or one of its dependencies. This application has failed to start because the application configuration is incorrect.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
Reinstalling the application may fix this problem. (Exception <span class="GramE">
from<span style="">&nbsp; </span>HRESULT</span>: 0x800736B1) File name: '<span class="SpellE">CppCLINativeDllWrapper</span>, Version=1.0.0.0, Culture=neutral,<span style="">&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="SpellE">PublicKeyToken</span>=null' ---&gt; <span class="SpellE">
<span class="GramE">System.Runtime.InteropServices.COMException</span></span><span class="GramE"><span style="">&nbsp;
</span>(</span>0x800736B1): This application has failed to start because the application<span style="">&nbsp;
</span>configuration is incorrect. Reinstalling the application may fix <span class="GramE">
this<span style="">&nbsp; </span>problem</span>. (Exception from HRESULT: 0x800736B1) at
<span class="SpellE"><span class="GramE">CSCallNativeDllWrapper.Program.Main</span></span><span class="GramE">(</span>String[]
<span class="SpellE">args</span>) </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">This is caused by the fact the debug build of <span class="SpellE">
CppCLINativeDllWrapper</span> and <span class="SpellE">CppDynamicLinkLibrary</span> depends on the Debug CRT which is only available in the development environments with Visual Studio 2008 installed. You must run the release build of the sample project in
 the non-development environment. </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<h3>Implementation</h3>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step1. Reference the C&#43;&#43;/CLI wrapper class library <span class="SpellE">CppCLINativeDllWrapper</span> in the VC# sample
<span class="SpellE">applicatino</span>. <span class="SpellE">CppCLINativeDllWrapper</span> wraps the functions and classes exported by the native C&#43;&#43; DLL
<span class="SpellE">CppDynamicLinkLibrary</span>.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step2. Call the .NET classes <span class="SpellE">CSimpleObjectWrapper</span> and
<span class="SpellE">NativeMethods</span> exposed by <span class="SpellE">CppCLINativeDllWrapper</span> to indirectly access the functions and classes exported by the native C&#43;&#43; DLL
<span class="SpellE">CppDynamicLinkLibrary</span>. For example, </p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/2x8kf7zx.aspx">Using C&#43;&#43;
<span class="SpellE">Interop</span> (Implicit <span class="SpellE">PInvoke</span>)</a></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/ms235281.aspx">How to: Wrap Native Class for Use by C#</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>