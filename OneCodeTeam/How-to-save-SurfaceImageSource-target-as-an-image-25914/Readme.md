# How to save SurfaceImageSource target as an image in Windows Store app
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* SurfaceImageSource
## IsPublished
* False
## ModifiedDate
* 2013-11-06 07:30:49
## Description

<h1><span style="">How to save the content of SurfaceImageSource to image file in Windows Store app (VBWindowsStoreAppSaveSurfaceImageSource)
</span></h1>
<h2><span style="">Introduction </span></h2>
<p class="MsoNormal">​<a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style=""></span></a><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.imaging.surfaceimagesource.aspx"><span style=""><span style="">SurfaceImageSource</span></span><span style=""><span style=""></span></span></a><span style=""><span style="">
</span></span>provides Microsoft DirectX shared surfaces to draw into and then composes the bits into app content. This code sample will show you how to save the content of
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.imaging.surfaceimagesource.aspx">
SurfaceImageSource</a> to image file.<span lang="EN" style=""> </span></p>
<h2><span style="">Running the Sample </span></h2>
<p class="MsoNormal"><span style="">Build the sample in Visual Studio 2012, and then run it. The app looks like this:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/100830/1/image.png" alt="" width="576" height="359" align="middle">
</span><span style=""></span></p>
<h2><span style="">Using the Code </span></h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">We first create a C&#43;&#43; Windows Runtime Component named &quot;MyImageSourceWinRT&quot;. Then create a sealed class &quot;MyImageSource&quot; which inherits from Windows::UI::Xaml::Media::Imaging::SurfaceImageSource. It extends
 SurfaceImagSource to save the content to image file. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
