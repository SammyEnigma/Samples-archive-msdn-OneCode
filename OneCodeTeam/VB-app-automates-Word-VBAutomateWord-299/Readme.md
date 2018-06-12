# VB app automates Word (VBAutomateWord)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Office
## Topics
* Automation
* Word
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:26:41
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION</span> (<span style="font-family:������">VBAutomateWord</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The VBAutomateWord example demonstrates the use of Visual Basic.NET codes to create a Microsoft Word instance, create a new document, insert a paragraph and a table, save the document, close the Microsoft Word application and then clean
 up unmanaged COM resources.</p>
<p class="MsoNormal">Office automation is based on Component Object Model (COM). When you call a COM object of Office from managed code, a Runtime Callable Wrapper (RCW) is automatically created. The RCW marshals calls between the .NET application and the
 COM object. The RCW keeps a reference count on the COM object. If all references have not been released on the RCW, the COM object of Office
</p>
<p class="MsoNormal">does not quit and may cause the Office application not to quit after your automation. In order to make sure that the Office application quits cleanly, the sample demonstrates two solutions.</p>
<p class="MsoNormal">Solution1.AutomateWord demonstrates automating Microsoft Word application by using Microsoft Word Primary Interop Assembly (PIA) and explicitly assigning each COM accessor object to a new variable that you would explicitly call Marshal.FinalReleaseComObject
 to release it at the end.</p>
<p class="MsoNormal">Solution2.AutomateWord demonstrates automating Microsoft Word application by using Microsoft Word PIA and forcing a garbage collection as soon as the automation function is off the stack (at which point the RCW objects are no longer rooted)
 to clean up RCWs and release COM objects.<span style="">&nbsp; </span></p>
<h2>Running the Sample </h2>
<p class="MsoNormal">The following steps walk through a demonstration of the Word automation sample that starts a Microsoft Word instance, creates a new document, inserts a paragraph and a table, saves the document, and quits the Microsoft Word application
 cleanly.</p>
<p class="MsoNormal">Step1. After you successfully build the sample project in Visual Studio 2008, you will get the application: VBAutomateWord.exe.</p>
<p class="MsoNormal">Step2. Open Windows Task Manager (Ctrl&#43;Shift&#43;Esc) to confirm that no winword.exe is running.
</p>
<p class="MsoNormal">Step3. Run the application. It should print the following content in the console window if no error is thrown.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53043/1/image.png" alt="" width="576" height="376" align="middle">
</span></p>
<p class="MsoNormal">Then, you will see two new documents in the directory of the application:
</p>
<p class="MsoNormal">Sample1.docx and Sample2.docx. Both documents have the following content.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53044/1/image.png" alt="" width="576" height="394" align="middle">
</span></p>
<p class="MsoNormal">Sample2.docx additionally has this table in the document.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53045/1/image.png" alt="" width="576" height="531" align="middle">
</span></p>
<p class="MsoNormal">Step4. In Windows Task Manager, confirm that the winword.exe process does not exist, i.e. the Microsoft Word intance was closed and cleaned up properly.</p>
<h2><span style="">Using the code </span></h2>
<p class="MsoNormal">Step1. Create a Console application and reference the Word Primary Interop Assembly (PIA). To reference the Word PIA, right-click the project file<span style="">
</span>and click the &quot;Add Reference...&quot; button. In the Add Reference dialog, navigate to the .NET tab, find Microsoft.Office.Interop.Word 12.0.0.0 and click OK.</p>
<p class="MsoNormal">Step2. Import and rename the Excel interop namepace:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports Word = Microsoft.Office.Interop.Word

</pre>
<pre id="codePreview" class="vb">
Imports Word = Microsoft.Office.Interop.Word

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Start up a Word application by creating a Word.Application object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oWord = New Word.Application()

</pre>
<pre id="codePreview" class="vb">
oWord = New Word.Application()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Get the Documents collection from Application.Documents and call its Add function to create a new document. The Add function returns a Document object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Create a new Document and add it to document collection.
Dim oDoc As Word.Document = oWord.Documents.Add()
Console.WriteLine(&quot;A new document is created&quot;)

</pre>
<pre id="codePreview" class="vb">
' Create a new Document and add it to document collection.
Dim oDoc As Word.Document = oWord.Documents.Add()
Console.WriteLine(&quot;A new document is created&quot;)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Insert a paragraph.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    oParas = oDoc.Paragraphs
    oPara = oParas.Add()
    oParaRng = oPara.Range
    oParaRng.Text = &quot;Heading 1&quot;
    oFont = oParaRng.Font
    oFont.Bold = 1
    oParaRng.InsertParagraphAfter()

</pre>
<pre id="codePreview" class="vb">
    oParas = oDoc.Paragraphs
    oPara = oParas.Add()
    oParaRng = oPara.Range
    oParaRng.Text = &quot;Heading 1&quot;
    oFont = oParaRng.Font
    oFont.Bold = 1
    oParaRng.InsertParagraphAfter()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Insert a table.</p>
<p class="MsoNormal">The following code has the problem that it invokes accessors which will also create RCWs and reference them. For example, calling Document.Bookmarks.Item creates an RCW for the Bookmarks object. If you invoke these accessors via tunneling
 as this code does, the RCWs are created on the GC heap, but the references are created under the hood on the stack and are then discarded. As such, there is no way to call MarshalFinalReleaseComObject on those RCWs. To get them to release, you would either
 need to force a garbage collection as soon as the calling function is off the stack (at which point these objects are no longer rooted) and then call GC.WaitForPendingFinalizers, or you would need to change the syntax to explicitly assign these accessor objects
 to a variable that you would then explicitly call Marshal.FinalReleaseComObject on.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    oBookmarkRng = oDoc.Bookmarks.Item(&quot;\endofdoc&quot;).Range


    oTable = oDoc.Tables.Add(oBookmarkRng, 5, 2)
    oTable.Range.ParagraphFormat.SpaceAfter = 6


    For r As Integer = 1 To 5
        For c As Integer = 1 To 2
            oTable.Cell(r, c).Range.Text = &quot;r&quot; & r & &quot;c&quot; & c
        Next
    Next


    ' Change width of columns 1 & 2
    oTable.Columns(1).Width = oWord.InchesToPoints(2)
    oTable.Columns(2).Width = oWord.InchesToPoints(3)

</pre>
<pre id="codePreview" class="vb">
    oBookmarkRng = oDoc.Bookmarks.Item(&quot;\endofdoc&quot;).Range


    oTable = oDoc.Tables.Add(oBookmarkRng, 5, 2)
    oTable.Range.ParagraphFormat.SpaceAfter = 6


    For r As Integer = 1 To 5
        For c As Integer = 1 To 2
            oTable.Cell(r, c).Range.Text = &quot;r&quot; & r & &quot;c&quot; & c
        Next
    Next


    ' Change width of columns 1 & 2
    oTable.Columns(1).Width = oWord.InchesToPoints(2)
    oTable.Columns(2).Width = oWord.InchesToPoints(3)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step7. Save the document as a docx file and close it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim fileName As String = Path.GetDirectoryName( _
Assembly.GetExecutingAssembly().Location) & &quot;\Sample1.docx&quot;
oDoc.SaveAs(fileName, Word.WdSaveFormat.wdFormatXMLDocument)
oDoc.Close()

</pre>
<pre id="codePreview" class="vb">
Dim fileName As String = Path.GetDirectoryName( _
Assembly.GetExecutingAssembly().Location) & &quot;\Sample1.docx&quot;
oDoc.SaveAs(fileName, Word.WdSaveFormat.wdFormatXMLDocument)
oDoc.Close()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step8. Quit the Word application.<span style=""> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oWord.Quit(False)

</pre>
<pre id="codePreview" class="vb">
oWord.Quit(False)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step9. Clean up the unmanaged COM resource. To get Word terminated rightly, we need to call Marshal.FinalReleaseComObject() on each COM object we used.We can either explicitly call Marshal.FinalReleaseComObject on all accessor objects:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' See Solution1.AutomateWord
    If Not oFont Is Nothing Then
        Marshal.FinalReleaseComObject(oFont)
        oFont = Nothing
    End If
    If Not oParaRng Is Nothing Then
        Marshal.FinalReleaseComObject(oParaRng)
        oParaRng = Nothing
    End If
    If Not oPara Is Nothing Then
        Marshal.FinalReleaseComObject(oPara)
        oPara = Nothing
    End If
    If Not oParas Is Nothing Then
        Marshal.FinalReleaseComObject(oParas)
        oParas = Nothing
    End If
    If Not oDoc Is Nothing Then
        Marshal.FinalReleaseComObject(oDoc)
        oDoc = Nothing
    End If
    If Not oDocs Is Nothing Then
        Marshal.FinalReleaseComObject(oDocs)
        oDocs = Nothing
    End If
    If Not oWord Is Nothing Then
        Marshal.FinalReleaseComObject(oWord)
        oWord = Nothing
    End If

</pre>
<pre id="codePreview" class="vb">
' See Solution1.AutomateWord
    If Not oFont Is Nothing Then
        Marshal.FinalReleaseComObject(oFont)
        oFont = Nothing
    End If
    If Not oParaRng Is Nothing Then
        Marshal.FinalReleaseComObject(oParaRng)
        oParaRng = Nothing
    End If
    If Not oPara Is Nothing Then
        Marshal.FinalReleaseComObject(oPara)
        oPara = Nothing
    End If
    If Not oParas Is Nothing Then
        Marshal.FinalReleaseComObject(oParas)
        oParas = Nothing
    End If
    If Not oDoc Is Nothing Then
        Marshal.FinalReleaseComObject(oDoc)
        oDoc = Nothing
    End If
    If Not oDocs Is Nothing Then
        Marshal.FinalReleaseComObject(oDocs)
        oDocs = Nothing
    End If
    If Not oWord Is Nothing Then
        Marshal.FinalReleaseComObject(oWord)
        oWord = Nothing
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
    ' See Solution2.AutomateWord
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
    ' See Solution2.AutomateWord
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
<h2>More Information</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/bb244391.aspx">MSDN: Word 2007 Developer Reference</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:������"><a href="http://support.microsoft.com/kb/316383/">How to automate Word from Visual Basic .NET to create a new document</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
