# How to unzip files to Azure blob storage in Azure
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* .NET Framework
* Cloud
## Topics
* Azure
* Worker Role
## IsPublished
* True
## ModifiedDate
* 2015-03-01 06:56:12
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<p><strong>How to unzip files to Azure blob storage in Azure</strong><strong>&nbsp;</strong></p>
<h2>Introduction</h2>
<p>For users with large amounts of unstructured data to store in the cloud, Blob storage offers a cost-effective and scalable solution. Users can store documents, social data, images and text in Blob storage.&nbsp;</p>
<p>&nbsp;This sample demonstrates how to unzip files to Azure blob storage in Azure.&nbsp;Uploading thousands of small files one by one is very slow. It would be great if we could upload a zip file to Azure and unzip it directly into blob storage in Azure.&nbsp;</p>
<h2>Running the Sample</h2>
<p>You should do the steps below before running the code sample.</p>
<p>&nbsp;Step 1: Create a storage account</p>
<p>&nbsp; &nbsp;&nbsp;1. Go to the <a href="https://manage.windowsazure.com/">&nbsp;Windows Azure Management Portal</a> and sign in.</p>
<p>&nbsp;&nbsp;&nbsp; 2. Click &ldquo;New&rdquo; -&gt; &ldquo;data service&rdquo; -&gt; &ldquo;storage&rdquo;-&gt; &ldquo;quick create&rdquo;.</p>
<p>&nbsp;&nbsp; 3. Click &ldquo;Manage Access Keys&rdquo; and get the storage account name and the primary access key</p>
<p>Open <a href="http://home.aspx.cs/">UnZipService.cs</a> file and <a href="http://home.aspx./">
UnZipService.</a>vb, replace Storage Account with the storage account name you got, and Primary Access Key with the primary access key you got.</p>
<p>&nbsp;<img id="134406" src="/site/view/file/134406/1/1.png" alt="" width="619" height="239"></p>
<p><img id="134407" src="/site/view/file/134407/1/2.png" alt="" width="576" height="190"></p>
<p>&nbsp;</p>
<p>Step 2: Install package</p>
<p>&nbsp;&nbsp; 1. Click <strong>Manage NuGet Packages</strong> to install packages.</p>
<p>&nbsp;&nbsp;2. Install Windows Azure Storage.</p>
<p>Step 3:&nbsp; Run project in Visual Studio 2013</p>
<p>&nbsp;&nbsp; 1. Input the name of the container to which you want to upload files.</p>
<p>&nbsp;&nbsp; 2. Select the zip file to you want to unzip and upload.</p>
<p>&nbsp;&nbsp; 3. Click &quot;Unzip File and Upload to Blob&quot;.</p>
<p>&nbsp;</p>
<p>4. Select the container of which you want to view all blobs</p>
<p>&nbsp;</p>
<h2>Using the Code</h2>
<p>&nbsp;1. Write code to use DoNetZip to unzip the file to local storage.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public bool UnZipFiles(string strPath, string strContainerName)

       {

           bool bln = true;

           try

           {

               if (!string.IsNullOrEmpty(strPath) &amp;&amp; !string.IsNullOrEmpty(strContainerName))

               {

                   ZipFile zipFile = ZipFile.Read(strPath);

                   zipFile.ExtractAll(strLoacalStorage, ExtractExistingFileAction.OverwriteSilently);

                   DirectoryInfo TheFolder = new DirectoryInfo(strLoacalStorage);

                   ListAllFiles(TheFolder, strContainerName);

               }    

           }

           catch(Exception ex)

           {

               bln = false;

               throw ex;

           }

            

           return bln;

       }</pre>
