# Extract and convert audio file
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Audio and video
* Windows Desktop App Development
## Topics
* Media
## IsPublished
* True
## ModifiedDate
* 2013-07-08 09:23:12
## Description

<h1>Extract and convert audio file (VBExtractAudioFile)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The sample demonstrates how to extract and convert audio file formats, which include wav, mp3 and mp4 files.</p>
<p class="MsoNormal">The sample is used to extract music file formats. We usually play music with Windows Media Player or other music-playing software. If we find our favorite music clip, we can use the function of this sample to extract it and convert it
 into another file format. All technology mentioned above is based on Expression Encoder SDK 3.0. When you install Expression Encoder 3.0, you can use Visual Studio 2012 to add a reference to it. In this way, you don't have to install the SDK installation kits
 individually.</p>
<p class="MsoNormal">The sample uses Expression Encoder SDK 3 to output *.mp4 or *.wma file. The .mp3 audio format is currently not supported as output format in Expression Encoder 3.
</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">1. Please install a free version, called &quot;Microsoft Expression Encoder 3&quot; at the link as follows:</p>
<p class="MsoNormal"><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=b6c8015b-e5de-46c0-98cd-1be12eef89a8">http://www.microsoft.com/downloads/en/details.aspx?FamilyID=b6c8015b-e5de-46c0-98cd-1be12eef89a8</a>
</p>
<p class="MsoNormal">The free version is a feature-filled VC-1 encoding application that supports the following:</p>
<p class="MsoNormal" style="text-indent:36.0pt">- High performance multi-core encoding
</p>
<p class="MsoNormal" style="text-indent:36.0pt">- Crop/scale/de - interlace operation</p>
<p class="MsoNormal" style="text-indent:36.0pt">- Multi-clip editing</p>
<p class="MsoNormal" style="text-indent:36.0pt">- A/B compares</p>
<p class="MsoNormal" style="text-indent:36.0pt">- live encoding</p>
<p class="MsoNormal" style="text-indent:36.0pt">- Up to 10 minutes of screen capture</p>
<p class="MsoNormal" style="text-indent:36.0pt">- Smart encoding</p>
<p class="MsoNormal" style="text-indent:36.0pt">- Silverlight templates</p>
<p class="MsoNormal" style="text-indent:36.0pt"><span style="">&nbsp;</span>- Multi-channel
</p>
<p class="MsoNormal" style="text-indent:36.0pt">- Audio import and export </p>
<p class="MsoNormal"><span style="">&nbsp; </span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>- Rich metadata support</p>
<p class="MsoNormal"><span style="">&nbsp;</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>- Presets and custom plug-ins as well as </p>
<p class="MsoNormal" style="text-indent:36.0pt">- Full access to the .NET SDK for all above features</p>
<p class="MsoNormal">The IIS Smooth Streaming version adds:</p>
<p class="MsoNormal" style="text-indent:36.0pt">- H.264 encoding</p>
<p class="MsoNormal" style="text-indent:36.0pt">- Smooth streaming encoding</p>
<p class="MsoNormal" style="text-indent:36.0pt">- Native support of MP4/H.264, TS, M2TS, AVCHD, MPEG-2, ISM, ISMV, AAC and AC-3 files</p>
<p class="MsoNormal" style="text-indent:36.0pt">- Unlimited screen capture durations</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1. Install Microsoft Expression Encoder 3. </p>
<p class="MsoNormal">Step2. Build and run the sample project in Visual Studio 2012.
</p>
<p class="MsoNormal">Step3. Prepare a .wma or .mp4 or .mp3 audio file.<span style="">&nbsp;
</span>Click the button which is written as &quot;Choose Audio File...&quot; and select the audio file.
</p>
<p class="MsoNormal">Step4. Click the play button and drag the block on the progress bar to seek the position that you want to start extracting.<span style="">&nbsp;
</span>Then, you click the &quot;Set Start Point&quot; button. Do the same operation to set the end of extract file.<span style="">&nbsp;
</span>It's important that you don't set the extract end point before the start point.</p>
<p class="MsoNormal">Step5. Select the audio output file format between WMA and MP4. Set the output directory.</p>
<p class="MsoNormal">Step6. Click the &quot;Extract&quot; button to extract the audio file.<span style="">&nbsp;
</span>If it succeeds, you will be informed the output file path.<span style="">&nbsp;
</span>You can play the output audio file to check if the audio clip is correct.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">1 .The sample uses the Windows Media Player control to play the source audio file. The following MSDN article introduces how to embed the Windows Media Player ActiveX control in a Windows Form.
<a href="http://msdn.microsoft.com/en-us/library/dd562851.aspx">http://msdn.microsoft.com/en-us/library/dd562851.aspx</a><span style="">&nbsp;
</span></p>
<p class="MsoNormal">We play a specified audio file in the Windows Media Player control by setting its URL property and calling AxWindowsMediaPlayer.Ctlcontrols.open.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Me.player.URL = openAudioFileDialog.FileName
         Me.player.Ctlcontrols.play()

