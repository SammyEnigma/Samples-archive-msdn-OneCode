# How to Detect the Web Browser Close Event in ASP.NET
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
* .NET
* Web App Development
## Topics
* Webpage
## IsPublished
* True
## ModifiedDate
* 2014-06-27 02:51:03
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Detect the Web Browser Close Event in ASP.NET
</span><span style="font-weight:bold; font-size:14pt">MVC (</span><span style="font-weight:bold; font-size:14pt">CS</span><span style="font-weight:bold; font-size:14pt">\VB</span><span style="font-weight:bold; font-size:14pt">ASPNETDetectBrowserCloseEvent</span><span style="font-weight:bold; font-size:14pt">)</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">As we know, HTTP is a stateless protocol,</span></span><span style="font-size:13pt"><span style="font-size:11pt"> so</span><span style="font-size:11pt"> the browser doesn't keep connecting to the server.
 When user</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> try to close the browser using alt-f4, browser close(X) and right click on browser and close</span><span style="font-size:11pt">,
</span><span style="font-size:11pt">all</span><span style="font-size:11pt"> these methods are
</span><span style="font-size:11pt">working fine, </span><span style="font-size:11pt">but
</span><span style="font-size:11pt">it's not possible to tell the server that the browser is closed.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">&nbsp;</span><span style="font-size:11pt">The sample demonstrates how to detect the browser close event</span><span style="font-size:11pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">It include</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> two parts:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1 Send ajax call every 20 seconds, to tell the server side</span><span style="font-size:11pt"> that the</span><span style="font-size:11pt"> page</span><span style="font-size:11pt"> is</span><span style="font-size:11pt">
 still open.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2 Send ajax call when </span>
<span style="font-size:11pt">the </span><span style="font-size:11pt">browser </span>
<span style="font-size:11pt">is </span><span style="font-size:11pt">close</span><span style="font-size:11pt">d</span><span style="font-size:11pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You can run the sample directly, then</span><span style="font-size:11pt"> type</span><span style="font-size:11pt">
</span><span style="font-size:11pt">http://localhost:{you</span><span style="font-size:11pt">r</span><span style="font-size:11pt"> port number}</span><span style="font-size:11pt">
</span><span style="font-size:11pt">/default/</span><span style="font-size:11pt"> to open the default page.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You will see </span><span style="font-size:11pt">a</span><span style="font-size:11pt"> page like below:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/119276/1/image.png" alt="" width="575" height="63" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The third line changes every 20 seconds.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">When you close the browser, you ca</span><span style="font-size:11pt">n open the xml file in app_data.</span><span style="font-size:11pt">
</span><span style="font-size:11pt">You</span><span style="font-size:11pt"> can find the information above is in the xml file.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The</span><span style="font-size:11pt"> following</span><span style="font-size:11pt"> code</span><span style="font-size:11pt">
</span><span style="font-size:11pt">s</span><span style="font-size:11pt">nippet</span><span style="font-size:11pt">
</span><span style="font-size:11pt">will </span><span style="font-size:11pt">show how to detect the browser close event.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">function recordeCloseTime()
{
    var targetUrl = &quot;@Url.Action(&quot;RecordCloseTime&quot;, &quot;Default&quot;)&quot; &#43; &quot;?clientId=&quot; &#43; getClientID();
    $.ajax({
        type: &quot;HEAD&quot;,
        url: targetUrl,
    });
}
</pre>
<pre id="codePreview" class="js">function recordeCloseTime()
{
    var targetUrl = &quot;@Url.Action(&quot;RecordCloseTime&quot;, &quot;Default&quot;)&quot; &#43; &quot;?clientId=&quot; &#43; getClientID();
    $.ajax({
        type: &quot;HEAD&quot;,
        url: targetUrl,
    });
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The</span><span style="font-size:11pt"> following</span><span style="font-size:11pt"> code</span><span style="font-size:11pt">
</span><span style="font-size:11pt">s</span><span style="font-size:11pt">nippet</span><span style="font-size:11pt">
</span><span style="font-size:11pt">will show</span><span style="font-size:11pt"> how to create a client id and store in cookie.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">function generateGuid() {
           var result, i, j;
           result = '';
           for (j = 0; j &lt; 32; j&#43;&#43;) {
               if (j == 8 || j == 12 || j == 16 || j == 20)
                   result = result &#43; '-';
               i = Math.floor(Math.random() * 16).toString(16).toUpperCase();
               result = result &#43; i;
           }
           return result;
       }
