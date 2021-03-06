# How to add wartermark text/image to a bitmap in Windows Store app
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* Windows Store app
* Wartermark text/image
## IsPublished
* True
## ModifiedDate
* 2015-01-07 12:56:37
## Description

<h2 class="MsoNormal">Introduction</h2>
<p class="MsoNormal"><span>In Windows Store app, you can't use GDI/GDI&#43; graphics API any more. This sample will show you how to draw watermark text or image to a bitmap in D2D. The sample contains two projects: one is a C&#43;&#43; Windows Runtime Component which
 wraps D2D/DWrite/WIC API and exposes some drawing functions and helper functions; the other one is the Client app which consumes the WinRT Component to finish the real work.</span></p>
<h2 class="MsoNormal">Video</h2>
<p><a href="http://channel9.msdn.com/Blogs/OneCode/How-to-add-wartermark-text-or-image-to-a-bitmap-in-Windows-Store-app/PLAYER" target="_blank"><img id="132142" src="https://i1.code.msdn.s-msft.com/how-to-add-wartermark-f6313fad/image/file/132142/1/how%20to%20add%20wartermark%20text%20or%20image%20to%20a%20bitmap%20in%20windows%20store%20app%20%20%20channel%209.png" alt="" width="640" height="360" style="border:1px solid black"></a></p>
<h2 class="MsoNormal"><span>Running the sample</span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; &nbsp;
</span></span></span><span>Build the solution in Visual Studio 2012, press F5 to run it.</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; &nbsp;&nbsp;</span></span></span><span>After the app is launched, you will
</span><span>see </span><span>something like this: </span></p>
<p class="MsoNormal"><span><img src="/site/view/file/83467/1/image.png" alt="" width="576" height="355" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Load a background image first, and then you can add watermark text or image to it.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/83468/1/image.png" alt="" width="576" height="354" align="middle">
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Optionally, you can undo the last operation. </span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>You can save the modified image to a file by clicking &quot;Save to file&quot; button.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/83469/1/image.png" alt="" width="576" height="432" align="middle">
</span></p>
<h2 class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</span></span></span></h2>
<h2 class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;</span></span></span><span>&nbsp; &nbsp; &nbsp; &nbsp;Using the Code</span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WatermarkComponent
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span><span>a)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>WatermarkComponent wraps D2D/DWrite/WIC API and exposes some useful functions:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">void Initialize();
void SetBitmapRenderTarget(IRandomAccessStream^  backgroundImageStream);
void BeginDraw();
IRandomAccessStream^ EndDraw(bool needPreview);
void DrawText(Platform::String^ text, Point startPoint, Platform::String^ fontFamilyName,Color foregroundColor, 
    float fontSize, FONT_STYLE_ENUM fontStyle, FONT_WEIGHT_ENUM fontWeight, Platform::String^ localeName);
void DrawImage(IRandomAccessStream^ watermarkImageStream, Point startPoint, float opacity);
void SaveBitmapToFile();
Platform::Array&lt;Platform::String^&gt;^ GetSystemFont();

</pre>
<pre id="codePreview" class="cplusplus">void Initialize();
void SetBitmapRenderTarget(IRandomAccessStream^  backgroundImageStream);
void BeginDraw();
IRandomAccessStream^ EndDraw(bool needPreview);
void DrawText(Platform::String^ text, Point startPoint, Platform::String^ fontFamilyName,Color foregroundColor, 
    float fontSize, FONT_STYLE_ENUM fontStyle, FONT_WEIGHT_ENUM fontWeight, Platform::String^ localeName);
void DrawImage(IRandomAccessStream^ watermarkImageStream, Point startPoint, float opacity);
void SaveBitmapToFile();
Platform::Array&lt;Platform::String^&gt;^ GetSystemFont();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span><span>b)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Initialize function is used to initialize the resources required to run
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// Initialize the DirectX resources required to run.
void D2DWrapper::Initialize()
{
    CreateDeviceIndependentResources();
    CreateDeviceResources();
}

