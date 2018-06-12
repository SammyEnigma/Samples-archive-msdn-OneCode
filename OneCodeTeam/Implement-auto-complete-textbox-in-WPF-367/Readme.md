# Implement auto-complete textbox in WPF (VBWPFAutoCompleteTextBox)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* WPF
## Topics
* Controls
* Auto-complete
## IsPublished
* True
## ModifiedDate
* 2011-04-05 07:34:59
## Description

<p style="font-family:Courier New"></p>
<h2>WPF APPLICATION : VBWPFAutoCompleteTextBox Project Overview<br>
<br>
AutoCompleteTextBox Sample<br>
</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Provide an easy implementation of AutoCompleteTextBox in WPF<br>
&nbsp; <br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
&nbsp; 1. Retemplate ComboBox to make it looks like TextBox.<br>
&nbsp; 2. Extend ComboBoxItem so that we can hightlight the already entered part<br>
&nbsp; &nbsp; &nbsp;in the dropdown list.<br>
&nbsp; 3. Get reference to the TextBox part of the ComboBox, and hook up <br>
&nbsp; &nbsp; &nbsp;TextBox.TextChanged event.<br>
&nbsp; 4. In the TextBox.TextChanged event handler, we filter the underlying <br>
&nbsp; &nbsp; &nbsp;datasource and create new list source with our customized ComboBox<br>
&nbsp; &nbsp; &nbsp;Items.<br>
&nbsp; <br>
<br>
<br>
&nbsp; </p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
</p>
<h3>Demo</h3>
<p style="font-family:Courier New"><br>
Step1. Build the sample project in Visual Studio 2008.<br>
<br>
Step2. Start Without Debugging, and the mian window of the project will show.<br>
<br>
Step3. Input a string (e.g. &quot;app&quot;) in the text box in the top of the window, and it<br>
will list all the items which starts with the input string.<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
