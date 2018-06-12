# How to implement retry logic while working with Azure AppFabric Caching
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* AppFabric
* Cache
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:18:51
## Description

<h1>Retry Azure Cache Operations (VBAzureRetryCache)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:black">When using cloud based services, it is very common to receive exceptions similar to below while performing cache operations such as get, put. These are called transient errors.<span style="">&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:black">Developer is required to implement retry logic to successfully complete their cache operations.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:black"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<i><span style="color:black">ErrorCode&lt;ERRCA0017&gt;:SubStatus&lt;ES0006&gt;:There is a temporary failure. Please retry later. (One or more specified cache servers are unavailable, which could be caused by busy network or servers. For on-premises cache clusters,
 also verify the following conditions. Ensure that security permission has been granted for this client account, and check that the AppFabric Caching Service is allowed through the firewall on all cache hosts. Also the MaxBufferSize on the server must be greater
 than or equal to the serialized object size sent from the client.) </span></i></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:black"><span style="">&nbsp;</span> </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:black">This sample implements retry logic to protect the application from crashing in the event of transient errors. This sample uses Transient Fault Handling Application Block to implement retry mechanism
</span></p>
<h2>Building the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style=""><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Ensure the newest Windows Azure SDK is installed on the machine.
<a href="http://www.windowsazure.com/en-us/develop/downloads/">Download Link</a></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style=""><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Modify the highlighted cachenamespace, autherizataionInfo attributes under DataCacheClient section of web.config and provide values of your own cache namespace and Authentication Token. Steps to obtain the value of authentication token,
 cache namespace value can be found <a href="http://msdn.microsoft.com/en-us/library/windowsazure/gg278346.aspx">
here</a></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;dataCacheClients&gt;


  &lt;dataCacheClient name=&quot;default&quot;&gt;
    &lt;hosts&gt;
      &lt;host name=&quot;skyappcache.cache.windows.net&quot; cachePort=&quot;22233&quot; /&gt;
    &lt;/hosts&gt;


    &lt;securityProperties mode=&quot;Message&quot;&gt;
      &lt;messageSecurity
        authorizationInfo=&quot;YWNzOmh0dHBzOi8vbXZwY2FjaGUtY2FjaGUuYWNjZXNzY29udHJvbC53aW5kb3dzLm5ldC9XUkFQdjAuOS8mb3duZXImOWRINnZQeWhhaFMrYXp1VnF0Y1RDY1NGNzgxdGpheEpNdzg0d1ZXN2FhWT0maHR0cDovL212cGNhY2hlLmNhY2hlLndpbmRvd3MubmV0&quot;&gt;
      &lt;/messageSecurity&gt;
    &lt;/securityProperties&gt;
  &lt;/dataCacheClient&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;dataCacheClients&gt;


  &lt;dataCacheClient name=&quot;default&quot;&gt;
    &lt;hosts&gt;
      &lt;host name=&quot;skyappcache.cache.windows.net&quot; cachePort=&quot;22233&quot; /&gt;
    &lt;/hosts&gt;


    &lt;securityProperties mode=&quot;Message&quot;&gt;
      &lt;messageSecurity
        authorizationInfo=&quot;YWNzOmh0dHBzOi8vbXZwY2FjaGUtY2FjaGUuYWNjZXNzY29udHJvbC53aW5kb3dzLm5ldC9XUkFQdjAuOS8mb3duZXImOWRINnZQeWhhaFMrYXp1VnF0Y1RDY1NGNzgxdGpheEpNdzg0d1ZXN2FhWT0maHR0cDovL212cGNhY2hlLmNhY2hlLndpbmRvd3MubmV0&quot;&gt;
      &lt;/messageSecurity&gt;
    &lt;/securityProperties&gt;
  &lt;/dataCacheClient&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol; color:black"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="color:black">Open the Project in VS 2010 and run it in debug or release mode
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol; color:black"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="color:black">Click on &quot;Add To Cache&quot; button to add a string object to Azure cache. Up on successful operation, &quot;</span><span style="color:black">String object added to cache!</span><span style="color:black">&quot;
 message will be printed on the webpage</span><span style="color:black"> </span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol; color:black"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="color:black">Click on &quot;Read From Cache&quot; button to read the string object from Azure Cache. Up on successful operation, value of the string object stored in Azure cache will be printed on the webpage. By default it
 will be &quot;</span><span style="color:black">My Cache</span><span style="color:black">&quot; (if no changes are made to code)</span><span style="color:black">
</span></p>
<h2>Using the Code</h2>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Define required objects globally, so that they are available for all code paths with in the module.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Define DataCache object
Dim cache As DataCache


' Global variable for retry strategy
Dim retryStrategy As FixedInterval


' Global variable for retry policy
Dim retryPolicy As RetryPolicy

</pre>
<pre id="codePreview" class="vb">
' Define DataCache object
Dim cache As DataCache


' Global variable for retry strategy
Dim retryStrategy As FixedInterval