</pre>
<pre id="codePreview" class="cplusplus">// Initialize the DirectX resources required to run.
void D2DWrapper::Initialize()
{
    CreateDeviceIndependentResources();
    CreateDeviceResources();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// Set bitmap render target. 
void D2DWrapper::SetBitmapRenderTarget(Streams::IRandomAccessStream^  backgroundImageStream)
{
    // Clear the render target.
    m_d2dContext-&gt;SetTarget(nullptr);


    // Convert the RandomAccessStream to an IStream.
    ComPtr&lt;IStream&gt; stream;
    DX::ThrowIfFailed(
        CreateStreamOverRandomAccessStream(backgroundImageStream, IID_PPV_ARGS(&amp;stream))
        );


    // Create the bitmap decoder.
    ComPtr&lt;IWICBitmapDecoder&gt; decoder;
    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateDecoderFromStream(
            stream.Get(),
            nullptr,
            WICDecodeMetadataCacheOnDemand,
            &amp;decoder
            )
        );
    
    // Get the first frame. 
    ComPtr&lt;IWICBitmapFrameDecode&gt; frame;
    DX::ThrowIfFailed(
        decoder-&gt;GetFrame(0, &amp;frame)
        );


    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateFormatConverter(&amp;m_backgroundBitmapConverter)
        );


    DX::ThrowIfFailed(
        m_backgroundBitmapConverter-&gt;Initialize(
            frame.Get(),
            GUID_WICPixelFormat32bppPBGRA,
            WICBitmapDitherTypeNone,
            nullptr,
            0.0f,
            WICBitmapPaletteTypeCustom  // Premultiplied BGRA has no paletting, so this is ignored.
            )
        );


    double dpiX = 96.0f;
    double dpiY = 96.0f;
    DX::ThrowIfFailed(
        m_backgroundBitmapConverter-&gt;GetResolution(&amp;dpiX, &amp;dpiY)
        );


    DX::ThrowIfFailed(
        m_d2dContext-&gt;CreateBitmapFromWicBitmap(
            m_backgroundBitmapConverter.Get(), 
            D2D1::BitmapProperties1(D2D1_BITMAP_OPTIONS_TARGET,
            D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_PREMULTIPLIED),
            static_cast&lt;float&gt;(dpiX),
            static_cast&lt;float&gt;(dpiY),0
            ),
            &amp;m_targetBitmap
            )
        );


    m_d2dContext-&gt;SetTarget(m_targetBitmap.Get());


    // Retrieve the renderTargetSize in DIPs.
    m_renderTargetSize = m_d2dContext-&gt;GetSize();
}

</pre>
<pre id="codePreview" class="cplusplus">// Set bitmap render target. 
void D2DWrapper::SetBitmapRenderTarget(Streams::IRandomAccessStream^  backgroundImageStream)
{
    // Clear the render target.
    m_d2dContext-&gt;SetTarget(nullptr);


    // Convert the RandomAccessStream to an IStream.
    ComPtr&lt;IStream&gt; stream;
    DX::ThrowIfFailed(
        CreateStreamOverRandomAccessStream(backgroundImageStream, IID_PPV_ARGS(&amp;stream))
        );


    // Create the bitmap decoder.
    ComPtr&lt;IWICBitmapDecoder&gt; decoder;
    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateDecoderFromStream(
            stream.Get(),
            nullptr,
            WICDecodeMetadataCacheOnDemand,
            &amp;decoder
            )
        );
    
    // Get the first frame. 
    ComPtr&lt;IWICBitmapFrameDecode&gt; frame;
    DX::ThrowIfFailed(
        decoder-&gt;GetFrame(0, &amp;frame)
        );


    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateFormatConverter(&amp;m_backgroundBitmapConverter)
        );


    DX::ThrowIfFailed(
        m_backgroundBitmapConverter-&gt;Initialize(
            frame.Get(),
            GUID_WICPixelFormat32bppPBGRA,
            WICBitmapDitherTypeNone,
            nullptr,
            0.0f,
            WICBitmapPaletteTypeCustom  // Premultiplied BGRA has no paletting, so this is ignored.
            )
        );


    double dpiX = 96.0f;
    double dpiY = 96.0f;
    DX::ThrowIfFailed(
        m_backgroundBitmapConverter-&gt;GetResolution(&amp;dpiX, &amp;dpiY)
        );


    DX::ThrowIfFailed(
        m_d2dContext-&gt;CreateBitmapFromWicBitmap(
            m_backgroundBitmapConverter.Get(), 
            D2D1::BitmapProperties1(D2D1_BITMAP_OPTIONS_TARGET,
            D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_PREMULTIPLIED),
            static_cast&lt;float&gt;(dpiX),
            static_cast&lt;float&gt;(dpiY),0
            ),
            &amp;m_targetBitmap
            )
        );


    m_d2dContext-&gt;SetTarget(m_targetBitmap.Get());


    // Retrieve the renderTargetSize in DIPs.
    m_renderTargetSize = m_d2dContext-&gt;GetSize();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// Call this function before you draw.