<pre class="hidden">Public Function UnZipFiles(ByVal strPath As String, ByVal strContainerName As String) As Boolean Implements IUnZipWcfService.UnZipFiles

       Dim bln As Boolean = True

       Try

           If (Not String.IsNullOrEmpty(strPath)) AndAlso (Not String.IsNullOrEmpty(strContainerName)) Then

               Dim zipFile As ZipFile = zipFile.Read(strPath)

               zipFile.ExtractAll(strLoacalStorage, ExtractExistingFileAction.OverwriteSilently)

               Dim TheFolder As New DirectoryInfo(strLoacalStorage)

               ListAllFiles(TheFolder, strContainerName)

           End If

       Catch ex As Exception

           bln = False

           Throw ex

       End Try

       Return bln

   End Function</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;UnZipFiles(<span class="cs__keyword">string</span>&nbsp;strPath,&nbsp;<span class="cs__keyword">string</span>&nbsp;strContainerName)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;bln&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(strPath)&nbsp;&amp;&amp;&nbsp;!<span class="cs__keyword">string</span>.IsNullOrEmpty(strContainerName))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ZipFile&nbsp;zipFile&nbsp;=&nbsp;ZipFile.Read(strPath);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;zipFile.ExtractAll(strLoacalStorage,&nbsp;ExtractExistingFileAction.OverwriteSilently);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DirectoryInfo&nbsp;TheFolder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DirectoryInfo(strLoacalStorage);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListAllFiles(TheFolder,&nbsp;strContainerName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>(Exception&nbsp;ex)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bln&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;ex;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;bln;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p></p>
<p>2. Write code to list all files of the specified directory.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private void ListAllFiles(DirectoryInfo dirInfo, string strContainerName)

    {

        try

        {

            foreach (var file in dirInfo.GetFileSystemInfos())

            {

                if (file is FileInfo)

                {

                    FileInfo fileInfo = (FileInfo)file;

                    UploadToBlob((FileInfo)file, strContainerName);

                }

                else

                {

                    DirectoryInfo newinfo = (DirectoryInfo)file;

                    ListAllFiles(newinfo, strContainerName);

                }

            }

        }

        catch (Exception ex)

        {

            throw ex;

        }

    }</pre>
<pre class="hidden">Private Sub ListAllFiles(ByVal dirInfo As DirectoryInfo, ByVal strContainerName As String)

    Try

        For Each File As FileSystemInfo In dirInfo.GetFileSystemInfos()

            If TypeOf File Is FileInfo Then

                Dim fileInfo As FileInfo = CType(File, FileInfo)

                UploadToBlob(CType(File, FileInfo), strContainerName)

            Else

                Dim newinfo As DirectoryInfo = CType(File, DirectoryInfo)

                ListAllFiles(newinfo, strContainerName)

            End If

        Next File

    Catch ex As Exception

        Throw ex

    End Try

End Sub</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ListAllFiles(DirectoryInfo&nbsp;dirInfo,&nbsp;<span class="cs__keyword">string</span>&nbsp;strContainerName)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;file&nbsp;<span class="cs__keyword">in</span>&nbsp;dirInfo.GetFileSystemInfos())&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(file&nbsp;<span class="cs__keyword">is</span>&nbsp;FileInfo)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileInfo&nbsp;fileInfo&nbsp;=&nbsp;(FileInfo)file;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UploadToBlob((FileInfo)file,&nbsp;strContainerName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DirectoryInfo&nbsp;newinfo&nbsp;=&nbsp;(DirectoryInfo)file;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListAllFiles(newinfo,&nbsp;strContainerName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;ex;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:10px">&nbsp;</span></div>
<p></p>
<p>3. Write code to upload the file to Azure blob Storage</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private void UploadToBlob(FileInfo fileInfo, string strContainerName)

       {

           try

           {

               CloudBlobClient blobClient = Csa_storageAccount.CreateCloudBlobClient();

               CloudBlobContainer blobContainer = blobClient.GetContainerReference(strContainerName);

               blobContainer.CreateIfNotExists();

               blobContainer.SetPermissions(new BlobContainerPermissions

               {

                   PublicAccess = BlobContainerPublicAccessType.Blob

               });

               //Generates  a blobName

               string strPath = fileInfo.FullName;

               string strNewBlobName = string.Empty;

               int intIndex = strPath.IndexOf(strLoacalStorage, 0);

               if (intIndex &gt;= 0)

               {

                   int intStartIndex = intIndex &#43; strLoacalStorage.Length;

                   int intLength = strPath.Length - intStartIndex;

                   strPath = strPath.Substring(intStartIndex, intLength);

               }

               string[] strArrPathName = strPath.Split('\\');

               if (strArrPathName.Length &gt; 0)

               {

                   for (int i = 0; i &lt; strArrPathName.Length; i&#43;&#43;)

                   {

                       strNewBlobName &#43;= strArrPathName[i] &#43; &quot;_&quot;;

                   }

                   strNewBlobName = strNewBlobName.Substring(0, strNewBlobName.Length - 1);

               }

               if (!string.IsNullOrEmpty(strNewBlobName))

               {

                   CloudBlockBlob blob = blobContainer.GetBlockBlobReference(strNewBlobName);

                   //upload files

                   using (FileStream stream = fileInfo.OpenRead())

                   {

                       blob.UploadFromStream(stream);

                   }

                   fileInfo.Delete();

               }

           }

           catch (Exception ex)

           {

               if (fileInfo.Exists)

               {

                   fileInfo.Delete();

               }

               throw ex;

           }

       }</pre>
<pre class="hidden">Private Sub UploadToBlob(ByVal fileInfo As FileInfo, ByVal strContainerName As String)

      Try

          Dim blobClient As CloudBlobClient = Csa_storageAccount.CreateCloudBlobClient()

          Dim blobContainer As CloudBlobContainer = blobClient.GetContainerReference(strContainerName)

          blobContainer.CreateIfNotExists()

          blobContainer.SetPermissions(New BlobContainerPermissions With {.PublicAccess = BlobContainerPublicAccessType.Blob})

          'Generates  a blobName

          Dim strPath As String = fileInfo.FullName

          Dim strNewBlobName As String = String.Empty

          Dim intIndex As Integer = strPath.IndexOf(strLoacalStorage, 0)

          If intIndex &gt;= 0 Then

              Dim intStartIndex As Integer = intIndex &#43; strLoacalStorage.Length

              Dim intLength As Integer = strPath.Length - intStartIndex

              strPath = strPath.Substring(intStartIndex, intLength)

          End If

          Dim strArrPathName() As String = strPath.Split(&quot;\&quot;c)

          If strArrPathName.Length &gt; 0 Then

              For i As Integer = 0 To strArrPathName.Length - 1

                  strNewBlobName &amp;= strArrPathName(i) &amp; &quot;_&quot;

              Next i

              strNewBlobName = strNewBlobName.Substring(0, strNewBlobName.Length - 1)

          End If

          If Not String.IsNullOrEmpty(strNewBlobName) Then

              Dim blob As CloudBlockBlob = blobContainer.GetBlockBlobReference(strNewBlobName)

              'upload files

              Using stream As FileStream = fileInfo.OpenRead()

                  blob.UploadFromStream(stream)

              End Using

              fileInfo.Delete()

          End If

      Catch ex As Exception

          If fileInfo.Exists Then

              fileInfo.Delete()

          End If

          Throw ex

      End Try

  End Sub</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;UploadToBlob(FileInfo&nbsp;fileInfo,&nbsp;<span class="cs__keyword">string</span>&nbsp;strContainerName)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlobClient&nbsp;blobClient&nbsp;=&nbsp;Csa_storageAccount.CreateCloudBlobClient();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlobContainer&nbsp;blobContainer&nbsp;=&nbsp;blobClient.GetContainerReference(strContainerName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blobContainer.CreateIfNotExists();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blobContainer.SetPermissions(<span class="cs__keyword">new</span>&nbsp;BlobContainerPermissions&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PublicAccess&nbsp;=&nbsp;BlobContainerPublicAccessType.Blob&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Generates&nbsp;&nbsp;a&nbsp;blobName</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;strPath&nbsp;=&nbsp;fileInfo.FullName;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;strNewBlobName&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;intIndex&nbsp;=&nbsp;strPath.IndexOf(strLoacalStorage,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(intIndex&nbsp;&gt;=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;intStartIndex&nbsp;=&nbsp;intIndex&nbsp;&#43;&nbsp;strLoacalStorage.Length;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;intLength&nbsp;=&nbsp;strPath.Length&nbsp;-&nbsp;intStartIndex;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;strPath&nbsp;=&nbsp;strPath.Substring(intStartIndex,&nbsp;intLength);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;strArrPathName&nbsp;=&nbsp;strPath.Split(<span class="cs__string">'\\'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(strArrPathName.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;strArrPathName.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;strNewBlobName&nbsp;&#43;=&nbsp;strArrPathName[i]&nbsp;&#43;&nbsp;<span class="cs__string">&quot;_&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;strNewBlobName&nbsp;=&nbsp;strNewBlobName.Substring(<span class="cs__number">0</span>,&nbsp;strNewBlobName.Length&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(strNewBlobName))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlockBlob&nbsp;blob&nbsp;=&nbsp;blobContainer.GetBlockBlobReference(strNewBlobName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//upload&nbsp;files</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(FileStream&nbsp;stream&nbsp;=&nbsp;fileInfo.OpenRead())&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blob.UploadFromStream(stream);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileInfo.Delete();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(fileInfo.Exists)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileInfo.Delete();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;ex;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p></p>
<p>&nbsp;</p>
<h2>More Information</h2>
<p>CloudStorageAccount Class</p>
<p>&nbsp; <a href="http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.cloudstorageaccount.aspx">
http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.cloudstorageaccount.aspx</a></p>
<p>&nbsp;</p>
<p>CloudBlobClient Class</p>
<p>&nbsp; <a href="http://msdn.microsoft.com/en-us/library/azure/microsoft.windowsazure.storage.blob.cloudblobclient.aspx">
http://msdn.microsoft.com/en-us/library/azure/microsoft.windowsazure.storage.blob.cloudblobclient.aspx</a></p>
<p>&nbsp;</p>
<p>CloudBlobContainer Class</p>
<p>&nbsp;&nbsp; <a href="http://msdn.microsoft.com/en-us/library/azure/microsoft.windowsazure.storage.blob.cloudblobcontainer.aspx">
http://msdn.microsoft.com/en-us/library/azure/microsoft.windowsazure.storage.blob.cloudblobcontainer.aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>CloudBlob.UploadFromStream Method (Stream)</p>
<p>&nbsp;&nbsp; <a href="http://msdn.microsoft.com/en-us/library/azure/ee772826(v=azure.95).aspx">
http://msdn.microsoft.com/en-us/library/azure/ee772826(v=azure.95).aspx</a></p>
<p>&nbsp;</p>
<p>DotNetZip - Zip and Unzip in C#, VB, any .NET language</p>
<p>&nbsp;&nbsp; <a href="http://dotnetzip.codeplex.com/">http://dotnetzip.codeplex.com/</a></p>
<p>&nbsp;</p>
