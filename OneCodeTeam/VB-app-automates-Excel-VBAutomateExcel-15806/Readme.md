# VB app automates Excel (VBAutomateExcel)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Office
## Topics
* Excel
* Automation
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:59:20
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION</span> (<span style="font-family:������">VBAutomateExcel</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">T<span style="">his </span>example demonstrates how to use Visual
<span style="">VB.NET</span> codes to create a Microsoft Excel instance, create a workbook, fill data into a specific range, save the workbook, close the Microsoft Excel application and then clean up unmanaged COM resources.Office automation is based on Component
 Object Model (COM). When you call a COM object of Office from managed code, a Runtime Callable Wrapper (RCW) is automatically created. The RCW marshals calls between the .NET application and the COM object. The RCW keeps a reference count on the COM object.
 If all references have not been released on the RCW, the COM object of Office does not quit and may cause the Office application not to quit after your automation. In order to make sure that the Office application quits cleanly, the sample demonstrates two
 solutions.</p>
<p class="MsoNormal">Solution1.AutomateExcel demonstrates automating Microsoft Excel application by using Microsoft Excel Primary Interop Assembly (PIA) and explicitly assigning each COM accessor object to a new variable that you would explicitly call Marshal.FinalReleaseComObject
 to release it at the end.</p>
<p class="MsoNormal">Solution2.AutomateExcel demonstrates automating Microsoft Excel application by using Microsoft Excel PIA and forcing a garbage collection as soon as the automation function is off the stack (at which point the RCW objects are no longer
 rooted) to clean up RCWs and release COM objects.<span style="">&nbsp; </span></p>
<h2>Running the Sample </h2>
<p class="MsoNormal">The following steps walk through a demonstration of the Excel automation sample that starts a Microsoft Excel instance, creates a workbook, fills data into a specified range, saves the workbook, and quits the Microsoft Excel application
 cleanly.</p>
<p class="MsoNormal">Step1. After you successfully build the sample project in Visual Studio 2010, you will get the application: CSAutomateExcel.exe.</p>
<p class="MsoNormal">Step2. Open Windows Task Manager (Ctrl&#43;Shift&#43;Esc) to confirm that no Excel.exe is running.
</p>
<p class="MsoNormal">Step3. Run the application. It should print the following content in the console window if no error is thrown.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53385/1/image.png" alt="" width="576" height="376" align="middle">
</span></p>
<p class="MsoNormal">Then, you will see two new workbooks in the directory of the application:
</p>
<p class="MsoNormal">Sample1.xlsx and Sample2.xlsx. Both workbooks have a worksheet named &quot;Report&quot;.
</p>
<p class="MsoNormal">The worksheet has the following data in the range A1:C6.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53386/1/image.png" alt="" width="528" height="523" align="middle">
</span></p>
<p class="MsoNormal">Step4. In Windows Task Manager, confirm that the Excel.exe process does not exist, i.e. the Microsoft Excel intance was closed and cleaned up properly.<span style="">
</span></p>
<h2><span style="">Using the code </span></h2>
<p class="MsoNormal">Step1. Create a Console application and reference the Excel Primary Interop Assembly (PIA). To reference the Excel PIA, right-click the project file<span style="">
</span>and click the &quot;Add Reference...&quot; button. In the Add Reference dialog, navigate to the .NET tab, find Microsoft.Office.Interop.Excel 12.0.0.0 and click OK.</p>
<p class="MsoNormal">Step2. Import and rename the Excel interop namepace:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports Excel = Microsoft.Office.Interop.Excel

</pre>
<pre id="codePreview" class="vb">
Imports Excel = Microsoft.Office.Interop.Excel

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Start up an Excel application by creating an Excel.Application object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim oXL As New Excel.Application

</pre>
<pre id="codePreview" class="vb">
Dim oXL As New Excel.Application

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Get the Workbooks collection from Application.Workbooks and call its Add function to create a new workbook. The Add function returns a Workbook object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oWBs = oXL.Workbooks
oWB = oWBs.Add()

</pre>
<pre id="codePreview" class="vb">
oWBs = oXL.Workbooks
oWB = oWBs.Add()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Get the active worksheet by calling Workbook.ActiveSheet and set the<span style="">
</span>sheet's Name.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oSheet = oWB.ActiveSheet
oSheet.Name = &quot;Report&quot;

</pre>
<pre id="codePreview" class="vb">
oSheet = oWB.ActiveSheet
oSheet.Name = &quot;Report&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Construct a two-dimensional array containing some first name and last name data and assign it to the Value2 property of a worksheet range. The array's content will appear in the range.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim saNames(,) As String = {{&quot;John&quot;, &quot;Smith&quot;}, _
                            {&quot;Tom&quot;, &quot;Brown&quot;}, _
                            {&quot;Sue&quot;, &quot;Thomas&quot;}, _
                            {&quot;Jane&quot;, &quot;Jones&quot;}, _
                            {&quot;Adam&quot;, &quot;Johnson&quot;}}


oRng1 = oSheet.Range(&quot;A2&quot;, &quot;B6&quot;)
oRng1.Value2 = saNames

</pre>
<pre id="codePreview" class="vb">
Dim saNames(,) As String = {{&quot;John&quot;, &quot;Smith&quot;}, _
                            {&quot;Tom&quot;, &quot;Brown&quot;}, _
                            {&quot;Sue&quot;, &quot;Thomas&quot;}, _
                            {&quot;Jane&quot;, &quot;Jones&quot;}, _
                            {&quot;Adam&quot;, &quot;Johnson&quot;}}


oRng1 = oSheet.Range(&quot;A2&quot;, &quot;B6&quot;)
oRng1.Value2 = saNames

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step7. Use formula to generate Full Name column from first name and last name by setting range's Formula property.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oRng2 = oSheet.Range(&quot;C2&quot;, &quot;C6&quot;)
oRng2.Formula = &quot;=A2 & &quot;&quot; &quot;&quot; & B2&quot;

</pre>
<pre id="codePreview" class="vb">
oRng2 = oSheet.Range(&quot;C2&quot;, &quot;C6&quot;)
oRng2.Formula = &quot;=A2 & &quot;&quot; &quot;&quot; & B2&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step8. Call workbook.SaveAs method to save the workbook as a local file. Then, call workbook.Close to close the workbook and call application.Quit to quit the application.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    oWB.SaveAs(fileName, Excel.XlFileFormat.xlOpenXMLWorkbook)
    oWB.Close()

</pre>
<pre id="codePreview" class="vb">
    oWB.SaveAs(fileName, Excel.XlFileFormat.xlOpenXMLWorkbook)
    oWB.Close()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step9. Clean up the unmanaged COM resource. To get Excel terminated rightly,we need to call Marshal.FinalReleaseComObject() on each COM object we used.<span style="">
</span>We can either explicitly call Marshal.FinalReleaseComObject on all accessor objects:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' See Solution1.AutomateExcel
    If Not oRng2 Is Nothing Then
        Marshal.FinalReleaseComObject(oRng2)
        oRng2 = Nothing
    End If
    If Not oRng1 Is Nothing Then
        Marshal.FinalReleaseComObject(oRng1)
        oRng1 = Nothing
    End If
    If Not oCells Is Nothing Then
        Marshal.FinalReleaseComObject(oCells)
        oCells = Nothing
    End If
    If Not oSheet Is Nothing Then
        Marshal.FinalReleaseComObject(oSheet)
        oSheet = Nothing
    End If
    If Not oWB Is Nothing Then
        Marshal.FinalReleaseComObject(oWB)
        oWB = Nothing
    End If
    If Not oWBs Is Nothing Then
        Marshal.FinalReleaseComObject(oWBs)
        oWBs = Nothing
    End If
    If Not oXL Is Nothing Then
        Marshal.FinalReleaseComObject(oXL)
        oXL = Nothing
    End If

</pre>
<pre id="codePreview" class="vb">
' See Solution1.AutomateExcel
    If Not oRng2 Is Nothing Then
        Marshal.FinalReleaseComObject(oRng2)
        oRng2 = Nothing
    End If
    If Not oRng1 Is Nothing Then
        Marshal.FinalReleaseComObject(oRng1)
        oRng1 = Nothing
    End If
    If Not oCells Is Nothing Then
        Marshal.FinalReleaseComObject(oCells)
        oCells = Nothing
    End If
    If Not oSheet Is Nothing Then
        Marshal.FinalReleaseComObject(oSheet)
        oSheet = Nothing
    End If
    If Not oWB Is Nothing Then
        Marshal.FinalReleaseComObject(oWB)
        oWB = Nothing
    End If
    If Not oWBs Is Nothing Then
        Marshal.FinalReleaseComObject(oWBs)
        oWBs = Nothing
    End If
    If Not oXL Is Nothing Then
        Marshal.FinalReleaseComObject(oXL)
        oXL = Nothing
    End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">and/or force a garbage collection as soon as the calling function is off the stack (at which point these objects are no longer rooted) and then call GC.WaitForPendingFinalizers.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    ' See Solution2.AutomateExcel
    GC.Collect()
    GC.WaitForPendingFinalizers()
    ' GC needs to be called twice in order to get the Finalizers called 
    ' - the first time in, it simply makes a list of what is to be 
    ' finalized, the second time in, it actually is finalizing. Only 
    ' then will the object do its automatic ReleaseComObject.
    GC.Collect()
    GC.WaitForPendingFinalizers()

</pre>
<pre id="codePreview" class="vb">
    ' See Solution2.AutomateExcel
    GC.Collect()
    GC.WaitForPendingFinalizers()
    ' GC needs to be called twice in order to get the Finalizers called 
    ' - the first time in, it simply makes a list of what is to be 
    ' finalized, the second time in, it actually is finalizing. Only 
    ' then will the object do its automatic ReleaseComObject.
    GC.Collect()
    GC.WaitForPendingFinalizers()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><a href="http://msdn.microsoft.com/en-us/library/bb149067.aspx">MSDN: Excel 2007 Developer Reference</a>
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><a href="http://support.microsoft.com/kb/302084">How to automate Microsoft Excel from Microsoft Visual C# .NET</a>
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><a href="http://blogs.msdn.com/geoffda/archive/2007/09/07/the-designer-process-that-would-not-terminate-part-2.aspx">How to terminate Excel process
 after automation</a> </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><a href="http://support.microsoft.com/kb/303296">How To Use Automation to Get and to Set Office Document Properties with Visual C# .NET</a>
</span></h2>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