void D2DWrapper::BeginDraw()
{
    m_d2dContext-&gt;BeginDraw();
    m_d2dContext-&gt;SetTransform(D2D1::Matrix3x2F::Identity());
}


// Call this function when you finish the drawing.
IRandomAccessStream^ D2DWrapper::EndDraw(bool needPreview)
{
    DX::ThrowIfFailed(
        m_d2dContext-&gt;EndDraw()
        );


    // If needPreview is true, we return a valid IRandomAccessStream reference.
    if(needPreview)
    {
        GUID wicFormat = GUID_ContainerFormatBmp;
        ComPtr&lt;IStream&gt; stream;
        ComPtr&lt;ISequentialStream&gt; ss;
        auto inMemStream =  ref new InMemoryRandomAccessStream();
        DX::ThrowIfFailed(
            CreateStreamOverRandomAccessStream(inMemStream ,IID_PPV_ARGS(&amp;stream))
            );


        SaveBitmapToStream(m_targetBitmap, m_wicFactory, m_d2dContext, wicFormat, stream.Get());
    
        return inMemStream;
    }


    return nullptr;
}

</pre>
<pre id="codePreview" class="cplusplus">// Call this function before you draw.
void D2DWrapper::BeginDraw()
{
    m_d2dContext-&gt;BeginDraw();
    m_d2dContext-&gt;SetTransform(D2D1::Matrix3x2F::Identity());
}


// Call this function when you finish the drawing.
IRandomAccessStream^ D2DWrapper::EndDraw(bool needPreview)
{
    DX::ThrowIfFailed(
        m_d2dContext-&gt;EndDraw()
        );


    // If needPreview is true, we return a valid IRandomAccessStream reference.
    if(needPreview)
    {
        GUID wicFormat = GUID_ContainerFormatBmp;
        ComPtr&lt;IStream&gt; stream;
        ComPtr&lt;ISequentialStream&gt; ss;
        auto inMemStream =  ref new InMemoryRandomAccessStream();
        DX::ThrowIfFailed(
            CreateStreamOverRandomAccessStream(inMemStream ,IID_PPV_ARGS(&amp;stream))
            );


        SaveBitmapToStream(m_targetBitmap, m_wicFactory, m_d2dContext, wicFormat, stream.Get());
    
        return inMemStream;
    }


    return nullptr;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// Draw text with the specified styles.
// Please note that startPoint.X and startPoint.Y should be in the range of 0.0f - 1.0f.
void D2DWrapper::DrawText(Platform::String^ text, Point startPoint, Platform::String^ fontFamilyName, 
                          Color foregroundColor, float fontSize, FONT_STYLE_ENUM fontStyle, 
                          FONT_WEIGHT_ENUM fontWeight, Platform::String^ localeName)
{
    // In case user input invalid startPoint, we do a simple validation.
    if(startPoint.X &lt; 0.0f || startPoint.X &gt; 1.0f || startPoint.Y &lt; 0.0f || startPoint.Y &gt; 1.0f)
    {
        throw ref new Platform::InvalidArgumentException(&quot;startPoint.X and startPoint.Y should be in the range of 0.0f - 1.0f&quot;);
    }


    // Create a DirectWrite text format object.
    DX::ThrowIfFailed(
        m_dwriteFactory-&gt;CreateTextFormat(
            fontFamilyName-&gt;Data(),                 // font family name
            nullptr,                             // system font collection
            (DWRITE_FONT_WEIGHT)fontWeight,         // font weight 
            (DWRITE_FONT_STYLE)fontStyle,         // font style
            DWRITE_FONT_STRETCH_NORMAL,             // default font stretch
            fontSize,                             // font size
            localeName-&gt;Data(),                     // locale name
            &amp;m_textFormat
            )
        );


    // Set text alignment.
    DX::ThrowIfFailed(
        m_textFormat-&gt;SetTextAlignment(DWRITE_TEXT_ALIGNMENT_LEADING)
        );


    // Set paragraph alignment.
    DX::ThrowIfFailed(
        m_textFormat-&gt;SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR)
        );


    D2D1_RECT_F layoutRect = {startPoint.X * m_renderTargetSize.width, startPoint.Y * m_renderTargetSize.height,
        m_renderTargetSize.width, m_renderTargetSize.height};


    
    D2D1_COLOR_F textColor = D2D1::ColorF(foregroundColor.R / 255.0f, foregroundColor.G / 255.0f, 
        foregroundColor.B /255.0f, foregroundColor.A / 255.0f);


     DX::ThrowIfFailed(
        m_d2dContext-&gt;CreateSolidColorBrush(
            textColor,
            &amp;m_textBrush
            )
        );


    m_d2dContext-&gt;DrawText(text-&gt;Data(),text-&gt;Length(), m_textFormat.Get(), &amp;layoutRect, m_textBrush.Get()); 
}


