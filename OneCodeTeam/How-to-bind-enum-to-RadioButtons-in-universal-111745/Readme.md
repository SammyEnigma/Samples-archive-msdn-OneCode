# How to bind enum to RadioButtons in universal Windows apps
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Phone 8
* Windows Store app Development
* Windows Phone Development
* Windows 8.1
* Windows Phone 8.1
* universal windows app
## Topics
* Enum
* universal app
* radiobutton
## IsPublished
* True
## ModifiedDate
* 2015-01-19 06:16:11
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1>How to bind enum to RadioButton in universal Windows apps</h1>
<h2>Introduction</h2>
<p>The Customer class in this sample contains a &lsquo;Sport&rsquo; enum type property; the sample shows how to convert Enum type To Boolean type, and vice versa. It also shows how to bind the enum type to RadioButtons.</p>
<p>This sample was upgraded to universal Windows app which targets both Windows 8.1 and Windows Phone 8.1.</p>
<h2>Running the Sample</h2>
<ol>
<li>After you launch the sample on Windows 8.1, this screen will be displayed. </li></ol>
<p><img id="132679" src="/site/view/file/132679/1/1.png" alt="" width="640" height="360" style="border:1px solid black"></p>
<p>The sample launching on Windows Phone 8.1:</p>
<p><img id="132680" src="/site/view/file/132680/1/2.png" alt="" width="355" height="592"></p>
<p>&nbsp;</p>
<p><span style="font-size:10px">&nbsp; &nbsp; &nbsp; 2. Click to select one of the items in GridView, the edit page will be displayed. You can select other RadioButton options and click &lsquo;Save&rsquo; at the bottom of the page.</span></p>
<p><img id="132681" src="/site/view/file/132681/1/3.png" alt="" width="640" height="360" style="border:1px solid black"></p>
<p><img id="132682" src="/site/view/file/132682/1/4.png" alt="" width="355" height="592"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2>Using the Code</h2>
<p>The code below shows how to create EnumToBoolConverter:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class EnumToBoolConverter : IValueConverter

   {

       public object Convert(object value, Type targetType, object parameter, string language)

       {

           string param = parameter as string;

           if (param == null)

               return DependencyProperty.UnsetValue;

           if (Enum.IsDefined(value.GetType(), value) == false)

               return DependencyProperty.UnsetValue;

 

           object paramValue = Enum.Parse(value.GetType(), param);

           return paramValue.Equals(value);

       }

 

       public object ConvertBack(object value, Type targetType, object parameter, string language)

       {

           string param = parameter as string;

           if (parameter == null)

               return DependencyProperty.UnsetValue;

 

           return Enum.Parse(typeof(Sport), param);

       }

   }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;EnumToBoolConverter&nbsp;:&nbsp;IValueConverter&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;Convert(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;Type&nbsp;targetType,&nbsp;<span class="cs__keyword">object</span>&nbsp;parameter,&nbsp;<span class="cs__keyword">string</span>&nbsp;language)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;param&nbsp;=&nbsp;parameter&nbsp;<span class="cs__keyword">as</span>&nbsp;<span class="cs__keyword">string</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(param&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;DependencyProperty.UnsetValue;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Enum.IsDefined(<span class="cs__keyword">value</span>.GetType(),&nbsp;<span class="cs__keyword">value</span>)&nbsp;==&nbsp;<span class="cs__keyword">false</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;DependencyProperty.UnsetValue;&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;paramValue&nbsp;=&nbsp;Enum.Parse(<span class="cs__keyword">value</span>.GetType(),&nbsp;param);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;paramValue.Equals(<span class="cs__keyword">value</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;ConvertBack(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;Type&nbsp;targetType,&nbsp;<span class="cs__keyword">object</span>&nbsp;parameter,&nbsp;<span class="cs__keyword">string</span>&nbsp;language)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;param&nbsp;=&nbsp;parameter&nbsp;<span class="cs__keyword">as</span>&nbsp;<span class="cs__keyword">string</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(parameter&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;DependencyProperty.UnsetValue;&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Enum.Parse(<span class="cs__keyword">typeof</span>(Sport),&nbsp;param);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}<span style="font-size:10px">&nbsp;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>The code below shows the binding in xaml:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;StackPanel Grid.Row=&quot;3&quot; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; VerticalAlignment=&quot;Top&quot; Margin=&quot;0,15,0,0&quot;&gt; 
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Basketball, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Basketball&lt;/RadioButton&gt; 
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Football, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Football&lt;/RadioButton&gt; 
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Baseball, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Baseball&lt;/RadioButton&gt; 
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Swimming, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Swimming&lt;/RadioButton&gt; 
&lt;/StackPanel&gt; 
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;3&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,15,0,0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RadioButton</span>&nbsp;<span class="xaml__attr_name">IsChecked</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=FavouriteSport,Converter={StaticResource&nbsp;ETBConverter},ConverterParameter=Basketball,&nbsp;Mode=TwoWay}&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,0,0,10&quot;</span><span class="xaml__tag_start">&gt;</span>Basketball<span class="xaml__tag_end">&lt;/RadioButton&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RadioButton</span>&nbsp;<span class="xaml__attr_name">IsChecked</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=FavouriteSport,Converter={StaticResource&nbsp;ETBConverter},ConverterParameter=Football,&nbsp;Mode=TwoWay}&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,0,0,10&quot;</span><span class="xaml__tag_start">&gt;</span>Football<span class="xaml__tag_end">&lt;/RadioButton&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RadioButton</span>&nbsp;<span class="xaml__attr_name">IsChecked</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=FavouriteSport,Converter={StaticResource&nbsp;ETBConverter},ConverterParameter=Baseball,&nbsp;Mode=TwoWay}&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,0,0,10&quot;</span><span class="xaml__tag_start">&gt;</span>Baseball<span class="xaml__tag_end">&lt;/RadioButton&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RadioButton</span>&nbsp;<span class="xaml__attr_name">IsChecked</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=FavouriteSport,Converter={StaticResource&nbsp;ETBConverter},ConverterParameter=Swimming,&nbsp;Mode=TwoWay}&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,0,0,10&quot;</span><span class="xaml__tag_start">&gt;</span>Swimming<span class="xaml__tag_end">&lt;/RadioButton&gt;</span>&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2>More Information</h2>
<p>IValueConverter Interface</p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/apps/BR209903">http://msdn.microsoft.com/en-us/library/windows/apps/BR209903</a></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
