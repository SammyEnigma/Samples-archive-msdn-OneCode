# Basics of threading in C# (CSThreadingBasic)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* threading
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:11:22
## Description

<h1>Console Application <span style="">(</span>CSThreadingBasic<span style="">) </span>
</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This example demonstrates how to create threads using C#.NET in three different approaches. And it also shows how to create a thread that require<span style="">s
</span>a parameter. In the target threads, it also shows how to use lock keyword to ensure a code snippet executed without interruption.
<span style=""><span style="">&nbsp;</span></span>A process can create one or more threads to execute a portion of the program code associated with the process. Use a
<span class="SpellE">ThreadStart</span> delegate or the <span class="SpellE">
ParameterizedThreadStart</span> delegate to specify the program code executed by a thread. The
<span class="SpellE">ParameterizedThreadStart</span> delegate allows you to pass data to the thread procedure. The .NET Framework provides us with the
<span class="SpellE">System.Threading</span> namespace, which includes the <span class="SpellE">
ThreadPool</span> class. This is a static class that you can access directly. It provides us with the essential parts of thread pools. It is an implementation of the common &quot;thread pool&quot; design pattern. It is useful for running many separate tasks
 in the background. <span class="SpellE"><span class="GramE">QueueUserWorkItem</span></span><span class="GramE">
<span style=""><span style="">&nbsp;</span>function</span></span><span style=""> q</span>ueues a work item to a worker thread in the thread pool. If a function in a DLL is queued to a worker thread, be sure that the function has completed execution before the
 DLL is unloaded. </p>
<p class="MsoNormal">By default, the thread pool has a maximum of 512 threads per process. To raise the queue limit, use the WT_SET_MAX_THREADPOOL_THREAD macro defined in
<span class="SpellE">WinNT.h</span>.<span style=""> </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/65164/1/image.png" alt="" width="720" height="365" align="middle">
</span></p>
<h2>Using the Code</h2>
<h3><span style="">1. </span>Create a thread by new Thread object<span style="">.
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
ThreadStart ts1 = new ThreadStart(ThreadFunction1);
Thread t1 = new Thread(ts1);
t1.Start();

</pre>
<pre id="codePreview" class="csharp">
ThreadStart ts1 = new ThreadStart(ThreadFunction1);
Thread t1 = new Thread(ts1);
t1.Start();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">2. </span></b><b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Create a thread by
<span class="SpellE">ThreadPool.QueueUserWorkItem</span></span></b><b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">.
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadFunction2));

</pre>
<pre id="codePreview" class="csharp">
ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadFunction2));

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">3. </span></b><b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Create a thread by
<span class="SpellE">ThreadStart.BeginInvoke</span></span></b><b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">.
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
ThreadStart ts2 = new ThreadStart(ThreadFunction3);
ts2.BeginInvoke(null, null);

</pre>
<pre id="codePreview" class="csharp">
ThreadStart ts2 = new ThreadStart(ThreadFunction3);
ts2.BeginInvoke(null, null);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">4. </span></b><b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Create a thread with parameters</span></b><b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">.
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
ParameterizedThreadStart pts = new ParameterizedThreadStart(ThreadFunction4);
Thread t2 = new Thread(pts);
t2.Start(&quot;Message&quot;);

</pre>
<pre id="codePreview" class="csharp">
ParameterizedThreadStart pts = new ParameterizedThreadStart(ThreadFunction4);
Thread t2 = new Thread(pts);
t2.Start(&quot;Message&quot;);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:18.0pt; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:新宋体">C# Threading Programming Guid. </span></p>
<p class="MsoNormal" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:18.0pt; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/ms173178(VS.80).aspx">http://msdn.microsoft.com/en-us/library/ms173178(VS.80).aspx</a>
</span></p>
<p class="MsoNormal" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:18.0pt; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:新宋体">Thread Class document. </span></p>
<p class="MsoNormal" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:18.0pt; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/system.threading.thread.aspx">http://msdn.microsoft.com/en-us/library/system.threading.thread.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:18.0pt; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:新宋体">ThreadPool.QueueWorkItem. </span></p>
<p class="MsoNormal" style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:18.0pt; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/kbf0f1ct.aspx">http://msdn.microsoft.com/en-us/library/kbf0f1ct.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>