// Draw image
void D2DWrapper::DrawImage(Windows::Storage::Streams::IRandomAccessStream^ watermarkImageStream, Point startPoint, 
                           float opacity)
{
    // In case user input the invalid startPoint, we do a simple Validation.
    if(startPoint.X &lt; 0.0f || startPoint.X &gt; 1.0f || startPoint.Y &lt; 0.0f || startPoint.Y &gt; 1.0f)
    {
        throw ref new Platform::InvalidArgumentException(&quot;startPoint.X and startPoint.Y should be in the range of 0.0f - 1.0f&quot;);
    }


    // Convert the RandomAccessStream to an IStream.
    ComPtr&lt;IStream&gt; stream;
    DX::ThrowIfFailed(
        CreateStreamOverRandomAccessStream(watermarkImageStream, IID_PPV_ARGS(&amp;stream))
        );


    // Create the bitmap decoder.
    ComPtr&lt;IWICBitmapDecoder&gt; decoder;
    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateDecoderFromStream(
            stream.Get(),
            nullptr,
            WICDecodeMetadataCacheOnDemand,
            &amp;decoder
            )
        );


    ComPtr&lt;IWICBitmapFrameDecode&gt; frame;
    DX::ThrowIfFailed(
        decoder-&gt;GetFrame(0, &amp;frame)
        );


    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateFormatConverter(&amp;m_watermarkImageConverter)
        );


    DX::ThrowIfFailed(
        m_watermarkImageConverter-&gt;Initialize(
            frame.Get(),
            GUID_WICPixelFormat32bppPBGRA,
            WICBitmapDitherTypeNone,
            nullptr,
            0.0f,
            WICBitmapPaletteTypeCustom  // Premultiplied BGRA has no paletting, so this is ignored.
            )
        );


    double dpiX = 96.0f;
    double dpiY = 96.0f;


    m_watermarkImageConverter-&gt;GetResolution(&amp;dpiX, &amp;dpiY);
    DX::ThrowIfFailed(
    m_d2dContext-&gt;CreateBitmapFromWicBitmap(
        m_watermarkImageConverter.Get(), 
        D2D1::BitmapProperties1(D2D1_BITMAP_OPTIONS_NONE,
        D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_PREMULTIPLIED),
        static_cast&lt;float&gt;(dpiX),
        static_cast&lt;float&gt;(dpiY),0
        ),
        &amp;m_watermarkBitmap
        )
    );


    D2D1_SIZE_F watermarkImageSize = m_watermarkBitmap-&gt;GetSize();


    float startPointOffsetX = startPoint.X * m_renderTargetSize.width;
    float startPointOffsetY = startPoint.Y * m_renderTargetSize.height;


    D2D1_RECT_F destinationRect = {startPointOffsetX, startPointOffsetY, startPointOffsetX &#43; watermarkImageSize.width,
        startPointOffsetY &#43; watermarkImageSize.height};


    m_d2dContext-&gt;DrawBitmap(m_watermarkBitmap.Get(), &amp;destinationRect, opacity);  


}