</pre>
<pre id="codePreview" class="js">function generateGuid() {
           var result, i, j;
           result = '';
           for (j = 0; j &lt; 32; j&#43;&#43;) {
               if (j == 8 || j == 12 || j == 16 || j == 20)
                   result = result &#43; '-';
               i = Math.floor(Math.random() * 16).toString(16).toUpperCase();
               result = result &#43; i;
           }
           return result;
       }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The</span><span style="font-size:11pt">
</span><span style="font-size:11pt">following </span><span style="font-size:11pt">code</span><span style="font-size:11pt">
</span><span style="font-size:11pt">s</span><span style="font-size:11pt">nippet</span><a name="_GoBack"></a><span style="font-size:11pt">
</span><span style="font-size:11pt">will show</span><span style="font-size:11pt"> how to refresh the refresh time in order to tell server side the page still open.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">function getRefreshTime()
      {
          var targetUrl = &quot;@Url.Action(&quot;GetRefreshTime&quot;, &quot;Default&quot;)&quot; &#43; &quot;?clientId=&quot; &#43; getClientID();
          $.ajax({
              type: &quot;GET&quot;,
              url: targetUrl,
              cache:false,
              success: function (data) {
                  if (data != &quot;&quot;) {
                      var clientInfo = JSON.parse(data);
                      $(&quot;#lbClientId&quot;).text(clientInfo.ClientID);
                      $(&quot;#lbActiveTime&quot;).text(new Date(clientInfo.ActiveTime));
                      $(&quot;#lbRefreshTime&quot;).text(new Date(clientInfo.RefreshTime));
                  }
              }
          });
      }
</pre>
<pre id="codePreview" class="js">function getRefreshTime()
      {
          var targetUrl = &quot;@Url.Action(&quot;GetRefreshTime&quot;, &quot;Default&quot;)&quot; &#43; &quot;?clientId=&quot; &#43; getClientID();
          $.ajax({
              type: &quot;GET&quot;,
              url: targetUrl,
              cache:false,
              success: function (data) {
                  if (data != &quot;&quot;) {
                      var clientInfo = JSON.parse(data);
                      $(&quot;#lbClientId&quot;).text(clientInfo.ClientID);
                      $(&quot;#lbActiveTime&quot;).text(new Date(clientInfo.ActiveTime));
                      $(&quot;#lbRefreshTime&quot;).text(new Date(clientInfo.RefreshTime));
                  }
              }
          });
      }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This codes </span><span style="font-size:11pt">will show</span><span style="font-size:11pt"> a simple data source to operate an xml database.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public class ClientInfoDataSource
    {
        private static string filePath = HttpContext.Current.Server.MapPath(&quot;~/App_Data/ClientInfos.xml&quot;);
        private static XDocument clientInfosXDoc;
       
        public ClientInfoDataSource()
        {
            clientInfosXDoc = XDocument.Load(filePath);
        }
        /// &lt;summary&gt;
        /// Get ClientInfo by ClientId
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;clientID&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public ClientInfo GetClientInfoByClientId(string clientID)
        {
            var query = from clientInfoXml in clientInfosXDoc.Descendants(&quot;ClientID&quot;)
                        where clientInfoXml.Value == clientID
                        select clientInfoXml.Parent;
            return convertToClientInfo(query.FirstOrDefault());
        }
        /// &lt;summary&gt;
        /// Insert ClientInfo message to XML file
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;clientInfo&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public void InsertClientInfo(ClientInfo clientInfo)
        {  
      clientInfosXDoc.Root.Add(convertToClientInfoXElement(clientInfo));
        }
        /// &lt;summary&gt;
        /// Update ActiveTime and RefreshTime
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;clientInfo&quot;&gt;&lt;/param&gt;
        public void UpdateClientInfo(ClientInfo clientInfo)
        {
            var query = from x in clientInfosXDoc.Root.Elements()
                        where x.Element(&quot;ClientID&quot;).Value == clientInfo.ClientID
                        select x;
            if (query.Count()&gt;0)
         {
                query.FirstOrDefault().Element(&quot;ActiveTime&quot;).Value = clientInfo.ActiveTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;);
                query.FirstOrDefault().Element(&quot;RefreshTime&quot;).Value = clientInfo.RefreshTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;);
         }
        }
        /// &lt;summary&gt;
        /// Save data source changes
        /// &lt;/summary&gt;
        public void Save()
        {
            clientInfosXDoc.Save(filePath);
        }
        /// &lt;summary&gt;
        /// Convert XML message to Class
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;clientInfoXml&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private ClientInfo convertToClientInfo(XElement clientInfoXml)
        {
            if (clientInfoXml!=null)
            {
                ClientInfo clientInfo = new ClientInfo();
                clientInfo.ClientID = clientInfoXml.Element(&quot;ClientID&quot;).Value;
                clientInfo.ActiveTime = DateTime.Parse(clientInfoXml.Element(&quot;ActiveTime&quot;).Value);
                clientInfo.RefreshTime = DateTime.Parse(clientInfoXml.Element(&quot;RefreshTime&quot;).Value);
                return clientInfo;
            }
            return null;
        }
        /// &lt;summary&gt;
        /// Convert Class to XML message
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;clientInfo&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private XElement convertToClientInfoXElement(ClientInfo clientInfo)
        {
            if (clientInfo!=null)
            {
                XElement xDoc = new XElement(&quot;ClientInfo&quot;,
                    new XElement(&quot;ClientID&quot;, clientInfo.ClientID),
                    new XElement(&quot;ActiveTime&quot;, clientInfo.ActiveTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;)),
                    new XElement(&quot;RefreshTime&quot;, clientInfo.RefreshTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;)));
                return xDoc;
            }
            return null;
        }
    }
</pre>
<pre class="hidden">Public Class ClientInfoDataSource
    Private Shared filePath As String = HttpContext.Current.Server.MapPath(&quot;~/App_Data/ClientInfos.xml&quot;)
    Private Shared clientInfosXDoc As XDocument
    Public Sub New()
        clientInfosXDoc = XDocument.Load(filePath)
    End Sub
    ''' &lt;summary&gt;
    ''' Get ClientInfo by ClientId
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;clientID&quot;&gt;&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Public Function GetClientInfoByClientId(clientID As String) As ClientInfo
        Dim query = From clientInfoXml In clientInfosXDoc.Descendants(&quot;ClientID&quot;) Where clientInfoXml.Value = clientID Select clientInfoXml.Parent
        Return convertToClientInfo(query.FirstOrDefault())
    End Function
    ''' &lt;summary&gt;
    ''' Insert ClientInfo message to XML file
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;clientInfo&quot;&gt;&lt;/param&gt;
    Public Sub InsertClientInfo(clientInfo As ClientInfo)
        clientInfosXDoc.Root.Add(convertToClientInfoXElement(clientInfo))
    End Sub
    ''' &lt;summary&gt;
    ''' Update ActiveTime and RefreshTime
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;clientInfo&quot;&gt;&lt;/param&gt;
    Public Sub UpdateClientInfo(clientInfo As ClientInfo)
        Dim query = From x In clientInfosXDoc.Root.Elements() Where x.Element(&quot;ClientID&quot;).Value = clientInfo.ClientID Select x
        If query.Count() &gt; 0 Then
            query.FirstOrDefault().Element(&quot;ActiveTime&quot;).Value = clientInfo.ActiveTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;)
            query.FirstOrDefault().Element(&quot;RefreshTime&quot;).Value = clientInfo.RefreshTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;)
        End If
    End Sub
    ''' &lt;summary&gt;
    ''' Save data source changes
    ''' &lt;/summary&gt;
    Public Sub Save()
        clientInfosXDoc.Save(filePath)
    End Sub
    ''' &lt;summary&gt;
    ''' Convert XML message to Class
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;clientInfoXml&quot;&gt;&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Private Function convertToClientInfo(clientInfoXml As XElement) As ClientInfo
        If clientInfoXml IsNot Nothing Then
            Dim clientInfo As New ClientInfo()
            clientInfo.ClientID = clientInfoXml.Element(&quot;ClientID&quot;).Value
            clientInfo.ActiveTime = DateTime.Parse(clientInfoXml.Element(&quot;ActiveTime&quot;).Value)
            clientInfo.RefreshTime = DateTime.Parse(clientInfoXml.Element(&quot;RefreshTime&quot;).Value)
            Return clientInfo
        End If
        Return Nothing
    End Function
    ''' &lt;summary&gt;
    ''' Convert Class to XML message
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;clientInfo&quot;&gt;&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Private Function convertToClientInfoXElement(clientInfo As ClientInfo) As XElement
        If clientInfo IsNot Nothing Then
            Dim xDoc As New XElement(&quot;ClientInfo&quot;, New XElement(&quot;ClientID&quot;, clientInfo.ClientID), New XElement(&quot;ActiveTime&quot;, clientInfo.ActiveTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;)), New XElement(&quot;RefreshTime&quot;, clientInfo.RefreshTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;)))
            Return xDoc
        End If
        Return Nothing
    End Function
End Class
</pre>
<pre id="codePreview" class="csharp">public class ClientInfoDataSource
    {
        private static string filePath = HttpContext.Current.Server.MapPath(&quot;~/App_Data/ClientInfos.xml&quot;);
        private static XDocument clientInfosXDoc;
       
        public ClientInfoDataSource()
        {
            clientInfosXDoc = XDocument.Load(filePath);
        }
        /// &lt;summary&gt;
        /// Get ClientInfo by ClientId
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;clientID&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public ClientInfo GetClientInfoByClientId(string clientID)
        {
            var query = from clientInfoXml in clientInfosXDoc.Descendants(&quot;ClientID&quot;)
                        where clientInfoXml.Value == clientID
                        select clientInfoXml.Parent;
            return convertToClientInfo(query.FirstOrDefault());
        }
        /// &lt;summary&gt;
        /// Insert ClientInfo message to XML file
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;clientInfo&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public void InsertClientInfo(ClientInfo clientInfo)
        {  
      clientInfosXDoc.Root.Add(convertToClientInfoXElement(clientInfo));
        }
        /// &lt;summary&gt;
        /// Update ActiveTime and RefreshTime
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;clientInfo&quot;&gt;&lt;/param&gt;
        public void UpdateClientInfo(ClientInfo clientInfo)
        {
            var query = from x in clientInfosXDoc.Root.Elements()
                        where x.Element(&quot;ClientID&quot;).Value == clientInfo.ClientID
                        select x;
            if (query.Count()&gt;0)
         {
                query.FirstOrDefault().Element(&quot;ActiveTime&quot;).Value = clientInfo.ActiveTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;);
                query.FirstOrDefault().Element(&quot;RefreshTime&quot;).Value = clientInfo.RefreshTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;);
         }
        }
        /// &lt;summary&gt;
        /// Save data source changes
        /// &lt;/summary&gt;
        public void Save()
        {
            clientInfosXDoc.Save(filePath);
        }
        /// &lt;summary&gt;
        /// Convert XML message to Class
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;clientInfoXml&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private ClientInfo convertToClientInfo(XElement clientInfoXml)
        {
            if (clientInfoXml!=null)
            {
                ClientInfo clientInfo = new ClientInfo();
                clientInfo.ClientID = clientInfoXml.Element(&quot;ClientID&quot;).Value;
                clientInfo.ActiveTime = DateTime.Parse(clientInfoXml.Element(&quot;ActiveTime&quot;).Value);
                clientInfo.RefreshTime = DateTime.Parse(clientInfoXml.Element(&quot;RefreshTime&quot;).Value);
                return clientInfo;
            }
            return null;
        }
        /// &lt;summary&gt;
        /// Convert Class to XML message
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;clientInfo&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private XElement convertToClientInfoXElement(ClientInfo clientInfo)
        {
            if (clientInfo!=null)
            {
                XElement xDoc = new XElement(&quot;ClientInfo&quot;,
                    new XElement(&quot;ClientID&quot;, clientInfo.ClientID),
                    new XElement(&quot;ActiveTime&quot;, clientInfo.ActiveTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;)),
                    new XElement(&quot;RefreshTime&quot;, clientInfo.RefreshTime.ToString(&quot;MM/dd/yyyy HH:mm:ss&quot;)));
                return xDoc;
            }
            return null;
        }
    }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