' Global variable for retry policy
Dim retryPolicy As RetryPolicy

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">This method configures strategies, policies, actions required for performing retries.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' This method configures strategies, policies, actions required for performing retries.
''' &lt;/summary&gt; 
Protected Sub SetupRetryPolicy()
    ' Define your retry strategy: in this sample, I'm retrying operation 3 times with 1 second interval
    retryStrategy = New FixedInterval(3, TimeSpan.FromSeconds(1))


    ' Define your retry policy here. This sample uses CacheTransientErrorDetectionStrategy 
    retryPolicy = New RetryPolicy(Of CacheTransientErrorDetectionStrategy)(retryStrategy)


    ' Get notifications from retries from  Transient Fault Handling Application Block code
    AddHandler retryPolicy.Retrying, AddressOf NewFunction
End Sub


Sub NewFunction(sender1, args)
    ' Log details of the retry.
    Dim msg = [String].Format(&quot;Retry - Count:{0}, Delay:{1}, Exception:{2}&quot;, args.CurrentRetryCount, args.Delay, args.LastException)


    ' Logging the notification details to the application trace. 
    Trace.Write(msg)


End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' This method configures strategies, policies, actions required for performing retries.
''' &lt;/summary&gt; 
Protected Sub SetupRetryPolicy()
    ' Define your retry strategy: in this sample, I'm retrying operation 3 times with 1 second interval
    retryStrategy = New FixedInterval(3, TimeSpan.FromSeconds(1))


    ' Define your retry policy here. This sample uses CacheTransientErrorDetectionStrategy 
    retryPolicy = New RetryPolicy(Of CacheTransientErrorDetectionStrategy)(retryStrategy)


    ' Get notifications from retries from  Transient Fault Handling Application Block code
    AddHandler retryPolicy.Retrying, AddressOf NewFunction
End Sub


Sub NewFunction(sender1, args)
    ' Log details of the retry.
    Dim msg = [String].Format(&quot;Retry - Count:{0}, Delay:{1}, Exception:{2}&quot;, args.CurrentRetryCount, args.Delay, args.LastException)


    ' Logging the notification details to the application trace. 
    Trace.Write(msg)


End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create the Cache Object using the DataCacheClient configuration specified in web.config and perform initial setup required for Azure cache retries
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ' Configure retry policies, strategies, actions
    SetupRetryPolicy()


    ' Create cache object using the cache settings specified web.config 
    cache = CacheUtil.GetCacheConfig()
End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ' Configure retry policies, strategies, actions
    SetupRetryPolicy()


    ' Create cache object using the cache settings specified web.config 
    cache = CacheUtil.GetCacheConfig()
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub btnAddToCache_Click(sender As Object, e As EventArgs)
    Try
        ' In order to use the retry policies, strategies defined in Transient Fault Handling
        ' Application Block , user calls to cache must be wrapped with in ExecuteAction delegate
        retryPolicy.ExecuteAction(Sub()
                                      ' I'm just storing simple string object here .. Assuming this call fails, 
                                      ' this sample retries the same call 3 times with 1 second interval before it gives up.
                                      cache.Put(&quot;MyDataSet&quot;, &quot;My Cache&quot;)
                                      Response.Write(&quot;String object added to cache!&quot;)




                                  End Sub)
    Catch dc As DataCacheException
        ' Exception occurred after implementing the Retry logic.
        ' Ideally you should log the exception to your application logs and show user friendly 
        ' error message on the webpage.
        Trace.Write(dc.[GetType]().ToString() &#43; dc.Message.ToString() &#43; dc.StackTrace.ToString())
    End Try
End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub btnAddToCache_Click(sender As Object, e As EventArgs)
    Try
        ' In order to use the retry policies, strategies defined in Transient Fault Handling
        ' Application Block , user calls to cache must be wrapped with in ExecuteAction delegate
        retryPolicy.ExecuteAction(Sub()
                                      ' I'm just storing simple string object here .. Assuming this call fails, 
                                      ' this sample retries the same call 3 times with 1 second interval before it gives up.
                                      cache.Put(&quot;MyDataSet&quot;, &quot;My Cache&quot;)
                                      Response.Write(&quot;String object added to cache!&quot;)




                                  End Sub)
    Catch dc As DataCacheException
        ' Exception occurred after implementing the Retry logic.
        ' Ideally you should log the exception to your application logs and show user friendly 
        ' error message on the webpage.
        Trace.Write(dc.[GetType]().ToString() &#43; dc.Message.ToString() &#43; dc.StackTrace.ToString())
    End Try
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Read the value of string object stored in Azure Cache on a button click event and perform retries in case of transient failures</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub btnReadFromCache_Click(sender As Object, e As EventArgs)
    Try
        ' In order to use the retry policies, strategies defined in Transient Fault 
        ' Handling Application Block , user calls to cache must be wrapped with in 
        ' ExecuteAction delegate.
        retryPolicy.ExecuteAction(Sub()


                                      ' Getting the object from azure cache and printing it on the page. 
                                      Response.Write(cache.[Get](&quot;MyDataSet&quot;))


                                  End Sub)
    Catch dc As DataCacheException
        ' Exception occurred after implementing the Retry logic.
        ' Ideally you should log the exception to your application logs and show user 
        ' friendly error message on the webpage.
        Trace.Write(dc.[GetType]().ToString() &#43; dc.Message.ToString() &#43; dc.StackTrace.ToString())
    End Try
End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub btnReadFromCache_Click(sender As Object, e As EventArgs)
    Try
        ' In order to use the retry policies, strategies defined in Transient Fault 
        ' Handling Application Block , user calls to cache must be wrapped with in 
        ' ExecuteAction delegate.
        retryPolicy.ExecuteAction(Sub()


                                      ' Getting the object from azure cache and printing it on the page. 
                                      Response.Write(cache.[Get](&quot;MyDataSet&quot;))


                                  End Sub)
    Catch dc As DataCacheException
        ' Exception occurred after implementing the Retry logic.
        ' Ideally you should log the exception to your application logs and show user 
        ' friendly error message on the webpage.
        Trace.Write(dc.[GetType]().ToString() &#43; dc.Message.ToString() &#43; dc.StackTrace.ToString())
    End Try
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">Refer to below blog entry for more information</p>
<p class="MsoNormal"><a href="http://blogs.msdn.com/b/narahari/archive/2011/12/29/implementing-retry-logic-for-azure-caching-applications-made-easy.aspx">http://blogs.msdn.com/b/narahari/archive/2011/12/29/implementing-retry-logic-for-azure-caching-applications-made-easy.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>