</pre>
<pre id="codePreview" class="cplusplus">// Draw text with the specified styles.
// Please note that startPoint.X and startPoint.Y should be in the range of 0.0f - 1.0f.
void D2DWrapper::DrawText(Platform::String^ text, Point startPoint, Platform::String^ fontFamilyName, 
                          Color foregroundColor, float fontSize, FONT_STYLE_ENUM fontStyle, 
                          FONT_WEIGHT_ENUM fontWeight, Platform::String^ localeName)
{
    // In case user input invalid startPoint, we do a simple validation.
    if(startPoint.X &lt; 0.0f || startPoint.X &gt; 1.0f || startPoint.Y &lt; 0.0f || startPoint.Y &gt; 1.0f)
    {
        throw ref new Platform::InvalidArgumentException(&quot;startPoint.X and startPoint.Y should be in the range of 0.0f - 1.0f&quot;);
    }


    // Create a DirectWrite text format object.
    DX::ThrowIfFailed(
        m_dwriteFactory-&gt;CreateTextFormat(
            fontFamilyName-&gt;Data(),                 // font family name
            nullptr,                             // system font collection
            (DWRITE_FONT_WEIGHT)fontWeight,         // font weight 
            (DWRITE_FONT_STYLE)fontStyle,         // font style
            DWRITE_FONT_STRETCH_NORMAL,             // default font stretch
            fontSize,                             // font size
            localeName-&gt;Data(),                     // locale name
            &amp;m_textFormat
            )
        );


    // Set text alignment.
    DX::ThrowIfFailed(
        m_textFormat-&gt;SetTextAlignment(DWRITE_TEXT_ALIGNMENT_LEADING)
        );


    // Set paragraph alignment.
    DX::ThrowIfFailed(
        m_textFormat-&gt;SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR)
        );


    D2D1_RECT_F layoutRect = {startPoint.X * m_renderTargetSize.width, startPoint.Y * m_renderTargetSize.height,
        m_renderTargetSize.width, m_renderTargetSize.height};


    
    D2D1_COLOR_F textColor = D2D1::ColorF(foregroundColor.R / 255.0f, foregroundColor.G / 255.0f, 
        foregroundColor.B /255.0f, foregroundColor.A / 255.0f);


     DX::ThrowIfFailed(
        m_d2dContext-&gt;CreateSolidColorBrush(
            textColor,
            &amp;m_textBrush
            )
        );


    m_d2dContext-&gt;DrawText(text-&gt;Data(),text-&gt;Length(), m_textFormat.Get(), &amp;layoutRect, m_textBrush.Get()); 
}