public ref class MyImageSource sealed : Windows::UI::Xaml::Media::Imaging::SurfaceImageSource 
{ 
public: 
&nbsp;&nbsp;&nbsp;&nbsp;MyImageSource(UINT pixelWidth, UINT pixelHeight, bool isOpaque); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;void BeginDraw(Windows::Foundation::Rect updateRect); 
&nbsp;&nbsp;&nbsp;&nbsp;void BeginDraw()&nbsp;&nbsp;&nbsp; { BeginDraw(Windows::Foundation::Rect(0, 0, (float)m_width, (float)m_height)); } 
&nbsp;&nbsp;&nbsp;&nbsp;void EndDraw(); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;void SetDpi(float dpi); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;void Clear(Windows::UI::Color color); 
&nbsp;&nbsp;&nbsp;&nbsp;void FillSolidRect(Windows::UI::Color color, Windows::Foundation::Rect rect); 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;void SaveSurfaceImageToFile();


protected: 
&nbsp;&nbsp;&nbsp;&nbsp;void CreateDeviceIndependentResources(); 
&nbsp;&nbsp;&nbsp;&nbsp;void CreateDeviceResources(); 


private:
&nbsp;&nbsp;&nbsp; void SaveBitmapToStream(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _In_ ComPtr&lt;IWICBitmap&gt; wicBitmap,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _In_ ComPtr&lt;IWICImagingFactory2&gt; wicFactory2,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _In_ REFGUID wicFormat,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _In_ IStream* stream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );

</pre>
<pre id="codePreview" class="cplusplus">
public ref class MyImageSource sealed : Windows::UI::Xaml::Media::Imaging::SurfaceImageSource 
{ 
public: 
&nbsp;&nbsp;&nbsp;&nbsp;MyImageSource(UINT pixelWidth, UINT pixelHeight, bool isOpaque); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;void BeginDraw(Windows::Foundation::Rect updateRect); 
&nbsp;&nbsp;&nbsp;&nbsp;void BeginDraw()&nbsp;&nbsp;&nbsp; { BeginDraw(Windows::Foundation::Rect(0, 0, (float)m_width, (float)m_height)); } 
&nbsp;&nbsp;&nbsp;&nbsp;void EndDraw(); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;void SetDpi(float dpi); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;void Clear(Windows::UI::Color color); 
&nbsp;&nbsp;&nbsp;&nbsp;void FillSolidRect(Windows::UI::Color color, Windows::Foundation::Rect rect); 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;void SaveSurfaceImageToFile();


protected: 
&nbsp;&nbsp;&nbsp;&nbsp;void CreateDeviceIndependentResources(); 
&nbsp;&nbsp;&nbsp;&nbsp;void CreateDeviceResources(); 


private:
&nbsp;&nbsp;&nbsp; void SaveBitmapToStream(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _In_ ComPtr&lt;IWICBitmap&gt; wicBitmap,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _In_ ComPtr&lt;IWICImagingFactory2&gt; wicFactory2,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _In_ REFGUID wicFormat,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _In_ IStream* stream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">BeginDraw method. In this method, we prepare D2D context render target and WIC bitmap render target for drawing.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Begins drawing, allowing updates to content in the specified area. 
void MyImageSource::BeginDraw(Windows::Foundation::Rect updateRect) 
{&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;POINT offset; 
&nbsp;&nbsp;&nbsp;&nbsp;ComPtr&lt;IDXGISurface&gt; surface; 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Express target area as a native RECT type. 
&nbsp;&nbsp;&nbsp;&nbsp;RECT updateRectNative;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;updateRectNative.left = static_cast&lt;LONG&gt;(updateRect.Left); 
&nbsp;&nbsp;&nbsp;&nbsp;updateRectNative.top = static_cast&lt;LONG&gt;(updateRect.Top); 
&nbsp;&nbsp;&nbsp;&nbsp;updateRectNative.right = static_cast&lt;LONG&gt;(updateRect.Right); 
&nbsp;&nbsp;&nbsp;&nbsp;updateRectNative.bottom = static_cast&lt;LONG&gt;(updateRect.Bottom); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Begin drawing - returns a target surface and an offset to use as the top left origin when drawing. 
&nbsp;&nbsp;&nbsp;&nbsp;HRESULT beginDrawHR = m_sisNative-&gt;BeginDraw(updateRectNative, &surface, &offset); 
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;if (beginDrawHR == DXGI_ERROR_DEVICE_REMOVED || beginDrawHR == DXGI_ERROR_DEVICE_RESET) 
&nbsp;&nbsp;&nbsp;&nbsp;{ 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// If the device has been removed or reset, attempt to recreate it and continue drawing. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateDeviceResources(); 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BeginDraw(updateRect); 
&nbsp;&nbsp;&nbsp;&nbsp;} 
&nbsp;&nbsp;&nbsp;&nbsp;else 
&nbsp;&nbsp;&nbsp;&nbsp;{ 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Notify the caller by throwing an exception if any other error was encountered. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed(beginDrawHR); 
&nbsp;&nbsp;&nbsp;&nbsp;} 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Create render target. 
&nbsp;&nbsp;&nbsp;&nbsp;ComPtr&lt;ID2D1Bitmap1&gt; bitmap; 
&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;CreateBitmapFromDxgiSurface( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;surface.Get(), 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nullptr, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&bitmap 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Set context's render target. 
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;SetTarget(bitmap.Get()); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Begin drawing using D2D context. 
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;BeginDraw(); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Apply a clip and transform to constrain updates to the target update area. 
&nbsp;&nbsp;&nbsp;&nbsp;// This is required to ensure coordinates within the target surface remain 
&nbsp;&nbsp;&nbsp;&nbsp;// consistent by taking into account the offset returned by BeginDraw, and 
&nbsp;&nbsp;&nbsp;&nbsp;// can also improve performance by optimizing the area that is drawn by D2D. 
&nbsp;&nbsp;&nbsp;&nbsp;// Apps should always account for the offset output parameter returned by&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;// BeginDraw, since it may not match the passed updateRect input parameter's location. 
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;PushAxisAlignedClip( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::RectF( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.x),&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.y),&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.x &#43; updateRect.Width), 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.y &#43; updateRect.Height)&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;),&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1_ANTIALIAS_MODE_ALIASED&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;SetTransform( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::Matrix3x2F::Translation( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.x), 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.y) 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 


&nbsp;&nbsp;&nbsp; // Create wic bitmap
&nbsp;&nbsp;&nbsp; WICPixelFormatGUID format = GUID_WICPixelFormat32bppPBGRA;&nbsp;&nbsp;&nbsp; 


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_wicFactory-&gt;CreateBitmap(updateRect.Width, updateRect.Height, format, WICBitmapCacheOnLoad, &m_wicBitmap)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; // Create wic render target
&nbsp;&nbsp;&nbsp; D2D1_RENDER_TARGET_PROPERTIES RTProps = D2D1::RenderTargetProperties(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );
&nbsp;&nbsp;&nbsp; RTProps.pixelFormat = D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM,D2D1_ALPHA_MODE_PREMULTIPLIED);


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_d2dFactory-&gt;CreateWicBitmapRenderTarget(m_wicBitmap.Get(),&RTProps,&m_wicBitmapRenderTarget)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; // Begin drawing using WIC Bitmap RenderTarget.
&nbsp;&nbsp;&nbsp; m_wicBitmapRenderTarget-&gt;BeginDraw();
} 

</pre>
<pre id="codePreview" class="cplusplus">
// Begins drawing, allowing updates to content in the specified area. 
void MyImageSource::BeginDraw(Windows::Foundation::Rect updateRect) 
{&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;POINT offset; 
&nbsp;&nbsp;&nbsp;&nbsp;ComPtr&lt;IDXGISurface&gt; surface; 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Express target area as a native RECT type. 
&nbsp;&nbsp;&nbsp;&nbsp;RECT updateRectNative;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;updateRectNative.left = static_cast&lt;LONG&gt;(updateRect.Left); 
&nbsp;&nbsp;&nbsp;&nbsp;updateRectNative.top = static_cast&lt;LONG&gt;(updateRect.Top); 
&nbsp;&nbsp;&nbsp;&nbsp;updateRectNative.right = static_cast&lt;LONG&gt;(updateRect.Right); 
&nbsp;&nbsp;&nbsp;&nbsp;updateRectNative.bottom = static_cast&lt;LONG&gt;(updateRect.Bottom); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Begin drawing - returns a target surface and an offset to use as the top left origin when drawing. 
&nbsp;&nbsp;&nbsp;&nbsp;HRESULT beginDrawHR = m_sisNative-&gt;BeginDraw(updateRectNative, &surface, &offset); 
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;if (beginDrawHR == DXGI_ERROR_DEVICE_REMOVED || beginDrawHR == DXGI_ERROR_DEVICE_RESET) 
&nbsp;&nbsp;&nbsp;&nbsp;{ 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// If the device has been removed or reset, attempt to recreate it and continue drawing. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateDeviceResources(); 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BeginDraw(updateRect); 
&nbsp;&nbsp;&nbsp;&nbsp;} 
&nbsp;&nbsp;&nbsp;&nbsp;else 
&nbsp;&nbsp;&nbsp;&nbsp;{ 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Notify the caller by throwing an exception if any other error was encountered. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed(beginDrawHR); 
&nbsp;&nbsp;&nbsp;&nbsp;} 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Create render target. 
&nbsp;&nbsp;&nbsp;&nbsp;ComPtr&lt;ID2D1Bitmap1&gt; bitmap; 
&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;CreateBitmapFromDxgiSurface( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;surface.Get(), 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nullptr, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&bitmap 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Set context's render target. 
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;SetTarget(bitmap.Get()); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Begin drawing using D2D context. 
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;BeginDraw(); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Apply a clip and transform to constrain updates to the target update area. 
&nbsp;&nbsp;&nbsp;&nbsp;// This is required to ensure coordinates within the target surface remain 
&nbsp;&nbsp;&nbsp;&nbsp;// consistent by taking into account the offset returned by BeginDraw, and 
&nbsp;&nbsp;&nbsp;&nbsp;// can also improve performance by optimizing the area that is drawn by D2D. 
&nbsp;&nbsp;&nbsp;&nbsp;// Apps should always account for the offset output parameter returned by&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;// BeginDraw, since it may not match the passed updateRect input parameter's location. 
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;PushAxisAlignedClip( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::RectF( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.x),&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.y),&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.x &#43; updateRect.Width), 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.y &#43; updateRect.Height)&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;),&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1_ANTIALIAS_MODE_ALIASED&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;SetTransform( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D2D1::Matrix3x2F::Translation( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.x), 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static_cast&lt;float&gt;(offset.y) 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 


&nbsp;&nbsp;&nbsp; // Create wic bitmap
&nbsp;&nbsp;&nbsp; WICPixelFormatGUID format = GUID_WICPixelFormat32bppPBGRA;&nbsp;&nbsp;&nbsp; 


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_wicFactory-&gt;CreateBitmap(updateRect.Width, updateRect.Height, format, WICBitmapCacheOnLoad, &m_wicBitmap)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; // Create wic render target
&nbsp;&nbsp;&nbsp; D2D1_RENDER_TARGET_PROPERTIES RTProps = D2D1::RenderTargetProperties(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );
&nbsp;&nbsp;&nbsp; RTProps.pixelFormat = D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM,D2D1_ALPHA_MODE_PREMULTIPLIED);


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_d2dFactory-&gt;CreateWicBitmapRenderTarget(m_wicBitmap.Get(),&RTProps,&m_wicBitmapRenderTarget)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; // Begin drawing using WIC Bitmap RenderTarget.
&nbsp;&nbsp;&nbsp; m_wicBitmapRenderTarget-&gt;BeginDraw();
} 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">FillSolidRect method. In this code sample, we just use this method to draw some simple rectangles. As you see, we draw the rectangle on WIC bitmap render target.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
void MyImageSource::FillSolidRect(Windows::UI::Color color, Windows::Foundation::Rect rect) 
{ 
&nbsp;&nbsp;&nbsp;&nbsp;// Create a solid color D2D brush. 
&nbsp;&nbsp;&nbsp;&nbsp;ComPtr&lt;ID2D1SolidColorBrush&gt; brush; 
&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_wicBitmapRenderTarget-&gt;CreateSolidColorBrush( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DX::ConvertToColorF(color), 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&brush 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Draw a filled rectangle. 
&nbsp;&nbsp;&nbsp;&nbsp;m_wicBitmapRenderTarget-&gt;FillRectangle(DX::ConvertToRectF(rect), brush.Get()); 
}

</pre>
<pre id="codePreview" class="cplusplus">
void MyImageSource::FillSolidRect(Windows::UI::Color color, Windows::Foundation::Rect rect) 
{ 
&nbsp;&nbsp;&nbsp;&nbsp;// Create a solid color D2D brush. 
&nbsp;&nbsp;&nbsp;&nbsp;ComPtr&lt;ID2D1SolidColorBrush&gt; brush; 
&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_wicBitmapRenderTarget-&gt;CreateSolidColorBrush( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DX::ConvertToColorF(color), 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&brush 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Draw a filled rectangle. 
&nbsp;&nbsp;&nbsp;&nbsp;m_wicBitmapRenderTarget-&gt;FillRectangle(DX::ConvertToRectF(rect), brush.Get()); 
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">EndDraw method. When drawing is finished, this method must be called. In this method, we first get D2D bitmap from off-screen WIC bitmap, then draw D2D bitmap on DXGI surface.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Ends drawing updates started by a previous BeginDraw call. 
void MyImageSource::EndDraw() 
{ 
&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_wicBitmapRenderTarget-&gt;EndDraw()
&nbsp;&nbsp;&nbsp; );
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;// Get D2D bitmap from wic bitmap
&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp; m_d2dContext-&gt;CreateBitmapFromWicBitmap(m_wicBitmap.Get(), &m_d2dBitmap)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; // Draw D2D bitmap on DXGI surface.
&nbsp;&nbsp;&nbsp; m_d2dContext-&gt;DrawBitmap(m_d2dBitmap.Get(),NULL,1.0,D2D1_INTERPOLATION_MODE_HIGH_QUALITY_CUBIC,NULL);


&nbsp;&nbsp;&nbsp; // Remove the transform and clip applied in BeginDraw since 
&nbsp;&nbsp;&nbsp;&nbsp;// the target area can change on every update. 
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;SetTransform(D2D1::IdentityMatrix()); 
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;PopAxisAlignedClip(); 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Remove the render target and end drawing. 
&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;EndDraw() 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;SetTarget(nullptr); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_sisNative-&gt;EndDraw() 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 
} 

</pre>
<pre id="codePreview" class="cplusplus">
// Ends drawing updates started by a previous BeginDraw call. 
void MyImageSource::EndDraw() 
{ 
&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_wicBitmapRenderTarget-&gt;EndDraw()
&nbsp;&nbsp;&nbsp; );
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;// Get D2D bitmap from wic bitmap
&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp; m_d2dContext-&gt;CreateBitmapFromWicBitmap(m_wicBitmap.Get(), &m_d2dBitmap)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; // Draw D2D bitmap on DXGI surface.
&nbsp;&nbsp;&nbsp; m_d2dContext-&gt;DrawBitmap(m_d2dBitmap.Get(),NULL,1.0,D2D1_INTERPOLATION_MODE_HIGH_QUALITY_CUBIC,NULL);


&nbsp;&nbsp;&nbsp; // Remove the transform and clip applied in BeginDraw since 
&nbsp;&nbsp;&nbsp;&nbsp;// the target area can change on every update. 
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;SetTransform(D2D1::IdentityMatrix()); 
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;PopAxisAlignedClip(); 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;// Remove the render target and end drawing. 
&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;EndDraw() 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_d2dContext-&gt;SetTarget(nullptr); 
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DX::ThrowIfFailed( 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_sisNative-&gt;EndDraw() 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;); 
} 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">SaveBitmapToStream method saves WIC bitmap to a stream.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Save WIC bitmap to a stream.
void MyImageSource::SaveBitmapToStream(
&nbsp; &nbsp;&nbsp;_In_ ComPtr&lt;IWICBitmap&gt; wicBitmap,
&nbsp;&nbsp;&nbsp; _In_ ComPtr&lt;IWICImagingFactory2&gt; wicFactory2,
&nbsp;&nbsp;&nbsp; _In_ REFGUID wicFormat,
&nbsp;&nbsp;&nbsp; _In_ IStream* stream
&nbsp;&nbsp;&nbsp; )
{
&nbsp;&nbsp;&nbsp; // Create and initialize WIC Bitmap Encoder.
&nbsp;&nbsp;&nbsp; ComPtr&lt;IWICBitmapEncoder&gt; wicBitmapEncoder;
&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicFactory2-&gt;CreateEncoder(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicFormat,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; nullptr,&nbsp;&nbsp;&nbsp; // No preferred codec vendor.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &wicBitmapEncoder
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; )
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicBitmapEncoder-&gt;Initialize(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; stream,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WICBitmapEncoderNoCache
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; )
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; // Create and initialize WIC Frame Encoder.
&nbsp;&nbsp;&nbsp; ComPtr&lt;IWICBitmapFrameEncode&gt; wicFrameEncode;
&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicBitmapEncoder-&gt;CreateNewFrame(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &wicFrameEncode,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; nullptr&nbsp;&nbsp;&nbsp;&nbsp; // No encoder options.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; )
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicFrameEncode-&gt;Initialize(nullptr)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; WICPixelFormatGUID format = GUID_WICPixelFormatDontCare;


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wicFrameEncode-&gt;SetPixelFormat(&format)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicFrameEncode-&gt;WriteSource(wicBitmap.Get(),nullptr)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicFrameEncode-&gt;Commit()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicBitmapEncoder-&gt;Commit()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; // Flush all memory buffers to the next-level storage object.
&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; stream-&gt;Commit(STGC_DEFAULT)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );
}

</pre>
<pre id="codePreview" class="cplusplus">
// Save WIC bitmap to a stream.
void MyImageSource::SaveBitmapToStream(
&nbsp; &nbsp;&nbsp;_In_ ComPtr&lt;IWICBitmap&gt; wicBitmap,
&nbsp;&nbsp;&nbsp; _In_ ComPtr&lt;IWICImagingFactory2&gt; wicFactory2,
&nbsp;&nbsp;&nbsp; _In_ REFGUID wicFormat,
&nbsp;&nbsp;&nbsp; _In_ IStream* stream
&nbsp;&nbsp;&nbsp; )
{
&nbsp;&nbsp;&nbsp; // Create and initialize WIC Bitmap Encoder.
&nbsp;&nbsp;&nbsp; ComPtr&lt;IWICBitmapEncoder&gt; wicBitmapEncoder;
&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicFactory2-&gt;CreateEncoder(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicFormat,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; nullptr,&nbsp;&nbsp;&nbsp; // No preferred codec vendor.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &wicBitmapEncoder
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; )
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicBitmapEncoder-&gt;Initialize(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; stream,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WICBitmapEncoderNoCache
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; )
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; // Create and initialize WIC Frame Encoder.
&nbsp;&nbsp;&nbsp; ComPtr&lt;IWICBitmapFrameEncode&gt; wicFrameEncode;
&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicBitmapEncoder-&gt;CreateNewFrame(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &wicFrameEncode,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; nullptr&nbsp;&nbsp;&nbsp;&nbsp; // No encoder options.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; )
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicFrameEncode-&gt;Initialize(nullptr)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; WICPixelFormatGUID format = GUID_WICPixelFormatDontCare;


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wicFrameEncode-&gt;SetPixelFormat(&format)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicFrameEncode-&gt;WriteSource(wicBitmap.Get(),nullptr)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicFrameEncode-&gt;Commit()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wicBitmapEncoder-&gt;Commit()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );


&nbsp;&nbsp;&nbsp; // Flush all memory buffers to the next-level storage object.
&nbsp;&nbsp;&nbsp; DX::ThrowIfFailed(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; stream-&gt;Commit(STGC_DEFAULT)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In VBWindowsStoreAppSaveSurfaceImageSource project, we add reference to
</span>&quot;<span style="background:white">MyImageSourceWinRT</span>&quot;.<span style="font-size:9.0pt; line-height:115%; font-family:Consolas; color:black">
</span><span style="">In MainPage.xaml.vb, we initialize the custom class as follows.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
myImageSource = New MyImageSource(imageWidth, imageHeight, True)
Me.MyImage.Source = myImageSource

</pre>
<pre id="codePreview" class="vb">
myImageSource = New MyImageSource(imageWidth, imageHeight, True)
Me.MyImage.Source = myImageSource

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Then try to draw something. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp; ' Begin updating the surfaceImageSource
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.BeginDraw()


&nbsp;&nbsp;&nbsp;&nbsp; ' Clear background
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.Clear(Colors.Black)


&nbsp;&nbsp;&nbsp;&nbsp; ' Draw something...
&nbsp;&nbsp;&nbsp; &nbsp;Dim rect As Rect
&nbsp;&nbsp;&nbsp;&nbsp; Dim startPointX As Single = 0.0F
&nbsp;&nbsp;&nbsp;&nbsp; Dim startPointY As Single = 0.0F
&nbsp;&nbsp;&nbsp;&nbsp; Dim deltaX As Single = 3.0F
&nbsp;&nbsp;&nbsp;&nbsp; Dim deltaY As Single = 3.0F


&nbsp;&nbsp;&nbsp;&nbsp; rect.X = startPointX
&nbsp;&nbsp;&nbsp;&nbsp; rect.Y = startPointY
&nbsp;&nbsp;&nbsp;&nbsp; rect.Width = (imageWidth - deltaX * 2) / 2.0F
&nbsp;&nbsp;&nbsp;&nbsp; rect.Height = (imageHeight - deltaY * 2) / 2.0F
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.FillSolidRect(Color.FromArgb(255, 250, 67, 5), rect)


&nbsp;&nbsp;&nbsp;&nbsp; rect.X = startPointX &#43; rect.Width &#43; 2 * deltaX
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.FillSolidRect(Color.FromArgb(255, 96, 176, 6), rect)


&nbsp;&nbsp;&nbsp;&nbsp; rect.X = startPointX
&nbsp;&nbsp;&nbsp;&nbsp; rect.Y = startPointY &#43; rect.Height &#43; 2 * deltaY
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.FillSolidRect(Color.FromArgb(255, 14, 179, 241), rect)


&nbsp;&nbsp;&nbsp;&nbsp; rect.X = startPointX &#43; rect.Width &#43; 2 * deltaX
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.FillSolidRect(Color.FromArgb(255, 247, 199, 36), rect)


&nbsp;&nbsp;&nbsp;&nbsp; ' Stop updating the SurfaceImageSource and draw its contents 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myImageSource.EndDraw()
 End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp; ' Begin updating the surfaceImageSource
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.BeginDraw()


&nbsp;&nbsp;&nbsp;&nbsp; ' Clear background
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.Clear(Colors.Black)


&nbsp;&nbsp;&nbsp;&nbsp; ' Draw something...
&nbsp;&nbsp;&nbsp; &nbsp;Dim rect As Rect
&nbsp;&nbsp;&nbsp;&nbsp; Dim startPointX As Single = 0.0F
&nbsp;&nbsp;&nbsp;&nbsp; Dim startPointY As Single = 0.0F
&nbsp;&nbsp;&nbsp;&nbsp; Dim deltaX As Single = 3.0F
&nbsp;&nbsp;&nbsp;&nbsp; Dim deltaY As Single = 3.0F


&nbsp;&nbsp;&nbsp;&nbsp; rect.X = startPointX
&nbsp;&nbsp;&nbsp;&nbsp; rect.Y = startPointY
&nbsp;&nbsp;&nbsp;&nbsp; rect.Width = (imageWidth - deltaX * 2) / 2.0F
&nbsp;&nbsp;&nbsp;&nbsp; rect.Height = (imageHeight - deltaY * 2) / 2.0F
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.FillSolidRect(Color.FromArgb(255, 250, 67, 5), rect)


&nbsp;&nbsp;&nbsp;&nbsp; rect.X = startPointX &#43; rect.Width &#43; 2 * deltaX
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.FillSolidRect(Color.FromArgb(255, 96, 176, 6), rect)


&nbsp;&nbsp;&nbsp;&nbsp; rect.X = startPointX
&nbsp;&nbsp;&nbsp;&nbsp; rect.Y = startPointY &#43; rect.Height &#43; 2 * deltaY
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.FillSolidRect(Color.FromArgb(255, 14, 179, 241), rect)


&nbsp;&nbsp;&nbsp;&nbsp; rect.X = startPointX &#43; rect.Width &#43; 2 * deltaX
&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.FillSolidRect(Color.FromArgb(255, 247, 199, 36), rect)


&nbsp;&nbsp;&nbsp;&nbsp; ' Stop updating the SurfaceImageSource and draw its contents 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myImageSource.EndDraw()
 End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Save to file. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub SaveButton_Click(sender As Object, e As RoutedEventArgs) Handles SaveButton.Click
&nbsp;&nbsp;&nbsp; NotifyUser(&quot;&quot;)
&nbsp;&nbsp;&nbsp; If EnsureUnsnapped() Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.SaveSurfaceImageToFile()
&nbsp;&nbsp;&nbsp; End If
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub SaveButton_Click(sender As Object, e As RoutedEventArgs) Handles SaveButton.Click
&nbsp;&nbsp;&nbsp; NotifyUser(&quot;&quot;)
&nbsp;&nbsp;&nbsp; If EnsureUnsnapped() Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; myImageSource.SaveSurfaceImageToFile()
&nbsp;&nbsp;&nbsp; End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<h2><span style="">More Information </span></h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.imaging.surfaceimagesource.aspx">SurfaceImageSource Class</a></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/library/windows/apps/hh825871.aspx">DirectX and XAML interop (Windows Store apps using C&#43;&#43; and DirectX)</a></p>
<p class="MsoNormal"><span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>