</pre>
<pre id="codePreview" class="vb">
Me.player.URL = openAudioFileDialog.FileName
         Me.player.Ctlcontrols.play()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">When the form is being closed, we call the AxWindowsMediaPlayer.close() method to release Windows Media Player resources.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Releases Windows Media Player resources.
        Me.player.close()
    End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Releases Windows Media Player resources.
        Me.player.close()
    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">In order to get the current playing position in the media item, and save the start and end points, we use the AxWindowsMediaPlayer.Ctlcontrols.currentPosition property. It contains the current position in the media item in seconds from
 the beginning:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If btnSetBeginEndPoints.Tag.Equals(&quot;SetStartPoint&quot;) Then
                ' Save the startpoint.
                ' player.Ctlcontrols.currentPosition contains the current 
                ' position in the media item in seconds from the beginning.
                Me.tbStartpoint.Text = (player.Ctlcontrols.currentPosition * 1000).ToString(&quot;0&quot;)
                Me.tbEndpoint.Text = &quot;&quot;


                Me.btnSetBeginEndPoints.Text = &quot;Set End Point&quot;
                Me.btnSetBeginEndPoints.Tag = &quot;SetEndPoint&quot;
            ElseIf btnSetBeginEndPoints.Tag.Equals(&quot;SetEndPoint&quot;) Then
                ' Check if the startpoint is in front of the endpoint.
                Dim endPoint As Integer = CInt(Fix(player.Ctlcontrols.currentPosition * 1000))
                If endPoint &lt;= Integer.Parse(Me.tbStartpoint.Text) Then
                    MessageBox.Show(&quot;Audio endpoint is overlapped. Please reset the endpoint.&quot;)
                Else
                    ' Save the endpoint.
                    Me.tbEndpoint.Text = endPoint.ToString()


                    Me.btnSetBeginEndPoints.Text = &quot;Set Start Point&quot;
                    Me.btnSetBeginEndPoints.Tag = &quot;SetStartPoint&quot;
                End If
            End If

</pre>
<pre id="codePreview" class="vb">
If btnSetBeginEndPoints.Tag.Equals(&quot;SetStartPoint&quot;) Then
                ' Save the startpoint.
                ' player.Ctlcontrols.currentPosition contains the current 
                ' position in the media item in seconds from the beginning.
                Me.tbStartpoint.Text = (player.Ctlcontrols.currentPosition * 1000).ToString(&quot;0&quot;)
                Me.tbEndpoint.Text = &quot;&quot;


                Me.btnSetBeginEndPoints.Text = &quot;Set End Point&quot;
                Me.btnSetBeginEndPoints.Tag = &quot;SetEndPoint&quot;
            ElseIf btnSetBeginEndPoints.Tag.Equals(&quot;SetEndPoint&quot;) Then
                ' Check if the startpoint is in front of the endpoint.
                Dim endPoint As Integer = CInt(Fix(player.Ctlcontrols.currentPosition * 1000))
                If endPoint &lt;= Integer.Parse(Me.tbStartpoint.Text) Then
                    MessageBox.Show(&quot;Audio endpoint is overlapped. Please reset the endpoint.&quot;)
                Else
                    ' Save the endpoint.
                    Me.tbEndpoint.Text = endPoint.ToString()


                    Me.btnSetBeginEndPoints.Text = &quot;Set Start Point&quot;
                    Me.btnSetBeginEndPoints.Tag = &quot;SetStartPoint&quot;
                End If
            End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">2. The sample uses following helper function to cut the audio file from start point to endpoint, and output the clip as the selected audio format.<span style="">&nbsp;
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Shared Function ExtractAudio(ByVal sourceAudioFile As String, ByVal outputDirectory As String, ByVal outputType As OutputAudioType, ByVal startpoint As Double, ByVal endpoint As Double) As String
      Using [job] As New Job()
          Dim src As New MediaItem(sourceAudioFile)
          Select Case outputType
              Case OutputAudioType.MP4
                  src.OutputFormat = New MP4OutputFormat()
                  src.OutputFormat.AudioProfile = New AacAudioProfile()
                  src.OutputFormat.AudioProfile.Codec = AudioCodec.AAC
                  src.OutputFormat.AudioProfile.BitsPerSample = 24
              Case OutputAudioType.WMA
                  src.OutputFormat = New WindowsMediaOutputFormat()
                  src.OutputFormat.AudioProfile = New WmaAudioProfile()
                  src.OutputFormat.AudioProfile.Bitrate = New VariableConstrainedBitrate(128, 192)
                  src.OutputFormat.AudioProfile.Codec = AudioCodec.WmaProfessional
                  src.OutputFormat.AudioProfile.BitsPerSample = 24
          End Select


          Dim spanStart As TimeSpan = TimeSpan.FromMilliseconds(startpoint)
          src.Sources(0).Clips(0).StartTime = spanStart
          Dim spanEnd As TimeSpan = TimeSpan.FromMilliseconds(endpoint)
          src.Sources(0).Clips(0).EndTime = spanEnd


          [job].MediaItems.Add(src)
          [job].OutputDirectory = outputDirectory
          [job].Encode()


          Return [job].MediaItems(0).ActualOutputFileFullPath
      End Using
  End Function