// Draw image
void D2DWrapper::DrawImage(Windows::Storage::Streams::IRandomAccessStream^ watermarkImageStream, Point startPoint, 
                           float opacity)
{
    // In case user input the invalid startPoint, we do a simple Validation.
    if(startPoint.X &lt; 0.0f || startPoint.X &gt; 1.0f || startPoint.Y &lt; 0.0f || startPoint.Y &gt; 1.0f)
    {
        throw ref new Platform::InvalidArgumentException(&quot;startPoint.X and startPoint.Y should be in the range of 0.0f - 1.0f&quot;);
    }


    // Convert the RandomAccessStream to an IStream.
    ComPtr&lt;IStream&gt; stream;
    DX::ThrowIfFailed(
        CreateStreamOverRandomAccessStream(watermarkImageStream, IID_PPV_ARGS(&amp;stream))
        );


    // Create the bitmap decoder.
    ComPtr&lt;IWICBitmapDecoder&gt; decoder;
    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateDecoderFromStream(
            stream.Get(),
            nullptr,
            WICDecodeMetadataCacheOnDemand,
            &amp;decoder
            )
        );


    ComPtr&lt;IWICBitmapFrameDecode&gt; frame;
    DX::ThrowIfFailed(
        decoder-&gt;GetFrame(0, &amp;frame)
        );


    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateFormatConverter(&amp;m_watermarkImageConverter)
        );


    DX::ThrowIfFailed(
        m_watermarkImageConverter-&gt;Initialize(
            frame.Get(),
            GUID_WICPixelFormat32bppPBGRA,
            WICBitmapDitherTypeNone,
            nullptr,
            0.0f,
            WICBitmapPaletteTypeCustom  // Premultiplied BGRA has no paletting, so this is ignored.
            )
        );


    double dpiX = 96.0f;
    double dpiY = 96.0f;


    m_watermarkImageConverter-&gt;GetResolution(&amp;dpiX, &amp;dpiY);
    DX::ThrowIfFailed(
    m_d2dContext-&gt;CreateBitmapFromWicBitmap(
        m_watermarkImageConverter.Get(), 
        D2D1::BitmapProperties1(D2D1_BITMAP_OPTIONS_NONE,
        D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_PREMULTIPLIED),
        static_cast&lt;float&gt;(dpiX),
        static_cast&lt;float&gt;(dpiY),0
        ),
        &amp;m_watermarkBitmap
        )
    );


    D2D1_SIZE_F watermarkImageSize = m_watermarkBitmap-&gt;GetSize();


    float startPointOffsetX = startPoint.X * m_renderTargetSize.width;
    float startPointOffsetY = startPoint.Y * m_renderTargetSize.height;


    D2D1_RECT_F destinationRect = {startPointOffsetX, startPointOffsetY, startPointOffsetX &#43; watermarkImageSize.width,
        startPointOffsetY &#43; watermarkImageSize.height};


    m_d2dContext-&gt;DrawBitmap(m_watermarkBitmap.Get(), &amp;destinationRect, opacity);  


}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">async private void AddTextButton_Click(object sender, RoutedEventArgs e)
{
    // Clear status text.
    this.NotifyUser(&quot;&quot;);


    try
    {
        if (backgroundImageStream != null)
        {
            if (previousImageStream != null)
            {
                previousImageStream.Dispose();
                previousImageStream = null;
            }


            // Cache the stream for Undo purpose.
            previousImageStream = currentImageStream;
            this.UndoButton.IsEnabled = true;


            Point startPoint = new Point(this.OffsetXSlider.Value, this.OffsetYSlider.Value);
            Color textColor = Color.FromArgb((byte)(this.FontOpacitySlider.Value * 255), fontColor.R, fontColor.G,
                fontColor.B);
            uint fontSize = Convert.ToUInt32(this.FontSizeComBox.SelectedValue);


            FONT_STYLE_ENUM fontStyle = (FONT_STYLE_ENUM)Enum.Parse(typeof(FONT_STYLE_ENUM),
                FontStyleComBox.SelectedValue.ToString());


            FONT_WEIGHT_ENUM fontWeight = (FONT_WEIGHT_ENUM)Enum.Parse(typeof(FONT_WEIGHT_ENUM),
                this.FontWeightComBox.SelectedValue.ToString());


            // BeginDraw
            d2dWrapper.BeginDraw();


            // Draw text
            d2dWrapper.DrawText(this.inputText.Text, startPoint, this.FontFamilyComBox.SelectedValue.ToString(),
                textColor, fontSize, fontStyle, fontWeight, string.Empty);


            // EndDraw
            currentImageStream = d2dWrapper.EndDraw(true);
            currentImageStream.Seek(0);


            // Update the preview image.
            BitmapImage bi = new BitmapImage();
            await bi.SetSourceAsync(currentImageStream);
            this.PreviewImage.Source = bi;


        }
    }
    catch (Exception ex)
    {
        this.NotifyUser(ex.Message);
    }
}

