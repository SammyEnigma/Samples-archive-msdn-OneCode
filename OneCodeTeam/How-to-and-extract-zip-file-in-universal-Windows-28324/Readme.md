# How to download and extract zip file in universal Windows apps
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows Phone
* Windows 8
* Windows Phone 8
* Windows Store app Development
* Windows Phone Development
* Windows 8.1
* Windows Phone 8.1
## Topics
* extract zip
* universal app
* download file
## IsPublished
* True
## ModifiedDate
* 2014-12-11 07:15:57
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to download and extract zip file</span><span style="font-weight:bold; font-size:14pt">s</span><span style="font-weight:bold; font-size:14pt"> in universal Windows
 &nbsp;app</span><span style="font-weight:bold; font-size:14pt">s</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This code sample will show how to download and extract zip file</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> in universal Windows app</span><span style="font-size:11pt">s</span><span style="font-size:11pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Just build the sample in Visual Studio 2013.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The following is the screenshot of the running sample.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113442/1/image.png" alt="" width="479" height="295" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Please note that </span>
<span>requests can</span><span style="font-size:11pt"> </span><span style="font-size:11pt">o</span><span>nly</span><span> resume</span><span> when
</span><span style="font-size:11pt">the server accepts range-requests</span><span>. Otherwise the download
</span><span>will</span><span> restart. (</span><a href="http://msdn.microsoft.com/en-US/library/windows/apps/windows.networking.backgroundtransfer.downloadoperation.resume.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-US/library/windows/apps/windows.networking.backgroundtransfer.downloadoperation.resume.aspx</span></a><span>)
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We use Background Transfer API to download the zip file. For the download part, please refer to the
</span><a href="http://code.msdn.microsoft.com/windowsapps/Background-Transfer-Sample-d7833f61" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">Background Transfer Sample</span></a><span style="font-size:11pt"> for more
</span><span>details</span><span style="font-size:11pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">However, to support the unzip function, we need</span><span style="font-size:11pt"> add
</span><span style="font-size:11pt">some additional code logic.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Once the zip file has been downloaded successfully, we need to rename it to its original name and create a destination folder. And then, we pass the zip file and the destination folder to UnZipFileAsync
 function which will call </span><span style="font-size:11pt">ZipHelper.</span><span>UnZipFileA</span><span>s</span><span>ync function
</span><span style="font-size:11pt">hosting in a Windows Runtime Component to extract the zip file.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span><span class="hidden">js</span>
<pre class="hidden">private async void StartDownload(BackgroundTransferPriority priority, bool requestUnconstrainedDownload)
{
    // The URI is validated by calling Uri.TryCreate() that will return 'false' for strings that are not valid URIs.
    // Note that when enabling the text box users may provide URIs to machines on the intrAnet that require
    // the &quot;Home or Work Networking&quot; capability.
    Uri source;
    if (!Uri.TryCreate(this.ZipFileUrlTextBox.Text.Trim(), UriKind.Absolute, out source))
    {
        NotifyUser(&quot;Invalid URI.&quot;, NotifyType.ErrorMessage);
        return;
    }
    FolderPicker folderPicker = new FolderPicker();
    folderPicker.SuggestedStartLocation = PickerLocationId.Downloads;
    folderPicker.FileTypeFilter.Add(&quot;.zip&quot;);
    StorageFolder destinationFolder = await folderPicker.PickSingleFolderAsync();
    if (destinationFolder != null)
    {
        // Application now has read/write access to all contents in the picked folder 
        // (including other sub-folder contents)
        StorageApplicationPermissions.FutureAccessList.AddOrReplace(&quot;PickedFolderToken&quot;, destinationFolder);
        Log(&quot;Picked folder: &quot; &#43; destinationFolder.Name);
    }
    else
    {
        Log(&quot;Operation cancelled.&quot;);
        return;
    }
    try
    {
        StorageFile localFile = await destinationFolder.CreateFileAsync(FileNameField.Text.Trim(), CreationCollisionOption.GenerateUniqueName);
        BackgroundDownloader downloader = new BackgroundDownloader();
        DownloadOperation download = downloader.CreateDownload(source, localFile);
        Log(String.Format(CultureInfo.CurrentCulture, &quot;Downloading {0} to {1} with {2} priority, {3}&quot;,
            source.AbsoluteUri, destinationFolder.Name, priority, download.Guid));
        download.Priority = priority;
        // In this sample, we do not show how to request unconstrained download.
        // For more information about background transfer, please refer to the SDK Background transfer sample:
        // http://code.msdn.microsoft.com/windowsapps/Background-Transfer-Sample-d7833f61
        if (!requestUnconstrainedDownload)
        {
            // Attach progress and completion handlers.
            await HandleDownloadAsync(download, true);
            StorageFolder unzipFolder =
                await destinationFolder.CreateFolderAsync(Path.GetFileNameWithoutExtension(localFile.Name), 
                CreationCollisionOption.GenerateUniqueName);
            await UnZipFileAsync(localFile, unzipFolder);
            return;
        }
    }
    catch(Exception ex)
    {
        LogStatus(ex.Message, NotifyType.ErrorMessage);
    }
}
</pre>
<pre class="hidden">void MainPage::StartDownload(BackgroundTransferPriority priority, boolean requestUnconstrainedDownload)
{
 // The URI is validated by calling TryGetUri() that will return 'false' for strings that are not valid URIs.
 // Note that when enabling the text box users may provide URIs to machines on the intrAnet that require the
 // &quot;Home or Work Networking&quot; capability.
 Uri^ source;
 if (!TryGetUri(ZipFileUrlTextBox-&gt;Text, &amp;source))
 {
  return;
 }
 FolderPicker^ folderPicker = ref new FolderPicker();
 folderPicker-&gt;SuggestedStartLocation = PickerLocationId::Downloads;
 folderPicker-&gt;FileTypeFilter-&gt;Append(&quot;.zip&quot;);
 create_task(folderPicker-&gt;PickSingleFolderAsync()).then([=](StorageFolder^ destinationFolder)
 {
 
  if (destinationFolder != nullptr)
  {
   pickedFolderPath = destinationFolder-&gt;Path;
   AccessCache::StorageApplicationPermissions::FutureAccessList-&gt;AddOrReplace(&quot;PickedFolderToken&quot;, destinationFolder);
   Log(&quot;Picked folder: &quot; &#43; destinationFolder-&gt;Name);
   create_task(destinationFolder-&gt;CreateFileAsync(FileNameField-&gt;Text, CreationCollisionOption::GenerateUniqueName))
    .then([=](StorageFile^ localFile)
   {
    localFileName = localFile-&gt;Name;
    BackgroundDownloader^ downloader = ref new BackgroundDownloader();
    DownloadOperation^ download = downloader-&gt;CreateDownload(source, localFile);
    Log(&quot;Downloading &quot; &#43; source-&gt;AbsoluteUri &#43; &quot; to &quot; &#43; localFile-&gt;Name &#43; &quot; with &quot; &#43;
     ((priority == BackgroundTransferPriority::Default) ? &quot;default&quot; : &quot;high&quot;) &#43;
     &quot; priority, &quot; &#43; download-&gt;Guid);
    download-&gt;Priority = priority;
    if (!requestUnconstrainedDownload)
    {
     // Attach progress and completion handlers.
     HandleDownloadAsync(download, true);
    }
   }).then([this](task&lt;void&gt; previousTask)
   {
    try
    {
     previousTask.get();
    }
    catch (Exception^ ex)
    {
     LogException(&quot;Error&quot;, ex);
    }
   });
  }
  else
  {
   Log(&quot;Operation cancelled&quot;);
   return;
  }
 }).then([this](task&lt;void&gt; previousTask)
 {
  try
  {
   previousTask.get();
  }
  catch (Exception^ ex)
  {
   LogException(&quot;Error&quot;, ex);
  }
 });
}
</pre>
<pre class="hidden">// download Zip File
function downloadZipFile(priority, requestUnconstrainedTransfer) {
// Instantiate downloads.
var newDownload = new DownloadOperation();
// The URI is validated by calling Uri.TryCreate() that will return 'false' for strings that are not valid URIs.
// Note that when enabling the text box users may provide URIs to machines on the intrAnet that require
// the &quot;Home or Work Networking&quot; capability.
try {
uri = new Windows.Foundation.Uri(document.getElementById(&quot;zipAddressUrl&quot;).value);
} catch (error) {
displayError(&quot;Error: Invalid URI. &quot; &#43; error.message);
return;
}
var openPicker = new Windows.Storage.Pickers.FolderPicker();
openPicker.suggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.desktop;
openPicker.fileTypeFilter.replaceAll([&quot;.zip&quot;]);
// Open the picker for the user to pick a file
openPicker.pickSingleFolderAsync().then(function (destinationFolder) {
if (destinationFolder) {
// Application now has read/write access to all contents in the picked folder 
// (including other sub-folder contents)
Windows.Storage.AccessCache.StorageApplicationPermissions.futureAccessList.addOrReplace(&quot;PickedFolderToken&quot;, destinationFolder);
Log(&quot;Picked folder: &quot; &#43; destinationFolder.name);
} else {
// The picker was dismissed with no selected file
Log(&quot;Operation cancelled.&quot;);
return;
}
var tmpFileName = Windows.Storage.CreationCollisionOption.generateUniqueName.toString() &#43; &quot;.tmp&quot;;
newDownload.start(uri, destinationFolder, tmpFileName, priority, requestUnconstrainedTransfer);
downloadOperations.push(newDownload);
});
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;StartDownload(BackgroundTransferPriority&nbsp;priority,&nbsp;<span class="cs__keyword">bool</span>&nbsp;requestUnconstrainedDownload)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;The&nbsp;URI&nbsp;is&nbsp;validated&nbsp;by&nbsp;calling&nbsp;Uri.TryCreate()&nbsp;that&nbsp;will&nbsp;return&nbsp;'false'&nbsp;for&nbsp;strings&nbsp;that&nbsp;are&nbsp;not&nbsp;valid&nbsp;URIs.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Note&nbsp;that&nbsp;when&nbsp;enabling&nbsp;the&nbsp;text&nbsp;box&nbsp;users&nbsp;may&nbsp;provide&nbsp;URIs&nbsp;to&nbsp;machines&nbsp;on&nbsp;the&nbsp;intrAnet&nbsp;that&nbsp;require</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;the&nbsp;&quot;Home&nbsp;or&nbsp;Work&nbsp;Networking&quot;&nbsp;capability.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;source;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!Uri.TryCreate(<span class="cs__keyword">this</span>.ZipFileUrlTextBox.Text.Trim(),&nbsp;UriKind.Absolute,&nbsp;<span class="cs__keyword">out</span>&nbsp;source))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NotifyUser(<span class="cs__string">&quot;Invalid&nbsp;URI.&quot;</span>,&nbsp;NotifyType.ErrorMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FolderPicker&nbsp;folderPicker&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FolderPicker();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;folderPicker.SuggestedStartLocation&nbsp;=&nbsp;PickerLocationId.Downloads;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;folderPicker.FileTypeFilter.Add(<span class="cs__string">&quot;.zip&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StorageFolder&nbsp;destinationFolder&nbsp;=&nbsp;await&nbsp;folderPicker.PickSingleFolderAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(destinationFolder&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Application&nbsp;now&nbsp;has&nbsp;read/write&nbsp;access&nbsp;to&nbsp;all&nbsp;contents&nbsp;in&nbsp;the&nbsp;picked&nbsp;folder&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;(including&nbsp;other&nbsp;sub-folder&nbsp;contents)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StorageApplicationPermissions.FutureAccessList.AddOrReplace(<span class="cs__string">&quot;PickedFolderToken&quot;</span>,&nbsp;destinationFolder);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Log(<span class="cs__string">&quot;Picked&nbsp;folder:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;destinationFolder.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Log(<span class="cs__string">&quot;Operation&nbsp;cancelled.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StorageFile&nbsp;localFile&nbsp;=&nbsp;await&nbsp;destinationFolder.CreateFileAsync(FileNameField.Text.Trim(),&nbsp;CreationCollisionOption.GenerateUniqueName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundDownloader&nbsp;downloader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BackgroundDownloader();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DownloadOperation&nbsp;download&nbsp;=&nbsp;downloader.CreateDownload(source,&nbsp;localFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Log(String.Format(CultureInfo.CurrentCulture,&nbsp;<span class="cs__string">&quot;Downloading&nbsp;{0}&nbsp;to&nbsp;{1}&nbsp;with&nbsp;{2}&nbsp;priority,&nbsp;{3}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;source.AbsoluteUri,&nbsp;destinationFolder.Name,&nbsp;priority,&nbsp;download.Guid));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;download.Priority&nbsp;=&nbsp;priority;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;In&nbsp;this&nbsp;sample,&nbsp;we&nbsp;do&nbsp;not&nbsp;show&nbsp;how&nbsp;to&nbsp;request&nbsp;unconstrained&nbsp;download.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;For&nbsp;more&nbsp;information&nbsp;about&nbsp;background&nbsp;transfer,&nbsp;please&nbsp;refer&nbsp;to&nbsp;the&nbsp;SDK&nbsp;Background&nbsp;transfer&nbsp;sample:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;http://code.msdn.microsoft.com/windowsapps/Background-Transfer-Sample-d7833f61</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!requestUnconstrainedDownload)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Attach&nbsp;progress&nbsp;and&nbsp;completion&nbsp;handlers.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;HandleDownloadAsync(download,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StorageFolder&nbsp;unzipFolder&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;destinationFolder.CreateFolderAsync(Path.GetFileNameWithoutExtension(localFile.Name),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreationCollisionOption.GenerateUniqueName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;UnZipFileAsync(localFile,&nbsp;unzipFolder);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LogStatus(ex.Message,&nbsp;NotifyType.ErrorMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>The UnZipFileAsync function unzips the specified zip file to a folder.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span><span class="hidden">js</span>
<pre class="hidden">/// &lt;summary&gt;
/// Unzip the specified zipfile to a folder.
/// &lt;/summary&gt;
/// &lt;param name=&quot;zipFile&quot;&gt;The zip file&lt;/param&gt;
/// &lt;param name=&quot;unzipFolder&quot;&gt;The destination folder&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private async Task UnZipFileAsync(StorageFile zipFile, StorageFolder unzipFolder)
{
    try
    {
        LogStatus(&quot;Unziping file: &quot; &#43; zipFile.DisplayName &#43; &quot;...&quot;, NotifyType.StatusMessage);
        await ZipHelper.UnZipFileAync(zipFile, unzipFolder);
        LogStatus(&quot;Unzip file '&quot; &#43; zipFile.DisplayName &#43; &quot;' successfully!&quot;, NotifyType.StatusMessage);
    }
    catch (Exception ex)
    {
        LogStatus(&quot;Failed to unzip file ...&quot; &#43; ex.Message, NotifyType.ErrorMessage);
    }
}
</pre>
<pre class="hidden">void MainPage::UnZipFileAsync(Windows::Storage::StorageFile^ zipFile, Windows::Storage::StorageFolder^ unzipFolder)
{
 try
 {
  LogStatus(&quot;Unziping file: &quot; &#43; zipFile-&gt;DisplayName &#43; &quot;...&quot;, NotifyType::StatusMessage);
  create_task(ZipHelper::UnZipFileAsync(zipFile, unzipFolder)).then([this,zipFile]()
  {
   LogStatus(&quot;Unzip file '&quot; &#43; zipFile-&gt;DisplayName &#43; &quot;' successfully!&quot;, NotifyType::StatusMessage);
  });
  
 }
 catch (Exception^ ex)
 {
  LogStatus(&quot;Failed to unzip file ...&quot; &#43; ex-&gt;Message, NotifyType::ErrorMessage);
 }
}
</pre>
<pre class="hidden">// Unzips the specified zipfile to a folder.
function upZipFile(zipFile, unzipFolder)
{
try{
LogStatus(&quot;Upziping file: &quot; &#43; zipFile.displayName &#43; &quot;...&quot;, NotifyType.StatusMessage);
ZipHelperWinRT.ZipHelper.unZipFileAsync(zipFile, unzipFolder).done(function (){
LogStatus(&quot;Unzip file '&quot; &#43; zipFile.displayName &#43; &quot;' successfully&quot;, NotifyType.StatusMessage);
}); 
}
catch (err) {
LogStatus(&quot;Failed to unzip file ...&quot; &#43; err.message, NotifyType.ErrorMessage);
}
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Unzip&nbsp;the&nbsp;specified&nbsp;zipfile&nbsp;to&nbsp;a&nbsp;folder.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;zipFile&quot;&gt;The&nbsp;zip&nbsp;file&lt;/param&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;unzipFolder&quot;&gt;The&nbsp;destination&nbsp;folder&lt;/param&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;async&nbsp;Task&nbsp;UnZipFileAsync(StorageFile&nbsp;zipFile,&nbsp;StorageFolder&nbsp;unzipFolder)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LogStatus(<span class="cs__string">&quot;Unziping&nbsp;file:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;zipFile.DisplayName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;...&quot;</span>,&nbsp;NotifyType.StatusMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;ZipHelper.UnZipFileAync(zipFile,&nbsp;unzipFolder);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LogStatus(<span class="cs__string">&quot;Unzip&nbsp;file&nbsp;'&quot;</span>&nbsp;&#43;&nbsp;zipFile.DisplayName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;'&nbsp;successfully!&quot;</span>,&nbsp;NotifyType.StatusMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LogStatus(<span class="cs__string">&quot;Failed&nbsp;to&nbsp;unzip&nbsp;file&nbsp;...&quot;</span>&nbsp;&#43;&nbsp;ex.Message,&nbsp;NotifyType.ErrorMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We wrap the unzip function in a Windows Runtime Component, so it can also be consumed by C&#43;&#43;/JS client apps.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">In this sample, we use ZipArchive to unzip the zip file.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The only public function in this component is UnzipFileAsync.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Unzips the specified zip file to the specified destination folder.
/// &lt;/summary&gt;
/// &lt;param name=&quot;zipFile&quot;&gt;The zip file&lt;/param&gt;
/// &lt;param name=&quot;destinationFolder&quot;&gt;The destination folder&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
public static IAsyncAction UnZipFileAync(StorageFile zipFile, StorageFolder destinationFolder)
{
    return UnZipFileHelper(zipFile, destinationFolder).AsAsyncAction();
}
</pre>
<pre id="codePreview" class="csharp">/// &lt;summary&gt;
/// Unzips the specified zip file to the specified destination folder.
/// &lt;/summary&gt;
/// &lt;param name=&quot;zipFile&quot;&gt;The zip file&lt;/param&gt;
/// &lt;param name=&quot;destinationFolder&quot;&gt;The destination folder&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
public static IAsyncAction UnZipFileAync(StorageFile zipFile, StorageFolder destinationFolder)
{
    return UnZipFileHelper(zipFile, destinationFolder).AsAsyncAction();
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The following is the private helper function</span><span style="font-size:11pt">s</span><span style="font-size:11pt">.</span><span>
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">#region private helper functions
private static async Task UnZipFileHelper(StorageFile zipFile, StorageFolder destinationFolder)
{
    if (zipFile == null || destinationFolder == null ||
        !Path.GetExtension(zipFile.DisplayName).Equals(&quot;.zip&quot;, StringComparison.CurrentCultureIgnoreCase)
        )
    {
        throw new ArgumentException(&quot;Invalid argument...&quot;);
    }
    Stream zipMemoryStream = await zipFile.OpenStreamForReadAsync();
    // Create zip archive to access compressed files in memory stream
    using (ZipArchive zipArchive = new ZipArchive(zipMemoryStream, ZipArchiveMode.Read))
    {
        // Unzip compressed file iteratively.
        foreach (ZipArchiveEntry entry in zipArchive.Entries)
        {
            await UnzipZipArchiveEntryAsync(entry, entry.FullName, destinationFolder);
        }
    }
}
/// &lt;summary&gt;
/// It checks if the specified path contains directory.
/// &lt;/summary&gt;
/// &lt;param name=&quot;entryPath&quot;&gt;The specified path&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private static bool IfPathContainDirectory(string entryPath)
{
    if (string.IsNullOrEmpty(entryPath))
    {
        return false;
    }
    return entryPath.Contains(&quot;/&quot;);
}
/// &lt;summary&gt;
/// It checks if the specified folder exists.
/// &lt;/summary&gt;
/// &lt;param name=&quot;storageFolder&quot;&gt;The container folder&lt;/param&gt;
/// &lt;param name=&quot;subFolderName&quot;&gt;The sub folder name&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private static async Task&lt;bool&gt; IfFolderExistsAsync(StorageFolder storageFolder, string subFolderName)
{
    try
    {
        await storageFolder.GetFolderAsync(subFolderName);
    }
    catch (FileNotFoundException)
    {
        return false;
    }
    catch(Exception)
    {
        throw;
    }
    return true;
}
/// &lt;summary&gt;
/// Unzips ZipArchiveEntry asynchronously.
/// &lt;/summary&gt;
/// &lt;param name=&quot;entry&quot;&gt;The entry which needs to be unzipped&lt;/param&gt;
/// &lt;param name=&quot;filePath&quot;&gt;The entry's full name&lt;/param&gt;
/// &lt;param name=&quot;unzipFolder&quot;&gt;The unzip folder&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private static async Task UnzipZipArchiveEntryAsync(ZipArchiveEntry entry, string filePath, StorageFolder unzipFolder)
{
    if (IfPathContainDirectory(filePath))
    {
        // Create sub folder
        string subFolderName = Path.GetDirectoryName(filePath);
        bool isSubFolderExist = await IfFolderExistsAsync(unzipFolder, subFolderName);
        StorageFolder subFolder;
        if (!isSubFolderExist)
        {
            // Create the sub folder.
            subFolder =
                await unzipFolder.CreateFolderAsync(subFolderName, CreationCollisionOption.ReplaceExisting);
        }
        else
        {
            // Just get the folder.
            subFolder =
                await unzipFolder.GetFolderAsync(subFolderName);
        }
        // All sub folders have been created. Just pass the file name to the Unzip function.
        string newFilePath = Path.GetFileName(filePath);
        if (!string.IsNullOrEmpty(newFilePath))
        {
            // Unzip file iteratively.
            await UnzipZipArchiveEntryAsync(entry, newFilePath, subFolder);
        }
    }
    else
    {
        // Read uncompressed contents
        using (Stream entryStream = entry.Open())
        {
            byte[] buffer = new byte[entry.Length];
            entryStream.Read(buffer, 0, buffer.Length);
            // Create a file to store the contents
            StorageFile uncompressedFile = await unzipFolder.CreateFileAsync
            (entry.Name, CreationCollisionOption.ReplaceExisting);
            // Store the contents
            using (IRandomAccessStream uncompressedFileStream =
            await uncompressedFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (Stream outstream = uncompressedFileStream.AsStreamForWrite())
                {
                    outstream.Write(buffer, 0, buffer.Length);
                    outstream.Flush();
                }
            }
        }
    }
}
#endregion
</pre>
<pre id="codePreview" class="csharp">#region private helper functions
private static async Task UnZipFileHelper(StorageFile zipFile, StorageFolder destinationFolder)
{
    if (zipFile == null || destinationFolder == null ||
        !Path.GetExtension(zipFile.DisplayName).Equals(&quot;.zip&quot;, StringComparison.CurrentCultureIgnoreCase)
        )
    {
        throw new ArgumentException(&quot;Invalid argument...&quot;);
    }
    Stream zipMemoryStream = await zipFile.OpenStreamForReadAsync();
    // Create zip archive to access compressed files in memory stream
    using (ZipArchive zipArchive = new ZipArchive(zipMemoryStream, ZipArchiveMode.Read))
    {
        // Unzip compressed file iteratively.
        foreach (ZipArchiveEntry entry in zipArchive.Entries)
        {
            await UnzipZipArchiveEntryAsync(entry, entry.FullName, destinationFolder);
        }
    }
}
/// &lt;summary&gt;
/// It checks if the specified path contains directory.
/// &lt;/summary&gt;
/// &lt;param name=&quot;entryPath&quot;&gt;The specified path&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private static bool IfPathContainDirectory(string entryPath)
{
    if (string.IsNullOrEmpty(entryPath))
    {
        return false;
    }
    return entryPath.Contains(&quot;/&quot;);
}
/// &lt;summary&gt;
/// It checks if the specified folder exists.
/// &lt;/summary&gt;
/// &lt;param name=&quot;storageFolder&quot;&gt;The container folder&lt;/param&gt;
/// &lt;param name=&quot;subFolderName&quot;&gt;The sub folder name&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private static async Task&lt;bool&gt; IfFolderExistsAsync(StorageFolder storageFolder, string subFolderName)
{
    try
    {
        await storageFolder.GetFolderAsync(subFolderName);
    }
    catch (FileNotFoundException)
    {
        return false;
    }
    catch(Exception)
    {
        throw;
    }
    return true;
}
/// &lt;summary&gt;
/// Unzips ZipArchiveEntry asynchronously.
/// &lt;/summary&gt;
/// &lt;param name=&quot;entry&quot;&gt;The entry which needs to be unzipped&lt;/param&gt;
/// &lt;param name=&quot;filePath&quot;&gt;The entry's full name&lt;/param&gt;
/// &lt;param name=&quot;unzipFolder&quot;&gt;The unzip folder&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private static async Task UnzipZipArchiveEntryAsync(ZipArchiveEntry entry, string filePath, StorageFolder unzipFolder)
{
    if (IfPathContainDirectory(filePath))
    {
        // Create sub folder
        string subFolderName = Path.GetDirectoryName(filePath);
        bool isSubFolderExist = await IfFolderExistsAsync(unzipFolder, subFolderName);
        StorageFolder subFolder;
        if (!isSubFolderExist)
        {
            // Create the sub folder.
            subFolder =
                await unzipFolder.CreateFolderAsync(subFolderName, CreationCollisionOption.ReplaceExisting);
        }
        else
        {
            // Just get the folder.
            subFolder =
                await unzipFolder.GetFolderAsync(subFolderName);
        }
        // All sub folders have been created. Just pass the file name to the Unzip function.
        string newFilePath = Path.GetFileName(filePath);
        if (!string.IsNullOrEmpty(newFilePath))
        {
            // Unzip file iteratively.
            await UnzipZipArchiveEntryAsync(entry, newFilePath, subFolder);
        }
    }
    else
    {
        // Read uncompressed contents
        using (Stream entryStream = entry.Open())
        {
            byte[] buffer = new byte[entry.Length];
            entryStream.Read(buffer, 0, buffer.Length);
            // Create a file to store the contents
            StorageFile uncompressedFile = await unzipFolder.CreateFileAsync
            (entry.Name, CreationCollisionOption.ReplaceExisting);
            // Store the contents
            using (IRandomAccessStream uncompressedFileStream =
            await uncompressedFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (Stream outstream = uncompressedFileStream.AsStreamForWrite())
                {
                    outstream.Write(buffer, 0, buffer.Length);
                    outstream.Flush();
                }
            }
        }
    }
}
#endregion
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <a href="http://code.msdn.microsoft.com/windowsapps/Background-Transfer-Sample-d7833f61" style="text-decoration:none">
<span style="color:#0563c1; text-decoration:underline">Background Transfer Sample</span></a></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <a href="http://msdn.microsoft.com/en-us/library/system.io.compression.ziparchive(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1" style="text-decoration:none">
<span style="color:#0563c1; text-decoration:underline">ZipArchive Class</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
