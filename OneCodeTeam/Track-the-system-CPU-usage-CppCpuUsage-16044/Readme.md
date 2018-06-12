# Track the system CPU usage (CppCpuUsage)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* CPU
* PerformanceCounter
## IsPublished
* True
## ModifiedDate
* 2012-03-12 12:44:17
## Description

<h1>Track the system CPU usage (CppCpuUsage)</h1>
<h2>Introduction</h2>
<p>This code sample demonstrates how to use the PerformanceCounter to track the CPU usage of the system or a certain process.&nbsp; It lets the user visualize a Plot of one or more Performance Counter Value against time.</p>
<p>&nbsp;</p>
<h2>Building the Sample</h2>
<ol>
<li>Open Solution in Visual Studio 2010. </li><li>Go to &ldquo;Build&rdquo; -&gt; &ldquo;Build Solution&rdquo; </li></ol>
<p>&nbsp;</p>
<h2>Running the Sample</h2>
<p>Open Solution in Visual Studio 2010</p>
<p>Go to &ldquo;Debug&rdquo; -&gt; &ldquo;Start without Debugging&rdquo;</p>
<p>From Drop Down, Select Performance Counter of Interest.</p>
<p>Click &ldquo;Add&rdquo;</p>
<p>See a graph of Performance Counter value against time.</p>
<p>You may add more counters by Repeating Steps 3 and 4.</p>
<p><img src="/site/view/file/54169/1/image001.png" alt="" width="581" height="448"></p>
<p>&nbsp;</p>
<h2>Using the Code</h2>
<p>This sample code functions in following high-level steps</p>
<p>1. First List Down Valid Counter Names. For each processor a &ldquo;Processor Time&rdquo; and &ldquo;Idle Time&rdquo; performance counter is added. For each running process a &ldquo;Processor Time&rdquo; performance counter is added.</p>
<p>2. A List of &ldquo;Selected&rdquo; Performance Counter is maintained. It is initialized to Empty Vector. When user selects a performance counter and clicks &ldquo;Add&rdquo;, that counter is added to the vector.</p>
<p>3. A Thread runs in parallel. This Periodically, Queries each Performance Counter in the &ldquo;Selected&rdquo; list. The performance counters are plotted against time using GDI&#43;.</p>
<p>Following are the reusable components of the Sample Code</p>
<p>1. Get the Processor Count of System</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">DWORD GetProcessorCount()
{
    SYSTEM_INFO sysinfo; 
    DWORD dwNumberOfProcessors;
 
    GetSystemInfo(&amp;sysinfo);
 
    dwNumberOfProcessors = sysinfo.dwNumberOfProcessors;
 
    return dwNumberOfProcessors;
}
</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__datatype">DWORD</span>&nbsp;GetProcessorCount()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SYSTEM_INFO&nbsp;sysinfo;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;dwNumberOfProcessors;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;GetSystemInfo(&amp;sysinfo);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dwNumberOfProcessors&nbsp;=&nbsp;sysinfo.dwNumberOfProcessors;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;dwNumberOfProcessors;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">2. Get list of running process</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">vector&lt;PCTSTR&gt; GetProcessNames()
{
    DWORD dwProcessID[SIZE];
    DWORD cbProcess;
    DWORD cProcessID;
    BOOL fResult = FALSE;
    DWORD index;
 
    HANDLE hProcess;
    HMODULE lphModule[SIZE];
    DWORD cbNeeded;    
    int len;
 
    vector&lt;PCTSTR&gt; vProcessNames;
 
    TCHAR * szProcessName;
    TCHAR * szProcessNameWithPrefix;
 
    fResult = EnumProcesses(dwProcessID, sizeof(dwProcessID), &amp;cbProcess);
 
    if(!fResult)
    {
        goto cleanup;
    }
 
    cProcessID = cbProcess / sizeof(DWORD);
 
    for( index = 0; index &lt; cProcessID; index&#43;&#43; )
    {
        szProcessName = new TCHAR[MAX_PATH];        
        hProcess = OpenProcess( PROCESS_QUERY_INFORMATION |
        PROCESS_VM_READ,
        FALSE, dwProcessID[index] );
        if( NULL != hProcess )
        {
            if ( EnumProcessModulesEx( hProcess, lphModule, sizeof(lphModule), 
                &amp;cbNeeded,LIST_MODULES_ALL) )
            {
                if( GetModuleBaseName( hProcess, lphModule[0], szProcessName, 
                    MAX_PATH ) )
                {
                    len = _tcslen(szProcessName);
                    _tcscpy(szProcessName&#43;len-4, TEXT(&quot;\0&quot;));
                    
                    bool fProcessExists = false;
                    int count = 0;
                    szProcessNameWithPrefix = new TCHAR[MAX_PATH];
                    _stprintf(szProcessNameWithPrefix, TEXT(&quot;%s&quot;), szProcessName);
                    do
                    {
                        if(count&gt;0)
                        {
                            _stprintf(szProcessNameWithPrefix,TEXT(&quot;%s#%d&quot;),szProcessName,count);
                        }
                        fProcessExists = false;
                        for(auto it = vProcessNames.begin(); it &lt; vProcessNames.end(); it&#43;&#43;)
                        {
                            if(_tcscmp(*it,szProcessNameWithPrefix)==0)
                            {
                                fProcessExists = true;
                                break;
                            }
                        }                    
                        count&#43;&#43;;
                    }
                    while(fProcessExists);
                    
                    vProcessNames.push_back(szProcessNameWithPrefix);
                }
            }
        }
    }
 
cleanup:
    szProcessName = NULL;
    szProcessNameWithPrefix = NULL;
    return vProcessNames;
}
</pre>
<div class="preview">
<pre class="cplusplus">vector&lt;<span class="cpp__datatype">PCTSTR</span>&gt;&nbsp;GetProcessNames()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;dwProcessID[SIZE];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;cbProcess;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;cProcessID;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;fResult&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;index;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HANDLE</span>&nbsp;hProcess;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HMODULE</span>&nbsp;lphModule[SIZE];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;cbNeeded;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;len;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;vector&lt;<span class="cpp__datatype">PCTSTR</span>&gt;&nbsp;vProcessNames;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">TCHAR</span>&nbsp;*&nbsp;szProcessName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">TCHAR</span>&nbsp;*&nbsp;szProcessNameWithPrefix;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;fResult&nbsp;=&nbsp;EnumProcesses(dwProcessID,&nbsp;<span class="cpp__keyword">sizeof</span>(dwProcessID),&nbsp;&amp;cbProcess);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(!fResult)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">goto</span>&nbsp;cleanup;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cProcessID&nbsp;=&nbsp;cbProcess&nbsp;/&nbsp;<span class="cpp__keyword">sizeof</span>(<span class="cpp__datatype">DWORD</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>(&nbsp;index&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;index&nbsp;&lt;&nbsp;cProcessID;&nbsp;index&#43;&#43;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;szProcessName&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;<span class="cpp__datatype">TCHAR</span>[MAX_PATH];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hProcess&nbsp;=&nbsp;OpenProcess(&nbsp;PROCESS_QUERY_INFORMATION&nbsp;|&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PROCESS_VM_READ,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FALSE,&nbsp;dwProcessID[index]&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;NULL&nbsp;!=&nbsp;hProcess&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;EnumProcessModulesEx(&nbsp;hProcess,&nbsp;lphModule,&nbsp;<span class="cpp__keyword">sizeof</span>(lphModule),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;cbNeeded,LIST_MODULES_ALL)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;GetModuleBaseName(&nbsp;hProcess,&nbsp;lphModule[<span class="cpp__number">0</span>],&nbsp;szProcessName,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MAX_PATH&nbsp;)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;len&nbsp;=&nbsp;_tcslen(szProcessName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_tcscpy(szProcessName&#43;len<span class="cpp__number">-4</span>,&nbsp;TEXT(<span class="cpp__string">&quot;\0&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">bool</span>&nbsp;fProcessExists&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;count&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;szProcessNameWithPrefix&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;<span class="cpp__datatype">TCHAR</span>[MAX_PATH];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stprintf(szProcessNameWithPrefix,&nbsp;TEXT(<span class="cpp__string">&quot;%s&quot;</span>),&nbsp;szProcessName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(count&gt;<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stprintf(szProcessNameWithPrefix,TEXT(<span class="cpp__string">&quot;%s#%d&quot;</span>),szProcessName,count);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fProcessExists&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>(auto&nbsp;it&nbsp;=&nbsp;vProcessNames.begin();&nbsp;it&nbsp;&lt;&nbsp;vProcessNames.end();&nbsp;it&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(_tcscmp(*it,szProcessNameWithPrefix)==<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fProcessExists&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;count&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">while</span>(fProcessExists);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vProcessNames.push_back(szProcessNameWithPrefix);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
cleanup:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;szProcessName&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;szProcessNameWithPrefix&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;vProcessNames;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">3. Get list of valid&nbsp; Performance Counter Names</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">vector&lt;PCTSTR&gt; GetValidCounterNames()
{
    vector&lt;PCTSTR&gt; validCounterNames;
    DWORD dwNumberOfProcessors = GetProcessorCount();
    DWORD index;
    vector&lt;PCTSTR&gt; vszProcessNames;
    TCHAR * szCounterName;
 
    validCounterNames.push_back(TEXT(&quot;\\Processor(_Total)\\% Processor Time&quot;));
    validCounterNames.push_back(TEXT(&quot;\\Processor(_Total)\\% Idle Time&quot;));
 
    for( index = 0; index &lt; dwNumberOfProcessors; index&#43;&#43; )
    {
        szCounterName = new TCHAR[MAX_PATH];
        _stprintf(szCounterName, TEXT(&quot;\\Processor(%u)\\%% Processor Time&quot;),index);
        validCounterNames.push_back(szCounterName);
        szCounterName = new TCHAR[MAX_PATH];
        _stprintf(szCounterName, TEXT(&quot;\\Processor(%u)\\%% Idle Time&quot;),index);
        validCounterNames.push_back(szCounterName);
    }
 
    vszProcessNames = GetProcessNames();
 
    for(auto element = vszProcessNames.begin(); 
        element &lt; vszProcessNames.end(); 
        element&#43;&#43; )
    {
        szCounterName = new TCHAR[MAX_PATH];
        _stprintf(szCounterName, TEXT(&quot;\\Process(%s)\\%% Processor Time&quot;),*element);
        validCounterNames.push_back(szCounterName);
    }    
    
cleanup:
    szCounterName = NULL;
    return validCounterNames;
}
</pre>
<div class="preview">
<pre class="cplusplus">vector&lt;<span class="cpp__datatype">PCTSTR</span>&gt;&nbsp;GetValidCounterNames()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;vector&lt;<span class="cpp__datatype">PCTSTR</span>&gt;&nbsp;validCounterNames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;dwNumberOfProcessors&nbsp;=&nbsp;GetProcessorCount();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;vector&lt;<span class="cpp__datatype">PCTSTR</span>&gt;&nbsp;vszProcessNames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">TCHAR</span>&nbsp;*&nbsp;szCounterName;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;validCounterNames.push_back(TEXT(<span class="cpp__string">&quot;\\Processor(_Total)\\%&nbsp;Processor&nbsp;Time&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;validCounterNames.push_back(TEXT(<span class="cpp__string">&quot;\\Processor(_Total)\\%&nbsp;Idle&nbsp;Time&quot;</span>));&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>(&nbsp;index&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;index&nbsp;&lt;&nbsp;dwNumberOfProcessors;&nbsp;index&#43;&#43;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;szCounterName&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;<span class="cpp__datatype">TCHAR</span>[MAX_PATH];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stprintf(szCounterName,&nbsp;TEXT(<span class="cpp__string">&quot;\\Processor(%u)\\%%&nbsp;Processor&nbsp;Time&quot;</span>),index);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;validCounterNames.push_back(szCounterName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;szCounterName&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;<span class="cpp__datatype">TCHAR</span>[MAX_PATH];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stprintf(szCounterName,&nbsp;TEXT(<span class="cpp__string">&quot;\\Processor(%u)\\%%&nbsp;Idle&nbsp;Time&quot;</span>),index);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;validCounterNames.push_back(szCounterName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;vszProcessNames&nbsp;=&nbsp;GetProcessNames();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>(auto&nbsp;element&nbsp;=&nbsp;vszProcessNames.begin();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;element&nbsp;&lt;&nbsp;vszProcessNames.end();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;element&#43;&#43;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;szCounterName&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;<span class="cpp__datatype">TCHAR</span>[MAX_PATH];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_stprintf(szCounterName,&nbsp;TEXT(<span class="cpp__string">&quot;\\Process(%s)\\%%&nbsp;Processor&nbsp;Time&quot;</span>),*element);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;validCounterNames.push_back(szCounterName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
cleanup:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;szCounterName&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;validCounterNames;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">4. class Query: For querying Performance Counters</div>
<p>&nbsp; a) Adds a Performance Counter to Log.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">void Query::AddCounterInfo(PCWSTR name)
{
    if(fIsWorking)
    {
        PDH_STATUS status;
        CounterInfo ci;
        ci.counterName = name;
        status = PdhAddCounter(query, ci.counterName, 0 , &amp;ci.counter);
 
        if(status != ERROR_SUCCESS)
        {
            return;
        }
 
        vciSelectedCounters.push_back(ci);
    }
}
</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__keyword">void</span>&nbsp;Query::AddCounterInfo(<span class="cpp__datatype">PCWSTR</span>&nbsp;name)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(fIsWorking)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PDH_STATUS&nbsp;status;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CounterInfo&nbsp;ci;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ci.counterName&nbsp;=&nbsp;name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;status&nbsp;=&nbsp;PdhAddCounter(query,&nbsp;ci.counterName,&nbsp;<span class="cpp__number">0</span>&nbsp;,&nbsp;&amp;ci.counter);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(status&nbsp;!=&nbsp;ERROR_SUCCESS)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vciSelectedCounters.push_back(ci);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp; b) Query once for each Selected Performance Counter.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">void Query::Record()
{
    PDH_STATUS status;
    ULONG CounterType;
    ULONG WaitResult;
    PDH_FMT_COUNTERVALUE DisplayValue;    
 
    status = PdhCollectQueryData(query);
 
    if(status != ERROR_SUCCESS)
    {
        return;
    }
 
    status = PdhCollectQueryDataEx(query, SAMPLE_INTERVAL, Event);
 
    if(status != ERROR_SUCCESS)
    {
        return;
    }
 
    WaitResult = WaitForSingleObject(Event, INFINITE);
 
    if (WaitResult == WAIT_OBJECT_0) 
    {
        for(auto it = vciSelectedCounters.begin(); it &lt; vciSelectedCounters.end(); it&#43;&#43;)
        {
            status = PdhGetFormattedCounterValue(it-&gt;counter, PDH_FMT_DOUBLE, &amp;CounterType, &amp;DisplayValue);            
 
            if(status != ERROR_SUCCESS)
            {
                continue;
            }
 
            Log log;
            log.time = time;
            log.value = DisplayValue.doubleValue;
            it-&gt;logs.push_back(log);                
        }
    }
 
    time&#43;&#43;;
}
</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__keyword">void</span>&nbsp;Query::Record()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PDH_STATUS&nbsp;status;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">ULONG</span>&nbsp;CounterType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">ULONG</span>&nbsp;WaitResult;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PDH_FMT_COUNTERVALUE&nbsp;DisplayValue;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;status&nbsp;=&nbsp;PdhCollectQueryData(query);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(status&nbsp;!=&nbsp;ERROR_SUCCESS)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;status&nbsp;=&nbsp;PdhCollectQueryDataEx(query,&nbsp;SAMPLE_INTERVAL,&nbsp;Event);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(status&nbsp;!=&nbsp;ERROR_SUCCESS)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WaitResult&nbsp;=&nbsp;WaitForSingleObject(Event,&nbsp;INFINITE);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(WaitResult&nbsp;==&nbsp;WAIT_OBJECT_0)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>(auto&nbsp;it&nbsp;=&nbsp;vciSelectedCounters.begin();&nbsp;it&nbsp;&lt;&nbsp;vciSelectedCounters.end();&nbsp;it&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;status&nbsp;=&nbsp;PdhGetFormattedCounterValue(it-&gt;counter,&nbsp;PDH_FMT_DOUBLE,&nbsp;&amp;CounterType,&nbsp;&amp;DisplayValue);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(status&nbsp;!=&nbsp;ERROR_SUCCESS)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">continue</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Log&nbsp;log;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;log.time&nbsp;=&nbsp;time;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;log.value&nbsp;=&nbsp;DisplayValue.doubleValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;it-&gt;logs.push_back(log);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;time&#43;&#43;;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p>&nbsp;</p>
<p>&nbsp;</p>