</pre>
<pre id="codePreview" class="csharp">async private void AddTextButton_Click(object sender, RoutedEventArgs e)
{
    // Clear status text.
    this.NotifyUser(&quot;&quot;);


    try
    {
        if (backgroundImageStream != null)
        {
            if (previousImageStream != null)
            {
                previousImageStream.Dispose();
                previousImageStream = null;
            }


            // Cache the stream for Undo purpose.
            previousImageStream = currentImageStream;
            this.UndoButton.IsEnabled = true;


            Point startPoint = new Point(this.OffsetXSlider.Value, this.OffsetYSlider.Value);
            Color textColor = Color.FromArgb((byte)(this.FontOpacitySlider.Value * 255), fontColor.R, fontColor.G,
                fontColor.B);
            uint fontSize = Convert.ToUInt32(this.FontSizeComBox.SelectedValue);


            FONT_STYLE_ENUM fontStyle = (FONT_STYLE_ENUM)Enum.Parse(typeof(FONT_STYLE_ENUM),
                FontStyleComBox.SelectedValue.ToString());


            FONT_WEIGHT_ENUM fontWeight = (FONT_WEIGHT_ENUM)Enum.Parse(typeof(FONT_WEIGHT_ENUM),
                this.FontWeightComBox.SelectedValue.ToString());


            // BeginDraw
            d2dWrapper.BeginDraw();


            // Draw text
            d2dWrapper.DrawText(this.inputText.Text, startPoint, this.FontFamilyComBox.SelectedValue.ToString(),
                textColor, fontSize, fontStyle, fontWeight, string.Empty);


            // EndDraw
            currentImageStream = d2dWrapper.EndDraw(true);
            currentImageStream.Seek(0);


            // Update the preview image.
            BitmapImage bi = new BitmapImage();
            await bi.SetSourceAsync(currentImageStream);
            this.PreviewImage.Source = bi;


        }
    }
    catch (Exception ex)
    {
        this.NotifyUser(ex.Message);
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">async private void AddwatermarkImageButton_Click(object sender, RoutedEventArgs e)
{
    // Clear status text.
    this.NotifyUser(&quot;&quot;);


    try
    {
        if (backgroundImageStream != null &amp;&amp; watermarkImageStream != null)
        {
            if (previousImageStream != null)
            {
                previousImageStream.Dispose();
                previousImageStream = null;
            }


            // Cache the stream for Undo purpose.
            previousImageStream = currentImageStream;
            this.UndoButton.IsEnabled = true;


            Point startPoint = new Point(this.OffsetXSlider.Value, this.OffsetYSlider.Value);


            // BeginDraw
            d2dWrapper.BeginDraw();


            // Draw image
            d2dWrapper.DrawImage(watermarkImageStream, startPoint, (float)this.watermarkImageOpacitySlider.Value);


            // EndDraw
            currentImageStream = d2dWrapper.EndDraw(true);
            currentImageStream.Seek(0);


            BitmapImage bi = new BitmapImage();
            await bi.SetSourceAsync(currentImageStream);
            this.PreviewImage.Source = bi;
        }
        else
        {
            this.NotifyUser(&quot;Can't add watermark image. Please make sure you have loaded background image and watermark image.&quot;);
        }
    }
    catch (Exception ex)
    {
        this.NotifyUser(ex.Message);
    }


}

</pre>
<pre id="codePreview" class="csharp">async private void AddwatermarkImageButton_Click(object sender, RoutedEventArgs e)
{
    // Clear status text.
    this.NotifyUser(&quot;&quot;);


    try
    {
        if (backgroundImageStream != null &amp;&amp; watermarkImageStream != null)
        {
            if (previousImageStream != null)
            {
                previousImageStream.Dispose();
                previousImageStream = null;
            }


            // Cache the stream for Undo purpose.
            previousImageStream = currentImageStream;
            this.UndoButton.IsEnabled = true;


            Point startPoint = new Point(this.OffsetXSlider.Value, this.OffsetYSlider.Value);


            // BeginDraw
            d2dWrapper.BeginDraw();


            // Draw image
            d2dWrapper.DrawImage(watermarkImageStream, startPoint, (float)this.watermarkImageOpacitySlider.Value);


            // EndDraw
            currentImageStream = d2dWrapper.EndDraw(true);
            currentImageStream.Seek(0);


            BitmapImage bi = new BitmapImage();
            await bi.SetSourceAsync(currentImageStream);
            this.PreviewImage.Source = bi;
        }
        else
        {
            this.NotifyUser(&quot;Can't add watermark image. Please make sure you have loaded background image and watermark image.&quot;);
        }
    }
    catch (Exception ex)
    {
        this.NotifyUser(ex.Message);
    }


}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN">Direct2D programming </span></p>
<p class="MsoNormal"><span lang="EN"><a href="http://msdn.microsoft.com/en-us/library/dd370990(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/dd370990(v=vs.85).aspx</a>
</span></p>
<p class="MsoNormal">XAML data binding sample<span lang="EN"> </span></p>
<p class="MsoNormal"><span lang="EN"><a href="http://code.msdn.microsoft.com/windowsapps/Data-Binding-7b1d67b5">http://code.msdn.microsoft.com/windowsapps/Data-Binding-7b1d67b5</a>
</span></p>
<p class="MsoNormal"><span class="SpellE">DirectWrite</span> font enumeration sample<span lang="EN">
</span></p>
<p class="MsoNormal"><span lang="EN"><a href="http://code.msdn.microsoft.com/windowsapps/DirectWrite-font-60e53e0b">http://code.msdn.microsoft.com/windowsapps/DirectWrite-font-60e53e0b</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
