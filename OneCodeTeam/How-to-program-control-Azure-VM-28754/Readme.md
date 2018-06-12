# How to program control Azure VM
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Azure
* VM
* Service Management
## IsPublished
* True
## ModifiedDate
* 2014-05-21 02:59:09
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to program</span><span style="font-weight:bold; font-size:14pt">m</span><span style="font-weight:bold; font-size:14pt">atically</span><span style="font-weight:bold; font-size:14pt">
 control Azure V</span><span style="font-weight:bold; font-size:14pt">irtual Machine</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">To operate </span></span><span style="font-size:13pt"><span style="font-size:11pt">W</span><span style="font-size:11pt">indows
</span><span style="font-size:11pt">A</span><span style="font-size:11pt">zure virtual</span><span style="font-size:11pt"> machine, using the
</span><span style="font-size:11pt">A</span><span style="font-size:11pt">zure </span>
<span style="font-size:11pt">PowerS</span><span style="font-size:11pt">hell</span><span style="font-size:11pt"> isn't the only way. We also can use management service API</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> to achieve this
 target. </span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample will </span>
<span style="font-size:11pt">demonstrate how to create a virtual machine, get its information and delete it.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Before running the sample, you must change the va</span><span>riable</span><span style="font-size:11pt">s below to yours.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<strong><span style="font-size:13pt"><span style="font-size:11pt">-</span></span><span style="font-size:13pt"><span style="font-size:11pt">VirtualMachineName</span></span>
</strong></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">&nbsp;</span><span style="font-size:11pt">A unique Name of your VirtualMachine.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">&nbsp;</span><strong><span style="font-size:11pt">-</span><span style="font-size:11pt">SettingsFilePath</span></strong></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="color:#000000; font-size:10pt">&nbsp;</span><span style="font-size:11pt">Download the&nbsp;</span><span style="font-size:11pt">publishsettings file</span><span style="font-size:11pt">&nbsp;from</span><span style="color:#000000; font-size:10pt">:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:5pt; margin-bottom:5pt; font-size:10.0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:12pt"><span style="color:#000000; font-size:10pt">&nbsp;</span><a href="https://manage.windowsazure.com/publishsettings/index?client=vs&schemaversion=2.0&whr=azure.com" style="text-decoration:none"><span style="color:#960bb4; font-size:10pt; text-decoration:underline">https://manage.windowsazure.com/publishsettings/index?client=vs&amp;schemaversion=2.0&amp;whr=azure.com</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:5pt; margin-bottom:5pt; font-size:10.0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:12pt"><span style="color:#000000; font-size:10pt">Then set the SettingsFilePath to publishsettings file&rsquo;s path.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-size:11pt">-SubscriptionID</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Set to your Azure subscription ID.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-size:11pt">-StorageAccountName</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Set to your storage account name. We need blob storage to store the VM VHD file.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The sample implement</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> three major
</span><span style="font-size:11pt">Azure Virtual Machine operations.</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt"><span>&bull;&nbsp;</span><span style="font-size:11pt">Create Azure Virtual Machine</span><span style="font-size:11pt">
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">#region Create Azure Virtual Machine
        public static void CreateAzureVM(string vmName, string location = null, string affinityGroup = null)
        {
            //Step 1:Create Hosted Service
            var createHostedServiceResponse=createHostedService(vmName,location,affinityGroup);
            //A successful operation returns status code 201 (Created).
            if ((int)createHostedServiceResponse.StatusCode == 201)
            {
                Console.WriteLine(&quot;Create cloud service success!&quot;);
            //Step 2: Create Virtual Machin Deployment
                var createDeploymentResponse = createVMDeployment(vmName, vmName, vmName);
                if ((int)createDeploymentResponse.StatusCode==202)
                {
                    Console.WriteLine(&quot;Create VM success!&quot;);
                }
                else
                {
                    Console.WriteLine(&quot;Error:&quot; &#43; getErrorMessageFromResponse(createDeploymentResponse));
                }
            }
            else
            {
                Console.WriteLine(&quot;Error:&quot;&#43;getErrorMessageFromResponse(createHostedServiceResponse));
            }
        }
        private static HttpWebResponse createHostedService(string serviceName, string location = null, string affinityGroup = null)
        {
            string locationOrAffinity = string.Empty;
            string value = string.Empty;
            if (string.IsNullOrEmpty(location) == false)
            {
                locationOrAffinity = &quot;Location&quot;;
                value = location;
            }
            else
            {
                locationOrAffinity = &quot;AffinityGroup&quot;;
                value = affinityGroup;
            }
            XDocument requestBody = new XDocument(
                new XElement(ns &#43; &quot;CreateHostedService&quot;,
                new XElement(ns &#43; &quot;ServiceName&quot;, serviceName),
                new XElement(ns &#43; &quot;Label&quot;, convertToBase64(serviceName)),
                new XElement(ns &#43; locationOrAffinity, value))
                   );
            var response = sendHttpReqeust(
               &quot;https://management.core.windows.net/&quot; &#43; SubscriptionID &#43; &quot;/services/hostedservices&quot;,
               &quot;POST&quot;,
               ClientCertificate,
               ContentType,
               Version,
               requestBody
               );
            return response;
        }
        private static HttpWebResponse createVMDeployment(string cloudServiceName, string deploymentName, string VMName)
        {
            var now = DateTime.UtcNow;
            string dateString = now.Year &#43; &quot;-&quot; &#43; now.Month &#43; &quot;-&quot; &#43; now.Day &#43; now.Hour &#43; now.Minute &#43; now.Second &#43; now.Millisecond;
            XDocument requestBody = new XDocument(
               new XElement(ns &#43; &quot;Deployment&quot;,
          new XElement(ns &#43; &quot;Name&quot;, deploymentName),
          new XElement(ns &#43; &quot;DeploymentSlot&quot;, DeploymentSlot),
          new XElement(ns &#43; &quot;Label&quot;, convertToBase64(deploymentName)),
          new XElement(ns &#43; &quot;RoleList&quot;,
            new XElement(ns &#43; &quot;Role&quot;,
              new XElement(ns &#43; &quot;RoleName&quot;, VMName),
              new XElement(ns &#43; &quot;RoleType&quot;, &quot;PersistentVMRole&quot;),
              new XElement(ns &#43; &quot;ConfigurationSets&quot;,
                new XElement(ns &#43; &quot;ConfigurationSet&quot;,
                  new XElement(ns &#43; &quot;ConfigurationSetType&quot;, &quot;WindowsProvisioningConfiguration&quot;),
                  new XElement(ns &#43; &quot;InputEndpoints&quot;,
                      new XElement(ns &#43; &quot;InputEndpoint&quot;,
                          new XElement(ns &#43; &quot;LocalPort&quot;, 3389),
                          new XElement(ns &#43; &quot;Name&quot;, &quot;RDP&quot;),
                          new XElement(ns &#43; &quot;Protocol&quot;, &quot;tcp&quot;)),
                       new XElement(ns &#43; &quot;InputEndpoint&quot;,
                          new XElement(ns &#43; &quot;LocalPort&quot;, 80),
                          new XElement(ns &#43; &quot;Name&quot;, &quot;web&quot;),
                          new XElement(ns &#43; &quot;Port&quot;, 80),
                          new XElement(ns &#43; &quot;Protocol&quot;, &quot;tcp&quot;))),
                  new XElement(ns &#43; &quot;ComputerName&quot;, VMName),
                  new XElement(ns &#43; &quot;AdminPassword&quot;, AdminPassword),
                  new XElement(ns &#43; &quot;AdminUsername&quot;, AdminUsername))),
              new XElement(ns &#43; &quot;Label&quot;, VMName),
              new XElement(ns &#43; &quot;OSVirtualHardDisk&quot;,
                new XElement(ns &#43; &quot;MediaLink&quot;, string.Format(&quot;http://{0}.blob.core.windows.net/vhds/{1}.vhd&quot;, StorageAccountName, dateString)),
                new XElement(ns &#43; &quot;SourceImageName&quot;, getSourceImageNameByFamliyName(ImageFamilyName))),
              new XElement(ns &#43; &quot;RoleSize&quot;, RoleSize)
                ))));
            var response = sendHttpReqeust(
                string.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments&quot;, SubscriptionID, cloudServiceName),
                &quot;POST&quot;,
                ClientCertificate,
                ContentType,
                Version,
                requestBody);
            return response;
        }
        private static string convertToBase64(string targetString)
        {
            System.Text.ASCIIEncoding ae = new System.Text.ASCIIEncoding();
            byte[] svcNameBytes = ae.GetBytes(targetString);
            return Convert.ToBase64String(svcNameBytes);
        }
        private static string getSourceImageNameByFamliyName(string imageFamliyName)
        {
            string imageName = null;
            var response = sendHttpReqeust(
                string.Format(&quot;https://management.core.windows.net/{0}/services/images&quot;, SubscriptionID),
                &quot;GET&quot;,
                ClientCertificate,
                 &quot;application/xml&quot;,
                 &quot;2014-02-01&quot;,
                 null
                );
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    var imagesXML = reader.ReadToEnd();
                    imageName = XElement.Parse(imagesXML).Elements()
                       .Where(o =&gt; o.Descendants(ns &#43; &quot;ImageFamily&quot;).Count() &gt; 0)
                       .Where(o =&gt; o.Element(ns &#43; &quot;ImageFamily&quot;).Value.ToString() == imageFamliyName)
                       .Last().Element(ns &#43; &quot;Name&quot;)
                       .Value.ToString();
                }
            }
            return imageName;
        }
        #endregion
</pre>
<pre class="hidden">#Region &quot;Create Azure Virtual Machine&quot;
    Public Sub CreateAzureVM(vmName As String, Optional location As String = Nothing, Optional affinityGroup As String = Nothing)
        'Step 1:Create Hosted Service
        Dim createHostedServiceResponse = createHostedService(vmName, location, affinityGroup)
        'A successful operation returns status code 201 (Created).
        If CInt(createHostedServiceResponse.StatusCode) = 201 Then
            Console.WriteLine(&quot;Create cloud service success!&quot;)
            'Step 2: Create Virtual Machin Deployment
            Dim createDeploymentResponse = createVMDeployment(vmName, vmName, vmName)
            If CInt(createDeploymentResponse.StatusCode) = 202 Then
                Console.WriteLine(&quot;Create VM success!&quot;)
            Else
                Console.WriteLine(&quot;Error:&quot; &amp; getErrorMessageFromResponse(createDeploymentResponse))
            End If
        Else
            Console.WriteLine(&quot;Error:&quot; &amp; getErrorMessageFromResponse(createHostedServiceResponse))
        End If
    End Sub
    Private Function createHostedService(serviceName As String, Optional location As String = Nothing, Optional affinityGroup As String = Nothing) As HttpWebResponse
        Dim locationOrAffinity As String = String.Empty
        Dim value As String = String.Empty
        If String.IsNullOrEmpty(location) = False Then
            locationOrAffinity = &quot;Location&quot;
            value = location
        Else
            locationOrAffinity = &quot;AffinityGroup&quot;
            value = affinityGroup
        End If
        Dim requestBody As New XDocument(New XElement(ns.ToString() &amp; &quot;CreateHostedService&quot;, New XElement(ns.ToString() &amp; &quot;ServiceName&quot;, serviceName), New XElement(ns.ToString() &amp; &quot;Label&quot;, convertToBase64(serviceName)), New XElement(ns.ToString() &amp; locationOrAffinity, value)))
        Dim response = sendHttpReqeust(&quot;https://management.core.windows.net/&quot; &amp; SubscriptionID &amp; &quot;/services/hostedservices&quot;, &quot;POST&quot;, ClientCertificate, ContentType, Version, requestBody)
        Return response
    End Function
    Private Function createVMDeployment(cloudServiceName As String, deploymentName As String, VMName As String) As HttpWebResponse
        Dim now = DateTime.UtcNow
        Dim dateString As String = Convert.ToString(now.Year) &amp; &quot;-&quot; &amp; Convert.ToString(now.Month) &amp; &quot;-&quot; &amp; Convert.ToString(now.Day) &amp; Convert.ToString(now.Hour) &amp; Convert.ToString(now.Minute) &amp; Convert.ToString(now.Second) &amp; Convert.ToString(now.Millisecond)
        Dim requestBody As New XDocument(New XElement(ns.ToString() &amp; &quot;Deployment&quot;, New XElement(ns.ToString() &amp; &quot;Name&quot;, deploymentName), New XElement(ns.ToString() &amp; &quot;DeploymentSlot&quot;, DeploymentSlot), New XElement(ns.ToString() &amp; &quot;Label&quot;, convertToBase64(deploymentName)), New XElement(ns.ToString() &amp; &quot;RoleList&quot;, New XElement(ns.ToString() &amp; &quot;Role&quot;, New XElement(ns.ToString() &amp; &quot;RoleName&quot;, VMName), New XElement(ns.ToString() &amp; &quot;RoleType&quot;, &quot;PersistentVMRole&quot;), New XElement(ns.ToString() &amp; &quot;ConfigurationSets&quot;, New XElement(ns.ToString() &amp; &quot;ConfigurationSet&quot;, New XElement(ns.ToString() &amp; &quot;ConfigurationSetType&quot;, &quot;WindowsProvisioningConfiguration&quot;), New XElement(ns.ToString() &amp; &quot;InputEndpoints&quot;, New XElement(ns.ToString() &amp; &quot;InputEndpoint&quot;, New XElement(ns.ToString() &amp; &quot;LocalPort&quot;, 3389), New XElement(ns.ToString() &amp; &quot;Name&quot;, &quot;RDP&quot;), New XElement(ns.ToString() &amp; &quot;Protocol&quot;, &quot;tcp&quot;)), New XElement(ns.ToString() &amp; &quot;InputEndpoint&quot;, New XElement(ns.ToString() &amp; &quot;LocalPort&quot;, 80), New XElement(ns.ToString() &amp; &quot;Name&quot;, &quot;web&quot;), New XElement(ns.ToString() &amp; &quot;Port&quot;, 80), New XElement(ns.ToString() &amp; &quot;Protocol&quot;, &quot;tcp&quot;))), New XElement(ns.ToString() &amp; &quot;ComputerName&quot;, VMName), New XElement(ns.ToString() &amp; &quot;AdminPassword&quot;, AdminPassword), New XElement(ns.ToString() &amp; &quot;AdminUsername&quot;, AdminUsername))), New XElement(ns.ToString() &amp; &quot;Label&quot;, VMName), New XElement(ns.ToString() &amp; &quot;OSVirtualHardDisk&quot;, New XElement(ns.ToString() &amp; &quot;MediaLink&quot;, String.Format(&quot;http://{0}.blob.core.windows.net/vhds/{1}.vhd&quot;, StorageAccountName, dateString)), New XElement(ns.ToString() &amp; &quot;SourceImageName&quot;, getSourceImageNameByFamliyName(ImageFamilyName))), _
            New XElement(ns.ToString() &amp; &quot;RoleSize&quot;, RoleSize)))))
        Dim response = sendHttpReqeust(String.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments&quot;, SubscriptionID, cloudServiceName), &quot;POST&quot;, ClientCertificate, ContentType, Version, requestBody)
        Return response
    End Function
    Private Function convertToBase64(targetString As String) As String
        Dim ae As New System.Text.ASCIIEncoding()
        Dim svcNameBytes As Byte() = ae.GetBytes(targetString)
        Return Convert.ToBase64String(svcNameBytes)
    End Function
    Private Function getSourceImageNameByFamliyName(imageFamliyName As String) As String
        Dim imageName As String = Nothing
        Dim response = sendHttpReqeust(String.Format(&quot;https://management.core.windows.net/{0}/services/images&quot;, SubscriptionID), &quot;GET&quot;, ClientCertificate, &quot;application/xml&quot;, &quot;2014-02-01&quot;, Nothing)
        Using responseStream As Stream = response.GetResponseStream()
            Using reader As New StreamReader(responseStream)
                Dim imagesXML = reader.ReadToEnd()
                imageName = XElement.Parse(imagesXML).Elements().Where(Function(o) o.Descendants(ns.ToString() &amp; &quot;ImageFamily&quot;).Count() &gt; 0).Where(Function(o) o.Element(ns.ToString() &amp; &quot;ImageFamily&quot;).Value.ToString() = imageFamliyName).Last().Element(ns.ToString() &amp; &quot;Name&quot;).Value.ToString()
            End Using
        End Using
        Return imageName
    End Function
#End Region
</pre>
<pre class="csharp" id="codePreview">#region Create Azure Virtual Machine
        public static void CreateAzureVM(string vmName, string location = null, string affinityGroup = null)
        {
            //Step 1:Create Hosted Service
            var createHostedServiceResponse=createHostedService(vmName,location,affinityGroup);
            //A successful operation returns status code 201 (Created).
            if ((int)createHostedServiceResponse.StatusCode == 201)
            {
                Console.WriteLine(&quot;Create cloud service success!&quot;);
            //Step 2: Create Virtual Machin Deployment
                var createDeploymentResponse = createVMDeployment(vmName, vmName, vmName);
                if ((int)createDeploymentResponse.StatusCode==202)
                {
                    Console.WriteLine(&quot;Create VM success!&quot;);
                }
                else
                {
                    Console.WriteLine(&quot;Error:&quot; &#43; getErrorMessageFromResponse(createDeploymentResponse));
                }
            }
            else
            {
                Console.WriteLine(&quot;Error:&quot;&#43;getErrorMessageFromResponse(createHostedServiceResponse));
            }
        }
        private static HttpWebResponse createHostedService(string serviceName, string location = null, string affinityGroup = null)
        {
            string locationOrAffinity = string.Empty;
            string value = string.Empty;
            if (string.IsNullOrEmpty(location) == false)
            {
                locationOrAffinity = &quot;Location&quot;;
                value = location;
            }
            else
            {
                locationOrAffinity = &quot;AffinityGroup&quot;;
                value = affinityGroup;
            }
            XDocument requestBody = new XDocument(
                new XElement(ns &#43; &quot;CreateHostedService&quot;,
                new XElement(ns &#43; &quot;ServiceName&quot;, serviceName),
                new XElement(ns &#43; &quot;Label&quot;, convertToBase64(serviceName)),
                new XElement(ns &#43; locationOrAffinity, value))
                   );
            var response = sendHttpReqeust(
               &quot;https://management.core.windows.net/&quot; &#43; SubscriptionID &#43; &quot;/services/hostedservices&quot;,
               &quot;POST&quot;,
               ClientCertificate,
               ContentType,
               Version,
               requestBody
               );
            return response;
        }
        private static HttpWebResponse createVMDeployment(string cloudServiceName, string deploymentName, string VMName)
        {
            var now = DateTime.UtcNow;
            string dateString = now.Year &#43; &quot;-&quot; &#43; now.Month &#43; &quot;-&quot; &#43; now.Day &#43; now.Hour &#43; now.Minute &#43; now.Second &#43; now.Millisecond;
            XDocument requestBody = new XDocument(
               new XElement(ns &#43; &quot;Deployment&quot;,
          new XElement(ns &#43; &quot;Name&quot;, deploymentName),
          new XElement(ns &#43; &quot;DeploymentSlot&quot;, DeploymentSlot),
          new XElement(ns &#43; &quot;Label&quot;, convertToBase64(deploymentName)),
          new XElement(ns &#43; &quot;RoleList&quot;,
            new XElement(ns &#43; &quot;Role&quot;,
              new XElement(ns &#43; &quot;RoleName&quot;, VMName),
              new XElement(ns &#43; &quot;RoleType&quot;, &quot;PersistentVMRole&quot;),
              new XElement(ns &#43; &quot;ConfigurationSets&quot;,
                new XElement(ns &#43; &quot;ConfigurationSet&quot;,
                  new XElement(ns &#43; &quot;ConfigurationSetType&quot;, &quot;WindowsProvisioningConfiguration&quot;),
                  new XElement(ns &#43; &quot;InputEndpoints&quot;,
                      new XElement(ns &#43; &quot;InputEndpoint&quot;,
                          new XElement(ns &#43; &quot;LocalPort&quot;, 3389),
                          new XElement(ns &#43; &quot;Name&quot;, &quot;RDP&quot;),
                          new XElement(ns &#43; &quot;Protocol&quot;, &quot;tcp&quot;)),
                       new XElement(ns &#43; &quot;InputEndpoint&quot;,
                          new XElement(ns &#43; &quot;LocalPort&quot;, 80),
                          new XElement(ns &#43; &quot;Name&quot;, &quot;web&quot;),
                          new XElement(ns &#43; &quot;Port&quot;, 80),
                          new XElement(ns &#43; &quot;Protocol&quot;, &quot;tcp&quot;))),
                  new XElement(ns &#43; &quot;ComputerName&quot;, VMName),
                  new XElement(ns &#43; &quot;AdminPassword&quot;, AdminPassword),
                  new XElement(ns &#43; &quot;AdminUsername&quot;, AdminUsername))),
              new XElement(ns &#43; &quot;Label&quot;, VMName),
              new XElement(ns &#43; &quot;OSVirtualHardDisk&quot;,
                new XElement(ns &#43; &quot;MediaLink&quot;, string.Format(&quot;http://{0}.blob.core.windows.net/vhds/{1}.vhd&quot;, StorageAccountName, dateString)),
                new XElement(ns &#43; &quot;SourceImageName&quot;, getSourceImageNameByFamliyName(ImageFamilyName))),
              new XElement(ns &#43; &quot;RoleSize&quot;, RoleSize)
                ))));
            var response = sendHttpReqeust(
                string.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments&quot;, SubscriptionID, cloudServiceName),
                &quot;POST&quot;,
                ClientCertificate,
                ContentType,
                Version,
                requestBody);
            return response;
        }
        private static string convertToBase64(string targetString)
        {
            System.Text.ASCIIEncoding ae = new System.Text.ASCIIEncoding();
            byte[] svcNameBytes = ae.GetBytes(targetString);
            return Convert.ToBase64String(svcNameBytes);
        }
        private static string getSourceImageNameByFamliyName(string imageFamliyName)
        {
            string imageName = null;
            var response = sendHttpReqeust(
                string.Format(&quot;https://management.core.windows.net/{0}/services/images&quot;, SubscriptionID),
                &quot;GET&quot;,
                ClientCertificate,
                 &quot;application/xml&quot;,
                 &quot;2014-02-01&quot;,
                 null
                );
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    var imagesXML = reader.ReadToEnd();
                    imageName = XElement.Parse(imagesXML).Elements()
                       .Where(o =&gt; o.Descendants(ns &#43; &quot;ImageFamily&quot;).Count() &gt; 0)
                       .Where(o =&gt; o.Element(ns &#43; &quot;ImageFamily&quot;).Value.ToString() == imageFamliyName)
                       .Last().Element(ns &#43; &quot;Name&quot;)
                       .Value.ToString();
                }
            }
            return imageName;
        }
        #endregion
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt"><span>&bull;&nbsp;</span><span style="font-size:11pt">Get Azure Virtual Machine information</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">#region Get Azure Vitrual Machine Informations
        public static void GetAzureVMInformations(string vmName)
        {
            Console.WriteLine(&quot;Start to get VM {0}'s informations&quot;,vmName);
            var response = getAzureVM(vmName, vmName, vmName);
            if ((int)response.StatusCode==200)
            {
                  using (Stream responseStream=response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                var imagesXML = reader.ReadToEnd();
                                Console.WriteLine(imagesXML);
                            }
                        }
            }
            else
            {
                Console.WriteLine(&quot;Error:&quot; &#43; getErrorMessageFromResponse(response));
            }
        }
        private static HttpWebResponse getAzureVM(string servicName, string deploymentName, string vmName)
        {
            var response = sendHttpReqeust(string.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments/{2}/roles/{3}&quot;, SubscriptionID, servicName, deploymentName, vmName),
                &quot;GET&quot;,
                ClientCertificate,
                ContentType,
                Version,
                null);
            return response;
        }
        #endregion
</pre>
<pre class="hidden">#Region &quot;Get Azure Vitrual Machine Informations&quot;
    Public Sub GetAzureVMInformations(vmName As String)
        Console.WriteLine(&quot;Start to get VM {0}'s informations&quot;, vmName)
        Dim response = getAzureVM(vmName, vmName, vmName)
        If CInt(response.StatusCode) = 200 Then
            Using responseStream As Stream = response.GetResponseStream()
                Using reader As New StreamReader(responseStream)
                    Dim imagesXML = reader.ReadToEnd()
                    Console.WriteLine(imagesXML)
                End Using
            End Using
        Else
            Console.WriteLine(&quot;Error:&quot; &amp; getErrorMessageFromResponse(response))
        End If
    End Sub
    Private Function getAzureVM(servicName As String, deploymentName As String, vmName As String) As HttpWebResponse
        Dim response = sendHttpReqeust(String.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments/{2}/roles/{3}&quot;, SubscriptionID, servicName, deploymentName, vmName), &quot;GET&quot;, ClientCertificate, ContentType, Version, Nothing)
        Return response
    End Function
#End Region
</pre>
<pre class="csharp" id="codePreview">#region Get Azure Vitrual Machine Informations
        public static void GetAzureVMInformations(string vmName)
        {
            Console.WriteLine(&quot;Start to get VM {0}'s informations&quot;,vmName);
            var response = getAzureVM(vmName, vmName, vmName);
            if ((int)response.StatusCode==200)
            {
                  using (Stream responseStream=response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                var imagesXML = reader.ReadToEnd();
                                Console.WriteLine(imagesXML);
                            }
                        }
            }
            else
            {
                Console.WriteLine(&quot;Error:&quot; &#43; getErrorMessageFromResponse(response));
            }
        }
        private static HttpWebResponse getAzureVM(string servicName, string deploymentName, string vmName)
        {
            var response = sendHttpReqeust(string.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments/{2}/roles/{3}&quot;, SubscriptionID, servicName, deploymentName, vmName),
                &quot;GET&quot;,
                ClientCertificate,
                ContentType,
                Version,
                null);
            return response;
        }
        #endregion
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt"><span>&bull;&nbsp;</span><span style="font-size:11pt">Delete Azure Virtual Machine(This method only work</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> when you have multiple VM</span><span style="font-size:11pt">s</span><a name="_GoBack"></a><span style="font-size:11pt">
 in VM deployment)</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">#region Delete Azure Virtual Machine
        public static void DeleteAzureVM(string vmName)
        {
            Console.WriteLine(&quot;Start to delete Azure VM, VM Name={0} this delete operation only work when there are multiple Virtual Machines in one VMDeployment&quot;,vmName);
            var response = deleteVM(vmName, vmName, vmName);
            if ((int)response.StatusCode==202)
            {
                Console.WriteLine(&quot;Delete success!&quot;);
            }
            else
            {
                Console.WriteLine(&quot;Error:&quot; &#43; getErrorMessageFromResponse(response));
            }
        }
        private static HttpWebResponse deleteVM(string servicName, string deploymentName, string vmName)
        {
            var response = sendHttpReqeust(string.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments/{2}/roles/{3}?comp=media&quot;, SubscriptionID, servicName, deploymentName, vmName),
                &quot;DELETE&quot;,
                ClientCertificate,
                null,
                Version,
                null);
            return response;
        }
        #endregion
</pre>
<pre class="hidden">#Region &quot;Delete Azure Virtual Machine&quot;
    Public Sub DeleteAzureVM(vmName As String)
        Console.WriteLine(&quot;Start to delete Azure VM, VM Name={0} this delete operation only work when there are multiple Virtual Machines in one VMDeployment&quot;, vmName)
        Dim response = deleteVM(vmName, vmName, vmName)
        If CInt(response.StatusCode) = 202 Then
            Console.WriteLine(&quot;Delete success!&quot;)
        Else
            Console.WriteLine(&quot;Error:&quot; &amp; getErrorMessageFromResponse(response))
        End If
    End Sub
    Private Function deleteVM(servicName As String, deploymentName As String, vmName As String) As HttpWebResponse
        Dim response = sendHttpReqeust(String.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments/{2}/roles/{3}?comp=media&quot;, SubscriptionID, servicName, deploymentName, vmName), &quot;DELETE&quot;, ClientCertificate, Nothing, Version, Nothing)
        Return response
    End Function
#End Region
</pre>
<pre class="csharp" id="codePreview">#region Delete Azure Virtual Machine
        public static void DeleteAzureVM(string vmName)
        {
            Console.WriteLine(&quot;Start to delete Azure VM, VM Name={0} this delete operation only work when there are multiple Virtual Machines in one VMDeployment&quot;,vmName);
            var response = deleteVM(vmName, vmName, vmName);
            if ((int)response.StatusCode==202)
            {
                Console.WriteLine(&quot;Delete success!&quot;);
            }
            else
            {
                Console.WriteLine(&quot;Error:&quot; &#43; getErrorMessageFromResponse(response));
            }
        }
        private static HttpWebResponse deleteVM(string servicName, string deploymentName, string vmName)
        {
            var response = sendHttpReqeust(string.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments/{2}/roles/{3}?comp=media&quot;, SubscriptionID, servicName, deploymentName, vmName),
                &quot;DELETE&quot;,
                ClientCertificate,
                null,
                Version,
                null);
            return response;
        }
        #endregion
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">msdn.microsoft.com/en-us/library/azure/ee460799.aspx</span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>