</pre>
<pre id="codePreview" class="vb">
Public Shared Function ExtractAudio(ByVal sourceAudioFile As String, ByVal outputDirectory As String, ByVal outputType As OutputAudioType, ByVal startpoint As Double, ByVal endpoint As Double) As String
      Using [job] As New Job()
          Dim src As New MediaItem(sourceAudioFile)
          Select Case outputType
              Case OutputAudioType.MP4
                  src.OutputFormat = New MP4OutputFormat()
                  src.OutputFormat.AudioProfile = New AacAudioProfile()
                  src.OutputFormat.AudioProfile.Codec = AudioCodec.AAC
                  src.OutputFormat.AudioProfile.BitsPerSample = 24
              Case OutputAudioType.WMA
                  src.OutputFormat = New WindowsMediaOutputFormat()
                  src.OutputFormat.AudioProfile = New WmaAudioProfile()
                  src.OutputFormat.AudioProfile.Bitrate = New VariableConstrainedBitrate(128, 192)
                  src.OutputFormat.AudioProfile.Codec = AudioCodec.WmaProfessional
                  src.OutputFormat.AudioProfile.BitsPerSample = 24
          End Select


          Dim spanStart As TimeSpan = TimeSpan.FromMilliseconds(startpoint)
          src.Sources(0).Clips(0).StartTime = spanStart
          Dim spanEnd As TimeSpan = TimeSpan.FromMilliseconds(endpoint)
          src.Sources(0).Clips(0).EndTime = spanEnd


          [job].MediaItems.Add(src)
          [job].OutputDirectory = outputDirectory
          [job].Encode()


          Return [job].MediaItems(0).ActualOutputFileFullPath
      End Using
  End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">btnExtract_Click in MainForm.vb calls the helper method to extract the audio file
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Extract the audio file.
          Dim outputType As OutputAudioType = CType(Me.cmbOutputAudioType.SelectedValue, OutputAudioType)
          Dim outputFileName As String = ExpressionEncoderWrapper.ExtractAudio(sourceAudioFile, outputDirectory, outputType, Double.Parse(startpoint), Double.Parse(endpoint))

</pre>
<pre id="codePreview" class="vb">
' Extract the audio file.
          Dim outputType As OutputAudioType = CType(Me.cmbOutputAudioType.SelectedValue, OutputAudioType)
          Dim outputFileName As String = ExpressionEncoderWrapper.ExtractAudio(sourceAudioFile, outputDirectory, outputType, Double.Parse(startpoint), Double.Parse(endpoint))

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal">Expression Encoder SDK Programming Reference </p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ff396833(v=Expression.40).aspx">http://msdn.microsoft.com/en-us/library/ff396833(v=Expression.40).aspx</a>
</p>
<p class="MsoNormal">Microsoft Expression Encoder 3 FAQ </p>
<p class="MsoNormal"><a href="http://social.expression.microsoft.com/Forums/en-US/encoder/thread/b7f76ae5-8c58-4c65-994c-45052f7a5cb3/">http://social.expression.microsoft.com/Forums/en-US/encoder/thread/b7f76ae5-8c58-4c65-994c-45052f7a5cb3/</a>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
