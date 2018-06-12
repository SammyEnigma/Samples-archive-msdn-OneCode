# Create layered window in Windows Forms (CSWinFormLayeredWindow)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
## Topics
* Layered Window
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:02:23
## Description

<p style="font-family:Courier New">Using a layered window can significantly improve performance and visual effects for a window that has a complex shape, animates its shape, or wishes to use alpha blending effects. The system automatically composes and repaints
 layered windows and the windows of underlying applications. As a result, layered windows are rendered smoothly, without the flickering typical of complex window regions. In addition, layered windows can be partially translucent, that is, alpha-blended.<br>
<br>
To create a layered window, specify the WS_EX_LAYERED extended window style when calling the CreateWindowEx function, or call the SetWindowLong function to set WS_EX_LAYERED after the window has been created. After the CreateWindowEx call, the layered window
 will not become visible until the SetLayeredWindowAttributes or UpdateLayeredWindow function has been called for this window. Note that WS_EX_LAYERED cannot be used for child windows.<br>
<br>
To set the opacity level or the transparency color key for a given layered window, call SetLayeredWindowAttributes. After the call, the system may still ask the window to paint when the window is shown or resized. However, because the system stores the image
 of a layered window, the system will not ask the window to paint if parts of it are revealed as a result of relative window moves on the desktop. Legacy applications do not need to restructure their painting code if they want to add translucency or transparency
 effects for a window, because the system redirects the painting of windows that called SetLayeredWindowAttributes into off-screen memory and recomposes it to achieve the desired effect.<br>
<br>
For faster and more efficient animation or if per-pixel alpha is needed, call UpdateLayeredWindow. UpdateLayeredWindow should be used primarily when the application must directly supply the shape and content of a layered window, without using the redirection
 mechanism the system provides through SetLayeredWindowAttributes. In addition, using UpdateLayeredWindow directly uses memory more efficiently, because the system does not need the additional memory required for storing the image of the redirected window.
 For maximum efficiency in animating windows, call UpdateLayeredWindow to change the position and the size of a layered window. Please note that after SetLayeredWindowAttributes has been called, subsequent UpdateLayeredWindow calls will fail until the layering
 style bit is cleared and set again.<br>
<br>
Hit testing of a layered window is based on the shape and transparency of the window. This means that the areas of the window that are color-keyed or whose alpha value is zero will let the mouse messages through. However, if the layered window has the WS_EX_TRANSPARENT
 extended window style, the shape of the layered window will be ignored and the mouse events will be passed to other windows underneath the layered window.<br>
<br>
<br>
<a target="_blank" href="http://www.codeproject.com/KB/GDI-plus/perpxalpha_sharp.aspx">http://www.codeproject.com/KB/GDI-plus/perpxalpha_sharp.aspx</a><br>
<a target="_blank" href="http://www.codeproject.com/kb/gdi/pxalphablend.aspx">http://www.codeproject.com/kb/gdi/pxalphablend.aspx</a><br>
<br>
Layered Windows<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms632599.aspx#layered">http://msdn.microsoft.com/en-us/library/ms632599.aspx#layered</a><br>
<br>
MSDN: OSFeature.LayeredWindows Field<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.osfeature.layeredwindows.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.osfeature.layeredwindows.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
